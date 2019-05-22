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
    public partial class SaleCheck : Form
    {
        DataClasses1DataContext mob_sys = new DataClasses1DataContext();
        DataTable dt = new DataTable();
        public SaleCheck()
        {
            InitializeComponent();
        }

        private void SaleCheck_Load(object sender, EventArgs e)
        {
            textBox2.Focus();
            button1.Enabled= false;
            textBox12.Enabled = false;
            dt.Columns.Add("مسلسل", typeof(int));
            dt.Columns.Add("رقم الصنف", typeof(int));
            dt.Columns.Add("اسم الصنف", typeof(string));
            dt.Columns.Add("العدد", typeof(int));
            dt.Columns.Add("سعر الوحده", typeof(float));
            dt.Columns.Add("الاجمالى ", typeof(float));
            dt.Columns.Add("ملاحظات", typeof(string));
            reset_form();
        }
        public void reset_form() 
        {
            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            var allitems = mob_sys.Items.Select(s => new { s.Name, s.count,s.Screen_Title_ID }).ToList();
            foreach (var item in allitems)
            {
                MyCollection.Add(item.Name);
            }
            txt_Add_Item.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_Add_Item.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = (MyCollection);
            txt_Add_Item.AutoCompleteCustomSource = DataCollection;
            textBox3.Text = System.DateTime.Now.Date.ToString();
            textBox4.Text = Class1.TheValue;
            label14.Text = Class1.TheValue;
            try
            {
                var maxid = mob_sys.Sale_checks.Max(s => s.ID);
                textBox1.Text = (maxid + 1).ToString();
            }
            catch (Exception)
            {
                textBox1.Text = "1";
            }
            linkLabel1.Visible = false;
            linkLabel1.Enabled = false;
        }
        public void ins_sal_details()
        {
            try
            {
                var sale_id = mob_sys.Sale_checks.Max(s => s.ID);
                if (dataGridView1.RowCount != -1)
                {
                    for (int i = 0; i < dataGridView1.RowCount ; i++)
                    {
                        var max_sal_id = mob_sys.Sale_check_details.Max(s => s.ID);
                        DataGridViewRow row = dataGridView1.Rows[i];

                        if (Combo__tax_Discount.SelectedIndex == 0)
                        {
                            var val = float.Parse(txt_value.Text);
                            var pa_price = float.Parse(row.Cells[4].Value.ToString());
                            var after_dis = (pa_price * val) / 100;
                            var result = pa_price - after_dis;

                            mob_sys.ins_Sale_check_detail(max_sal_id + 1, int.Parse(row.Cells[1].Value.ToString()),
                            int.Parse(row.Cells[3].Value.ToString())
                            , double.Parse(row.Cells[5].Value.ToString()), row.Cells[6].Value.ToString(), sale_id, double.Parse(row.Cells[4].Value.ToString()), result);

                        }
                        else if (Combo__tax_Discount.SelectedIndex == 1)
                        {
                            var val = float.Parse(txt_value.Text);
                            var pa_price = float.Parse(row.Cells[4].Value.ToString());
                            var after_dis = (pa_price * val) / 100;
                            var result = pa_price + after_dis;
                            mob_sys.ins_Sale_check_detail(max_sal_id + 1, int.Parse(row.Cells[1].Value.ToString()), int.Parse(row.Cells[3].Value.ToString())
                            , double.Parse(row.Cells[5].Value.ToString()), row.Cells[6].Value.ToString(), sale_id, double.Parse(row.Cells[4].Value.ToString()),result);
                        }
                        else
                            mob_sys.ins_Sale_check_detail(max_sal_id + 1, int.Parse(row.Cells[1].Value.ToString()), int.Parse(row.Cells[3].Value.ToString())
                            , double.Parse(row.Cells[5].Value.ToString()), row.Cells[6].Value.ToString(), sale_id, double.Parse(row.Cells[4].Value.ToString()), 0.00);
                        mob_sys.sub_item_count(int.Parse(row.Cells[3].Value.ToString()), int.Parse(row.Cells[1].Value.ToString()));
                            
                    }
                }

            }
            catch (Exception)
            {
                var sale_id = mob_sys.Sale_checks.Max(s => s.ID);
                if (dataGridView1.RowCount != -1)
                {
                    for (int i = 0; i < dataGridView1.RowCount ; i++)
                    {
                        DataGridViewRow row = dataGridView1.Rows[i];
                        if (Combo__tax_Discount.SelectedIndex == 0)
                        {
                            var val = float.Parse(txt_value.Text);
                            var pa_price = float.Parse(row.Cells[4].Value.ToString());
                            var after_dis = (pa_price * val) / 100;
                            var result = pa_price - after_dis;
                            mob_sys.ins_Sale_check_detail(i + 1, int.Parse(row.Cells[1].Value.ToString()), int.Parse(row.Cells[3].Value.ToString())
                                , double.Parse(row.Cells[5].Value.ToString()), row.Cells[6].Value.ToString(), sale_id,
                                double.Parse(row.Cells[4].Value.ToString()),result);
                        }
                        else if (Combo__tax_Discount.SelectedIndex == 1)
                        {
                            var val = float.Parse(txt_value.Text);
                            var pa_price = float.Parse(row.Cells[4].Value.ToString());
                            var after_dis = (pa_price * val) / 100;
                            var result = pa_price + after_dis;
                            mob_sys.ins_Sale_check_detail(i + 1, int.Parse(row.Cells[1].Value.ToString()), int.Parse(row.Cells[3].Value.ToString())
                                , double.Parse(row.Cells[5].Value.ToString()), row.Cells[6].Value.ToString(), sale_id,double.Parse(row.Cells[4].Value.ToString()), result);
                        }
                        else
                            mob_sys.ins_Sale_check_detail(i + 1, int.Parse(row.Cells[1].Value.ToString()), int.Parse(row.Cells[3].Value.ToString())
                               , double.Parse(row.Cells[5].Value.ToString()), row.Cells[6].Value.ToString(), sale_id,
                               double.Parse(row.Cells[4].Value.ToString()),0.00);
                             mob_sys.sub_item_count(int.Parse(row.Cells[3].Value.ToString()), int.Parse(row.Cells[1].Value.ToString()));
                    }
                }
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
       {
           if (textBox2.Text != "" && textBox6.Text != "")
           {
                if (textBox10.Text != "")
                {
                        try
                        {
                            var maxid = mob_sys.Sale_checks.Max(s => s.ID);
                            if (txt_value.Text !="")
                            {
                                var val = float.Parse(txt_value.Text);
                                if (Combo__tax_Discount.SelectedIndex == 0)
                                {
                                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                    {
                                       DataGridViewRow row = dataGridView1.Rows[i];
                                       var pa_price=float.Parse(row.Cells[4].Value.ToString());
                                       var after_dis = (pa_price * val) / 100;
                                       var result = pa_price - after_dis;
                                   }
                                    mob_sys.insert_sale_check(maxid + 1, System.DateTime.Now.Date, textBox2.Text, Class1.TheID, double.Parse(textBox6.Text),
                                      textBox9.Text, float.Parse(textBox10.Text), val, 0.00, float.Parse(txt_Check_remaining.Text));
                                }
                                else 
                                {
                                    mob_sys.insert_sale_check(maxid + 1, System.DateTime.Now.Date, textBox2.Text, Class1.TheID, double.Parse(textBox6.Text),
                                        textBox9.Text, float.Parse(textBox10.Text), 0.00, val, float.Parse(txt_Check_remaining.Text));
                                }
                            }
                            else
                            {
                                mob_sys.insert_sale_check(maxid + 1, System.DateTime.Now.Date, textBox2.Text, Class1.TheID, double.Parse(textBox6.Text),
                                 textBox9.Text, float.Parse(textBox10.Text), 0.00, 0.00, 0.00);
                            }
                            ins_sal_details();
                            label13.Text = "تم عمل الفاتورة";
                            button1.Text = "تم الحفظ";
                            textBox6.Text = textBox10.Text = textBox11.Text =txt_value.Text=txt_Check_remaining.Text= "";
                            label20.Text = "";
                            textBox10.Enabled = false;
                            button5.Enabled = false;
                            textBox8.Enabled = false;
                            textBox9.Enabled = false;
                            textBox12.Enabled = false;
                            textBox2.Enabled = false;
                            textBox5.Enabled = false;
                            txt_Add_Item.Enabled = false;
                            button1.Enabled = false;
                        }
                        catch (Exception)
                        {
                            if (txt_value.Text != "")
                            {
                                var val = float.Parse(txt_value.Text);
                                if (Combo__tax_Discount.SelectedIndex == 0)
                                {
                                        mob_sys.insert_sale_check(1, System.DateTime.Now.Date, textBox2.Text, Class1.TheID,
                                        double.Parse(textBox6.Text), textBox9.Text, float.Parse(textBox10.Text), val, 0.00, float.Parse(txt_Check_remaining.Text));
                                }
                                else
                                {
                                    mob_sys.insert_sale_check(1, System.DateTime.Now.Date, textBox2.Text, Class1.TheID,
                                        double.Parse(textBox6.Text), textBox9.Text, float.Parse(textBox10.Text), 0.00, val, float.Parse(txt_Check_remaining.Text));
                                }
                            }
                            else
                            {
                                mob_sys.insert_sale_check(1, System.DateTime.Now.Date, textBox2.Text, Class1.TheID,
                                     double.Parse(textBox6.Text), textBox9.Text, float.Parse(textBox10.Text), 0.00, 0.00, 0.00);
                            }
                            ins_sal_details();
                            label13.Text = "تم عمل الفاتوره";
                            button1.Text = "تم الحفظ";
                            label20.Text = "";
                            textBox10.Enabled = false;
                            button5.Enabled = false;
                            textBox8.Enabled = false;
                            textBox9.Enabled = false;
                            textBox12.Enabled = false;
                            textBox2.Enabled = false;
                            textBox5.Enabled = false;
                            txt_Add_Item.Enabled = false;
                            button1.Enabled = false;
                        }
               }
                else label13.Text = " ادخل القيمه المدفوعه ";
                mob_sys.SubmitChanges();
                }
                else label13.Text = " رجاء ادخل اسم المشترى وادخل اصناف ";
            }
        private bool ifexist_item(string x)
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    if (row.Cells[2].Value.ToString() == x)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        int i =0;
        float total;
        int count_grid=1;
        public void additem_to_grid() {   
            total = 0;
                i=0;
                if (textBox7.Text != "لايوجد رصيد بالمخزن" && textBox5.Text  !="")
            {
                if (int.Parse(textBox5.Text) <= int.Parse(textBox7.Text))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        row.ReadOnly = true;
                    }
                    if (!ifexist_item(txt_Add_Item.Text))
                    {
                        if (textBox5.Text != "")
                        {
                            if (linkLabel1.Enabled == false)
                            {
                                try
                                {
                                    var x = txt_Add_Item.Text;
                                    var count = int.Parse(textBox5.Text);
                                    var itemdetails = mob_sys.Items.Where(s => s.Name == x).Select(s => new { s.ID, s.Name, s.Sale_Price }).SingleOrDefault();
                                    var pa_price = itemdetails.Sale_Price.ToString();
                                    var price = count * int.Parse(pa_price);
                                    dt.Rows.Add(count_grid, itemdetails.ID, itemdetails.Name, count, double.Parse(pa_price), double.Parse(price.ToString()), textBox8.Text);
                                    dataGridView1.DataSource = dt;
                                    count_grid++;
                                    txt_Add_Item.Text = textBox5.Text = textBox7.Text = textBox12.Text = textBox8.Text = "";
                                    linkLabel1.Visible = false;
                                    sum_total();
                                    textBox6.Text = total.ToString();
                                }
                                catch (Exception)
                                {
                                    label13.Text = "تأكد من اسم الصنف";
                                    txt_Add_Item.Text = textBox5.Text = "";
                                }
                            } label13.Text = "سعر الصنف اولا";
                        }
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("هل تريد التعديل فى الصنف ؟", "Some Title", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            foreach (DataRow item in dt.Rows)
                            {
                                var x = item["اسم الصنف"];
                                if (item["اسم الصنف"].ToString() == txt_Add_Item.Text)
                                {
                                    int curR = int.Parse(item["مسلسل"].ToString());
                                    var xx = txt_Add_Item.Text;
                                    DataGridViewRow row = dataGridView1.Rows[curR - 1];
                                    var countt = int.Parse(textBox5.Text);
                                    var itemdetailss = mob_sys.Items.Where(s => s.Name == xx).Select(s => new { s.ID, s.Name, s.Sale_Price }).SingleOrDefault();
                                    var pa_pricee = itemdetailss.Sale_Price.ToString();
                                    var price = countt * int.Parse(pa_pricee);
                                    row.Cells[1].Value = itemdetailss.ID;
                                    row.Cells[2].Value = txt_Add_Item.Text;
                                    row.Cells[3].Value = textBox5.Text;
                                    row.Cells[4].Value = pa_pricee.ToString();
                                    row.Cells[5].Value = price.ToString();
                                    row.Cells[6].Value = textBox8.Text;
                                    dataGridView1.DataSource = dt;
                                    txt_Add_Item.Text = textBox5.Text = "";
                                }
                                total = 0;
                                i = 0;
                                sum_total();
                                textBox6.Text = total.ToString();
                            }
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            //do something else
                        }
                    }
                }
                else label13.Text = "الكميه المطلوبه اكبر من الموجود ف المخزن ";
            }
            else label13.Text = "رجاء تاكد من الكميه المطلوبه او الكميه ف المخزن";
        }

        private float sum_total()
        {
            var rows_count = dataGridView1.RowCount;
            do
            {
                if (i != rows_count)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    var x = row.Index;
                    var p = row.Cells[5].Value.ToString();
                    total += int.Parse(p);
                    i++;
                }
            } while (i < rows_count);

            return total;
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                additem_to_grid();

            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home h = new Home();
            h.ShowDialog();
        }

        private void txt_Add_Item_TextChanged(object sender, EventArgs e)
        {
            var itemdetails = mob_sys.Items.Where(s => s.Name == txt_Add_Item.Text).Select(s => new { s.ID, s.Name, s.count,s.Sale_Price ,s.Recieve_Price}).SingleOrDefault();
            try
            {
                textBox12.Text = itemdetails.ID.ToString();
                if (itemdetails.count > 0)
                {
                    textBox7.Text = itemdetails.count.ToString();   
                }

                if (itemdetails.Sale_Price == 0 || itemdetails.Sale_Price <= itemdetails.Recieve_Price)
                {
                    linkLabel1.Visible = true;
                    linkLabel1.Enabled = true;
                }
                else 
                {
                    linkLabel1.Visible = false;
                    linkLabel1.Enabled = false;
                }
            }
            catch (Exception) {   textBox7.Text = "لايوجد رصيد بالمخزن";}
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13){
                additem_to_grid();
            }   
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (button1.Text=="تم الحفظ")
            {
                DialogResult dialogResult = MessageBox.Show("هل تريد فتح فاتورة جديدة ؟", "تحذير", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    label13.Text = "فاتورة جديدة";
                    button1.Enabled = false;
                    txt_value.Text = "";
                    txt_Check_remaining.Text = "";
                    label20.Text = "";
                    textBox10.Enabled = true;
                    button5.Enabled = true;
                    textBox8.Enabled = true;
                    textBox9.Enabled = true;
                    textBox12.Enabled = true;
                    textBox2.Enabled = true;
                    textBox5.Enabled = true;
                    txt_Add_Item.Enabled = true;
                    textBox2.Text = "";
                    textBox6.Text = "";
                    textBox10.Text = "";
                    textBox11.Text = "";
                    button1.Text = "حفظ";
                    try
                    {
                        var maxid = mob_sys.Sale_checks.Max(s => s.ID);
                        textBox1.Text = (maxid + 1).ToString();
                    }
                    catch (Exception)
                    {
                        textBox1.Text = "1";
                    }
                    dt.Clear();
                    dataGridView1.DataSource = "";
                    dataGridView1.Refresh();

                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else ...
                }    
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("سيؤدى ذلك التصرف لمسح محتويات الفاتورة بالكامل قبل حفظها\n هل ترغب فى المسح و إعادة إنشاء فاتورة أخرى جديدة ؟", "تحذير", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    label13.Text = "فاتورة جديدة";
                    button1.Enabled = false;
                    label20.Text = "";
                    txt_value.Text = "";
                    txt_Check_remaining.Text = "";
                    textBox10.Enabled = true;
                    button5.Enabled = true;
                    textBox8.Enabled = true;
                    textBox9.Enabled = true;
                    textBox12.Enabled = true;
                    textBox2.Enabled = true;
                    textBox5.Enabled = true;
                    txt_Add_Item.Enabled = true;
                    textBox2.Text = "";
                    textBox6.Text = "";
                    textBox10.Text = "";
                    textBox11.Text = "";
                    button1.Text = "حفظ";
                    try
                    {
                        var maxid = mob_sys.Sale_checks.Max(s => s.ID);
                        textBox1.Text = (maxid + 1).ToString();
                    }
                    catch (Exception)
                    {
                        textBox1.Text = "1";
                    }
                    dt.Clear();
                    dataGridView1.DataSource = "";
                    dataGridView1.Refresh();

                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else ...
                }
            }
            
        }


        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            txt_value.Enabled = false;
            Combo__tax_Discount.Enabled = false;
            txt_value.Enabled = false;
            try
            {
                if (txt_Check_remaining.Text!="")
                {
                    if (textBox10.Text != "")
                    {
                        var current = float.Parse(textBox10.Text);
                        var total = float.Parse(txt_Check_remaining.Text);
                        if (current <= total)
                        {
                            var remain = total - current;
                            textBox11.Text = remain.ToString();
                            label20.Text = "";
                            button1.Enabled = true;
                        }
                        else
                        {
                            label20.Text = "قيمه المدفوع اكبر من الاجمالى";
                            button1.Enabled = false;
                        }
                    }    
                }
                else if (txt_Check_remaining.Text=="")
                {
                    if (textBox10.Text != "")
                    {
                        var current = float.Parse(textBox10.Text);
                        var total = float.Parse(textBox6.Text);
                        if (current <= total)
                        {
                            var remain = total - current;
                            textBox11.Text = remain.ToString();
                            label20.Text = "";
                            button1.Enabled = true;
                        }
                        else
                        {
                            label20.Text = "قيمه المدفوع اكبر من الاجمالى";
                            button1.Enabled = false;
                        }
                    }
                }
                
            }
            catch (Exception)
            {

                label20.Text = "لاحظ ! أدخل المبلغ المدفوع بشكل رقمى فقط";
                button1.Enabled = false;
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            additem_to_grid();
        }

       
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Class1.Item_Id = int.Parse(textBox12.Text);
            Class1.Click_edititem = 1;
            EditItem edit = new EditItem();
            edit.ShowDialog();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
        }
        private void Combo__tax_Discount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Combo__tax_Discount.SelectedIndex == 1 || Combo__tax_Discount.SelectedIndex == 0)
            {
                total = float.Parse(textBox6.Text);
                txt_Check_remaining.Text = "0.00";
                txt_value.Text = "0.00";
            }
        }
        float add_val = 0;
        float disc_val = 0;

        private void txt_value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txt_value.Text != "" && textBox6.Text != "")
                {
                    var taxvalll = txt_value.Text;

                    var total_costt = total;
                    var t = total;
                    if (txt_value.Text != "" && Combo__tax_Discount.SelectedIndex == 1)
                    {
                        add_val = float.Parse(taxvalll);
                        total_costt = (total_costt * float.Parse(taxvalll)) / 100;
                        t += total_costt;
                        txt_Check_remaining.Text = t.ToString();
                    }
                    else if (txt_value.Text != "" && Combo__tax_Discount.SelectedIndex == 0)
                    {
                        disc_val = float.Parse(taxvalll);
                        total_costt = (total_costt * float.Parse(taxvalll)) / 100;
                        t -= total_costt;
                        txt_Check_remaining.Text = t.ToString();
                    }
                    textBox10.Focus();
                }
                else MessageBox.Show("تاكد من ادخال اصناف للفاتوره");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button1.Text == "حفظ")
            {
                label13.Text = "إحفظ الفاتورة";
            }
            else if (button1.Text == "تم الحفظ")
            {
                Class1.Sale_id = mob_sys.Sale_checks.Max(s => s.ID);
                View_report_sale_check v = new View_report_sale_check();
                v.Show();
            }        
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txt_value.Enabled = true;
            txt_value.Text = txt_Check_remaining.Text =textBox10.Text=textBox11.Text= "";
            txt_Check_remaining.Enabled = true;
            Combo__tax_Discount.Enabled = true;
            Combo__tax_Discount.ResetText();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txt_Add_Item.Focus();
            }
            
        }

        private void txt_Add_Item_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                textBox5.Focus();
            }
        }
    }
}
