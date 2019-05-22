using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mazaya_3G_return
{
    public partial class view_purch_report_byID : Form
    {
        DataClasses1DataContext mob_sys = new DataClasses1DataContext();
        public view_purch_report_byID()
        {
            InitializeComponent();
        }

        private void view_purch_report_byID_Load(object sender, EventArgs e)
        {
            var x = mob_sys.get_purch_check_id(Class1.Purch_id).ToList();
            DataSet2 ds = new DataSet2();
            int i = 1;
            foreach (var item in x)
            {
                ds.purch_check.Rows.Add(item.ID,item.Recieve_Date, item.Supplier_Name, item.UserName,item.Company, item.Total,item.diff,
                item.difference_col, item.Discount_val, item.Addition_val, item.purch_details_notes, item.count, i, item.Name, item.item_details,
                item.Price);
                i++;
            }
            purch_byid cr = new purch_byid();
            cr.SetDataSource(ds.Tables["purch_check"]);
            crystalReportViewer2.ReportSource = cr;
            crystalReportViewer2.Refresh();
            
        }
    }
}
