using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace WinFormComponents.Controls
{
    public partial class Form_EntityEdit<T> : Form
    {
        public delegate void EditFinishedEvetHandler(T entity);
        public event EditFinishedEvetHandler onEditFinished;

        public List<EditPropertyDefinition> PropertyDefinitions { get; set; }
        public T Entity { get; set; }
        public bool BackVisible { get; set; }

        private int formHeight;
        private int formWidth;

        public string ExitTxt { get; set; } = "EXIT";
        public string ConformTxt { get; set; } = "CONFIRM";

        public Form_EntityEdit(List<EditPropertyDefinition> _definitions, T _entity)
        {
            InitializeComponent();
            PropertyDefinitions = _definitions;
            Entity = _entity;
            BackVisible = true;
        }



        private void Form_EntityEdit_Load(object sender, EventArgs e)
        {
            var labelsWidth=LoadLabels();
            var fieldsHeight=LoadTextBoxs(labelsWidth);
            LoadButtons(fieldsHeight);
            ResizeForm(formWidth, formHeight);

            
        }

        private int LoadLabels()
        {
            int x = 10;
            int y = 15;
            int width = 0;
            foreach(var item in PropertyDefinitions )
            {
                CreateLabelForProperty(x, ref y, ref width, item);
            }
            return width;
        }

        private void CreateLabelForProperty(int x, ref int y, ref int width, EditPropertyDefinition item)
        {
            var lbl = new Label();
            lbl.Text = item.Lable;
            lbl.Name = item.Name;
            lbl.AutoSize = true;
            lbl.Location = new Point(x, y);
            pnlContainer.Controls.Add(lbl);
            width = Math.Max(width, lbl.Width);
            y += lbl.Height + 17;
        }

        private int LoadTextBoxs(int lblWidth)
        {
            int x = lblWidth + 20;
            int y = 10;
            int width = 0;
            foreach (var item in PropertyDefinitions)
            {
                CreateInputForProperty(x, ref y, ref width, item);
            }
            formWidth = x + width + 10;
            RepositionControls();
            return y;
        }

        private void CreateInputForProperty(int x, ref int y, ref int width, EditPropertyDefinition item)
        {
            var txt = new TextBox();
            txt.Text = Entity.GetType().GetProperty(item.Name).GetValue(Entity, null)?.ToString();
            txt.Name = item.Name;

            if (item.FiledSize != null)
                txt.Width = item.FiledSize.Value;
            else
                txt.Width = 150;

            txt.Location = new Point(x, y);
            pnlContainer.Controls.Add(txt);
            width = Math.Max(width, txt.Width);
            y += txt.Height + 10;
        }

        private void RepositionControls()
        {
            if (formWidth < 300)
            {
                foreach (var txt in pnlContainer.Controls.OfType<TextBox>())
                {
                    txt.Location = new Point(300 - 20 - txt.Width, txt.Location.Y);
                }
            }
        }

        private void LoadButtons(int fieldsHeight)
        {
            int y = fieldsHeight + 25;
            int x;
            if (formWidth > 300)
                x = formWidth - 10 - 2 * 130 - 20;
            else
                x = 10;

            Button btnBack = CreateButton(y, x, btnBack_Click, ExitTxt);

            if (BackVisible)
                pnlContainer.Controls.Add(btnBack);

            x += 130 + 10;

            Button btnAdd = CreateButton(y, x, btnAdd_Click, ConformTxt);

            pnlContainer.Controls.Add(btnAdd);
            y += btnBack.Height;
            formHeight = y + 10;
        }

        private Button CreateButton(int y, int x, EventHandler click, string txt)
        {
            var btnBack = new Button();
            btnBack.Click += click;
            btnBack.Width = 130;
            btnBack.Location = new Point(x, y);
            btnBack.Text = txt;
            return btnBack;
        }

        private void ResizeForm(int width,int height)
        {
            if(width>300)
                this.Width = width;
            else
                this.Width = 300;
            this.Height = height+40;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(FillEntity())
            {
                onEditFinished?.Invoke(Entity);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool FillEntity()
        {
            try
            {
                foreach (var txt in pnlContainer.Controls.OfType<TextBox>())
                {
                    PropertyInfo prop = Entity.GetType().GetProperty(txt.Name);
                    if (prop != null && prop.CanWrite && !string.IsNullOrEmpty(txt.Text))
                    {
                        if (Nullable.GetUnderlyingType(prop.PropertyType) != null)
                            prop.SetValue(Entity, Convert.ChangeType(txt.Text, Nullable.GetUnderlyingType(prop.PropertyType)), null);
                        else
                            prop.SetValue(Entity, Convert.ChangeType(txt.Text, prop.PropertyType), null);
                    }
                }
                return true;
            }
            catch
            {
                MessageBox.Show("Non valid format", "Non valid format");
                return false;
            }
        }

    }



    public class EditPropertyDefinition
    {
        public string Name { get; set; }
        public string Lable{ get; set; }
        public int? FiledSize { get; set; }
    }

}
