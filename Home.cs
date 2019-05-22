using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BLC_mallU;




namespace Mazaya_3G_return
{

    public partial class Home : Form
    {
        DataClasses1DataContext mob_sys = new DataClasses1DataContext();
        //mazayaEntities mob_sys = new mazayaEntities();

        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();

        public Home()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Edit_Patient edit_patient = new Edit_Patient();
            //edit_patient.Show();
        }

        bool linklablepress=false;
        public void combo_mob_Accessories()
        {
            comboBox4.Items.Add("موبايلات");
            comboBox4.Items.Add("إكسسوارات");
        }

       
        private void Home_Load(object sender, EventArgs e)
        {
            textBox2.Focus();
            txt_Check_remaining.Enabled = false;
            txt_value.Enabled = false;
            Combo__tax_Discount.Enabled = false;
            textBox11.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            combo_mob_Accessories();
            //textBox6.Text = "200";
           linklablepress = false;
           if (Class1.TheID == 0)
           {
               //DialogResult dialogResult = MessageBox.Show("هل تريد اغلاق البرنامج ؟", "Some Title", MessageBoxButtons.YesNo);
               //if (dialogResult == DialogResult.Yes)
               //{
               //    this.Close();
               //}
               //if (dialogResult == DialogResult.No)
               //{
               //    login l = new login();
               //    l.ShowDialog();
               //}
           }
           
           if (linklablepress)
           {
                this.Show();
           }
           
            label8.Text = Class1.TheValue ;

            ///////////////////////
            ///declare dt
            dt.Columns.Add("مسلسل", typeof(int));
            dt.Columns.Add("رقم الصنف", typeof(int));
            dt.Columns.Add("اسم الصنف", typeof(string));
            dt.Columns.Add("النوع", typeof(string));
            dt.Columns.Add("الشركه المصنعة", typeof(string));
            dt.Columns.Add("العدد", typeof(int));
            dt.Columns.Add("سعر الوحده", typeof(float));
            dt.Columns.Add("الاجمالى ", typeof(float));
           
            dt.Columns.Add("ملاحظات", typeof(string));
           
            reset_form(); 
        }
        public void reset_form() {
            try
            {
                var maxid = mob_sys.Purchase_checks.Max(s => s.ID);
                textBox1.Text = (maxid + 1).ToString();

            }
            catch (Exception)
            {
                textBox1.Text = "1";
            }
            ////Auto complete
            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();

            var allitems = mob_sys.Items.Select(s => new { s.Name, s.count }).ToList();

            foreach (var item in allitems)
            {

                MyCollection.Add(item.Name);

            }

            textBox15.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox15.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = (MyCollection);
            textBox15.AutoCompleteCustomSource = DataCollection;
            ////end Auto complete
            loadcombo3();
            load_compo2();
            loadcombo1();
            loadcombo_screenTitle();
            /////end fill combobox

            textBox3.Text = System.DateTime.Now.Date.ToString();
            textBox4.Text = Class1.TheValue;
            label8.Text = Class1.TheValue;
            textBox2.Text = textBox10.Text = textBox11.Text = textBox12.Text = textBox9.Text = textBox6.Text = "";
            dt.Clear();
            button1.Enabled = false;
            textBox15.Text = textBox13.Text =  textBox14.Text = "";
           
          
        }
        AutoCompleteStringCollection MyCollection2 = new AutoCompleteStringCollection();
        AutoCompleteStringCollection MyCollection3_1 = new AutoCompleteStringCollection();
        AutoCompleteStringCollection MyCollection4 = new AutoCompleteStringCollection();
        AutoCompleteStringCollection MyCollection_ScreenTitle = new AutoCompleteStringCollection();
       
        public void loadcombo1() {

            MyCollection3_1.Clear();
            comboBox6.Items.Clear();
           
            var typ_name = mob_sys.Type_items.Select(s => new { type = s.Type, id = s.ID }).ToList();
            foreach (var item in typ_name)
            {

                MyCollection3_1.Add(item.type);

            }
            foreach (var item in MyCollection3_1)
            {
                comboBox6.Items.Add(item);
            }
            comboBox6.ValueMember = "id";
            comboBox6.DisplayMember = "type";

            comboBox6.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox6.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection3 = (MyCollection3_1);
            comboBox6.AutoCompleteCustomSource = DataCollection3;
            /////end fill combobox
        }

        public void loadcombo_screenTitle()
        {

            MyCollection_ScreenTitle.Clear();
            comboBox7.Items.Clear();
            
            var typ_name = mob_sys.Screen_Titles.Select(s => new { s.ID, s.Screen_Title1 }).ToList();
            foreach (var screen_TiTlE in typ_name)
            {

                MyCollection_ScreenTitle.Add(screen_TiTlE.Screen_Title1.ToString());

            }
            foreach (var item in MyCollection_ScreenTitle)
            {
                comboBox7.Items.Add(item);
            }
            comboBox7.ValueMember = "ID";
            comboBox7.DisplayMember = "Screen_Title1";

            comboBox7.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox7.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection_screen_Title = (MyCollection_ScreenTitle);
            comboBox7.AutoCompleteCustomSource = DataCollection_screen_Title;
            /////end fill combobox
        }
        public void loadcombo3() {

            comboBox3.Items.Clear();
            comboBox3.Items.Add("موبايلات");
            comboBox3.Items.Add("إكسسوارات");
            
        }
        
       public void load_compo2()
       {
           MyCollection2.Clear();
           comboBox5.Items.Clear();
           var company_name = mob_sys.Producing_companies.Select(s => new { company = s.Producing_company1, id = s.ID }).ToList();
            foreach (var item in company_name)
            {

                MyCollection2.Add(item.company);

            }
            foreach (var item in MyCollection2)
            {
                comboBox5.Items.Add(item);
            }
            comboBox5.ValueMember = "id";
            comboBox5.DisplayMember = "company";
            comboBox5.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox5.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection2 = (MyCollection2);
            comboBox5.AutoCompleteCustomSource = DataCollection2;
       }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linklablepress = true;

            Class1.TheID = 0;
            Class1.TheValue = "";
            this.Hide();
            login l = new login();
            l.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditProfile ep = new EditProfile();
            
