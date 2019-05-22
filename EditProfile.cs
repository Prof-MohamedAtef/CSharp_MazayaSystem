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
    public partial class EditProfile : Form
    {
        public EditProfile()
        {
            InitializeComponent();
        }
        DataClasses1DataContext mob_sys = new DataClasses1DataContext();
        public void setpanal1(bool x)
        {
            txt_address.ReadOnly=x;
            txt_email.ReadOnly = x;
            txt_firstname.ReadOnly = x;
            txt_lastname.ReadOnly = x;
            txt_username.ReadOnly = x;
            txt_tel.ReadOnly = x;
            
            txt_hint.ReadOnly = x;

        }
    
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            setpanal1(false);
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            if (txt_firstname.Text !=""&&txt_password.Text!=""&&txt_confpassword.Text !=""&&txt_username.Text!="")
            {
                if (txt_password.Text == txt_confpassword.Text)
                {
                    mob_sys.updateProfile(Class1.TheID, txt_username.Text, txt_password.Text, 0,
                        txt_firstname.Text, txt_lastname.Text, txt_tel.Text, txt_email.Text, txt_address.Text, txt_hint.Text);
                    button1.Text = "تم التعديل";
                    DialogResult dialogResult = MessageBox.Show("تم التعديل......هل تريد التعديل مره أخرى ؟", "Some Title", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        setpanal1(false);
                        txt_password.Text = txt_confpassword.Text = "";
                        panel2.Visible = true;
                        button2.Enabled = false;
                        button1.Enabled = true;
                        button1.Text = "حفظ";

                    }
                    if (dialogResult == DialogResult.No)
                    {

                        this.Hide();
                    }
                    

                }
                else label13.Text = "الباسورد غير متتطابق";
                
            }
            else label13.Text = "تأكد من ادخال الاسم الاول واسم المستخدم والباسورد ";


        }

        private void EditProfile_Load(object sender, EventArgs e)
        {
            setpanal1(true);
            panel2.Visible = false;
            button2.Enabled = true;
            button1.Enabled = false;
            label9.Text = Class1.TheID.ToString();
            var details = mob_sys.login_Tbls.Where(s => s.ID == Class1.TheID).Select(s =>
                new
                {
                    password = s.Password,
                    state = s.State,
                    username = s.UserName,
                    tel = s.tel,
                    lastname = s.lastname,
                    firstname = s.firstname,
                    email = s.email,
                    address = s.add_ress,
                    hint = s.hint
                }).SingleOrDefault();
            txt_address.Text = details.address;
            txt_email.Text = details.email;
            txt_firstname.Text = details.firstname;
            txt_lastname.Text = details.lastname;
            txt_tel.Text = details.tel;
            txt_username.Text = details.username;
            if (details.state == 1)
            {
                label9.Text = "Admin";
            }
            else label9.Text = "Member";

            
        }

        private void txt_firstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txt_lastname.Focus();
            }
        }

        private void txt_lastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txt_username.Focus();
            }
        }

        private void txt_tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txt_email.Focus();
            }
        }

        private void txt_username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txt_tel.Focus();
            }
        }

        private void txt_email_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txt_address.Focus();
            }
        }

        private void txt_address_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txt_hint.Focus();
            }
        }

        private void txt_hint_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                comboBox1.Focus();
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txt_password.Focus();
            }
        }

        private void txt_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txt_confpassword.Focus();
            }
        }

        private void txt_confpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                button1.Focus();
            }
        }

        private void EditProfile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                button2.Focus();
            }
        }
    }
}
