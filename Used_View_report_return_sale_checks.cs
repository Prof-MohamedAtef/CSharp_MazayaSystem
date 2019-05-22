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
    public partial class Used_View_report_return_sale_checks : Form
    {
        DataClasses1DataContext mob_sys = new DataClasses1DataContext();

        public Used_View_report_return_sale_checks()
        {
            InitializeComponent();
        }

        private void Used_View_report_return_sale_checks_Load(object sender, EventArgs e)
        {
            var x = mob_sys.Used_get_return_sale_check_by_id(Class1.Return_id).ToList();
            DataSet2 ds = new DataSet2();
            int i = 1;
            foreach (var item in x)
            {
                ds.Used_Return_check.Rows.Add(item.ID, item.Return_Date, item.Return_from, item.UserName, item.Total, item.paid_mount,
                item.return_details_notes, item.count, i, item.Name, item.item_notes, item.Price, item.remaining);
                i++;
            }
            return_byid2 cr = new return_byid2();
            cr.SetDataSource(ds.Tables["Used_Return_check"]);
            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();
        }
    }
}