            ep.ShowDialog();
            
        }

       
        private void فاتورةجديدةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home_Load(null,null);
        }

        private void منتجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class1.Click_edititem = 0;
            EditItem edit_item = new EditItem();
            edit_item.ShowDialog();
        }

        private void فاتورةToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void منتجToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Query_Item Query_Ite = new Query_Item();
            Query_Ite.ShowDialog();
        }

        private void فاتورةبيعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SaleCheck sale_ch = new SaleCheck();
            sale_ch.ShowDialog();
        }

        private void فاتورةشراءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reset_form();
        }
        public bool isitemexit(string x) {
            try
            {
                var allitems = mob_sys.Items.Select(s => new { s.Name}).ToList();
                foreach (var item in allitems)
                {
                    if (item.Name == x )
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
        //public bool isitemexit2(string x, int t, int c, float p)
        //{
        //    try
        //    {
        //        var allitems = mob_sys.Items.Select(s => new { s.Name, s.Producing_company_id, s.Type, s.Recieve_Price }).ToList();
        //        foreach (var item in allitems)
        //        {


        //            if (item.Name == x && item.Type == t && item.Producing_company_id == c && item.Recieve_Price != p)
        //            {

        //                return true;
        //            }

        //        }
        //        return false;
        //    }

        //    catch (Exception)
        //    {
        //        return false;
        //    }


        //}
        public void ins_item()
        {
            if (dataGridView1.RowCount != -1)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    
                    var t = row.Cells[3].Value.ToString();
                    var type_id = mob_sys.Type_items.Where(s => s.Type == t).Select(s => s.ID).SingleOrDefault();
                    var c = row.Cells[4].Value.ToString();
                    var comp_id = mob_sys.Producing_companies.Where(s => s.Producing_company1 == c).Select(s => s.ID).SingleOrDefault();
                    var item_count = int.Parse(row.Cells[5].Value.ToString());
                    var item_name = row.Cells[2].Value.ToString();
                    var pricee = float.Parse(row.Cells[7].Value.ToString());
                    var p=double.Parse(row.Cells[6].Value.ToString());
                    if (c!= " ")
                    {
                        try
                        {
                            var max_item_id = mob_sys.Items.Max(s => s.ID);
                            if (isitemexit(row.Cells[2].Value.ToString()))
                            {
                                 var prev_count = mob_sys.Items.Where(s => s.Name == item_name).Select(s => s.count).SingleOrDefault();
                                 var id_item = mob_sys.Items.Where(s => s.Name == item_name).Select(s => new { s.ID ,s.Recieve_Price}).SingleOrDefault();
                                 DialogResult dialogResult = MessageBox.Show("اسم الصنف :\n" + item_name + "\nالتسعيرة الحالية =  " + id_item.Recieve_Price + "جنيها\n" + "\nهل تريد تعديل السعر ؟"+"إضغط\nYes\nلتعديل السعر\nNoللإضافة على السعر القديم\nCancel\nلإلغاء العملية", "Some Title", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                                 if (dialogResult == DialogResult.Yes)
                                 {
                                     mob_sys.updateitemcouunt2(id_item.ID, item_count + prev_count,p);
                                 }
                                 else if (dialogResult == DialogResult.No)
                                 { 
                                 //here ... reject price and accept quantity
                                     mob_sys.updateitemcouunt2(id_item.ID, item_count + prev_count, id_item.Recieve_Price);
                                     
                                 }
                                 else if (dialogResult == DialogResult.Cancel)
                                 {
                                     continue;
                                 }
                            }
                            else
                            {
                                mob_sys.ins_Items(max_item_id + 1, row.Cells[2].Value.ToString(), type_id,
                                int.Parse(row.Cells[5].Value.ToString())
                                , double.Parse(row.Cells[6].Value.ToString()), 0.00, row.Cells[8].Value.ToString(), comp_id, 0);
                            }
                        }
                        catch (Exception)
                        {
                            mob_sys.ins_Items(1, row.Cells[2].Value.ToString(), type_id,
                            int.Parse(row.Cells[5].Value.ToString())
                            , double.Parse(row.Cells[6].Value.ToString()), 0.00, row.Cells[8].Value.ToString(), comp_id, 0);
                        }
                    }
                    else { ////add accessories
                        try
                        {
                            var max_item_id = mob_sys.Items.Max(s => s.ID);
                           //--------
                            if (isitemexit(row.Cells[2].Value.ToString()))
                            {
                                var prev_count = mob_sys.Items.Where(s => s.Name == item_name).Select(s => s.count).SingleOrDefault();
                                var id_item = mob_sys.Items.Where(s => s.Name == item_name).Select(s => new { s.ID, s.Recieve_Price }).SingleOrDefault();

                                DialogResult dialogResult = MessageBox.Show("اسم الصنف :\n" + item_name + "\nالتسعيرة الحالية =  " + id_item.Recieve_Price + "جنيها\n" + "هل تريد تعديل السعر ؟" + "إضغط\nYes\nلتعديل السعر\nNoللإضافة على السعر القديم\nCancel\nلإلغاء العملية", "Some Title", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    mob_sys.updateitemcouunt2(id_item.ID, item_count + prev_count, p);
                                }
                                else if (dialogResult == DialogResult.No)
                                {
                                    //here ... reject price and accept quantity
                                    mob_sys.updateitemcouunt2(id_item.ID, item_count + prev_count, id_item.Recieve_Price);
                                    //label22.Text = "الفاتورة مازالت قائمة";
                                }
                                else if (dialogResult == DialogResult.Cancel)
                                {
                                    continue;
                                }
                            }
                            //----
                            else 
                            { 
                                var screen = row.Cells[3].Value.ToString();
                                var screen_id=mob_sys.Screen_Titles.Where(s=>s.Screen_Title1==screen).Select(s=>s.ID).SingleOrDefault();
                                mob_sys.ins_Items(max_item_id + 1, row.Cells[2].Value.ToString(), 0,
                                int.Parse(row.Cells[5].Value.ToString())
                                , double.Parse(row.Cells[6].Value.ToString()), 0.00, row.Cells[8].Value.ToString(), 0, screen_id);
                            }
                        }
                        catch (Exception)
                        {
                            var screen = row.Cells[3].Value.ToString();
                            var screen_id = mob_sys.Screen_Titles.Where(s => s.Screen_Title1 == screen).Select(s => s.ID).SingleOrDefault();
                            mob_sys.ins_Items(1, row.Cells[2].Value.ToString(), 0,
                            int.Parse(row.Cells[5].Value.ToString())
                            , double.Parse(row.Cells[6].Value.ToString()), 0.00, row.Cells[8].Value.ToString(), 0, screen_id);
                        }
                    }
                    //  call details
                    try
                    {
                        var max_purch_details_id = mob_sys.purchase_check_details.Max(s => s.ID);
                        var max_purch_id = mob_sys.Purchase_checks.Max(s => s.ID);
                        var id_itemm = mob_sys.Items.Where(s => s.Name == item_name).Select(s => s.ID).SingleOrDefault();
                        mob_sys.ins_purchase_check_detail(max_purch_details_id + 1, id_itemm,
                        int.Parse(row.Cells[5].Value.ToString())
                        , double.Parse(row.Cells[7].Value.ToString()), row.Cells[8].Value.ToString(), max_purch_id);
                    }
                    catch (Exception)
                    {
                        var item_namee = row.Cells[2].Value.ToString();
                        var max_purch_id = mob_sys.Purchase_checks.Max(s => s.ID);
                        var id_itemm = mob_sys.Items.Where(s => s.Name == item_namee).Select(s => s.ID).SingleOrDefault();
                        mob_sys.ins_purchase_check_detail(1, id_itemm,
                        int.Parse(row.Cells[5].Value.ToString())
                        , double.Parse(row.Cells[7].Value.ToString()), row.Cells[8].Value.ToString(), max_purch_id);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (textBox2.Text != "" && textBox10.Text != "" && textBox6.Text != "")
                {
                    if (textBox11.Text != "")
                    {
                        var d = System.DateTime.Now.Date;
                        var subname = textBox10.Text;
                        var sub_comp = textBox2.Text;
                        var diff = float.Parse(textBox11.Text);
                        var egmaly = double.Parse(textBox6.Text);
                        var n = textBox9.Text;
                        
                        try
                        {
                            var maxid = mob_sys.Purchase_checks.Max(s => s.ID);
                            var max = maxid + 1;
                            
                             if (txt_value.Text !="")
                            {
                                var remain = float.Parse(txt_Check_remaining.Text);        
                                var val = float.Parse(txt_value.Text);
                                if (Combo__tax_Discount.SelectedIndex == 0)
                                {
                                    mob_sys.insert_Purchase_check(max, d, subname, sub_comp, Class1.TheID, egmaly, n, diff, val, 0.00, remain);
                                }
                                else 
                                {
                                    mob_sys.insert_Purchase_check(max, d, subname, sub_comp, Class1.TheID, egmaly, n, diff, 0.00, val, remain);
                                }
                            }
                            else
                            {
                                mob_sys.insert_Purchase_check(max, d, subname, sub_comp, Class1.TheID, egmaly, n, diff, 0.00, 0.00, 0.00);
                            }
                            ins_item();
                            label11.Text = "تم عمل الفاتوره";
                            button1.Text = "تم الحفظ";

                            button1.Enabled = false;
                            textBox11.Text = textBox12.Text = textBox6.Text = txt_Check_remaining.Text =txt_value.Text= "";
                            Combo__tax_Discount.ResetText();
                            label22.Text = "";
                            //reset_form();
                            total = 0;
                            i = 0;
                        }
                        catch (Exception)
                        {
                            
                            if (txt_value.Text != "")
                            {
                                var val = float.Parse(txt_value.Text);
                                var remain = float.Parse(txt_Check_remaining.Text);        
                                if (Combo__tax_Discount.SelectedIndex == 0)
                                {
                                    mob_sys.insert_Purchase_check(1, d, subname, sub_comp, Class1.TheID, egmaly, n, diff, val, 0.00, remain);
                                }
                                else
                                {
                                    mob_sys.insert_Purchase_check(1, d, subname, sub_comp, Class1.TheID, egmaly, n, diff, 0.00, val, remain);
                                }
                            }
                            else
                            {
                                mob_sys.insert_Purchase_check(1, d, subname, sub_comp, Class1.TheID, egmaly, n, diff, 0.00, 0.00, 0.00);

                            }
                            ins_item();
                            label11.Text = "تم عمل الفاتوره";
                            button1.Text = "تم الحفظ";
                            button1.Enabled = false;
                            textBox11.Text = textBox12.Text = textBox6.Text = txt_Check_remaining.Text = txt_value.Text = "";

                            textBox11.Enabled = true;
                            label22.Text = "";
                            //reset_form();
                            total = 0;
                            i = 0;
                        }

                    }
                    else label22.Text = "تاكد من المدفوع اولا بطريقه صحيحه";// و ده تانى واحد ظهر 
                }
                else label11.Text = " رجاء ادخل اسم المورد والشركه الموردة و الاصناف ";
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Wait Please");
            //}
        }

        
        int count_grid = 1;
        int w = 1;
        private void additem_to_grid()
        {
            if (comboBox4.SelectedIndex == 0)/////موبايلاااااااااااااااااااااااااااااات
            {
                if (textBox13.Text != "" && textBox15.Text != "" && comboBox5.SelectedIndex != -1 && comboBox6.SelectedIndex != -1&&textBox16.Text!="")
                {
                    if (!ifexist_item(textBox15.Text))
                    {
                        var x = textBox15.Text;
                        var count = int.Parse(textBox16.Text);
                        var comb_id = comboBox5.SelectedIndex + 1;
                        var comb = mob_sys.Producing_companies.Where(s => s.ID == comb_id).Select(s => s.Producing_company1).SingleOrDefault();
                        var type_id = comboBox6.SelectedIndex + 1;
                        var type = mob_sys.Type_items.Where(s => s.ID == type_id).Select(s => s.Type).SingleOrDefault();
                        var pa_price = textBox13.Text;
                        var price = count * int.Parse(pa_price);
                        try
                        {
                            var max_id = mob_sys.Items.Max(s => s.ID);
                            dt.Rows.Add(count_grid, max_id + w, x, type, comb, count, double.Parse(pa_price), double.Parse(price.ToString()), textBox14.Text);
                        }
                        catch (Exception)
                        {
                            dt.Rows.Add(count_grid, w, x, type, comb, count, double.Parse(pa_price), double.Parse(price.ToString()), textBox14.Text);
                        }
                        count_grid++;
                        w++; 
                        dataGridView1.DataSource = dt;
                        textBox15.Text = textBox13.Text = textBox14.Text = textBox13.Text = textBox16.Text = "";
                        sum_total();
                        textBox6.Text = total.ToString();
                    }
                    else
                    {

                    //}
                    
                    //{// هى دى 
                        DialogResult dialogResult = MessageBox.Show("هل تريد التعديل فى الصنف ؟", "Some Title", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            var comb_id = comboBox5.SelectedIndex + 1;
                            var comb = mob_sys.Producing_companies.Where(s => s.ID == comb_id).Select(s => s.Producing_company1).SingleOrDefault();

                            var type_id = comboBox6.SelectedIndex + 1;
                            var type = mob_sys.Type_items.Where(s => s.ID == type_id).Select(s => s.Type).SingleOrDefault();

                            foreach (DataRow item in dt.Rows)
                            {
                                var x = item["اسم الصنف"];
                                if (item["اسم الصنف"].ToString() == textBox15.Text)
                                {
                                    int curR = int.Parse(item["مسلسل"].ToString());
                                    var xx = textBox15.Text;

                                    DataGridViewRow row = dataGridView1.Rows[curR - 1];
                                    var countt = int.Parse(textBox16.Text);
                                    var pa_pricee = textBox13.Text;
                                    var price = countt * int.Parse(pa_pricee);

                                    row.Cells[1].Value = curR;

                                    row.Cells[2].Value = xx;
                                    row.Cells[3].Value = type;
                                    row.Cells[4].Value = comb;
                                    row.Cells[5].Value = countt;
                                    row.Cells[6].Value = pa_pricee.ToString();
                                    row.Cells[7].Value = price.ToString();
                                    row.Cells[8].Value = textBox14.Text;
                                    dataGridView1.DataSource = dt;

                                    textBox15.Text = textBox13.Text = textBox14.Text = textBox13.Text = textBox16.Text = "";
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
                else label11.Text = "تاكد من ادخال كل بيانات الصنف";
            }
            else////اكسسواراااااااااااااااااااااااااااااااااااااااااات
            {
                if (comboBox7.SelectedIndex != -1 && comboBox8.SelectedIndex != -1 && textBox17.Text != "" && textBox16.Text != "")
                {var x = comboBox8.Text;
                     if (!ifexist_item(x))
                    {
                    var count = int.Parse(textBox16.Text);
                    var type = comboBox7.Text;
                   
                    var pa_price = textBox17.Text;
                    var price = count * int.Parse(pa_price);
                    try
                    {
                        var max_id = mob_sys.Items.Max(s => s.ID);
                        dt.Rows.Add(count_grid, max_id + w, x, type, " ", count, double.Parse(pa_price), double.Parse(price.ToString()), textBox14.Text);

                    }
                    catch (Exception)
                    {
                        dt.Rows.Add(count_grid, w, x, type, " ", count, double.Parse(pa_price), double.Parse(price.ToString()),  textBox14.Text);

                    }
                    count_grid++;
                    w++;
                   
                    dataGridView1.DataSource = dt;

                    textBox15.Text = textBox13.Text = textBox14.Text = textBox13.Text = textBox16.Text = textBox17.Text = "";
                    sum_total();
                    textBox6.Text = total.ToString();
                    }
                     else
                     {
                         DialogResult dialogResult = MessageBox.Show("هل تريد التعديل فى الصنف ؟", "Some Title", MessageBoxButtons.YesNo);
                         if (dialogResult == DialogResult.Yes)
                         {
                             foreach (DataRow item in dt.Rows)
                             {
                                 var xx = item["اسم الصنف"];
                                 if (item["اسم الصنف"].ToString() == x)
                                 {
                                     int curR = int.Parse(item["مسلسل"].ToString());
                                     

                                     DataGridViewRow row = dataGridView1.Rows[curR - 1];
                                     var countt = int.Parse(textBox16.Text);
                                     var pa_pricee = textBox17.Text;
                                     var price = countt * int.Parse(pa_pricee);
                                     var type = comboBox8.Text;
                                     row.Cells[1].Value = curR;

                                     row.Cells[2].Value = x;
                                     row.Cells[3].Value = type;
                                     row.Cells[4].Value = " ";
                                     row.Cells[5].Value = countt;
                                     row.Cells[6].Value = pa_pricee.ToString();
                                     row.Cells[7].Value = price.ToString();
                                    
                                     row.Cells[8].Value = textBox14.Text;
                                     dataGridView1.DataSource = dt;

                                     textBox15.Text = textBox13.Text = textBox14.Text = textBox13.Text = textBox16.Text = "";

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
                else label11.Text = "تاكد من ادخال البيانات";
            }
           
        }
        int i = 0;
        float total;
        //int curRow = -1;
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
                    total += int.Parse(p);
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

        
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            login l = new login();
            l.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button1.Text != "حفظ")
            {
                DialogResult dialogResult = MessageBox.Show("هل تريد فتح فاتورة جديدة ؟", "تحذير", MessageBoxButtons.YesNo,MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dialogResult == DialogResult.Yes)
                {
                    button1.Text = "حفظ";
                    button1.Enabled = false;
                    txt_value.Text = "";
                    txt_value.Enabled = false;
                    Combo__tax_Discount.ResetText();
                    Combo__tax_Discount.Enabled = false;
                    txt_Check_remaining.Text = "";
                    txt_Check_remaining.Enabled = false;
                    button2.Enabled = true;
                    textBox13.Enabled = true;
                    textBox13.Text = "";
                    textBox14.Enabled = true;
                    textBox14.Text = "";
                    textBox15.Enabled = true;
                    textBox15.Text = "";
                    textBox16.Enabled = true;
                    textBox16.Text = "";
                    textBox17.Enabled = true;
                    textBox17.Text = "";
                    comboBox4.ResetText();
                    comboBox5.ResetText();
                    comboBox6.ResetText();
                    comboBox7.ResetText();
                    comboBox8.ResetText();
                    
                    textBox11.Text = "";
                    textBox6.Text = "";
                    textBox12.Text = "";
                    textBox13.Text = "";
                    textBox10.Text = "";
                    textBox9.Enabled = true;
                    dt.Clear();
                    dataGridView1.DataSource = "";
                    
                    label11.Text = "فاتورة جديدة";
                    reset_form();// اهى فى الفاتورة جديدة
                    dt.Clear();
                    dataGridView1.Refresh();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else ...
                }
            }
            else if (button1.Text == "حفظ"&& textBox11.Text!="")
            {
                    DialogResult dialogResult = MessageBox.Show("سيؤدى ذلك التصرف لمسح محتويات الفاتورة بالكامل قبل حفظها\n هل ترغب فى المسح و إعادة إنشاء فاتورة أخرى جديدة ؟", "تحذير", MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2);
                    if (dialogResult == DialogResult.Yes)
                    {
                        button1.Enabled = false;
                        button2.Enabled = true;
                        textBox13.Enabled = true;
                        textBox13.Text = "";
                        textBox14.Enabled = true;
                        textBox14.Text = "";
                        textBox15.Enabled = true;
                        textBox15.Text = "";
                        textBox16.Enabled = true;
                        
                        Combo__tax_Discount.Enabled = false;
                        Combo__tax_Discount.ResetText();
                        txt_value.Text = "";
                        txt_value.Enabled = false;
                        txt_Check_remaining.Text = "";
                        txt_Check_remaining.Enabled = false;
                        textBox17.Enabled = true;
                        textBox17.Text = "";
                        comboBox4.ResetText();
                        comboBox5.ResetText();
                        comboBox6.ResetText();
                        textBox16.Text = ""; 
                        comboBox7.ResetText();
                        comboBox8.ResetText();
                        textBox11.Text = "";
                        textBox6.Text = "";
                        textBox12.Text = "";
                        textBox10.Text = "";
                        textBox9.Enabled = true;
                        dt.Clear();
                        dataGridView1.DataSource = "";
                        label8.Text = "فاتورة جديدة";
                        reset_form();// اهى فى الفاتورة جديدة
                        dataGridView1.Refresh();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something    
                    }
            }
            else 
            {
                MessageBox.Show("فاتورة جديدة مفتوحة الآن");
            }
           // reset_form();
            total = 0;
            i = 0;
        }

        

        private void button7_Click_1(object sender, EventArgs e)
        {
            additem_company add_i_comp = new additem_company();
            add_i_comp.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            additem_company add_i_comp = new additem_company();
            add_i_comp.ShowDialog();
        }

      

        

        

        

        private void textBox11_TextChanged_1(object sender, EventArgs e)
        {
            txt_value.Enabled = false;
            Combo__tax_Discount.Enabled = false;
            txt_Check_remaining.Enabled = false;
            try
            {
                if (txt_Check_remaining.Text != "")
                {
                    if (textBox11.Text != "")
                    {
                        var current = float.Parse(textBox11.Text);
                        var total = float.Parse(txt_Check_remaining.Text);
                        if (current <= total)
                        {
                            var remain = total - current;
                            textBox12.Text = remain.ToString();
                            label22.Text = "";
                            button1.Enabled = true;
                        }
                        else
                        {
                            label22.Text = "قيمه المدفوع اكبر من الاجمالى";
                            button1.Enabled = false;
                        }
                    }
                }
                else if (txt_Check_remaining.Text == "")
                {
                    if (textBox11.Text != "")
                    {
                        var current = float.Parse(textBox11.Text);
                        var total = float.Parse(textBox6.Text);
                        if (current <= total)
                        {
                            var remain = total - current;
                            textBox12.Text = remain.ToString();
                            label22.Text = "";
                            button1.Enabled = true;
                        }
                        else
                        {
                            label22.Text = "قيمه المدفوع اكبر من الاجمالى";
                            button1.Enabled = false;
                        }
                    }
                }

            }
            catch (Exception)
            {

                label22.Text = "لاحظ ! أدخل المبلغ المدفوع بشكل رقمى فقط";
                button1.Enabled = false;
            }
        
        }

        

        private void فاتورةToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Search_Check sc = new Search_Check();
            sc.ShowDialog();
        }

        private void lمشترياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report_day_purch r_p=new report_day_purch();
            r_p.ShowDialog();
        }

        private void مبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report_day_sale r_s = new report_day_sale();
            r_s.ShowDialog();

        }

        private void مرتجعاتToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button1.Text == "حفظ")
            {
                //printPreviewDialog1.ShowDialog();
                //i_print = 0;
                label11.Text = "إحفظ الفاتورة";
            }
            else if (button1.Text == "تم الحفظ")
            {
                //printPreviewDialog1.ShowDialog();
                //i_print = 0;
                Class1.Purch_id = mob_sys.Purchase_checks.Max(s => s.ID);
                view_purch_report_byID v = new view_purch_report_byID();
                v.Show();
            }
            //printPreviewDialog1.ShowDialog();
            //i_print = 0;
        }
        
        //int i_print = 0;

        //private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    int height = 0;
        //    //int width = 0;


        //    Pen p = new Pen(Brushes.Black, 2.5f);

        //    #region numbering
        //    e.Graphics.FillRectangle(Brushes.Silver, new Rectangle(60, 250, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
        //    e.Graphics.DrawRectangle(p, new Rectangle(60, 250, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
        //    e.Graphics.DrawString(dataGridView1.Columns[0].HeaderText.ToString(), dataGridView1.Font, Brushes.Black, new Rectangle(60, 250, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
        //    #endregion

        //    #region Item Name

        //    e.Graphics.FillRectangle(Brushes.Silver, new Rectangle(60 + dataGridView1.Columns[0].Width, 250, dataGridView1.Columns[0].Width + 200, dataGridView1.Rows[0].Height));
        //    e.Graphics.DrawRectangle(p, new Rectangle(60 + dataGridView1.Columns[0].Width, 250, dataGridView1.Columns[0].Width+200, dataGridView1.Rows[0].Height));
        //    e.Graphics.DrawString(dataGridView1.Columns[2].HeaderText.ToString(), dataGridView1.Font, Brushes.Black, new Rectangle(60 + dataGridView1.Columns[0].Width, 250, dataGridView1.Columns[0].Width+200, dataGridView1.Rows[0].Height));

        //    #endregion

        //    #region Quantity

        //    e.Graphics.FillRectangle(Brushes.Silver, new Rectangle(360 + dataGridView1.Columns[0].Width, 250, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
        //    e.Graphics.DrawRectangle(p, new Rectangle(360 + dataGridView1.Columns[0].Width, 250, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
        //    e.Graphics.DrawString(dataGridView1.Columns[3].HeaderText.ToString(), dataGridView1.Font, Brushes.Black, new Rectangle(360 + dataGridView1.Columns[0].Width, 250, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));

        //    #endregion

        //    #region Price

        //    e.Graphics.FillRectangle(Brushes.Silver, new Rectangle(460 + dataGridView1.Columns[0].Width, 250, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
        //    e.Graphics.DrawRectangle(p, new Rectangle(460 + dataGridView1.Columns[0].Width, 250, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
        //    e.Graphics.DrawString(dataGridView1.Columns[4].HeaderText.ToString(), dataGridView1.Font, Brushes.Black, new Rectangle(460 + dataGridView1.Columns[0].Width, 250, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));

        //    #endregion

        //    #region Total

        //    e.Graphics.FillRectangle(Brushes.Silver, new Rectangle(560 + dataGridView1.Columns[0].Width, 250, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
        //    e.Graphics.DrawRectangle(p, new Rectangle(560 + dataGridView1.Columns[0].Width, 250, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
        //    e.Graphics.DrawString(dataGridView1.Columns[5].HeaderText.ToString(), dataGridView1.Font, Brushes.Black, new Rectangle(560 + dataGridView1.Columns[0].Width, 250, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));

        //    #endregion
        //    height = 250;

        //    while (i_print < dataGridView1.Rows.Count)
        //    {

        //        if (height > e.MarginBounds.Height)
        //        {
        //            height = 250;
        //            e.HasMorePages = true;
        //            return;
        //        }
        //        height += dataGridView1.Rows[0].Height;


        //        //Column 0
        //        e.Graphics.DrawRectangle(p, new Rectangle(60, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
        //        e.Graphics.DrawString(dataGridView1.Rows[i_print].Cells[0].FormattedValue.ToString(), dataGridView1.Font, Brushes.Black, new Rectangle(65, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
        //        //Column 2
        //        e.Graphics.DrawRectangle(p, new Rectangle(60 + dataGridView1.Columns[0].Width, height, dataGridView1.Columns[0].Width+200, dataGridView1.Rows[0].Height));
        //        e.Graphics.DrawString(dataGridView1.Rows[i_print].Cells[2].FormattedValue.ToString(), dataGridView1.Font, Brushes.Black, new Rectangle(165, height, dataGridView1.Columns[0].Width+200, dataGridView1.Rows[0].Height));
        //        //Column 3
        //        e.Graphics.DrawRectangle(p, new Rectangle(360 + dataGridView1.Columns[0].Width, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
        //        e.Graphics.DrawString(dataGridView1.Rows[i_print].Cells[3].FormattedValue.ToString(), dataGridView1.Font, Brushes.Black, new Rectangle(465, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
        //        //Column 4
        //        e.Graphics.DrawRectangle(p, new Rectangle(460 + dataGridView1.Columns[0].Width, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
        //        e.Graphics.DrawString(dataGridView1.Rows[i_print].Cells[4].FormattedValue.ToString(), dataGridView1.Font, Brushes.Black, new Rectangle(565, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
        //        //Column 5
        //        e.Graphics.DrawRectangle(p, new Rectangle(560 + dataGridView1.Columns[0].Width, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
        //        e.Graphics.DrawString(dataGridView1.Rows[i_print].Cells[5].FormattedValue.ToString(), dataGridView1.Font, Brushes.Black, new Rectangle(665, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));

        //        i_print++;

        //    }


        //    // Titles & Margins 

        //    Graphics graphics = e.Graphics;

        //    Font font = new Font("Courier New", 12);

        //    float fontHeight = font.GetHeight();
        //    int store_X = 65;
        //    int store_Y = 40;

        //    int Mall_X = 200;
        //    int Mall_Y = 90;
        //    int Type_of_receipt_X = 280;
        //    int Type_of_receipt_Y = 135;
        //    int details_border_start_X= 60;
        //    int details_border_start_Y=170;
        //    int details_border_End_X=700;
        //    int details_border_End_Y=40;
        //    int date_X=250;
        //    int date_Y=180;
        //    int Date_result_X=68;
        //    int Date_result_Y=180;
        //    int Reciept_X = 690;
        //    int Reciept_Y = 180;
        //    int Reciept_Result_X = 590;
        //    int Reciept_Result_Y = 180;
        //    int Casheir_name_X = 460;
        //    int Casheir_name_Y = 180;
        //    int casheir_Result_X = 360;
        //    int casheir_Result_Y = 180; 
        //    int address_X = 90;
        //    int address_Y = 1100;
        //    int total_title_X = 490;
        //    int total_title_Y = 850;
        //    int total_title_Result_X = 340;
        //    int total_title_Result_Y = 850;
        //    int Paid_title_X = 490;
        //    int Paid_title_Y = 900;
        //    int Paid_title_Result_X = 340;
        //    int Paid_title_Result_Y = 900;
        //    int Wait_title_X = 490;
        //    int Wait_title_Y =  950;
        //    int Wait_title_Result_X = 340;
        //    int Wait_title_Result_Y = 950;
        //    int Paid_Wait_Total_Border_Start_X = 335;
        //    int Paid_Wait_Total_Border_Start_Y = 840;
        //    int Paid_Wait_Total_Border_End_X = 200;
        //    int Paid_Wait_Total_Border_End_Y = 155;
            
        //    // line border
        //    Point[] points = { new Point(335,  885),new Point(535, 885) };
        //    Point[] points2 = { new Point(335, 930), new Point(535, 930) };
        //    //int offset = 40;
        //    graphics.DrawString("3 G for Mobile Services", new Font("Courier New", 34,FontStyle.Bold), new SolidBrush(Color.Black), store_X, store_Y);

        //    graphics.DrawString("Mazaya Mall accounting System", new Font("Courier New", 18), new SolidBrush(Color.Black), Mall_X, Mall_Y);
        //    graphics.DrawString("فاتورة إستلام بضاعة", new Font("Courier New", 15), new SolidBrush(Color.Black), Type_of_receipt_X, Type_of_receipt_Y);
        //    graphics.DrawString("تاريخ", new Font("Arial", 11, FontStyle.Bold), new SolidBrush(Color.Black), date_X, date_Y);
        //    graphics.DrawString("رقم الفاتورة", new Font("Arial", 11, FontStyle.Bold), new SolidBrush(Color.Black), Reciept_X, Reciept_Y);
        //    graphics.DrawString("كاشير", new Font("Arial", 11, FontStyle.Bold), new SolidBrush(Color.Black), Casheir_name_X, Casheir_name_Y);
        //    graphics.DrawString("العنوان : العريش ، وسط البلد ، شارع 23 يوليو ، مزايا مول ، الدور الثانى                              موبايل رقم : 01يبسيبيببي ", new Font("Arial", 11,FontStyle.Bold), new SolidBrush(Color.Black), address_X, address_Y);

        //    e.Graphics.DrawRectangle(p, new Rectangle(details_border_start_X, details_border_start_Y, details_border_End_X, details_border_End_Y));
        //    //Date
        //    e.Graphics.DrawString(textBox3.Text, new Font("Arial", 11, FontStyle.Bold), Brushes.Black, Date_result_X, Date_result_Y);
        //    //Casheir name
        //    e.Graphics.DrawString(textBox4.Text, new Font("Arial", 11, FontStyle.Bold), Brushes.Black, casheir_Result_X, casheir_Result_Y);
        //    //Receipt Number
        //    e.Graphics.DrawString(textBox1.Text, new Font("Arial", 11, FontStyle.Bold), Brushes.Black, Reciept_Result_X, Reciept_Result_Y);
        //    //receipt
        //    e.Graphics.DrawString("الإذن", new Font("Arial", 11, FontStyle.Bold), new SolidBrush(Color.Black), total_title_X, total_title_Y);
        //    e.Graphics.DrawString(textBox6.Text, new Font("Arial", 11, FontStyle.Bold), Brushes.Black, total_title_Result_X, total_title_Result_Y);
        //    //paid
        //    e.Graphics.DrawString("مدفوع", new Font("Arial", 11, FontStyle.Bold), new SolidBrush(Color.Black), Paid_title_X, Paid_title_Y);
        //    e.Graphics.DrawString(textBox11.Text, new Font("Arial", 11, FontStyle.Bold), Brushes.Black, Paid_title_Result_X, Paid_title_Result_Y);
        //    //wait
        //    e.Graphics.DrawString("باقى", new Font("Arial", 11, FontStyle.Bold), new SolidBrush(Color.Black), Wait_title_X, Wait_title_Y);
        //    e.Graphics.DrawString(textBox12.Text, new Font("Arial", 11, FontStyle.Bold), Brushes.Black, Wait_title_Result_X, Wait_title_Result_Y);
        //    // Total,Paid,Wait Border
        //    e.Graphics.DrawRectangle(p, new Rectangle(Paid_Wait_Total_Border_Start_X,Paid_Wait_Total_Border_Start_Y,Paid_Wait_Total_Border_End_X,Paid_Wait_Total_Border_End_Y));
        //    e.Graphics.DrawLines(p, points);
        //    e.Graphics.DrawLines(p, points2);
        //}

        

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {//mob
            if (comboBox4.SelectedIndex==0)
            {
                groupBox3.Enabled = true;
                groupBox4.Enabled = false;
                textBox15.Text = "";
                textBox13.Text = "";
                textBox16.Text = "";
                comboBox5.ResetText();
                comboBox6.ResetText();
                textBox15.Focus();

           
            }//accessories
            else if (comboBox4.SelectedIndex==1)
            {
                groupBox3.Enabled = false; ;
                groupBox4.Enabled = true;
                textBox17.Text = "";
                textBox16.Text = "";
                comboBox7.ResetText();
                comboBox8.ResetText();
                textBox17.Focus();

            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.SelectedIndex==0)
            {
                
                var combo_8_Accessories_Types_Screen = mob_sys.Accessories_Types_2s.Where(s => s.Screen_Title_ID == comboBox7.SelectedIndex + 1).Select(s => s.Accessories_types);
                comboBox8.Items.Clear();
                foreach (var item in combo_8_Accessories_Types_Screen)
                {
                    
                    comboBox8.Items.Add(item);
                }
            }
            else if (comboBox7.SelectedIndex == 1)
            {
                var combo_8_Accessories_Types_grab = mob_sys.Accessories_Types_2s.Where(s => s.Screen_Title_ID == comboBox7.SelectedIndex + 1).Select(s => s.Accessories_types);
                comboBox8.Items.Clear();
                foreach (var item in combo_8_Accessories_Types_grab)
                {
                    
                    comboBox8.Items.Add(item);
                }
            }
            else if (comboBox7.SelectedIndex == 2)
            {
                var combo_8_Accessories_Types_power = mob_sys.Accessories_Types_2s.Where(s => s.Screen_Title_ID == comboBox7.SelectedIndex + 1).Select(s => s.Accessories_types);
                comboBox8.Items.Clear();
                foreach (var item in combo_8_Accessories_Types_power)
                {

                    comboBox8.Items.Add(item);
                }
            }
            else if (comboBox7.SelectedIndex == 3)
            {
                var combo_8_Accessories_Types_Samsung_power = mob_sys.Accessories_Types_2s.Where(s => s.Screen_Title_ID == comboBox7.SelectedIndex + 1).Select(s => s.Accessories_types);
                comboBox8.Items.Clear();
                foreach (var item in combo_8_Accessories_Types_Samsung_power)
                {

                    comboBox8.Items.Add(item);
                }
            }
            else if (comboBox7.SelectedIndex == 4)
            {
                var combo_8_Accessories_Types_hand_free = mob_sys.Accessories_Types_2s.Where(s => s.Screen_Title_ID == comboBox7.SelectedIndex + 1).Select(s => s.Accessories_types);
                comboBox8.Items.Clear();
                foreach (var item in combo_8_Accessories_Types_hand_free)
                {

                    comboBox8.Items.Add(item);
                }
            }
            else if (comboBox7.SelectedIndex == 5)
            {
                var combo_8_Accessories_Types_battrey = mob_sys.Accessories_Types_2s.Where(s => s.Screen_Title_ID == comboBox7.SelectedIndex + 1).Select(s => s.Accessories_types);
                comboBox8.Items.Clear();
                foreach (var item in combo_8_Accessories_Types_battrey)
                {

                    comboBox8.Items.Add(item);
                }
            }
            else if (comboBox7.SelectedIndex == 6)
            {
                var combo_8_Accessories_Types_reader = mob_sys.Accessories_Types_2s.Where(s => s.Screen_Title_ID == comboBox7.SelectedIndex + 1).Select(s => s.Accessories_types);
                comboBox8.Items.Clear();
                foreach (var item in combo_8_Accessories_Types_reader)
                {

                    comboBox8.Items.Add(item);
                }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox11.Enabled = true;
            txt_Check_remaining.Enabled = true;
            txt_value.Enabled = true;
            Combo__tax_Discount.Enabled = true;

        }

        

        private void Combo__tax_Discount_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                       /// total += total_costt;
                         t += total_costt;
                      
                        //label2.Text = total.ToString();
                        txt_Check_remaining.Text = t.ToString();
                        //            txt_value.Text = "";
                    }
                    else if (txt_value.Text != "" && Combo__tax_Discount.SelectedIndex == 0)
                    {
                        disc_val = float.Parse(taxvalll);
                        total_costt = (total_costt * float.Parse(taxvalll)) / 100;
                       // total -= total_costt;
                        t -= total_costt;

                        txt_Check_remaining.Text = t.ToString();
                        //label2.Text = total.ToString();
                        //txt_value.Text = "";
                    }
                    textBox11.Focus();
                }
                else MessageBox.Show("تاكد من ادخال اصناف للفاتوره");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (button1.Text == "حفظ")
                {
                    additem_to_grid();
                    textBox15.Text = textBox13.Text = textBox14.Text = label11.Text = "";
                    comboBox5.ResetText();
                    comboBox6.ResetText();
                    comboBox7.ResetText();
                    comboBox8.ResetText();
                    textBox6.Text = total.ToString();
                }
                else if(button1.Text=="تم الحفظ")
                {
                    button2.Enabled = false;
                }
                
            }
            catch (Exception)
            {
                label11.Text = "تاكد من السعر والكميه بطريقه صحيحه ";
            }
            if (textBox6.Text=="0")
            {
                label11.Text = "أعد إدخال بياناتك مرة ثانية";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txt_value.Text = "";
            txt_Check_remaining.Text = "";
            //Combo__tax_Discount.Enabled = true;
            Combo__tax_Discount.ResetText();
            
            txt_value.Enabled = true;
            txt_Check_remaining.Enabled = true;
            textBox11.Text = textBox12.Text = "";
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==(char)13)
            {
                 button2_Click(null, null);
                 textBox16.Focus();
            }
        }

        private void Home_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                textBox10.Focus();
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                comboBox4.Focus();
            }
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                textBox13.Focus();
            }
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                comboBox5.Focus();
            }
        }

        private void comboBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                comboBox6.Focus();
            }
        }

        private void comboBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                textBox16.Focus();
            }
        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                comboBox7.Focus();
            }
        }

        private void comboBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                comboBox8.Focus();
            }
        }

        private void comboBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                textBox16.Focus();
            }
        }

        private void شهريةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            search_Period sp = new search_Period();
            sp.ShowDialog();
        }

        

        private void اضافةشركةمصنعةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            additem_company addi_comp = new additem_company();
            addi_comp.ShowDialog();
        }

        private void اضافةنوعجهازجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            additem_company addi_comp = new additem_company();
            addi_comp.ShowDialog();
        }

        private void سدادأقساطالعملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updatediff up_fiff = new updatediff();
            up_fiff.ShowDialog();
        }

        private void سدادأقساطالموردينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            suppliers_payment spa = new suppliers_payment();
            spa.ShowDialog();
        }

        

        private void شراءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            used u = new used();
            u.ShowDialog();
        }

        private void إضافةمستخدمينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Register r = new Register();
            r.ShowDialog();
        }

        private void بيعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Used_Sale us = new Used_Sale();
            us.ShowDialog();
        }

        private void مرتجعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void منتجToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Used_Query_Item Query_Ite = new Used_Query_Item();
            Query_Ite.ShowDialog();
        }

        private void فاتورةToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Used_Search_Check sc = new Used_Search_Check();
            sc.ShowDialog();
        }

        private void backupYourDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                blc_mallU b = new blc_mallU();
                b.Implement_Backup();
                MessageBox.Show("A new version of your data is successfully saved");
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to Backup your Data");
            }
        }

        private void منتجمستعملToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class1.Click_edititem = 0;
            Used_EditItem edit_item = new Used_EditItem();
            edit_item.ShowDialog();
        }

        private void إجمالىToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void مشترياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Used_report_day_purch r_p = new Used_report_day_purch();
            r_p.ShowDialog();
        }

        private void مبيعاتToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Used_report_day_sale r_s = new Used_report_day_sale();
            r_s.ShowDialog();
        }

        private void مردوداتمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Used_report_day_return r_r = new Used_report_day_return();
            r_r.ShowDialog();
        }

        private void قسطعميلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Used_updatediff up_fiff = new Used_updatediff();
            up_fiff.ShowDialog();
        }

        private void قسطموردToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Used_suppliers_payment spa = new Used_suppliers_payment();
            spa.ShowDialog();
        }

        private void مردوداتمشترياتToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void مرتجعبيعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Returns r = new Returns();
            r.ShowDialog();
        }

        private void مرتجعبيعToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Used_Returns ur = new Used_Returns();
            ur.ShowDialog();
        }

        private void مرتجعشراءToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void مردوداتمشترياتToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            report_day_return r_r = new report_day_return();
            r_r.ShowDialog();
        }

        private void مرتجعشراءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purshase_Return P_R = new Purshase_Return();
            P_R.ShowDialog();
        }

        private void سدادقسطمرجعمباعلعميلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updatediff_for_client u_d_for_Client = new updatediff_for_client();
            u_d_for_Client.ShowDialog();
        }

        private void قسطمرجعمباعلعميلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updatediff_for_client_Used u_d_for_Client_Used = new updatediff_for_client_Used();
            u_d_for_Client_Used.ShowDialog();
        }
    }
}


