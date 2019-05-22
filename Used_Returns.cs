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
    public partial class Used_Returns : Form
    {
        DataClasses1DataContext mob_sys = new DataClasses1DataContext();
        DataTable dt = new DataTable();
        public Used_Returns()
        {
            InitializeComponent();
        }

        private void Used_Returns_Load(object sender, EventArgs e)
        {
            textBox11.Focus();
            if (Class1.Sellected_check_id != 0)
            {
                textBox2.Text = Class1.Sellected_check_id.ToString();
                after_press_id_enter();
            }
            else { textBox2.Text = textBox11.Text = ""; }
            dt.Columns.Add("مسلسل", typeof(int));
            dt.Columns.Add("رقم الصنف", typeof(int));
            dt.Columns.Add("اسم الصنف", typeof(string));
            dt.Columns.Add("الشركه المصنعه", typeof(string));
            dt.Columns.Add("النوع", typeof(string));
            dt.Columns.Add("العدد المرتجع", typeof(int));
            dt.Columns.Add("سعر الأصلى", typeof(float));
            dt.Columns.Add("سعر البيع", typeof(float));
            dt.Columns.Add("الاجمالى ", typeof(float));
            reset_form();
            autocomplete_names();
            button1.Enabled = false;
            button2.Enabled = true;
        }
        public void reset_form()
        {
                textBox2.Enabled = true;
                textBox11.Enabled = true;
                txt_Add_Item.Items.Clear();
                try
                {
                    var max_check_id = mob_sys.Used_Return_checks.Max(s => s.ID);
                    textBox1.Text = (max_check_id + 1).ToString();
                }
                catch (Exception) { textBox1.Text = "1"; }
                textBox3.Text = System.DateTime.Now.Date.ToString();
                textBox4.Text = Class1.TheValue;
                txt_Add_Item.Items.Clear();
                textBox9.Text  = textBox6.Text = "";
                textBox5.Text = textBox7.Text = textBox12.Text = textBox13.Text = textBox10.Text =  "";
                dt.Clear();
                label8.Text = "";
        }
        public bool ischeckexist(int i)
        {
            try
            {
                var allitems = mob_sys.Used_Sale_Checks.Select(s => s.ID).ToList();
                foreach (var item in allitems)
                {
                    if (item == i)
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
        public void auto_complete(int salecheck_id)
        {
            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();

            var allitems = mob_sys.Used_Sale_Check_details.Where(s => s.Sale_check_id == salecheck_id).Select(s => s.Item_ID).ToList();

            foreach (var item in allitems)
            {
                var item_name = mob_sys.Used_Items.Where(s => s.ID == item).Select(s => new { name = s.Name, id = s.ID }).SingleOrDefault();
                MyCollection.Add(item_name.name);
            }
            foreach (var item in MyCollection)
            {
                txt_Add_Item.Items.Add(item);
            }
            txt_Add_Item.ValueMember = "Item_ID";
            txt_Add_Item.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_Add_Item.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = (MyCollection);
            txt_Add_Item.AutoCompleteCustomSource = DataCollection;
        }
        public void autocomplete_names() {
            AutoCompleteStringCollection MyCollection2 = new AutoCompleteStringCollection();
            var allnames = mob_sys.Used_Sale_Checks.Select(s => new { s.Sale_to,s.ID }).ToList();
            foreach (var item in allnames)
            {
                MyCollection2.Add(item.Sale_to);
            }
            textBox11.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox11.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = (MyCollection2);
            textBox11.AutoCompleteCustomSource = DataCollection;
        }
        public void after_press_id_enter()
        {
            fill_names_combo();
            int id = int.Parse(textBox2.Text);
            var name = mob_sys.Used_Sale_Checks.Where(s => s.ID == id).Select(s => new { s.Sale_to, s.Total_Price, s.remaining_val, s.difference_col }).SingleOrDefault();
            if (name.remaining_val == 0.00 || name.remaining_val == 0)
            {
                var rem = name.Total_Price - name.difference_col;
                textBox18.Text = rem.ToString();
                textBox19.Text = name.Total_Price.ToString();
            }
            else
            {
                var rem = name.remaining_val - name.difference_col;
                textBox18.Text = rem.ToString();
                textBox19.Text = name.remaining_val.ToString();

            }
            textBox11.Text = name.Sale_to;
            textBox11.Enabled = false;
            textBox2.Enabled = false;
            button2.Enabled = false;
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (e.KeyChar == (char)13)
                {

                    after_press_id_enter();
                }
            }
            catch (Exception) { label8.Text = "رقم الفاتوره غير موجود"; }
        }
        public void fill_names_combo()
        {
            try
            {
                var checkid = int.Parse(textBox2.Text);

                if (ischeckexist(checkid))
                {

                    txt_Add_Item.Items.Clear();

                    auto_complete(checkid);
                  
                }
                else label8.Text = "الفاتوره غير موجوده";
            }
            catch (Exception)
            {

                MessageBox.Show("هذا الحقل مخصص لأرقام الفواتير فقط");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            total = 0;
            i = 0;
            if (button1.Text == "تم الحفظ")
            {
                DialogResult dialogResult = MessageBox.Show("هل تريد فتح فاتورة جديدة ؟", "تحذير", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    textBox11.Clear();
                    textBox2.Clear();
                    button2.Enabled = true;
                    textBox17.Text = "";
                    button1.Text = "حفظ";
                    button1.Enabled = false;
                    txt_Add_Item.Enabled = true;
                    textBox13.Enabled= true;
                    button5.Enabled = true;
                    textBox14.Enabled = true;
                    textBox14.Text = "";
                    textBox15.Text = "";
                    textBox5.Text = "";
                    textBox7.Text = "";
                    txt_Add_Item.Text = "";
                    textBox10.Text = "";
                    textBox12.Text = "";
                    textBox9.Enabled = true;
                    textBox6.Text = "";
                    dt.Clear();
                    dataGridView1.DataSource = "";
                    label8.Text = "فاتورة جديدة";
                    reset_form();
                    dt.Clear();
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
                    textBox11.Clear();
                    textBox2.Clear();
                    button2.Enabled = true;
                    textBox17.Text = "";
                    button1.Text = "حفظ";
                    button1.Enabled = false;
                    txt_Add_Item.Enabled = true;
                    textBox13.Enabled = true;
                    button5.Enabled = true;
                    textBox14.Enabled = true;
                    textBox14.Text = "";
                    textBox15.Text = "";
                    textBox9.Enabled = true;
                    textBox6.Text = "";
                    dt.Clear();
                    dataGridView1.DataSource = "";
                    label8.Text = "فاتورة جديدة";
                    reset_form();
                    dt.Clear();
                    dataGridView1.Refresh();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else ...
                }
            }
        }

        float total = 0;
        int i = 0;
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "" && textBox5.Text != "" && txt_Add_Item.Text != "" && textBox13.Text != "")
            {
                try
                {
                    if (int.Parse(textBox17.Text) <= int.Parse(textBox13.Text) && int.Parse(textBox17.Text) >0)
                    {
                        additem_to_grid();
                        total = 0;
                        i = 0;
                        sum_total();
                        textBox6.Text = total.ToString();
                        textBox17.Text = textBox13.Text = textBox16.Text = "";
                    }
                    else label8.Text = "لا يمكن ارجاع هذه الكمية";
                }
                catch (Exception)
                {
                    label8.Text = "رجاء تاكد من الكميه المرتجعه";
                }
            }
            else label8.Text = "تاكد من ادخال كل بيانات الصنف";
        }

        int count_grid = 1;
        int w = 1;
        private void additem_to_grid()
        {
            if (textBox13.Text != "")
            {
                if (int.Parse(textBox13.Text) <= int.Parse(textBox5.Text))
                {
                    if (!ifexist_item(txt_Add_Item.Text))
                    {
                        var count = float.Parse(textBox17.Text);
                        var x = txt_Add_Item.SelectedItem.ToString();
                        var name_id = mob_sys.Used_Items.Where(s => s.Name == x).Select(s => s.ID).SingleOrDefault();
                        var x2=textBox11.Text;
                        var sale_price=mob_sys.Used_Sale_Checks.Where(s=>s.Sale_to ==x2).Select(s=>s.difference_col).SingleOrDefault();
                        var comb = textBox12.Text;
                        var type = textBox10.Text;
                        var pa_price = textBox7.Text;
                        var price = count * float.Parse(pa_price);
                        dt.Rows.Add(count_grid, name_id, x, comb, type, count, double.Parse(pa_price), double.Parse(sale_price.ToString()), double.Parse(price.ToString()));
                        count_grid++;
                        w++;
                        dataGridView1.DataSource = dt;
                        txt_Add_Item.Text = textBox5.Text = textBox7.Text = textBox13.Text = textBox12.Text =textBox10.Text = "";
                        sum_total();
                        textBox6.Text = total.ToString();
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("هل تريد التعديل فى الصنف ؟", "Some Title", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            var comb = textBox12.Text;
                            var type = textBox10.Text;

                            foreach (DataRow item in dt.Rows)
                            {
                                var x = item["اسم الصنف"];
                                if (item["اسم الصنف"].ToString() == txt_Add_Item.Text)
                                {
                                    int curR = int.Parse(item["مسلسل"].ToString());
                                    var xx = txt_Add_Item.Text;

                                    DataGridViewRow row = dataGridView1.Rows[curR - 1];
                                    var countt = int.Parse(textBox13.Text);
                                    var p = float.Parse(row.Cells[6].Value.ToString());
                                    row.Cells[5].Value = countt.ToString();
                                    var totall = float.Parse(countt.ToString()) * p;
                                    row.Cells[7].Value = totall;
                                    dataGridView1.DataSource = dt;
                                    txt_Add_Item.Text = textBox5.Text = textBox7.Text = "";
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
                else label8.Text = "الكميه المرتجعه اكبر من المباعه";
            }
            else label8.Text = "رجاء حدد الكميه المرتجعه";
        }

        private float sum_total()
        {
            var rows_count = dataGridView1.RowCount ;
            do
            {
                if (i != rows_count)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    var x = row.Index;
                    var p = row.Cells[7].Value.ToString();
                    total += float.Parse(p);
                    i++;
                }
            } while (i < rows_count);

            return total;
        }

        private bool ifexist_item(string p)
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    if (row.Cells[2].Value.ToString() == p)
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

        private void txt_Add_Item_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox17.Focus();
            if (textBox2.Text != "")
            {
                var x = txt_Add_Item.SelectedItem.ToString();
                var allnames = mob_sys.Used_Items.Where(s => s.Name == x).Select(s => new
                {
                    s.Notes,
                    s.ID,
                    s.Producing_Company_id,
                    s.Type,
                    s.Sale_Price,
                    s.Recieve_Price,
                    s.Count
                }).SingleOrDefault();
                int s_id = int.Parse(textBox2.Text);
                var pa_price = mob_sys.Used_Sale_Check_details.Where(s => s.Sale_check_id == s_id && s.Item_ID == allnames.ID).Select(s => s.Paid_Item_Price).SingleOrDefault();
                var comb_id = allnames.Producing_Company_id;
                var comb = mob_sys.Producing_companies.Where(s => s.ID == comb_id).Select(s => s.Producing_company1).SingleOrDefault();

                var type_id = allnames.Type;
                var type = mob_sys.Type_items.Where(s => s.ID == type_id).Select(s => s.Type).SingleOrDefault();

                textBox7.Text = pa_price.ToString();
                textBox12.Text = comb;
                textBox10.Text = type;
                var check_idd=int.Parse(textBox2.Text);
                var sale_count = mob_sys.Used_Sale_Check_details.Where(s => s.Sale_check_id ==check_idd && s.Item_ID==allnames.ID ).Select(s => s.Count).SingleOrDefault();
                textBox5.Text = sale_count.ToString();
                int quantity = 0;
                if (isSaleidexistinReturncheck(s_id))
                {
                    var r_id = mob_sys.Used_Return_checks.Where(s => s.sale_check_id == s_id ).Select(s => s.ID).ToList();

                    foreach (var item in r_id)
                    {
                        if (isItemidexistinReturncheck(allnames.ID, item))
                        {
                            var count_return = mob_sys.Used_Return_Check_details.Where(s => s.Item_ID == allnames.ID && s.Return_check_id == item).Select(s => s.Count).SingleOrDefault();
                            quantity = quantity + count_return;
                            textBox16.Text = quantity.ToString();
                            textBox13.Text = (sale_count - int.Parse(textBox16.Text)).ToString();
                        }
                        else
                        {
                            textBox16.Text = "0";
                            textBox13.Text = (sale_count - int.Parse(textBox16.Text)).ToString();
                        }
                    }
                }
                else
                {
                    textBox16.Text = "0";
                    textBox13.Text = (sale_count - int.Parse(textBox16.Text)).ToString();
                }
            }
        }
        public bool isSaleidexistinReturncheck(int i)
        {
            try
            {
                var allitems = mob_sys.Used_Return_checks.Select(s => s.sale_check_id).ToList();
                foreach (var item in allitems)
                {
                    if (item == i)
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
        public bool isItemidexistinReturncheck(int i, int ch_id)
        {
            try
            {

                var allitems = mob_sys.Used_Return_Check_details.Where(s => s.Return_check_id == ch_id).Select(s => s.Item_ID).ToList();
                foreach (var item in allitems)
                {
                    if (item == i)
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
        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                additem_to_grid();
                sum_total();
                textBox6.Text = total.ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
                if (textBox11.Text != "" && textBox14.Text != "")
                {
                    if (textBox6.Text != "")
                    {
                        if (float.Parse(textBox14.Text) <= float.Parse(textBox6.Text))
                        {
                            var d = System.DateTime.Now.Date;
                            var subname = textBox11.Text;
                            var sub_comp = textBox2.Text;
                            var n = textBox9.Text;
                            var diff = float.Parse(textBox14.Text);
                            var egmaly = double.Parse(textBox6.Text);
                            try
                            {
                                var maxid = mob_sys.Used_Return_checks.Max(s => s.ID);
                                var max = maxid + 1;

                                mob_sys.Used_insert_return_check(max, d, subname,
                                            Class1.TheID, egmaly, int.Parse(textBox2.Text), n, diff);
                                ins_item();
                                label8.Text = "تم عمل الفاتوره";
                                button1.Text = "تم الحفظ";

                                button4.Enabled = true;
                                txt_Add_Item.Enabled = false;
                                textBox14.Enabled = false;
                                textBox13.Enabled = false;
                                textBox9.Enabled = false;
                                label16.Text = "";
                                button5.Enabled = false;
                                button1.Enabled = false;
                                i = 0;
                            }
                            catch (Exception)
                            {
                                mob_sys.Used_insert_return_check(1, d, subname, Class1.TheID, egmaly, int.Parse(textBox2.Text), n, diff);
                                ins_item();
                                label8.Text = "تم عمل الفاتوره";
                                button1.Text = "تم الحفظ";
                                button4.Enabled = true;
                                txt_Add_Item.Enabled = false;
                                textBox14.Enabled = false;
                                textBox13.Enabled = false;
                                textBox9.Enabled = false;
                                label16.Text = "";
                                button5.Enabled = false;
                                button1.Enabled = false;
                                i = 0;
                            }
                        }
                        else label8.Text = "المبلغ المدفوع أكبر من إجمالى المرجع";
                    }
                    else label8.Text = "رجاء اختر الاصناف ";
                }
                else label8.Text = " رجاء ادخل اسم المشترى أو المبلغ المدفوع أو كلاهما ";
            }

        private void ins_item()
        {
            if (dataGridView1.RowCount != -1)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    var item_id = int.Parse(row.Cells[1].Value.ToString());
                    var count = int.Parse(row.Cells[5].Value.ToString());

                    var pricee = float.Parse(row.Cells[6].Value.ToString());

                    var max_return_id = mob_sys.Used_Return_checks.Max(s => s.ID);
                    try
                    {
                        var return_id = mob_sys.Used_Return_Check_details.Max(s => s.ID);
                        mob_sys.Used_ins_returns_check_detail(return_id + 1, item_id, count, pricee, "", max_return_id);
                        mob_sys.Used_plus_item_count(count,item_id);
                    }
                    catch (Exception)
                    {
                        mob_sys.Used_ins_returns_check_detail(1, item_id, count, pricee, " ", max_return_id);
                        mob_sys.Used_plus_item_count(count, item_id);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            used h = new used();
            h.ShowDialog();   
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox14.Text != "")
                {
                    var current = float.Parse(textBox14.Text);
                    var total = float.Parse(textBox6.Text);
                    button1.Enabled = true;
                    if (current <= total)
                   
                    {
                        var remain = total - current;
                        textBox15.Text = remain.ToString();
                        button1.Enabled = true;
                    }
                    else
                    {
                        label16.Text = "قيمه المدفوع اكبر من المسموح ارجاعه";
                        button1.Enabled = false;
                    }
                }
            }
            catch (Exception)
            {
                button1.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox14.Text != "" && textBox15.Text != "" && textBox6.Text != "")
            {
                if (float.Parse(textBox14.Text) <= float.Parse(textBox6.Text))
                {
                    if (button1.Text == "تم الحفظ")
                    {
                        Class1.Return_id= mob_sys.Used_Return_checks.Max(s => s.ID);
                        Used_View_report_return_sale_checks v = new Used_View_report_return_sale_checks();
                        v.Show();
                    }
                    else
                    {
                        label16.Text = "إحفظ الفاتورة";
                    }
                }
                else label8.Text = "المبلغ المدفوع أكبر من إجمالى المرجع";
            }
            else label16.Text = "تأكد من إدخال المبلغ المردود";
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(textBox17.Text) <= int.Parse(textBox13.Text))
                {
                    label16.Text = "";
                }
                else label16.Text = "الكميه المرتجعه اكبر من المسموح بها";
            }catch(Exception){}
        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)13)
            {
                 button5_Click(null,null);
            }
        }

        //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    updatediff up_diff = new updatediff();
        //    up_diff.ShowDialog();
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox2.Text);
            var name = mob_sys.Used_Sale_Checks.Where(s => s.ID == id).Select(s => new { s.Sale_to, s.Total_Price, s.remaining_val, s.difference_col }).SingleOrDefault();
            if (name.remaining_val == 0.00 || name.remaining_val == 0)
            {
                var rem = name.Total_Price - name.difference_col;
                textBox18.Text = rem.ToString();
            }
            else
            {
                var rem = name.remaining_val - name.difference_col;
                textBox18.Text = rem.ToString();
            } 
        }

        private void label114_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (ifsale_to_exist())
            {
                // MessageBox.Show("موجود");
                Class1.Saleto = textBox11.Text;
                this.Close();
                Used_allchecks_by_name all_checks = new Used_allchecks_by_name();
                all_checks.Show();

            }
            else MessageBox.Show("موجود غير");
        }

        private bool ifsale_to_exist()
        {
            try
            {
                var all_names = mob_sys.Used_Sale_Checks.Select(s => s.Sale_to).ToList();
                foreach (var item in all_names)
                {
                    if (item == textBox11.Text)
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

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                button2.Focus();
            }
        }
    }
}