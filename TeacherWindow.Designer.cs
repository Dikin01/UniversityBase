
namespace UB._1
{
    partial class TeacherWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherWindow));
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 489);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Преподаватели";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.printTable);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1230, 457);
            this.dataGridView1.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(12, 534);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 39);
            this.button2.TabIndex = 5;
            this.button2.Text = "Очистить таблицу";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.clearTable);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBox1.Location = new System.Drawing.Point(527, 498);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(107, 22);
            this.textBox1.TabIndex = 7;
            this.textBox1.Tag = "Add";
            this.textBox1.Text = "Таб. номер";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox_TextChangeToUInt32);
            this.textBox1.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBox1.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBox2.Location = new System.Drawing.Point(640, 498);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(103, 22);
            this.textBox2.TabIndex = 8;
            this.textBox2.Tag = "Add";
            this.textBox2.Text = "Фамилия";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox_TextChange);
            this.textBox2.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBox2.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBox3.Location = new System.Drawing.Point(749, 498);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(103, 22);
            this.textBox3.TabIndex = 9;
            this.textBox3.Tag = "Add";
            this.textBox3.Text = "Имя";
            this.textBox3.TextChanged += new System.EventHandler(this.textBox_TextChange);
            this.textBox3.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBox3.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBox4.Location = new System.Drawing.Point(858, 498);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(103, 22);
            this.textBox4.TabIndex = 10;
            this.textBox4.Tag = "Add";
            this.textBox4.Text = "Отчество";
            this.textBox4.TextChanged += new System.EventHandler(this.textBox_TextChange);
            this.textBox4.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBox4.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBox5.Location = new System.Drawing.Point(1015, 498);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(103, 22);
            this.textBox5.TabIndex = 12;
            this.textBox5.Tag = "Add";
            this.textBox5.Text = "Должность";
            this.textBox5.TextChanged += new System.EventHandler(this.textBox_TextChange);
            this.textBox5.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBox5.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBox6.Location = new System.Drawing.Point(967, 498);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(42, 22);
            this.textBox6.TabIndex = 11;
            this.textBox6.Tag = "Add";
            this.textBox6.Text = "Стаж";
            this.textBox6.TextChanged += new System.EventHandler(this.textBox_TextChangeToUInt32);
            this.textBox6.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBox6.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBox7.Location = new System.Drawing.Point(1124, 498);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(118, 22);
            this.textBox7.TabIndex = 13;
            this.textBox7.Tag = "Add";
            this.textBox7.Text = "Ид. кафедры";
            this.textBox7.TextChanged += new System.EventHandler(this.textBox_TextChangeToUInt32);
            this.textBox7.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBox7.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(246, 489);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(263, 39);
            this.button3.TabIndex = 14;
            this.button3.Tag = "Add";
            this.button3.Text = "Добавить преподавателя";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.addNewTeacher);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(246, 583);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(263, 39);
            this.button4.TabIndex = 15;
            this.button4.Tag = "Delete";
            this.button4.Text = "Удалить преподавателя";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.deleteTeacher);
            // 
            // textBox8
            // 
            this.textBox8.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBox8.Location = new System.Drawing.Point(527, 592);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(107, 22);
            this.textBox8.TabIndex = 16;
            this.textBox8.Tag = "Delete";
            this.textBox8.Text = "Таб. номер";
            this.textBox8.TextChanged += new System.EventHandler(this.textBox_TextChangeToUInt32);
            this.textBox8.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBox8.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(246, 538);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(263, 39);
            this.button5.TabIndex = 24;
            this.button5.Tag = "Update";
            this.button5.Text = "Изменить преподавателя";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.updateTeacher);
            // 
            // textBox9
            // 
            this.textBox9.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox9.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBox9.Location = new System.Drawing.Point(1124, 547);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(118, 22);
            this.textBox9.TabIndex = 23;
            this.textBox9.Tag = "Update";
            this.textBox9.Text = "Ид. кафедры";
            this.textBox9.TextChanged += new System.EventHandler(this.textBox_TextChangeToUInt32);
            this.textBox9.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBox9.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // textBox10
            // 
            this.textBox10.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox10.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBox10.Location = new System.Drawing.Point(967, 547);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(42, 22);
            this.textBox10.TabIndex = 21;
            this.textBox10.Tag = "Update";
            this.textBox10.Text = "Стаж";
            this.textBox10.TextChanged += new System.EventHandler(this.textBox_TextChangeToUInt32);
            this.textBox10.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBox10.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // textBox11
            // 
            this.textBox11.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox11.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBox11.Location = new System.Drawing.Point(1015, 547);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(103, 22);
            this.textBox11.TabIndex = 22;
            this.textBox11.Tag = "Update";
            this.textBox11.Text = "Должность";
            this.textBox11.TextChanged += new System.EventHandler(this.textBox_TextChange);
            this.textBox11.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBox11.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // textBox12
            // 
            this.textBox12.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox12.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBox12.Location = new System.Drawing.Point(858, 547);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(103, 22);
            this.textBox12.TabIndex = 20;
            this.textBox12.Tag = "Update";
            this.textBox12.Text = "Отчество";
            this.textBox12.TextChanged += new System.EventHandler(this.textBox_TextChange);
            this.textBox12.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBox12.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // textBox13
            // 
            this.textBox13.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox13.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBox13.Location = new System.Drawing.Point(749, 547);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(103, 22);
            this.textBox13.TabIndex = 19;
            this.textBox13.Tag = "Update";
            this.textBox13.Text = "Имя";
            this.textBox13.TextChanged += new System.EventHandler(this.textBox_TextChange);
            this.textBox13.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBox13.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // textBox14
            // 
            this.textBox14.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox14.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBox14.Location = new System.Drawing.Point(640, 547);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(103, 22);
            this.textBox14.TabIndex = 18;
            this.textBox14.Tag = "Update";
            this.textBox14.Text = "Фамилия";
            this.textBox14.TextChanged += new System.EventHandler(this.textBox_TextChange);
            this.textBox14.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBox14.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // textBox15
            // 
            this.textBox15.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox15.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBox15.Location = new System.Drawing.Point(527, 547);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(107, 22);
            this.textBox15.TabIndex = 17;
            this.textBox15.Tag = "Update";
            this.textBox15.Text = "Таб. номер";
            this.textBox15.TextChanged += new System.EventHandler(this.textBox_TextChangeToUInt32);
            this.textBox15.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBox15.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // TeacherWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1254, 691);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TeacherWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Преподаватели";
            this.Load += new System.EventHandler(this.TeacherWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox15;
    }
}