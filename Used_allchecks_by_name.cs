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
    public partial class Used_allchecks_by_name : Form
    {
        public Used_allchecks_by_name()
        {
            InitializeComponent();
        }
        DataClasses1DataContext mob_sys = new DataClasses1DataContext();
        DataTable dt1 = new DataTable();
        DataTable dt3 = new DataTable();

        private void Used_allchecks_by_name_Load(object sender, EventArgs e)
        {
            
            ///declare dt1
            dt1.Columns.Add("مسلسل", typeof(int));
            dt1.Columns.Add("رقم الفاتورة", typeof(int));
            dt1.Columns.Add("اسم المشترى", typeof(string));
            dt1.Columns.Add("التاريخ", typeof(string));
            dt1.Columns.Add("اسم الكاشير", typeof(string));
            dt1.Columns.Add("الاجمالى ", typeof(float));
            dt1.Columns.Add("ملاحظات", typeof(string));
            dt3.Columns.Add("مسلسل", typeof(int));
            dt3.Columns.Add("رقم الصنف", typeof(int));
            dt3.Columns.Add("اسم الصنف", typeof(string));
            dt3.Columns.Add("الشركه المصنعه", typeof(string));
            dt3.Columns.Add("النوع", typeof(string));
            dt3.Columns.Add("العدد", typeof(int));
            dt3.Columns.Add("الاجمالى", typeof(float));
            dt3.Columns.Add("ملاحظات", typeof(string));
           
            label1.Text = Class1.Saleto;
    var prev = mob_sys.Used_Sale_Checks.Where(s => s.Sale_to == Class1.Saleto).Select(s => new
            {
                s.ID,
                s.Notes,
                s.Sale_to,
                s.Seller_id,
                s.Total_Price,s.Sale_date
            }).ToList();
            int count = 1;
            foreach (var item in prev)
            {
                var casheirName = mob_sys.login_Tbls.Where(s => s.ID == item.Seller_id).Select(s => s.UserName).SingleOrDefault();
                dt1.Rows.Add(count, item.ID, item.Sale_to,item.Sale_date, casheirName, item.Total_Price, item.Notes);
                dataGridView1.DataSource = dt1;
                count++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Used_Returns r = new Used_Returns();
            r.Show();
        }
        int selectedrow = 0;
        int select_id = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int curRow = dataGridView1.CurrentRow.Index;
                DataGridViewRow row = dataGridView1.Rows[curRow];
                var check_id = int.Parse(row.Cells[1].Value.ToString());
                lbl_check_id.Text = check_id.ToString();
                load_sale_grid_details(check_id);
                selectedrow = int.Parse(row.Cells[0].Value.ToString());
                select_id = check_id;
            }
            catch (Exception) { lbl_check_id.Text = "لايوجد فواتير"; }
        }

        private void load_sale_grid_details(int i)
        {
            int c = 1;
            dt3.Clear();
            var sale_details = mob_sys.Used_Sale_Check_details.Where(s => s.Sale_check_id==i).Select(s => new
            {
               s.Count,
               s.Item_ID,
               s.Notes,
               s.Price,
            }).ToList();
            foreach (var item in sale_details)
            {
                var item_name = mob_sys.Used_Items.Where(s => s.ID == item.Item_ID).Select(s => s.Name).SingleOrDefault();
                var comp_type_id = mob_sys.Used_Items.Where(s => s.ID == item.Item_ID).Select(s => new { s.Producing_Company_id,s.Type }).SingleOrDefault();
                var comp_name = mob_sys.Producing_companies.Where(s => s.ID == comp_type_id.Producing_Company_id).Select(s => s.Producing_company1).SingleOrDefault();
                var type_name = mob_sys.Type_items.Where(s => s.ID == comp_type_id.Type).Select(s => s.Type).SingleOrDefault();
                
                dt3.Rows.Add(c, item.Item_ID, item_name, comp_name, type_name, item.Count,item.Price, item.Notes);
                dataGridView2.DataSource = dt3;
                c++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.Sellected_check_id = select_id;
            this.Close();
            Used_Returns r = new Used_Returns();
            r.Show();
        }
    }
}
