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
    public partial class Used_View_report_sale_check : Form
    {
        DataClasses1DataContext mob_sys = new DataClasses1DataContext();

        public Used_View_report_sale_check()
        {
            InitializeComponent();
        }

        private void Used_View_report_sale_check_Load(object sender, EventArgs e)
        {
            var x = mob_sys.Used_get_sale_check_by_id2(Class1.Sale_id).ToList();
            DataSet2 ds = new DataSet2();
            int i = 1;
            foreach (var item in x)
            {
                ds.Used_Sale_check.Rows.Add(item.ID, item.sale_Date, item.Sale_To, item.UserName, item.TotalPrice, item.difference_col,
                item.Discount_val, item.Addition_val, item.remaining, item.sale_details_notes, item.count, i, item.Name, item.item_notes,
                item.Price);
                i++;
            }
            Sale_byid cr = new Sale_byid();
            cr.SetDataSource(ds.Tables["Used_Sale_check"]);
            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();
        }
    }
}
