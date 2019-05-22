using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mazaya_3G_return
{
    public partial class Used_View_report_store_items : Form
    {

        DataClasses1DataContext mob_sys = new DataClasses1DataContext();
        public Used_View_report_store_items()
        {
            InitializeComponent();
        }

        private void Used_View_report_store_items_Load(object sender, EventArgs e)
        {
            var Username = Class1.TheValue;
            var x = mob_sys.USed_get_store_items().ToList();
            DataSet2 ds = new DataSet2();
            //int i = 1;
            foreach (var item in x)
            {
                ds.Used_Store_Items.Rows.Add(item.ID,item.Items_Names, item.quantity, item.Recieve_Price, item.Sale_Price,Username);
              //  i++;
            }
            get_store_items cr = new get_store_items();
            cr.SetDataSource(ds.Tables["Used_Store_Items"]);
            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();
        }
    }
}