using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormComponents.Controls;

namespace WinFormComponents
{
    public partial class Form_Catalog : Form
    {
        public Form_Catalog()
        {
            InitializeComponent();
        }

        private void btnSearchForm_Click(object sender, EventArgs e)
        {

            List<DummyCustomer> dummyData = Enumerable.Range(0, 100)
                .Select(i => new DummyCustomer { Name = $"Customer_{i}", Code = $"0000{i}" })
                .ToList();

            List<SearchColumnDefinition> colDeff = new List<SearchColumnDefinition>();
            colDeff.Add(new SearchColumnDefinition { Name = nameof(DummyCustomer.Name), Header = "Name" });
            colDeff.Add(new SearchColumnDefinition { Name = nameof(DummyCustomer.Code), Header = "Code" });
            Form_Search<DummyCustomer> customerSearch = new Form_Search<DummyCustomer>(dummyData, colDeff, false, "IsSelected");

            customerSearch.OnSelection += cl => 
            {
                var c = cl.FirstOrDefault();
                MessageBox.Show($"Selected: ({c?.Code}) {c?.Name}");
            };
            customerSearch.ShowDialog();
        }


        #region DUMMY DATA
        public class DummyCustomer
        {
            public string Name { get; set; }
            public string Code { get; set; }
        }
        #endregion
    }
}
