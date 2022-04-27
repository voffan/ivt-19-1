
namespace Comp_park_app.UI
{
    partial class Form_addRegisEmployee
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
            this.button_Add = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_addDepart = new System.Windows.Forms.Button();
            this.button_addPositon = new System.Windows.Forms.Button();
            this.comboBox_Department = new System.Windows.Forms.ComboBox();
            this.comboBox_Position = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(94, 226);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 23);
            this.button_Add.TabIndex = 23;
            this.button_Add.Text = "Добавить";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Edit_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(219, 226);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "Закрыть";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "Сотрудник";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "Должность";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Отдел";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "ФИО";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(145, 69);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(100, 23);
            this.textBox_Name.TabIndex = 14;
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(145, 98);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(100, 23);
            this.textBox_Password.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 15);
            this.label5.TabIndex = 27;
            this.label5.Text = "Пароль";
            // 
            // button_addDepart
            // 
            this.button_addDepart.Location = new System.Drawing.Point(253, 126);
            this.button_addDepart.Name = "button_addDepart";
            this.button_addDepart.Size = new System.Drawing.Size(132, 23);
            this.button_addDepart.TabIndex = 28;
            this.button_addDepart.Text = "Добавить отдел";
            this.button_addDepart.UseVisualStyleBackColor = true;
            this.button_addDepart.Click += new System.EventHandler(this.button3_Click);
            // 
            // button_addPositon
            // 
            this.button_addPositon.Location = new System.Drawing.Point(253, 156);
            this.button_addPositon.Name = "button_addPositon";
            this.button_addPositon.Size = new System.Drawing.Size(132, 23);
            this.button_addPositon.TabIndex = 29;
            this.button_addPositon.Text = "Добавить Должность";
            this.button_addPositon.UseVisualStyleBackColor = true;
            this.button_addPositon.Click += new System.EventHandler(this.button_addPositon_Click);
            // 
            // comboBox_Department
            // 
            this.comboBox_Department.FormattingEnabled = true;
            this.comboBox_Department.Location = new System.Drawing.Point(145, 130);
            this.comboBox_Department.Name = "comboBox_Department";
            this.comboBox_Department.Size = new System.Drawing.Size(100, 23);
            this.comboBox_Department.TabIndex = 30;
            // 
            // comboBox_Position
            // 
            this.comboBox_Position.FormattingEnabled = true;
            this.comboBox_Position.Location = new System.Drawing.Point(145, 159);
            this.comboBox_Position.Name = "comboBox_Position";
            this.comboBox_Position.Size = new System.Drawing.Size(100, 23);
            this.comboBox_Position.TabIndex = 31;
            // 
            // Form_addRegisEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 300);
            this.Controls.Add(this.comboBox_Position);
            this.Controls.Add(this.comboBox_Department);
            this.Controls.Add(this.button_addPositon);
            this.Controls.Add(this.button_addDepart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Name);
            this.Name = "Form_addRegisEmployee";
            this.Text = "Form_addRegisEmployee";
            this.Load += new System.EventHandler(this.Form_addRegisEmployee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_addDepart;
        private System.Windows.Forms.Button button_addPositon;
        private System.Windows.Forms.ComboBox comboBox_Department;
        private System.Windows.Forms.ComboBox comboBox_Position;
    }
}