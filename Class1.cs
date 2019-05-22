using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mazaya_3G_return
{
    static class Class1
    {
        static string name;
        public static string TheValue
        {
            set { name = value; }
            get { return name; }
        }
        static int id;
        public static int TheID
        {
            set { id = value; }
            get { return id; }
        }
        static int item_id;
        public static int Item_Id
        {
            set { item_id = value; }
            get { return item_id; }
        }
        static int click_edititem;
        public static int Click_edititem
        {
            set { click_edititem = value; }
            get { return click_edititem; }
        }
        static int purch_id;
        public static int Purch_id
        {
            set { purch_id = value; }
            get { return purch_id; }
        }
        
        static int sale_id;
        public static int Sale_id
        {
            set { sale_id = value; }
            get { return sale_id; }
        }

        static int return_id;
        public static int Return_id
        {
            set { return_id = value; }
            get { return return_id; }
        }
        static string saleto;
        public static string Saleto
        {
            set { saleto = value; }
            get { return saleto; }
        }
        static int sellected_check_id;
        public static int Sellected_check_id
        {
            set { sellected_check_id = value; }
            get { return sellected_check_id; }
        }

    }
}
