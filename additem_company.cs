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
    public partial class additem_company : Form
    {
        DataClasses1DataContext mob_sys = new DataClasses1DataContext();
        public additem_company()
        {
            InitializeComponent();
        }
        public void reset_form()
        {
            textBox1.Text = textBox2.Text = "";
            try
            {
                var max_comp_id = mob_sys.Producing_companies.Max(s => s.ID);
                label2.Text = (max_comp_id + 1).ToString();
            }
            catch (Exception) {label2.Text = " 1"; }

            try
            {
                var max_type_id = mob_sys.Type_items.Max(s => s.ID);
                label4.Text = (max_type_id + 1).ToString();
            }
            catch (Exception) { label4.Text = " 1"; }
        }
        private void additem_company_Load(object sender, EventArgs e)
        {
            reset_form();

           
        }

        public bool istypeexit(string x)
        {
            try
            {
                var alltypes = mob_sys.Type_items.Select(s => s.Type).ToList();
                foreach (var item in alltypes)
                {


                    if (item == x)
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
        public bool isitemexit(string x)
        {
            try
            {
                var allcomps = mob_sys.Producing_companies.Select(s => s.Producing_company1).ToList();
                foreach (var item in allcomps)
                {


                    if (item == x)
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
        private void button1_Click(object sender, EventArgs e)
        {
            var id = int.Parse(label2.Text);

            if (textBox1.Text != "")
            {
                var name = textBox1.Text;
                if (!isitemexit(name))
                {
                    mob_sys.ins_production_company(id, name);
                    reset_form();
                    label7.Text = "تمت الاضافه";
                }
                else label7.Text = "الشركه موجوده بالفعل";

            }
            else label7.Text = "اكتب اسم الشركه";
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var id = int.Parse(label4.Text);

            if (textBox2.Text != "")
            {
                var name = textBox2.Text;
                if (!istypeexit(name))
                {

                    mob_sys.ins_type(id, name);
                    reset_form();
                }
                else label8.Text = "النوع موجود بالفعل";

            }
            else label8.Text = "اكتب النوع";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
