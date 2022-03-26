namespace Autoreport.UI
{
    partial class AddClientForm : BaseAddForm
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
            this.flowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lastNameText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.firstNameText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.middleNameText = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.phoneText = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.phoneAdditionalText = new System.Windows.Forms.MaskedTextBox();
            this.resetBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.flowLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayout
            // 
            this.flowLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayout.Controls.Add(this.label1);
            this.flowLayout.Controls.Add(this.lastNameText);
            this.flowLayout.Controls.Add(this.label7);
            this.flowLayout.Controls.Add(this.firstNameText);
            this.flowLayout.Controls.Add(this.label9);
            this.flowLayout.Controls.Add(this.middleNameText);
            this.flowLayout.Controls.Add(this.label14);
            this.flowLayout.Controls.Add(this.phoneText);
            this.flowLayout.Controls.Add(this.label2);
            this.flowLayout.Controls.Add(this.phoneAdditionalText);
            this.flowLayout.Location = new System.Drawing.Point(12, 12);
            this.flowLayout.Name = "flowLayout";
            this.flowLayout.Size = new System.Drawing.Size(476, 176);
            this.flowLayout.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.MinimumSize = new System.Drawing.Size(232, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Фамилия";
            // 
            // lastNameText
            // 
            this.lastNameText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lastNameText.Location = new System.Drawing.Point(241, 3);
            this.lastNameText.Name = "lastNameText";
            this.lastNameText.Size = new System.Drawing.Size(232, 25);
            this.lastNameText.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(3, 34);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.MinimumSize = new System.Drawing.Size(232, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(232, 25);
            this.label7.TabIndex = 1;
            this.label7.Text = "Имя";
            // 
            // firstNameText
            // 
            this.firstNameText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.firstNameText.Location = new System.Drawing.Point(241, 34);
            this.firstNameText.Name = "firstNameText";
            this.firstNameText.Size = new System.Drawing.Size(232, 25);
            this.firstNameText.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(3, 65);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.MinimumSize = new System.Drawing.Size(232, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(232, 25);
            this.label9.TabIndex = 2;
            this.label9.Text = "Отчество";
            // 
            // middleNameText
            // 
            this.middleNameText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.middleNameText.Location = new System.Drawing.Point(241, 65);
            this.middleNameText.Name = "middleNameText";
            this.middleNameText.Size = new System.Drawing.Size(232, 25);
            this.middleNameText.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(3, 96);
            this.label14.Margin = new System.Windows.Forms.Padding(3);
            this.label14.MinimumSize = new System.Drawing.Size(232, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(232, 25);
            this.label14.TabIndex = 6;
            this.label14.Text = "Номер телефона 1";
            // 
            // phoneText
            // 
            this.phoneText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.phoneText.Location = new System.Drawing.Point(241, 96);
            this.phoneText.Mask = "+7 (000) 000-00-00";
            this.phoneText.Name = "phoneText";
            this.phoneText.Size = new System.Drawing.Size(232, 25);
            this.phoneText.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(3, 127);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.MinimumSize = new System.Drawing.Size(232, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = "Номер телефона 2";
            // 
            // phoneAdditionalText
            // 
            this.phoneAdditionalText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.phoneAdditionalText.Location = new System.Drawing.Point(241, 127);
            this.phoneAdditionalText.Mask = "+7 (000) 000-00-00";
            this.phoneAdditionalText.Name = "phoneAdditionalText";
            this.phoneAdditionalText.Size = new System.Drawing.Size(232, 25);
            this.phoneAdditionalText.TabIndex = 21;
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(12, 194);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(200, 30);
            this.resetBtn.TabIndex = 13;
            this.resetBtn.Text = "Сброс";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(288, 194);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(200, 30);
            this.saveBtn.TabIndex = 14;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // AddClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 235);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.flowLayout);
            this.Name = "AddClientForm";
            this.Text = "AddClientForm";
            this.flowLayout.ResumeLayout(false);
            this.flowLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lastNameText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox firstNameText;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox middleNameText;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MaskedTextBox phoneText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox phoneAdditionalText;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayout;
    }
}