namespace Autoreport.UI
{
    partial class AddDepositForm : AddFormSelective
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
            this.dataText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.sumText = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.positionDepositBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.removeSelectedBtn = new System.Windows.Forms.Button();
            this.selectBtn = new System.Windows.Forms.Button();
            this.selectedBox = new System.Windows.Forms.ListBox();
            this.resetBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.flowLayout.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayout
            // 
            this.flowLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayout.Controls.Add(this.label1);
            this.flowLayout.Controls.Add(this.dataText);
            this.flowLayout.Controls.Add(this.label7);
            this.flowLayout.Controls.Add(this.sumText);
            this.flowLayout.Controls.Add(this.label13);
            this.flowLayout.Controls.Add(this.positionDepositBox);
            this.flowLayout.Controls.Add(this.label2);
            this.flowLayout.Controls.Add(this.panel1);
            this.flowLayout.Controls.Add(this.selectedBox);
            this.flowLayout.Location = new System.Drawing.Point(12, 12);
            this.flowLayout.Name = "flowLayout";
            this.flowLayout.Size = new System.Drawing.Size(476, 269);
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
            this.label1.Text = "Данные";
            // 
            // dataText
            // 
            this.dataText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dataText.Location = new System.Drawing.Point(241, 3);
            this.dataText.Name = "dataText";
            this.dataText.Size = new System.Drawing.Size(232, 25);
            this.dataText.TabIndex = 9;
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
            this.label7.Text = "Сумма";
            // 
            // sumText
            // 
            this.sumText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sumText.Location = new System.Drawing.Point(241, 34);
            this.sumText.Name = "sumText";
            this.sumText.Size = new System.Drawing.Size(232, 25);
            this.sumText.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(3, 65);
            this.label13.Margin = new System.Windows.Forms.Padding(3);
            this.label13.MinimumSize = new System.Drawing.Size(232, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(232, 25);
            this.label13.TabIndex = 5;
            this.label13.Text = "Тип залога";
            // 
            // positionDepositBox
            // 
            this.positionDepositBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.positionDepositBox.FormattingEnabled = true;
            this.positionDepositBox.Location = new System.Drawing.Point(241, 65);
            this.positionDepositBox.Name = "positionDepositBox";
            this.positionDepositBox.Size = new System.Drawing.Size(232, 23);
            this.positionDepositBox.TabIndex = 18;
            this.positionDepositBox.Click += new System.EventHandler(this.selectedClientsBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(3, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.MinimumSize = new System.Drawing.Size(232, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 25);
            this.label2.TabIndex = 19;
            this.label2.Text = "Владелец";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.removeSelectedBtn);
            this.panel1.Controls.Add(this.selectBtn);
            this.panel1.Location = new System.Drawing.Point(241, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(75, 49);
            this.panel1.TabIndex = 20;
            // 
            // removeSelectedBtn
            // 
            this.removeSelectedBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.removeSelectedBtn.Enabled = false;
            this.removeSelectedBtn.Location = new System.Drawing.Point(0, 26);
            this.removeSelectedBtn.Name = "removeSelectedBtn";
            this.removeSelectedBtn.Size = new System.Drawing.Size(75, 23);
            this.removeSelectedBtn.TabIndex = 13;
            this.removeSelectedBtn.Text = "Удалить";
            this.removeSelectedBtn.UseVisualStyleBackColor = true;
            this.removeSelectedBtn.Click += new System.EventHandler(this.removeSelectedBtn_Click);
            // 
            // selectBtn
            // 
            this.selectBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectBtn.Location = new System.Drawing.Point(0, 0);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(75, 23);
            this.selectBtn.TabIndex = 12;
            this.selectBtn.Text = "Выбрать";
            this.selectBtn.UseVisualStyleBackColor = true;
            this.selectBtn.Click += new System.EventHandler(this.SelectBtn_Click);
            // 
            // selectedBox
            // 
            this.selectedBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectedBox.FormattingEnabled = true;
            this.selectedBox.IntegralHeight = false;
            this.selectedBox.ItemHeight = 17;
            this.selectedBox.Location = new System.Drawing.Point(322, 96);
            this.selectedBox.Name = "selectedBox";
            this.selectedBox.Size = new System.Drawing.Size(151, 87);
            this.selectedBox.TabIndex = 21;
            this.selectedBox.SelectedIndexChanged += new System.EventHandler(this.selectedClientsBox_SelectedIndexChanged);
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(12, 287);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(200, 30);
            this.resetBtn.TabIndex = 13;
            this.resetBtn.Text = "Сброс";
            this.resetBtn.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(288, 287);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(200, 30);
            this.saveBtn.TabIndex = 14;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // AddDepositForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 328);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.flowLayout);
            this.Name = "AddDepositForm";
            this.Text = "AddDepositForm";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Load += new System.EventHandler(this.AddDepositForm_Load);
            this.flowLayout.ResumeLayout(false);
            this.flowLayout.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox sumText;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox positionDepositBox;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox dataText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button removeSelectedBtn;
        private System.Windows.Forms.Button selectBtn;
        private System.Windows.Forms.ListBox selectedBox;
    }
}