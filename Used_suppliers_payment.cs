﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mazaya_3G_return
{
    public partial class Used_suppliers_payment : Form
    {
        DataClasses1DataContext mob_sys = new DataClasses1DataContext();

        public Used_suppliers_payment()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    load_details();
                    textBox5.Focus();
                }
            }
            catch (Exception)
            {

                label9.Text = "لا يوجد فاتورة بهذا الرقم";
            }
            
        }

        public void load_details()
        {
            try
            {
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;

                int ch_id = int.Parse(textBox1.Text);
                var check_details = mob_sys.Used_Purchase_checks.Where(s => s.ID == ch_id).Select(s => new { s.Company, s.Total_Price, s.Difference_col, s.remaining_Val }).SingleOrDefault();
                textBox3.Text = check_details.Difference_col.ToString();

                if (check_details.remaining_Val != 0.00)
                {
                    textBox2.Text = check_details.remaining_Val.ToString();
                    textBox4.Text = (check_details.remaining_Val - check_details.Difference_col).ToString();
                }
                else
                {
                    textBox2.Text = check_details.Total_Price.ToString();
                    textBox4.Text = (check_details.Total_Price - check_details.Difference_col).ToString();
                }
                textBox6.Text = check_details.Company;
            }
            catch (Exception)
            {

            }
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

                    if (p <= total && p <= diff&& p!=0)
                    {
                        try
                        {
                            var max = mob_sys.Used_Payment_Outs.Max(s => s.ID);
                            mob_sys.Used_ins_payment_out(max + 1, Class1.TheID, System.DateTime.Now.Date, p, textBox6.Text);

                            mob_sys.Used_update_diff_purchase_out(i, p);
                            label9.Text = "تم السداد ";
                            load_details();
                        }
                        catch (Exception)
                        {
                            mob_sys.Used_ins_payment_out(1, Class1.TheID, System.DateTime.Now.Date, p, textBox6.Text);
                            mob_sys.Used_update_diff_purchase_out(i, p);
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

        private void Used_suppliers_payment_Load(object sender, EventArgs e)
        {
            label8.Text = Class1.TheValue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
