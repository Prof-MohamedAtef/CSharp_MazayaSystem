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
    public partial class Used_EditItem : Form
    {
        DataClasses1DataContext mob_sys = new DataClasses1DataContext();
        public Used_EditItem()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Used_EditItem e_item = new Used_EditItem();
            e_item.ShowDialog();
        }

        private void radio_id_CheckedChanged(object sender, EventArgs e)
        {
            txt_code_search.Enabled = true;
            textBox1.Enabled = false;
            textBox1.Text = "";
        }

        private void radio_name_CheckedChanged(object sender, EventArgs e)
        {
            txt_code_search.Enabled = false;
            textBox1.Enabled = true;
            txt_code_search.Text = ""; 
        }

        private void Used_EditItem_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();

            var allitems = mob_sys.Used_Items.Select(s => new { s.Name, s.Count }).ToList();

            foreach (var item in allitems)
            {

                MyCollection.Add(item.Name);

            }

            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = (MyCollection);
            textBox1.AutoCompleteCustomSource = DataCollection;
            control_txt(false);
            if (Class1.Click_edititem !=0)
            {
                if (Class1.Item_Id != 0)
                {
                    load_detailsbycode(Class1.Item_Id);
                    txt_sale_price.Enabled = true;
                } 
            }
           
        }
        public void control_txt(bool x)
        {
            txt_code.Enabled = x;
            txt_company.Enabled = x;
            txt_item_name.Enabled = x;
            txt_note.Enabled = x;
            txt_type.Enabled = x;
            txt_purch_price.Enabled = x;
            txt_sale_price.Enabled = x;

        }
        public bool isitemexit(string x, int i)
        {
            var allitems = mob_sys.Used_Items.Select(s => new { s.Name, s.ID }).ToList();
            foreach (var item in allitems)
            {
                if (item.Name == x || item.ID == i)
                {
                    return true;
                }
            }
            return false;
        }

        public void load_detailsbycode(int x)
        {
            if (isitemexit(" ", x))
            {
                txt_sale_price.Enabled = true;
                var sale_details = mob_sys.Used_Items.Where(s => s.ID == x).Select(s => new
                {
                    s.Count,
                    s.Name,
                    s.Notes,
                    s.Producing_Company_id,
                    s.Recieve_Price,
                    s.Sale_Price,
                    s.Type,

                }).SingleOrDefault();

                var comp_type_id = mob_sys.Used_Items.Where(s => s.ID == x).Select(s => new { s.Name, s.Producing_Company_id, s.Type }).SingleOrDefault();
                var comp_name = mob_sys.Producing_companies.Where(s => s.ID == comp_type_id.Producing_Company_id).Select(s => s.Producing_company1).SingleOrDefault();
                var type_name = mob_sys.Type_items.Where(s => s.ID == comp_type_id.Type).Select(s => s.Type).SingleOrDefault();
                txt_code.Text = x.ToString();
                txt_company.Text = comp_name;
                txt_item_name.Text = comp_type_id.Name;
                txt_note.Text = sale_details.Notes;
                txt_type.Text = type_name;
                txt_purch_price.Text = sale_details.Recieve_Price.ToString();
                txt_sale_price.Text = sale_details.Sale_Price.ToString();


            }
            else label9.Text = "غير موجود";
        }
        private void txt_code_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                int x = int.Parse(txt_code_search.Text);
                load_detailsbycode(x);
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_sale_price.Text != "" && txt_sale_price.Text != "0" && txt_sale_price.Text != "0.00")
                {
                    if (txt_code_search.Text != "")
                    {
                        var id = int.Parse(txt_code_search.Text);
                        var price = float.Parse(txt_sale_price.Text);
                        mob_sys.Used_update_item_saleprice(id, price);
                        label9.Text = "تم التسعير";
                    }
                    else if (Class1.Item_Id != 0)
                    {
                        var id = Class1.Item_Id;
                        var price = float.Parse(txt_sale_price.Text);
                        mob_sys.Used_update_item_saleprice(id, price);
                        label9.Text = "تم التسعير";
                    }
                    else if (textBox1.Text != "")
                    {
                        var name_id = mob_sys.Used_Items.Where(s => s.Name == textBox1.Text).Select(s => s.ID).SingleOrDefault();
                       
                        var price = float.Parse(txt_sale_price.Text);
                        mob_sys.Used_update_item_saleprice(name_id, price);
                        label9.Text = "تم التسعير";
                    }
                }
                else label9.Text = "تاكد من ادخال السعر بطريقه صحيحه ";
            }
            catch (Exception) { label9.Text = "تأكد من ادخال السعر بطريقه صحيحه"; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && radio_name.Checked)
            {
                var x = textBox1.Text;
                if (isitemexit(x, 0))
                {
                    var name_id = mob_sys.Used_Items.Where(s => s.Name == x).Select(s => s.ID).SingleOrDefault();
                    load_detailsbycode(name_id);
                   
                }
                else label9.Text = "غير موجود";
            }
            else if (txt_code_search.Text != "" && radio_id.Checked)
            {
                int x = int.Parse(txt_code_search.Text);
                load_detailsbycode(x);
            }
        }

        private void txt_sale_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                button2.Focus();
            }
        }
    }
}
