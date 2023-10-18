namespace Sql_Database_FilmTheater_FirstTry.MenuForms
{
    partial class FilmsDisplayForm
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
            this.FilmsCombobox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddResrvation = new System.Windows.Forms.Button();
            this.AddSeat = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.SeatComboBox = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.RowComboBox = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.ScreeningComboBox = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FilmsCombobox
            // 
            this.FilmsCombobox.BackColor = System.Drawing.SystemColors.Control;
            this.FilmsCombobox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FilmsCombobox.ForeColor = System.Drawing.SystemColors.Desktop;
            this.FilmsCombobox.FormattingEnabled = true;
            this.FilmsCombobox.Location = new System.Drawing.Point(12, 37);
            this.FilmsCombobox.Name = "FilmsCombobox";
            this.FilmsCombobox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FilmsCombobox.Size = new System.Drawing.Size(220, 23);
            this.FilmsCombobox.TabIndex = 1;
            this.FilmsCombobox.SelectedIndexChanged += new System.EventHandler(this.FilmsCombobox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(4)))), ((int)(((byte)(26)))));
            this.panel1.Controls.Add(this.AddResrvation);
            this.panel1.Controls.Add(this.AddSeat);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.SeatComboBox);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.RowComboBox);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.ScreeningComboBox);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.FilmsCombobox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 450);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // AddResrvation
            // 
            this.AddResrvation.Location = new System.Drawing.Point(222, 288);
            this.AddResrvation.Name = "AddResrvation";
            this.AddResrvation.Size = new System.Drawing.Size(148, 36);
            this.AddResrvation.TabIndex = 10;
            this.AddResrvation.Text = "Зарезервировать";
            this.AddResrvation.UseVisualStyleBackColor = true;
            this.AddResrvation.Visible = false;
            this.AddResrvation.Click += new System.EventHandler(this.AddResrvation_Click);
            // 
            // AddSeat
            // 
            this.AddSeat.Location = new System.Drawing.Point(15, 288);
            this.AddSeat.Name = "AddSeat";
            this.AddSeat.Size = new System.Drawing.Size(132, 36);
            this.AddSeat.TabIndex = 9;
            this.AddSeat.Text = "Добавить место";
            this.AddSeat.UseVisualStyleBackColor = true;
            this.AddSeat.Visible = false;
            this.AddSeat.Click += new System.EventHandler(this.AddSeat_Click);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(4)))), ((int)(((byte)(26)))));
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Noto Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox4.ForeColor = System.Drawing.SystemColors.Info;
            this.textBox4.Location = new System.Drawing.Point(12, 210);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(220, 19);
            this.textBox4.TabIndex = 8;
            this.textBox4.Text = "Выберите место:";
            // 
            // SeatComboBox
            // 
            this.SeatComboBox.BackColor = System.Drawing.SystemColors.Control;
            this.SeatComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SeatComboBox.ForeColor = System.Drawing.SystemColors.Desktop;
            this.SeatComboBox.FormattingEnabled = true;
            this.SeatComboBox.Location = new System.Drawing.Point(12, 235);
            this.SeatComboBox.Name = "SeatComboBox";
            this.SeatComboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SeatComboBox.Size = new System.Drawing.Size(220, 23);
            this.SeatComboBox.TabIndex = 7;
            this.SeatComboBox.SelectionChangeCommitted += new System.EventHandler(this.SeatComboBox_SelectionChangeCommitted);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(4)))), ((int)(((byte)(26)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Noto Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox3.ForeColor = System.Drawing.SystemColors.Info;
            this.textBox3.Location = new System.Drawing.Point(12, 140);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(220, 19);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = "Выберите ряд:";
            // 
            // RowComboBox
            // 
            this.RowComboBox.BackColor = System.Drawing.SystemColors.Control;
            this.RowComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RowComboBox.ForeColor = System.Drawing.SystemColors.Desktop;
            this.RowComboBox.FormattingEnabled = true;
            this.RowComboBox.Location = new System.Drawing.Point(12, 165);
            this.RowComboBox.Name = "RowComboBox";
            this.RowComboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RowComboBox.Size = new System.Drawing.Size(220, 23);
            this.RowComboBox.TabIndex = 5;
            this.RowComboBox.SelectionChangeCommitted += new System.EventHandler(this.RowComboBox_SelectionChangeCommitted);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(4)))), ((int)(((byte)(26)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Noto Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox2.ForeColor = System.Drawing.SystemColors.Info;
            this.textBox2.Location = new System.Drawing.Point(12, 73);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(220, 19);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "Выберите сеанс:";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // ScreeningComboBox
            // 
            this.ScreeningComboBox.BackColor = System.Drawing.SystemColors.Control;
            this.ScreeningComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ScreeningComboBox.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ScreeningComboBox.FormattingEnabled = true;
            this.ScreeningComboBox.Location = new System.Drawing.Point(12, 98);
            this.ScreeningComboBox.Name = "ScreeningComboBox";
            this.ScreeningComboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ScreeningComboBox.Size = new System.Drawing.Size(220, 23);
            this.ScreeningComboBox.TabIndex = 3;
            this.ScreeningComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.ScreeningComboBox.SelectionChangeCommitted += new System.EventHandler(this.ScreeningComboBox_SelectionChangeCommitted);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(4)))), ((int)(((byte)(26)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Noto Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.ForeColor = System.Drawing.SystemColors.Info;
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(220, 19);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Выберите фильм:";
            // 
            // FilmsDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(4)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "FilmsDisplayForm";
            this.Text = "FilmsDisplayForm";
            this.Load += new System.EventHandler(this.FilmsDisplayForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox FilmsCombobox;
        private Panel panel1;
        private TextBox textBox1;
        private TextBox textBox2;
        private ComboBox ScreeningComboBox;
        private TextBox textBox4;
        private ComboBox SeatComboBox;
        private TextBox textBox3;
        private ComboBox RowComboBox;
        private Button AddSeat;
        private Button AddResrvation;
    }
}