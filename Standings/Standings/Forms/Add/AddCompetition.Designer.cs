namespace Standings.Forms.Add
{
    partial class AddCompetition
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Location1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Name1 = new System.Windows.Forms.TextBox();
            this.Level1 = new System.Windows.Forms.ComboBox();
            this.Date1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(66, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 19);
            this.label6.TabIndex = 38;
            this.label6.Text = "Место";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(77, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 19);
            this.label5.TabIndex = 37;
            this.label5.Text = "Дата";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(65, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 33;
            this.label2.Text = "Уровень";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(65, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 32;
            this.label1.Text = "Название";
            // 
            // Location1
            // 
            this.Location1.Location = new System.Drawing.Point(176, 171);
            this.Location1.Name = "Location1";
            this.Location1.Size = new System.Drawing.Size(192, 23);
            this.Location1.TabIndex = 30;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(113, 299);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 39);
            this.button1.TabIndex = 29;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Name1
            // 
            this.Name1.Location = new System.Drawing.Point(176, 90);
            this.Name1.Name = "Name1";
            this.Name1.Size = new System.Drawing.Size(192, 23);
            this.Name1.TabIndex = 39;
            // 
            // Level1
            // 
            this.Level1.FormattingEnabled = true;
            this.Level1.Location = new System.Drawing.Point(176, 213);
            this.Level1.Name = "Level1";
            this.Level1.Size = new System.Drawing.Size(192, 23);
            this.Level1.TabIndex = 40;
            this.Level1.SelectedIndexChanged += new System.EventHandler(this.Level1_SelectedIndexChanged);
            // 
            // Date1
            // 
            this.Date1.Location = new System.Drawing.Point(176, 130);
            this.Date1.Name = "Date1";
            this.Date1.Size = new System.Drawing.Size(192, 23);
            this.Date1.TabIndex = 41;
            // 
            // AddCompetition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 396);
            this.Controls.Add(this.Date1);
            this.Controls.Add(this.Level1);
            this.Controls.Add(this.Name1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Location1);
            this.Controls.Add(this.button1);
            this.Name = "AddCompetition";
            this.Text = "AddCompetition";
            this.Load += new System.EventHandler(this.AddCompetition_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Location1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Name1;
        private System.Windows.Forms.ComboBox Level1;
        private System.Windows.Forms.DateTimePicker Date1;
    }
}