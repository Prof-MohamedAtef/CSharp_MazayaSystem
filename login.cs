using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Collections;
//using H.D.D.Serial_num;


namespace Mazaya_3G_return
{   
    public partial class login : Form
    {
        DataClasses1DataContext mob_sys = new DataClasses1DataContext();
        //mazayaEntities mob_sys = new mazayaEntities();

       public static string name;
       public static int ID;
       
        public login()
        {
            InitializeComponent();
        }

        //string hd_serial_num = "32535735394a4246313630363733202020202020";
        //------------
        
    internal class HardDrive
    {
        private string model = null;
        private string serialNo = null;
        private string type = null;

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }

        public string SerialNo
        {
            get 
            {
                return this.serialNo;
            }
            set
            {
                this.serialNo = value;
            }
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }
    }
        //--------------
        private void login_Load(object sender, EventArgs e)
        {
            ArrayList hdCollection = new ArrayList();
            //serial number is here
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
            //int I1 = 0;
            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                // get the hard drive from collection
                // using index
                HardDrive hd = new HardDrive();

                // get the hardware serial no.
                if (wmi_HD["SerialNumber"] == null)
                    hd.SerialNo = "None";
                else
                    hd.SerialNo = wmi_HD["SerialNumber"].ToString();
                //hd = (HardDrive)hdCollection[i];
                hdCollection.Add(hd.SerialNo);
                //++I1;

                for (int i = 0; i < hdCollection.Count - 1; i++)
                {
                    label5.Text = hdCollection[0].ToString();
                }

                foreach (var item in hdCollection)
                {
                    //listBox1.Items.Add(item);
                    //comboBox1.Items.Add(item);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (label5.Text == hd_serial_num)
            //{
                Home h = new Home();
                SaleCheck s_ch = new SaleCheck();
                bool x = false;
                if (txt_name.Text != "" && txt_pass.Text != "")
                {
                    var logintbl = mob_sys.login_Tbls.Select(s => new { ID = s.ID, Password = s.Password, Name = s.UserName }).ToList();
                    foreach (var item in logintbl)
                    {
                        if (txt_name.Text == item.Name && txt_pass.Text == item.Password)
                        {
                            x = true;
                            ID = item.ID;
                            break;
                        }
                        else x = false;
                    }
                    if (x)
                    {
                        name = txt_name.Text;
                        label4.Text = "مسموح الدخول";
                        Class1.TheValue = name;
                        Class1.TheID = ID;
                        this.Hide();
                        h.Show();
                    }
                    else label4.Text = "غير مسموح الدخول";
                }
                else label4.Text = "تأكد من ادخال الاسم والباسورد";
            //}
            //else
            //{
            //    label4.Text = "إحذر ! هكذا أنت تلعب بعداد عمر البرنامج ";
            //}
        }

        

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    if (listBox1.SelectedItem != null)
        //    {
        //        textBox1.Text = listBox1.SelectedItem.ToString();
        //        label5.Text = listBox1.SelectedItem.ToString();
        //    }
        //    else
        //    {
        //        MessageBox.Show("select your item on listbox");
        //    }
        //}

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    if (label5.Text == textBox1.Text)
        //    {
        //        MessageBox.Show("Done");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Not yet");
        //    }
        //}

        private void button4_Click(object sender, EventArgs e)
        {

        }
        
    }

}
