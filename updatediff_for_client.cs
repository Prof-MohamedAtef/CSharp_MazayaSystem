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
    public partial class updatediff_for_client : Form
    {
        DataClasses1DataContext mob_sys = new DataClasses1DataContext();

        public updatediff_for_client()
        {
            InitializeComponent();
        }
        public void load_details() {
            try
            {
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;

                int ch_id = int.Parse(textBox1.Text);
                var check_details = mob_sys.Returns_checks.Where(s => s.ID == ch_id).Select(s => new { s.Total_price, s.difference_col, s.Return_from }).SingleOrDefault();
                textBox2.Text = check_details.Total_price.ToString();
                textBox3.Text = check_details.difference_col.ToString();
                var difference_value = check_details.Total_price - check_details.difference_col;

                if (difference_value != 0.00)
                {
                    textBox4.Text = difference_value.ToString();
                    //textBox4.Text = (check_details.remaining_val - check_details.difference_col).ToString();
                }
                else
                {
                    textBox4.Text = difference_value.ToString();
                    //textBox4.Text = (check_details.Total_price - check_details.difference_col).ToString();
                }
                textBox6.Text = check_details.Return_from;
            }
            catch (Exception)
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void updatediff_for_client_Load(object sender, EventArgs e)
        {
            label8.Text = Class1.TheValue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox5.Text != "")
                {
                    var i = int.Parse(textBox1.Text);
                    var p = float.Parse(textBox5.Text);
                    var total = float.Parse(textBox2.Text);
                    var diff = float.Parse(textBox4.Text);

                    if (p <= total && p <= diff && p != 0)
                    {
                        try
                        {
                            var max = mob_sys.Payment_Return_clients.Max(s => s.ID);
                            mob_sys.payment_Return_Client(max + 1, Class1.TheID, System.DateTime.Now.Date, p, textBox6.Text);

                            mob_sys.update_diff_return_clients(i, p);
                            label9.Text = "تم السداد ";
                            load_details();
                        }
                        catch (Exception)
                        {
                            mob_sys.payment_Return_Client(1, Class1.TheID, System.DateTime.Now.Date, p, textBox6.Text);
                            mob_sys.update_diff_return_clients(i, p);
                            label9.Text = "تم السداد ";
                            load_details();
                        }
                    }
                    else label9.Text = "  المبلغ اكبر من الاجمالى او الباقى او يساوى صفرا  ";
                }
                else label9.Text = "رجاء تاكد من قيمه المبلغ";
            }
            else label9.Text = "رجاء ادخل رقم الفاتوره";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var all_id = mob_sys.Returns_checks.Where(s => s.Return_from == textBox6.Text).Select(s => s.ID).ToList();
                AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                foreach (var item in all_id)
                {
                    MyCollection.Add(item.ToString());
                }
                textBox6.AutoCompleteMode = AutoCompleteMode.Suggest;
                textBox6.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection DataCollection = (MyCollection);
                textBox6.AutoCompleteCustomSource = DataCollection;
            }
            catch (Exception)
            {   
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                load_details();
                textBox5.Focus();
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                button1.Focus();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text=="")
            {
                label9.Text = "ادخل رقم فاتورة صحيح !";
            }
            else
            {
                label9.Text = "";
            }
        }
    }
}
