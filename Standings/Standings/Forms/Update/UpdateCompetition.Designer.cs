namespace Standings.Forms.Update
{
    partial class UpdateCompetition
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
            this.label1 = new System.Windows.Forms.Label();
            this.Name1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Date1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.Location1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Level1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(50, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 33;
            this.label1.Text = "Название";
            // 
            // Name1
            // 
            this.Name1.Location = new System.Drawing.Point(143, 65);
            this.Name1.Name = "Name1";
            this.Name1.Size = new System.Drawing.Size(192, 23);
            this.Name1.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(82, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 19);
            this.label5.TabIndex = 41;
            this.label5.Text = "Дата";
            // 
            // Date1
            // 
            this.Date1.Location = new System.Drawing.Point(143, 117);
            this.Date1.Name = "Date1";
            this.Date1.Size = new System.Drawing.Size(192, 23);
            this.Date1.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(71, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 19);
            this.label6.TabIndex = 43;
            this.label6.Text = "Место";
            // 
            // Location1
            // 
            this.Location1.Location = new System.Drawing.Point(143, 167);
            this.Location1.Name = "Location1";
            this.Location1.Size = new System.Drawing.Size(192, 23);
            this.Location1.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(57, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 45;
            this.label2.Text = "Уровень";
            // 
            // Level1
            // 
            this.Level1.FormattingEnabled = true;
            this.Level1.Location = new System.Drawing.Point(143, 220);
            this.Level1.Name = "Level1";
            this.Level1.Size = new System.Drawing.Size(192, 23);
            this.Level1.TabIndex = 46;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(110, 309);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 39);
            this.button1.TabIndex = 47;
            this.button1.Text = "Изменить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UpdateCompetition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Level1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Location1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Date1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Name1);
            this.Controls.Add(this.label1);
            this.Name = "UpdateCompetition";
            this.Text = "UpdateCompetition";
            this.Load += new System.EventHandler(this.UpdateCompetition_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox Name1;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DateTimePicker Date1;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox Location1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox Level1;
        private System.Windows.Forms.Button button1;
    }
}