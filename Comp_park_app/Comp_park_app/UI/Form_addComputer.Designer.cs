﻿
namespace Comp_park_app
{
    partial class Form_addComputer
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
            this.comboBox_HDD = new System.Windows.Forms.ComboBox();
            this.comboBox_RAM = new System.Windows.Forms.ComboBox();
            this.label_HDD = new System.Windows.Forms.Label();
            this.label_RAM = new System.Windows.Forms.Label();
            this.comboBox_Processor = new System.Windows.Forms.ComboBox();
            this.comboBox_Motherboard = new System.Windows.Forms.ComboBox();
            this.label_Processor = new System.Windows.Forms.Label();
            this.label_Motherboard = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_addComputer = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox_proc = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_Department = new System.Windows.Forms.ComboBox();
            this.textBox_ItemNo = new System.Windows.Forms.TextBox();
            this.comboBox_Employee = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_Status = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.button_Edit = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox_Reason = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox_HDD
            // 
            this.comboBox_HDD.FormattingEnabled = true;
            this.comboBox_HDD.Location = new System.Drawing.Point(144, 230);
            this.comboBox_HDD.Name = "comboBox_HDD";
            this.comboBox_HDD.Size = new System.Drawing.Size(121, 23);
            this.comboBox_HDD.TabIndex = 0;
            this.comboBox_HDD.SelectedIndexChanged += new System.EventHandler(this.comboBox_HDD_SelectedIndexChanged);
            // 
            // comboBox_RAM
            // 
            this.comboBox_RAM.FormattingEnabled = true;
            this.comboBox_RAM.Location = new System.Drawing.Point(405, 233);
            this.comboBox_RAM.Name = "comboBox_RAM";
            this.comboBox_RAM.Size = new System.Drawing.Size(121, 23);
            this.comboBox_RAM.TabIndex = 1;
            this.comboBox_RAM.SelectedIndexChanged += new System.EventHandler(this.comboBox_RAM_SelectedIndexChanged);
            // 
            // label_HDD
            // 
            this.label_HDD.AutoSize = true;
            this.label_HDD.Location = new System.Drawing.Point(72, 233);
            this.label_HDD.Name = "label_HDD";
            this.label_HDD.Size = new System.Drawing.Size(32, 15);
            this.label_HDD.TabIndex = 2;
            this.label_HDD.Text = "HDD";
            // 
            // label_RAM
            // 
            this.label_RAM.AutoSize = true;
            this.label_RAM.Location = new System.Drawing.Point(322, 236);
            this.label_RAM.Name = "label_RAM";
            this.label_RAM.Size = new System.Drawing.Size(33, 15);
            this.label_RAM.TabIndex = 3;
            this.label_RAM.Text = "RAM";
            // 
            // comboBox_Processor
            // 
            this.comboBox_Processor.FormattingEnabled = true;
            this.comboBox_Processor.Location = new System.Drawing.Point(144, 410);
            this.comboBox_Processor.Name = "comboBox_Processor";
            this.comboBox_Processor.Size = new System.Drawing.Size(121, 23);
            this.comboBox_Processor.TabIndex = 4;
            this.comboBox_Processor.SelectedIndexChanged += new System.EventHandler(this.comboBox_Processor_SelectedIndexChanged);
            // 
            // comboBox_Motherboard
            // 
            this.comboBox_Motherboard.FormattingEnabled = true;
            this.comboBox_Motherboard.Location = new System.Drawing.Point(405, 410);
            this.comboBox_Motherboard.Name = "comboBox_Motherboard";
            this.comboBox_Motherboard.Size = new System.Drawing.Size(121, 23);
            this.comboBox_Motherboard.TabIndex = 5;
            // 
            // label_Processor
            // 
            this.label_Processor.AutoSize = true;
            this.label_Processor.Location = new System.Drawing.Point(72, 413);
            this.label_Processor.Name = "label_Processor";
            this.label_Processor.Size = new System.Drawing.Size(58, 15);
            this.label_Processor.TabIndex = 6;
            this.label_Processor.Text = "Processor";
            // 
            // label_Motherboard
            // 
            this.label_Motherboard.AutoSize = true;
            this.label_Motherboard.Location = new System.Drawing.Point(322, 413);
            this.label_Motherboard.Name = "label_Motherboard";
            this.label_Motherboard.Size = new System.Drawing.Size(77, 15);
            this.label_Motherboard.TabIndex = 7;
            this.label_Motherboard.Text = "Motherboard";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Компьютер";
            // 
            // button_addComputer
            // 
            this.button_addComputer.Location = new System.Drawing.Point(405, 523);
            this.button_addComputer.Name = "button_addComputer";
            this.button_addComputer.Size = new System.Drawing.Size(121, 23);
            this.button_addComputer.TabIndex = 9;
            this.button_addComputer.Text = "Добавить";
            this.button_addComputer.UseVisualStyleBackColor = true;
            this.button_addComputer.Click += new System.EventHandler(this.button_addComputer_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(72, 272);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(193, 94);
            this.listBox1.TabIndex = 10;
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 15;
            this.listBox2.Location = new System.Drawing.Point(322, 272);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(204, 94);
            this.listBox2.TabIndex = 11;
            this.listBox2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox2_MouseDoubleClick);
            // 
            // listBox_proc
            // 
            this.listBox_proc.FormattingEnabled = true;
            this.listBox_proc.ItemHeight = 15;
            this.listBox_proc.Location = new System.Drawing.Point(72, 452);
            this.listBox_proc.Name = "listBox_proc";
            this.listBox_proc.Size = new System.Drawing.Size(193, 94);
            this.listBox_proc.TabIndex = 12;
            this.listBox_proc.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox3_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Отдел";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Инвентарный номер";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "Сотрудник";
            // 
            // comboBox_Department
            // 
            this.comboBox_Department.FormattingEnabled = true;
            this.comboBox_Department.Location = new System.Drawing.Point(144, 57);
            this.comboBox_Department.Name = "comboBox_Department";
            this.comboBox_Department.Size = new System.Drawing.Size(121, 23);
            this.comboBox_Department.TabIndex = 17;
            // 
            // textBox_ItemNo
            // 
            this.textBox_ItemNo.Location = new System.Drawing.Point(223, 105);
            this.textBox_ItemNo.Name = "textBox_ItemNo";
            this.textBox_ItemNo.Size = new System.Drawing.Size(132, 23);
            this.textBox_ItemNo.TabIndex = 18;
            // 
            // comboBox_Employee
            // 
            this.comboBox_Employee.FormattingEnabled = true;
            this.comboBox_Employee.Location = new System.Drawing.Point(144, 201);
            this.comboBox_Employee.Name = "comboBox_Employee";
            this.comboBox_Employee.Size = new System.Drawing.Size(121, 23);
            this.comboBox_Employee.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Состояние";
            // 
            // comboBox_Status
            // 
            this.comboBox_Status.FormattingEnabled = true;
            this.comboBox_Status.Location = new System.Drawing.Point(144, 143);
            this.comboBox_Status.Name = "comboBox_Status";
            this.comboBox_Status.Size = new System.Drawing.Size(121, 23);
            this.comboBox_Status.TabIndex = 21;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(369, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 22;
            this.comboBox1.Visible = false;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(369, 60);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 23);
            this.comboBox2.TabIndex = 23;
            this.comboBox2.Visible = false;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(369, 105);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 23);
            this.comboBox3.TabIndex = 24;
            this.comboBox3.Visible = false;
            // 
            // button_Edit
            // 
            this.button_Edit.Location = new System.Drawing.Point(405, 523);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(121, 23);
            this.button_Edit.TabIndex = 25;
            this.button_Edit.Text = "Изменить";
            this.button_Edit.UseVisualStyleBackColor = true;
            this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(322, 452);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(204, 23);
            this.dateTimePicker1.TabIndex = 26;
            // 
            // textBox_Reason
            // 
            this.textBox_Reason.Location = new System.Drawing.Point(144, 172);
            this.textBox_Reason.Name = "textBox_Reason";
            this.textBox_Reason.Size = new System.Drawing.Size(121, 23);
            this.textBox_Reason.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(72, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 15);
            this.label6.TabIndex = 28;
            this.label6.Text = "Причина";
            // 
            // Form_addComputer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 583);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_Reason);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button_Edit);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.comboBox_Status);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_Employee);
            this.Controls.Add(this.textBox_ItemNo);
            this.Controls.Add(this.comboBox_Department);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_proc);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button_addComputer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_Motherboard);
            this.Controls.Add(this.label_Processor);
            this.Controls.Add(this.comboBox_Motherboard);
            this.Controls.Add(this.comboBox_Processor);
            this.Controls.Add(this.label_RAM);
            this.Controls.Add(this.label_HDD);
            this.Controls.Add(this.comboBox_RAM);
            this.Controls.Add(this.comboBox_HDD);
            this.Name = "Form_addComputer";
            this.Text = "Form_Computer";
            this.Load += new System.EventHandler(this.Form_addComputer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_HDD;
        private System.Windows.Forms.ComboBox comboBox_RAM;
        private System.Windows.Forms.Label label_HDD;
        private System.Windows.Forms.Label label_RAM;
        private System.Windows.Forms.ComboBox comboBox_Processor;
        private System.Windows.Forms.ComboBox comboBox_Motherboard;
        private System.Windows.Forms.Label label_Processor;
        private System.Windows.Forms.Label label_Motherboard;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_addComputer;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox_proc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Department;
        private System.Windows.Forms.TextBox textBox_ItemNo;
        private System.Windows.Forms.ComboBox comboBox_Employee;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_Status;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox_Reason;
        private System.Windows.Forms.Label label6;
    }
}