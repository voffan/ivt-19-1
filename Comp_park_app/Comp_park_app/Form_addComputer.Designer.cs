
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
            this.button_addHDDs = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // comboBox_HDD
            // 
            this.comboBox_HDD.FormattingEnabled = true;
            this.comboBox_HDD.Location = new System.Drawing.Point(133, 103);
            this.comboBox_HDD.Name = "comboBox_HDD";
            this.comboBox_HDD.Size = new System.Drawing.Size(121, 23);
            this.comboBox_HDD.TabIndex = 0;
            this.comboBox_HDD.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox_RAM
            // 
            this.comboBox_RAM.FormattingEnabled = true;
            this.comboBox_RAM.Location = new System.Drawing.Point(394, 106);
            this.comboBox_RAM.Name = "comboBox_RAM";
            this.comboBox_RAM.Size = new System.Drawing.Size(121, 23);
            this.comboBox_RAM.TabIndex = 1;
            this.comboBox_RAM.SelectedIndexChanged += new System.EventHandler(this.comboBox_RAM_SelectedIndexChanged);
            // 
            // label_HDD
            // 
            this.label_HDD.AutoSize = true;
            this.label_HDD.Location = new System.Drawing.Point(61, 106);
            this.label_HDD.Name = "label_HDD";
            this.label_HDD.Size = new System.Drawing.Size(32, 15);
            this.label_HDD.TabIndex = 2;
            this.label_HDD.Text = "HDD";
            // 
            // label_RAM
            // 
            this.label_RAM.AutoSize = true;
            this.label_RAM.Location = new System.Drawing.Point(311, 109);
            this.label_RAM.Name = "label_RAM";
            this.label_RAM.Size = new System.Drawing.Size(33, 15);
            this.label_RAM.TabIndex = 3;
            this.label_RAM.Text = "RAM";
            // 
            // comboBox_Processor
            // 
            this.comboBox_Processor.FormattingEnabled = true;
            this.comboBox_Processor.Location = new System.Drawing.Point(133, 283);
            this.comboBox_Processor.Name = "comboBox_Processor";
            this.comboBox_Processor.Size = new System.Drawing.Size(121, 23);
            this.comboBox_Processor.TabIndex = 4;
            // 
            // comboBox_Motherboard
            // 
            this.comboBox_Motherboard.FormattingEnabled = true;
            this.comboBox_Motherboard.Location = new System.Drawing.Point(394, 283);
            this.comboBox_Motherboard.Name = "comboBox_Motherboard";
            this.comboBox_Motherboard.Size = new System.Drawing.Size(121, 23);
            this.comboBox_Motherboard.TabIndex = 5;
            // 
            // label_Processor
            // 
            this.label_Processor.AutoSize = true;
            this.label_Processor.Location = new System.Drawing.Point(61, 286);
            this.label_Processor.Name = "label_Processor";
            this.label_Processor.Size = new System.Drawing.Size(58, 15);
            this.label_Processor.TabIndex = 6;
            this.label_Processor.Text = "Processor";
            // 
            // label_Motherboard
            // 
            this.label_Motherboard.AutoSize = true;
            this.label_Motherboard.Location = new System.Drawing.Point(311, 286);
            this.label_Motherboard.Name = "label_Motherboard";
            this.label_Motherboard.Size = new System.Drawing.Size(77, 15);
            this.label_Motherboard.TabIndex = 7;
            this.label_Motherboard.Text = "Motherborad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Компьютер";
            // 
            // button_addHDDs
            // 
            this.button_addHDDs.Location = new System.Drawing.Point(187, 145);
            this.button_addHDDs.Name = "button_addHDDs";
            this.button_addHDDs.Size = new System.Drawing.Size(67, 23);
            this.button_addHDDs.TabIndex = 9;
            this.button_addHDDs.Text = "Добавить";
            this.button_addHDDs.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(61, 145);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 94);
            this.listBox1.TabIndex = 10;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 15;
            this.listBox2.Location = new System.Drawing.Point(311, 145);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 94);
            this.listBox2.TabIndex = 11;
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 15;
            this.listBox3.Location = new System.Drawing.Point(61, 325);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(120, 94);
            this.listBox3.TabIndex = 12;
            // 
            // listBox4
            // 
            this.listBox4.FormattingEnabled = true;
            this.listBox4.ItemHeight = 15;
            this.listBox4.Location = new System.Drawing.Point(311, 325);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(120, 94);
            this.listBox4.TabIndex = 13;
            // 
            // Form_addComputer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 509);
            this.Controls.Add(this.listBox4);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button_addHDDs);
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
            this.Text = "Form_addComputer";
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
        private System.Windows.Forms.Button button_addHDDs;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.ListBox listBox4;
    }
}