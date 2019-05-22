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
    public partial class report_day_purch : Form
    {
        DataClasses1DataContext mob_sys = new DataClasses1DataContext();
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();

        public report_day_purch()
        {
            InitializeComponent();

        }

        private void report_day_purch_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("مسلسل", typeof(int));

            dt.Columns.Add("رقم الفاتوره", typeof(int));
            dt.Columns.Add("اسم الشركه الموردة", typeof(string));
            dt.Columns.Add("اسم المورد", typeof(string));
            dt.Columns.Add("اسم المستخدم", typeof(string));
            dt.Columns.Add("الاجمالى ", typeof(float));
            dt.Columns.Add("المدفوع ", typeof(float));
            dt.Columns.Add("الباقى ", typeof(float));
            dt.Columns.Add("ملاحظات", typeof(string));
            dt2.Columns.Add("مسلسل", typeof(int));

            dt2.Columns.Add("كود الصنف", typeof(int));
            dt2.Columns.Add("اسم الصنف", typeof(string));
            dt2.Columns.Add("الكمية ", typeof(int));

            dt2.Columns.Add("سعر البيع ", typeof(float));

            dt2.Columns.Add("الاجمالى ", typeof(float));
            dt2.Columns.Add("ملاحظات", typeof(string));
            

            int i=1;
          var x=  mob_sys.purch_checks_date(System.DateTime.Now.Date).ToList();
            foreach (var item in x)
	{
        dt.Rows.Add(i,item.ID,item.Company,item.Supplier_Name,item.UserName,item.Total_price,item.difference_col,item.diff,item.Notes);
        i++;
            }
            dataGridView1.DataSource = dt;
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dt2.Clear();

            int cur = dataGridView1.CurrentRow.Index;
            DataGridViewRow row = dataGridView1.Rows[cur];

            int id = int.Parse(row.Cells[1].Value.ToString());
            var x = mob_sys.purch_details(id).ToList();
            int i = 1;
            foreach (var item in x)
            {
                dt2.Rows.Add(i, item.Item_ID, item.Name, item.count, item.Recieve_Price, item.Price, item.Notes);
                i++;
            }
            dataGridView2.DataSource = dt2;
        }
    }
}
