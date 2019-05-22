namespace Mazaya_3G_return
{
    partial class Search_Check
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search_Check));
            this.txt_code_search = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Search_btn = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.radio_date = new System.Windows.Forms.RadioButton();
            this.radio_id = new System.Windows.Forms.RadioButton();
            this.sale_grid = new System.Windows.Forms.DataGridView();
            this.details_grid = new System.Windows.Forms.DataGridView();
            this.Purchase_grid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_check_id = new System.Windows.Forms.Label();
            this.first_check = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.next_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.sale_message = new System.Windows.Forms.Label();
            this.pursh_message = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.check_id_lbl = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cashername_lbl = new System.Windows.Forms.Label();
            this.total_price_lbl = new System.Windows.Forms.Label();
            this.note_lbl = new System.Windows.Forms.Label();
            this.date_lbl = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sale_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.details_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Purchase_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_code_search
            // 
            this.txt_code_search.Enabled = false;
            this.txt_code_search.Location = new System.Drawing.Point(471, 19);
            this.txt_code_search.Name = "txt_code_search";
            this.txt_code_search.Size = new System.Drawing.Size(156, 20);
            this.txt_code_search.TabIndex = 80;
            this.txt_code_search.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_code_search_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Search_btn);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.radio_date);
            this.groupBox1.Controls.Add(this.txt_code_search);
            this.groupBox1.Controls.Add(this.radio_id);
            this.groupBox1.Location = new System.Drawing.Point(301, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(780, 46);
            this.groupBox1.TabIndex = 82;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بحث عن طريق/";
            // 
            // Search_btn
            // 
            this.Search_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Search_btn.Location = new System.Drawing.Point(19, 16);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(87, 23);
            this.Search_btn.TabIndex = 82;
            this.Search_btn.Text = "بحث";
            this.Search_btn.UseVisualStyleBackColor = false;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(132, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(233, 20);
            this.dateTimePicker1.TabIndex = 81;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // radio_date
            // 
            this.radio_date.AutoSize = true;
            this.radio_date.Location = new System.Drawing.Point(372, 22);
            this.radio_date.Name = "radio_date";
            this.radio_date.Size = new System.Drawing.Size(59, 17);
            this.radio_date.TabIndex = 1;
            this.radio_date.TabStop = true;
            this.radio_date.Text = "التاريخ";
            this.radio_date.UseVisualStyleBackColor = true;
            this.radio_date.CheckedChanged += new System.EventHandler(this.radio_date_CheckedChanged);
            // 
            // radio_id
            // 
            this.radio_id.AutoSize = true;
            this.radio_id.Location = new System.Drawing.Point(631, 22);
            this.radio_id.Name = "radio_id";
            this.radio_id.Size = new System.Drawing.Size(52, 17);
            this.radio_id.TabIndex = 0;
            this.radio_id.TabStop = true;
            this.radio_id.Text = "الكود";
            this.radio_id.UseVisualStyleBackColor = true;
            this.radio_id.CheckedChanged += new System.EventHandler(this.radio_id_CheckedChanged);
            // 
            // sale_grid
            // 
            this.sale_grid.AllowUserToAddRows = false;
            this.sale_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sale_grid.Location = new System.Drawing.Point(695, 285);
            this.sale_grid.Name = "sale_grid";
            this.sale_grid.ReadOnly = true;
            this.sale_grid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.sale_grid.Size = new System.Drawing.Size(671, 145);
            this.sale_grid.TabIndex = 83;
            this.sale_grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sale_grid_CellClick);
            // 
            // details_grid
            // 
            this.details_grid.AllowUserToAddRows = false;
            this.details_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.details_grid.Location = new System.Drawing.Point(6, 285);
            this.details_grid.Name = "details_grid";
            this.details_grid.ReadOnly = true;
            this.details_grid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.details_grid.Size = new System.Drawing.Size(671, 285);
            this.details_grid.TabIndex = 84;
            // 
            // Purchase_grid
            // 
            this.Purchase_grid.AllowUserToAddRows = false;
            this.Purchase_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Purchase_grid.Location = new System.Drawing.Point(695, 466);
            this.Purchase_grid.Name = "Purchase_grid";
            this.Purchase_grid.ReadOnly = true;
            this.Purchase_grid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Purchase_grid.Size = new System.Drawing.Size(671, 225);
            this.Purchase_grid.TabIndex = 85;
            this.Purchase_grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Purchase_grid_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1294, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 86;
            this.label1.Text = "فواتير البيع";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1284, 440);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 87;
            this.label2.Text = "فواتير الشراء";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(608, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 88;
            this.label3.Text = "فاتوره رقم";
            // 
            // lbl_check_id
            // 
            this.lbl_check_id.AutoSize = true;
            this.lbl_check_id.Location = new System.Drawing.Point(1030, 206);
            this.lbl_check_id.Name = "lbl_check_id";
            this.lbl_check_id.Size = new System.Drawing.Size(0, 13);
            this.lbl_check_id.TabIndex = 89;
            // 
            // first_check
            // 
            this.first_check.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.first_check.Location = new System.Drawing.Point(785, 189);
            this.first_check.Name = "first_check";
            this.first_check.Size = new System.Drawing.Size(87, 48);
            this.first_check.TabIndex = 97;
            this.first_check.Text = "اول شيك";
            this.first_check.UseVisualStyleBackColor = false;
            this.first_check.Click += new System.EventHandler(this.first_check_Click_1);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button3.Location = new System.Drawing.Point(656, 189);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 48);
            this.button3.TabIndex = 96;
            this.button3.Text = "سابق";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // next_btn
            // 
            this.next_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.next_btn.Location = new System.Drawing.Point(527, 189);
            this.next_btn.Name = "next_btn";
            this.next_btn.Size = new System.Drawing.Size(87, 48);
            this.next_btn.TabIndex = 95;
            this.next_btn.Text = "التالى ";
            this.next_btn.UseVisualStyleBackColor = false;
            this.next_btn.Click += new System.EventHandler(this.next_btn_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(398, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 48);
            this.button1.TabIndex = 94;
            this.button1.Text = "أخر فاتورة";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // sale_message
            // 
            this.sale_message.AutoSize = true;
            this.sale_message.ForeColor = System.Drawing.Color.Red;
            this.sale_message.Location = new System.Drawing.Point(1181, 207);
            this.sale_message.Name = "sale_message";
            this.sale_message.Size = new System.Drawing.Size(0, 13);
            this.sale_message.TabIndex = 98;
            // 
            // pursh_message
            // 
            this.pursh_message.AutoSize = true;
            this.pursh_message.Location = new System.Drawing.Point(707, 440);
            this.pursh_message.Name = "pursh_message";
            this.pursh_message.Size = new System.Drawing.Size(0, 13);
            this.pursh_message.TabIndex = 99;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(160, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 83;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.ForeColor = System.Drawing.Color.Yellow;
            this.label9.Location = new System.Drawing.Point(602, 631);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 109;
            this.label9.Text = "اسم الكاشير";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.ForeColor = System.Drawing.Color.Yellow;
            this.label8.Location = new System.Drawing.Point(623, 669);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 108;
            this.label8.Text = "الاجمالى";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.ForeColor = System.Drawing.Color.Yellow;
            this.label7.Location = new System.Drawing.Point(432, 631);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 107;
            this.label7.Text = "المشترى";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.ForeColor = System.Drawing.Color.Yellow;
            this.label6.Location = new System.Drawing.Point(432, 669);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 106;
            this.label6.Text = "ملاحظات";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(609, 592);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 105;
            this.label5.Text = "رقم الفاتورة";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.ForeColor = System.Drawing.Color.Yellow;
            this.label10.Location = new System.Drawing.Point(440, 592);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 110;
            this.label10.Text = "التاريخ";
            // 
            // check_id_lbl
            // 
            this.check_id_lbl.AutoSize = true;
            this.check_id_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.check_id_lbl.Location = new System.Drawing.Point(527, 592);
            this.check_id_lbl.Name = "check_id_lbl";
            this.check_id_lbl.Size = new System.Drawing.Size(0, 13);
            this.check_id_lbl.TabIndex = 111;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(336, 631);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 13);
            this.label11.TabIndex = 112;
            // 
            // cashername_lbl
            // 
            this.cashername_lbl.AutoSize = true;
            this.cashername_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cashername_lbl.Location = new System.Drawing.Point(508, 631);
            this.cashername_lbl.Name = "cashername_lbl";
            this.cashername_lbl.Size = new System.Drawing.Size(0, 13);
            this.cashername_lbl.TabIndex = 113;
            // 
            // total_price_lbl
            // 
            this.total_price_lbl.AutoSize = true;
            this.total_price_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.total_price_lbl.Location = new System.Drawing.Point(527, 669);
            this.total_price_lbl.Name = "total_price_lbl";
            this.total_price_lbl.Size = new System.Drawing.Size(0, 13);
            this.total_price_lbl.TabIndex = 114;
            // 
            // note_lbl
            // 
            this.note_lbl.AutoSize = true;
            this.note_lbl.ForeColor = System.Drawing.Color.Yellow;
            this.note_lbl.Location = new System.Drawing.Point(263, 669);
            this.note_lbl.Name = "note_lbl";
            this.note_lbl.Size = new System.Drawing.Size(0, 13);
            this.note_lbl.TabIndex = 115;
            // 
            // date_lbl
            // 
            this.date_lbl.AutoSize = true;
            this.date_lbl.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.date_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.date_lbl.Location = new System.Drawing.Point(272, 592);
            this.date_lbl.Name = "date_lbl";
            this.date_lbl.Size = new System.Drawing.Size(0, 13);
            this.date_lbl.TabIndex = 116;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(31, 631);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 13);
            this.label12.TabIndex = 118;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.ForeColor = System.Drawing.Color.Yellow;
            this.label13.Location = new System.Drawing.Point(197, 631);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 13);
            this.label13.TabIndex = 117;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.Location = new System.Drawing.Point(12, 189);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 48);
            this.button2.TabIndex = 120;
            this.button2.Text = "إلغاء و عودة";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button4.Location = new System.Drawing.Point(202, 189);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(154, 48);
            this.button4.TabIndex = 121;
            this.button4.Text = "طباعة";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(570, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(261, 23);
            this.label14.TabIndex = 122;
            this.label14.Text = "إستعلام فاتورة بضاعة جديدة";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(880, 260);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(0, 13);
            this.label15.TabIndex = 124;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.ForeColor = System.Drawing.Color.Yellow;
            this.label16.Location = new System.Drawing.Point(1030, 260);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 13);
            this.label16.TabIndex = 123;
            this.label16.Text = "إجمالى بيع";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label17.Location = new System.Drawing.Point(880, 440);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(0, 13);
            this.label17.TabIndex = 126;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label18.ForeColor = System.Drawing.Color.Yellow;
            this.label18.Location = new System.Drawing.Point(1026, 440);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 13);
            this.label18.TabIndex = 125;
            this.label18.Text = "إجمالى شراء";
            // 
            // Search_Check
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1370, 712);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.date_lbl);
            this.Controls.Add(this.note_lbl);
            this.Controls.Add(this.total_price_lbl);
            this.Controls.Add(this.cashername_lbl);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.check_id_lbl);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pursh_message);
            this.Controls.Add(this.sale_message);
            this.Controls.Add(this.first_check);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.next_btn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_check_id);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Purchase_grid);
            this.Controls.Add(this.details_grid);
            this.Controls.Add(this.sale_grid);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Search_Check";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Search_Check_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sale_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.details_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Purchase_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_code_search;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RadioButton radio_date;
        private System.Windows.Forms.RadioButton radio_id;
        private System.Windows.Forms.DataGridView sale_grid;
        private System.Windows.Forms.DataGridView details_grid;
        private System.Windows.Forms.DataGridView Purchase_grid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_check_id;
        private System.Windows.Forms.Button Search_btn;
        private System.Windows.Forms.Button first_check;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button next_btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label sale_message;
        private System.Windows.Forms.Label pursh_message;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label check_id_lbl;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label cashername_lbl;
        private System.Windows.Forms.Label total_price_lbl;
        private System.Windows.Forms.Label note_lbl;
        private System.Windows.Forms.Label date_lbl;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
    }
}