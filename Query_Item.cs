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
    public partial class Query_Item : Form
    {
        DataClasses1DataContext mob_sys = new DataClasses1DataContext();
        DataTable dt = new DataTable();
        public Query_Item()
        {
            InitializeComponent();
        }

        private void Query_Item_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("إسم الصنف",typeof(string));
            dt.Columns.Add("العدد", typeof(int));
            dt.Columns.Add("سعر الإستلام", typeof(float));
            dt.Columns.Add("سعر البيع", typeof(float));
            dt.Columns.Add("مقدار الربح", typeof(float));
            autocomplete();
        }
        private void Btn_Show_Store_Items_Click(object sender, EventArgs e)
        {
            label8.Text = "";
            dt.Clear();
            var items = mob_sys.Items.Select(s => new { s.Name, s.count, s.Recieve_Price, s.Sale_Price });
            var maxid = mob_sys.Items.Max(s => s.ID);
            foreach (var item in items)
            {
                var profit = item.Sale_Price - item.Recieve_Price;
                dt.Rows.Add(item.Name.ToString(), item.count.ToString(), item.Recieve_Price.ToString(), item.Sale_Price.ToString(),profit.ToString());
                dataGridView1.DataSource = dt;
            }
            label1.Text = maxid.ToString();
        }
        public void autocomplete()
        {
            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            var allitems = mob_sys.Items.Select(s => new{s.Name} ).ToList();
            foreach (var item in allitems)
            {   MyCollection.Add(item.Name);}
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = (MyCollection);
            textBox1.AutoCompleteCustomSource = DataCollection;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    var items = mob_sys.Items.Where(s => s.Name == textBox1.Text).Select(s => new { s.count, s.Recieve_Price, s.Sale_Price });
                    foreach (var item in items)
                    {
                        textBox2.Text = item.count.ToString();
                        textBox3.Text = item.Recieve_Price.ToString();
                        textBox4.Text = item.Sale_Price.ToString();
                    }
                }
            }
            catch (Exception)
            {
                label7.Text = "تأكد من الإسم";
            }   
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                button2.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource!=null)
            {   
                View_report_store_items v = new View_report_store_items();
                v.Show();
            }
            else
            {
                label8.Text = "إضغط عرض أصناف المخزن أولا";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}