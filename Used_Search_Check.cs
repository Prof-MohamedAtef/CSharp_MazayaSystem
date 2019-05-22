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
    public partial class Used_Search_Check : Form
    {
        DataClasses1DataContext mob_sys = new DataClasses1DataContext();

        public Used_Search_Check()
        {
            InitializeComponent();
        }
        

        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();

        private void Used_Search_Check_Load(object sender, EventArgs e)
        {
           
            ///declare dt1
            dt1.Columns.Add("مسلسل", typeof(int));
            dt1.Columns.Add("رقم الفاتورة", typeof(int));
            dt1.Columns.Add("اسم المشترى", typeof(string));
            dt1.Columns.Add("اسم الكاشير", typeof(string));
            dt1.Columns.Add("الاجمالى ", typeof(float));
            dt1.Columns.Add("ملاحظات", typeof(string));
            ///dt2
            dt2.Columns.Add("مسلسل", typeof(int));
            dt2.Columns.Add("رقم الفاتورة", typeof(int));
            dt2.Columns.Add(" المورد", typeof(string));
            dt2.Columns.Add("شركه التوريد", typeof(string));
            dt2.Columns.Add("اسم الكاشير", typeof(string));
            dt2.Columns.Add("الاجمالى ", typeof(float));
            dt2.Columns.Add("ملاحظات", typeof(string));
            ///dt3
            dt3.Columns.Add("مسلسل", typeof(int));
            dt3.Columns.Add("رقم الصنف", typeof(int));
            dt3.Columns.Add("اسم الصنف", typeof(string));
            dt3.Columns.Add("الشركه المصنعه", typeof(string));
            dt3.Columns.Add("النوع", typeof(string));
            dt3.Columns.Add("العدد", typeof(int));
            dt3.Columns.Add("الاجمالى", typeof(float));
            dt3.Columns.Add("ملاحظات", typeof(string));

            setbuttons(false);
            
          
        }
        public void setbuttons(bool x) {
            first_check.Enabled = x;
            button1.Enabled = x;
            next_btn.Enabled = x;
            button3.Enabled = x;
        
        }
        private void txt_code_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)13)
            {
                total = total2 = 0;
                i = i2 = 0;
                label15.Text = label17.Text = "";

                Search_btn_Click(null, null);
            }
        }
        int count = 1;
        //--------
        int i = 0;
        float total;
        //int curRow = -1;
        private float sum_total_sales()
        {
            //sale_grid.DataSource = "";
            var rows_count = sale_grid.RowCount-1;
            do
            {
                if (i <= rows_count)                           
                {
                    DataGridViewRow row = sale_grid.Rows[i];
                    //var x = row.Index;
                    var p = row.Cells[4].Value.ToString();
                    total += float.Parse(p);
                    i++;
                }
            } while (i < rows_count);
            return total;
        }
        //----------------
        int i2 = 0;
        float total2;
        //int curRow = -1;
        private float sum_total_purchase()
        {
            //Purchase_grid.DataSource = "";
            var rows_count2 = Purchase_grid.RowCount-1;
            do
            {
                if (i2 <= rows_count2 )
                {
                    DataGridViewRow row2 = Purchase_grid.Rows[i2];
                    //var x = row.Index;
                    var p2 = row2.Cells[5].Value.ToString();
                    total2 += float.Parse(p2);
                    i2++;
                }
            } while (i2 < rows_count2);
            return total2;
        }
        //----------------
        private void Search_btn_Click(object sender, EventArgs e)
        {
            //sale_grid.DataSource = "";
            //Purchase_grid.DataSource = "";
            if (radio_date.Checked)
            {
                
                    dt1.Rows.Clear();
                    dt2.Rows.Clear();
                    var date_picker = dateTimePicker1.Value.Date;
                        var prev = mob_sys.Used_Sale_Checks.Where(s => s.Sale_date == date_picker).Select(s => new
                        {
                            s.ID,
                            s.Notes,
                            s.Sale_to,
                            s.Seller_id,
                            s.Total_Price
                        }).ToList();
                        count = 1;
                        if (prev.Count !=0)
                        {
                            foreach (var item in prev)
                            {

                                var casheirName = mob_sys.login_Tbls.Where(s => s.ID == item.Seller_id).Select(s => s.UserName).SingleOrDefault();
                                dt1.Rows.Add(count, item.ID, item.Sale_to, casheirName, item.Total_Price, item.Notes);
                                sale_grid.DataSource = dt1;
                                count++;
                                sale_message.Text = label4.Text = " ";
                                label15.Text = sum_total_sales().ToString();  
                            }   
                        }
                        else sale_message.Text = "لا يوجد فواتير بيع فى هذا اليوم";
                               //---------------purshace grid
                        var pursh_prev = mob_sys.Used_Purchase_checks.Where(s => s.Recieve_date == date_picker).Select(s => new
                        {
                            s.ID,
                            s.Notes,
                            s.Supplier_Name,
                            s.Company,
                            s.Cashier_id,
                            s.Total_Price
                        }).ToList();
                        count = 1;
                        if (pursh_prev.Count!=0)
                        {
                            foreach (var item in pursh_prev)
                            {
                                var casheirName = mob_sys.login_Tbls.Where(s => s.ID == item.Cashier_id).Select(s => s.UserName).SingleOrDefault();
                                dt2.Rows.Add(count, item.ID, item.Supplier_Name, item.Company, casheirName, item.Total_Price, item.Notes);
                                Purchase_grid.DataSource = dt2;
                                count++;
                                pursh_message.Text =label4.Text= " ";
                                label17.Text = sum_total_purchase().ToString();

                            }
                        }
                        else pursh_message.Text = "لا يوجد فواتير ف هذا اليوم";
                    
               
            }////end date search

                //start code search
            else if (radio_id.Checked)
            {
                try
                {
                    dt1.Rows.Clear();
                    dt2.Rows.Clear();
                    var ch_id = int.Parse(txt_code_search.Text);
                    try
                    {
                        var prev = mob_sys.Used_Sale_Checks.Where(s => s.ID == ch_id).Select(s => new
                        {
                            s.ID,
                            s.Notes,
                            s.Sale_to,
                            s.Seller_id,
                            s.Total_Price
                        }).ToList();
                        count = 1;
                        foreach (var item in prev)
                        {
                            var casheirName = mob_sys.login_Tbls.Where(s => s.ID == item.Seller_id).Select(s => s.UserName).SingleOrDefault();
                            dt1.Rows.Add(count, item.ID, item.Sale_to, casheirName, item.Total_Price, item.Notes);
                            sale_grid.DataSource = dt1;
                            count++;
                            sale_message.Text = label4.Text = " ";
                            label15.Text = sum_total_sales().ToString();
                            
                        }
                    }
                    catch (Exception) { sale_message.Text = "لا يوجد فواتير بهذا الكود"; }
                    //---------------purshace grid
                    try
                    {
                        var pursh_prev = mob_sys.Used_Purchase_checks.Where(s => s.ID == ch_id).Select(s => new
                        {
                            s.ID,
                            s.Notes,
                            s.Supplier_Name,
                            s.Company,
                            s.Cashier_id,
                            s.Total_Price
                        }).ToList();
                        count = 1;
                        foreach (var item in pursh_prev)
                        {
                            var casheirName = mob_sys.login_Tbls.Where(s => s.ID == item.Cashier_id).Select(s => s.UserName).SingleOrDefault();
                            dt2.Rows.Add(count, item.ID, item.Supplier_Name, item.Company, casheirName, item.Total_Price, item.Notes);
                            Purchase_grid.DataSource = dt2;
                            count++;
                            pursh_message.Text =label4.Text= " ";
                           
                            label17.Text = sum_total_purchase().ToString();
                            
                            
                        }
                    }
                    catch (Exception) { pursh_message.Text = "لا يوجد فواتير بهذا الكود"; }


                }
                catch (Exception) { label4.Text = "رجاء اكتب رقم الفاتورة"; }
            }
            
        }
        int c = 1;
        bool grid ;
        public void load_sale_grid_details( int i) {
            c = 1;
            dt3.Clear();
            var sale_details = mob_sys.Used_Sale_Check_details.Where(s => s.Sale_check_id == i).Select(s => new
            {
               s.Count,
               s.Item_ID,
               s.Notes,
               s.Price,
            }).ToList();
            foreach (var item in sale_details)
            {
                var item_name = mob_sys.Used_Items.Where(s => s.ID == item.Item_ID).Select(s => s.Name).SingleOrDefault();
                var comp_type_id = mob_sys.Used_Items.Where(s => s.ID == item.Item_ID).Select(s => new { s.Producing_Company_id, s.Type }).SingleOrDefault();
                var comp_name = mob_sys.Producing_companies.Where(s => s.ID == comp_type_id.Producing_Company_id).Select(s => s.Producing_company1).SingleOrDefault();
                var type_name = mob_sys.Type_items.Where(s => s.ID == comp_type_id.Type).Select(s => s.Type).SingleOrDefault();
                
                dt3.Rows.Add(c, item.Item_ID, item_name, comp_name, type_name, item.Count,item.Price, item.Notes);
                details_grid.DataSource = dt3;
                c++;

               
            }
        
            int curRow = sale_grid.CurrentRow.Index;
           DataGridViewRow row =sale_grid.Rows[curRow];
           var check_id = int.Parse(row.Cells[1].Value.ToString());
           check_id_lbl.Text = check_id.ToString();

           date_lbl.Text = dateTimePicker1.Value.Date.ToString();

           label7.Text = "المشترى";
           label11.Text = row.Cells[2].Value.ToString();

           cashername_lbl.Text = row.Cells[3].Value.ToString();
           total_price_lbl.Text = row.Cells[4].Value.ToString();
           note_lbl.Text = row.Cells[5].Value.ToString();

        }
        int selectedrow = 0;
        private void sale_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            grid = false;
            try
            {
                int curRow = sale_grid.CurrentRow.Index;
                DataGridViewRow row = sale_grid.Rows[curRow];
                var check_id = int.Parse(row.Cells[1].Value.ToString());
                lbl_check_id.Text = check_id.ToString();
                load_sale_grid_details(check_id);
                selectedrow = int.Parse(row.Cells[0].Value.ToString());
                setbuttons(true);
            }
            catch (Exception) { lbl_check_id.Text = "لايوجد فواتير"; }
        }
        public void load_purchase_grid_details(int i)
        {
            
            c = 1;
            dt3.Clear();
            var pursh_details = mob_sys.Used_Purchase_Check_details.Where(s => s.purchase_check_id == i).Select(s => new
            {
                s.Count,
                s.Item_ID,
                s.Notes,
                s.Price,
            }).ToList();
            foreach (var item in pursh_details)
            {
                var item_name = mob_sys.Used_Items.Where(s => s.ID == item.Item_ID).Select(s => s.Name).SingleOrDefault();
                var comp_type_id = mob_sys.Used_Items.Where(s => s.ID == item.Item_ID).Select(s => new { s.Producing_Company_id, s.Type }).SingleOrDefault();
                var comp_name = mob_sys.Producing_companies.Where(s => s.ID == comp_type_id.Producing_Company_id).Select(s => s.Producing_company1).SingleOrDefault();
                var type_name = mob_sys.Type_items.Where(s => s.ID == comp_type_id.Type).Select(s => s.Type).SingleOrDefault();

                dt3.Rows.Add(c, item.Item_ID, item_name, comp_name, type_name, item.Count, item.Price, item.Notes);
                details_grid.DataSource = dt3;
                c++;
            }
            
            int curRow = Purchase_grid.CurrentRow.Index;
            DataGridViewRow row = Purchase_grid.Rows[curRow];
            var check_id = int.Parse(row.Cells[1].Value.ToString());
            check_id_lbl.Text = check_id.ToString();

            date_lbl.Text = dateTimePicker1.Value.Date.ToString();

            label7.Text = "المورد";
            label11.Text = row.Cells[2].Value.ToString();

            cashername_lbl.Text = row.Cells[4].Value.ToString();
            total_price_lbl.Text = row.Cells[5].Value.ToString();
            note_lbl.Text = row.Cells[6].Value.ToString();
            label13.Text = "الشركه المورده";
            label12.Text = row.Cells[3].Value.ToString();
        }

        private void Purchase_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            grid = true;
            dt3.Clear();
            try
            {
                int curRow = Purchase_grid.CurrentRow.Index;

                DataGridViewRow row = Purchase_grid.Rows[curRow];
                var check_id = int.Parse(row.Cells[1].Value.ToString());
                lbl_check_id.Text = check_id.ToString();

                load_purchase_grid_details(check_id);
                selectedrow = int.Parse(row.Cells[0].Value.ToString());
                setbuttons(true);

            }
            catch (Exception) { lbl_check_id.Text = "لايوجد فواتير"; }
        }

        

        private void radio_date_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = true;
            txt_code_search.Enabled = false;
            label4.Text = "";
            dt1.Rows.Clear();
            dt2.Rows.Clear();
            sale_grid.DataSource = "";
            Purchase_grid.DataSource = "";
        }

        private void radio_id_CheckedChanged(object sender, EventArgs e)
        {
            label15.Text = "";
            label17.Text = "";
            txt_code_search.Enabled = true;
            dateTimePicker1.Enabled = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //dt1.Rows.Clear();
            //dt2.Rows.Clear();
            //sale_grid.DataSource = "";
            //Purchase_grid.DataSource = "";
            total = 0;
            total2 = 0;
            //ألتانى ده بتاع الشراء ( مخزن تجميع فواتير الشراء ) كملى يا روح قلبى ♥ ♥ 
            i = 0;
            i2 = 0;
            label15.Text = label17.Text = "";
                
            Search_btn_Click(null,null);
            //sum_total_purchase();
            //sum_total_sales();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            used h = new used();
            h.ShowDialog();
        }

        private void first_check_Click_1(object sender, EventArgs e)
        {
            dt3.Clear();
            if (grid)
            {
                if (Purchase_grid.RowCount > 0)
                {
                    int ii = 0;
                    DataGridViewRow row = Purchase_grid.Rows[ii];
                    var cel1 = row.Cells[1].Value.ToString();
                    lbl_check_id.Text = cel1.ToString();
                    load_purchase_grid_details(int.Parse(cel1));
                }

            }
            else
            {
                if (sale_grid.RowCount > 0)
                {
                    int ii = 0;
                    DataGridViewRow row = sale_grid.Rows[ii];
                    var cel1 = row.Cells[1].Value.ToString();
                    lbl_check_id.Text = cel1.ToString();
                    load_sale_grid_details(int.Parse(cel1));
                }

            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            dt3.Clear();
            if (grid)
            {
                //purshace
                if (Purchase_grid.RowCount != -1)
                {
                    selectedrow -= 1;
                    if (selectedrow == 0)
                    {

                        DataGridViewRow row = Purchase_grid.Rows[selectedrow];

                        var cel1 = int.Parse(row.Cells[1].Value.ToString());
                        load_purchase_grid_details(cel1);
                        lbl_check_id.Text = cel1.ToString();
                        selectedrow = Purchase_grid.RowCount;
                    }
                    else if (selectedrow == -1)
                    {
                        selectedrow = Purchase_grid.RowCount;
                        DataGridViewRow row = Purchase_grid.Rows[selectedrow];

                        var cel1 = int.Parse(row.Cells[1].Value.ToString());
                        load_purchase_grid_details(cel1);
                        lbl_check_id.Text = cel1.ToString();

                        selectedrow -= 1;
                    }
                    else
                    {

                        DataGridViewRow row = Purchase_grid.Rows[selectedrow];

                        var cel1 = int.Parse(row.Cells[1].Value.ToString());
                        load_purchase_grid_details(cel1);
                        lbl_check_id.Text = cel1.ToString();
                    }
                }
            }


            else
            {
                //sale
                if (sale_grid.RowCount != -1)
                {
                    selectedrow -= 1;
                    if (selectedrow == 0)
                    {

                        DataGridViewRow row = sale_grid.Rows[selectedrow];

                        var cel1 = int.Parse(row.Cells[1].Value.ToString());
                        load_sale_grid_details(cel1);
                        lbl_check_id.Text = cel1.ToString();
                        selectedrow = sale_grid.RowCount;
                    }
                    else if (selectedrow == -1)
                    {
                        selectedrow = sale_grid.RowCount;
                        DataGridViewRow row = sale_grid.Rows[selectedrow];

                        var cel1 = int.Parse(row.Cells[1].Value.ToString());
                        load_sale_grid_details(cel1);
                        lbl_check_id.Text = cel1.ToString();

                        selectedrow -= 1;
                    }
                    else
                    {
                        DataGridViewRow row = sale_grid.Rows[selectedrow];
                        var cel1 = int.Parse(row.Cells[1].Value.ToString());
                        load_sale_grid_details(cel1);
                        lbl_check_id.Text = cel1.ToString();
                    }

                }

            }
    
          
        }

        private void next_btn_Click_1(object sender, EventArgs e)
        {
            dt3.Clear();
            if (grid)
            {
                if (Purchase_grid.RowCount != -1)
                {
                    if (selectedrow == Purchase_grid.RowCount)
                    {
                        DataGridViewRow row = Purchase_grid.Rows[selectedrow - 1];

                        var cel1 = int.Parse(row.Cells[1].Value.ToString());
                        load_purchase_grid_details(cel1);
                        lbl_check_id.Text = cel1.ToString();

                        selectedrow = 0;

                    }
                    else
                    {

                        DataGridViewRow row = Purchase_grid.Rows[selectedrow];

                        var cel1 = int.Parse(row.Cells[1].Value.ToString());
                        load_purchase_grid_details(cel1);
                        lbl_check_id.Text = cel1.ToString();
                        selectedrow += 1;
                    }

                }
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dt3.Clear();
            if (grid)
            {
                if (Purchase_grid.RowCount > 0)
                {
                    int ii = Purchase_grid.RowCount -1;
                    DataGridViewRow row = Purchase_grid.Rows[ii];
                    var cel1 = row.Cells[1].Value.ToString();
                    lbl_check_id.Text = cel1.ToString();
                    load_purchase_grid_details(int.Parse(cel1));
                }

            }
            else
            {
                if (sale_grid.RowCount > 0)
                {
                    int ii = sale_grid.RowCount -1;
                    DataGridViewRow row = sale_grid.Rows[ii];
                    var cel1 = row.Cells[1].Value.ToString();
                    lbl_check_id.Text = cel1.ToString();
                    load_sale_grid_details(int.Parse(cel1));
                }

            }
        }
       
    }
}
