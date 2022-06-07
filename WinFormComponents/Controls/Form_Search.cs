using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormComponents.Utilities;

namespace WinFormComponents.Controls
{
    public partial class Form_Search<T> : Form where T : class
    {
        public List<T> Objects { get; set; }

        private bool multiSelect = false;
        private string selectProperty = null;
        private bool inForm = false;
        private bool selectOnEnter = false;

        public string Title { get; set; } = "SEARCH FORM";
        public string ExitTxt { get; set; } = "EXIT";
        public string ConfirmTxt { get; set; } = "CONFIRM";

        public List<SearchColumnDefinition> ColumnDefinitions { get; set; }
        public Form_Search(List<T> _objects, List<SearchColumnDefinition> _columnDefinitions,
            bool _multiSelect, string _selectProperty = null, bool _inForm = false,
            bool _selectOnEnter = false, bool _wrap = false)
        {
            InitializeComponent();
            Objects = _objects;
            ColumnDefinitions = _columnDefinitions;
            multiSelect = _multiSelect;
            selectProperty = _selectProperty;
            inForm = _inForm;
            selectOnEnter = _selectOnEnter;

            if (_wrap && _objects.Count() < 500) //radi presporo sa vise redova
            {
                this.dgwList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        private void Form_Search_Load(object sender, EventArgs e)
        {
            TranslateLabels();
            LoadGrid(Objects);
            FormatGrid(ColumnDefinitions);
            SetSelectOnEnter();

            ResizeGrid();
            ResizeForm();
        }

        private void TranslateLabels()
        {
            Text = Title;
            if (multiSelect || inForm)
                btnAction.Text = ConfirmTxt;
            else
                btnAction.Text = ExitTxt;
        }

        private void LoadGrid(List<T> objects)
        {
            dgwList.DataSource = objects;
        }

        private void FormatGrid(List<SearchColumnDefinition> defintions)
        {
            FormatDataColumns(defintions);

            dgwList.MultiSelect = multiSelect;
            if (multiSelect)
                FormatSelectColumn(selectProperty);
        }

        private void FormatDataColumns(List<SearchColumnDefinition> defintions)
        {
            foreach (DataGridViewColumn item in dgwList.Columns)
            {
                var definition = defintions.FirstOrDefault(x => x.Name == item.DataPropertyName);
                if (definition == null)
                    item.Visible = false;
                else
                {
                    item.HeaderText = definition.Header;
                    item.ReadOnly = true;
                    if (!string.IsNullOrEmpty(definition.Format))
                        item.DefaultCellStyle.Format = definition.Format;
                    if (definition.DisplayIndex != null)
                        item.DisplayIndex = definition.DisplayIndex.Value;
                    if (definition.Width > 0)
                        item.Width = definition.Width;
                }
            }
        }

        private void FormatSelectColumn(string _selectProperty)
        {
            DataGridViewCheckBoxColumn colSelect = new DataGridViewCheckBoxColumn();
            colSelect.Name = "colSelect";
            if (_selectProperty != null)
                colSelect.DataPropertyName = _selectProperty;
            colSelect.HeaderText = "";
            dgwList.Columns.Insert(0, colSelect);

            foreach (DataGridViewRow row in dgwList.Rows)
            {
                var entity = row.DataBoundItem;
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["colSelect"];
                try
                {
                    chk.Value = entity.GetType().GetProperty(_selectProperty).GetValue(entity, null);
                }
                catch
                {
                    chk.Value = true;
                }
            }
        }

        private void ResizeGrid()
        {
            int width = 0;
            foreach (DataGridViewColumn item in dgwList.Columns.Cast<DataGridViewColumn>().Where(x => x.Visible == true))
            {
                item.MinimumWidth = item.Name == "colSelect" ? 20 : 100;
                if (item.Name == "colSelect")
                    item.Width = 50;
                width += item.Width;
            }
            dgwList.Width = width + 20;


        }

        private void ResizeForm()
        {
            //Width = dgwList.Width + 10;
        }

        private void SetSelectOnEnter()
        {
            if (selectOnEnter)
            {
                this.KeyDown += SelectOnEnter;
                this.dgwList.KeyDown += SelectOnEnter;
                this.txtSearch.KeyDown += (s, e) =>
                {
                    if (e.KeyCode == Keys.Down)
                    {
                        dgwList.Select();
                        dgwList.Focus();
                    }
                    else
                        SelectOnEnter(s, e);
                };
            }
        }

        private void SelectOnEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgwList.SelectedRows.Count > 0)
            {
                SelectItem();
            }
        }

        private void dgwList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!multiSelect)
            {
                SelectItem();
            }
        }

        private void SelectItem()
        {
            var selected = new List<T>();

            var row = dgwList.CurrentRow;
            if (row == null)
            {
                if (dgwList.SelectedRows.Count > 0)
                    row = dgwList.SelectedRows[0];
            }

            if (row != null)
            {
                selected.Add((T)row.DataBoundItem);
                OnSelection?.Invoke(selected);

                if (!inForm)
                    this.Close();
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (multiSelect)
                OnSelection?.Invoke((List<T>)(dgwList.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToBoolean(x.Cells["colSelect"].Value) == true).Select(s => (T)s.DataBoundItem).ToList()));
            if (inForm && dgwList.CurrentRow != null)
            {
                var selected = new List<T>();
                selected.Add((T)dgwList.CurrentRow.DataBoundItem);
                OnSelection?.Invoke(selected);
            }
            if (!inForm)
                this.Close();
        }

        public delegate void SelectedEvetHandler(List<T> objects);
        public event SelectedEvetHandler OnSelection;

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search(txtSearch.Text);
            FormatGrid(ColumnDefinitions);
            ResizeGrid();
        }

        private void Search(string text)
        {
            dgwList.DataSource = Utility.Search<T>(Objects, text);
        }
    }

    public class SearchColumnDefinition
    {
        public string Name { get; set; }
        public string Header { get; set; }
        public string Format { get; set; }
        public int Width { get; set; }
        public int? DisplayIndex { get; set; }
    }
}
