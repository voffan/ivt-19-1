
namespace Comp_park_app.UI
{
    partial class Form_reports
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
            this.button_reportsWorking = new System.Windows.Forms.Button();
            this.button_reportsRepaired = new System.Windows.Forms.Button();
            this.button_reportsRemoved = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_reportsWorking
            // 
            this.button_reportsWorking.Location = new System.Drawing.Point(47, 53);
            this.button_reportsWorking.Name = "button_reportsWorking";
            this.button_reportsWorking.Size = new System.Drawing.Size(98, 64);
            this.button_reportsWorking.TabIndex = 0;
            this.button_reportsWorking.Text = "Отчет о работающей технике";
            this.button_reportsWorking.UseVisualStyleBackColor = true;
            this.button_reportsWorking.Click += new System.EventHandler(this.button_reportsWorking_Click);
            // 
            // button_reportsRepaired
            // 
            this.button_reportsRepaired.Location = new System.Drawing.Point(162, 53);
            this.button_reportsRepaired.Name = "button_reportsRepaired";
            this.button_reportsRepaired.Size = new System.Drawing.Size(98, 64);
            this.button_reportsRepaired.TabIndex = 1;
            this.button_reportsRepaired.Text = "Отчет о технике на ремонте";
            this.button_reportsRepaired.UseVisualStyleBackColor = true;
            this.button_reportsRepaired.Click += new System.EventHandler(this.button_reportsRepaired_Click);
            // 
            // button_reportsRemoved
            // 
            this.button_reportsRemoved.Location = new System.Drawing.Point(283, 53);
            this.button_reportsRemoved.Name = "button_reportsRemoved";
            this.button_reportsRemoved.Size = new System.Drawing.Size(98, 64);
            this.button_reportsRemoved.TabIndex = 2;
            this.button_reportsRemoved.Text = "Отчет о списанной технике";
            this.button_reportsRemoved.UseVisualStyleBackColor = true;
            this.button_reportsRemoved.Click += new System.EventHandler(this.button_reportsRemoved_Click);
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(162, 145);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(98, 27);
            this.button_exit.TabIndex = 3;
            this.button_exit.Text = "Назад";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // Form_reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 210);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_reportsRemoved);
            this.Controls.Add(this.button_reportsRepaired);
            this.Controls.Add(this.button_reportsWorking);
            this.Name = "Form_reports";
            this.Text = "Form_reports";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_reportsWorking;
        private System.Windows.Forms.Button button_reportsRepaired;
        private System.Windows.Forms.Button button_reportsRemoved;
        private System.Windows.Forms.Button button_exit;
    }
}