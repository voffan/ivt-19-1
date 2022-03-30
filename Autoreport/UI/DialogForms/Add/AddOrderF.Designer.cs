
using System;
using System.Windows.Forms;

namespace Autoreport.UI
{
    partial class AddOrderF : AddFormSelective
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
            this.orderDateText = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.returnDateText = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.selectedBox_Deposit = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ownerLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.removeSelectedBtn = new System.Windows.Forms.Button();
            this.selectBtn = new System.Windows.Forms.Button();
            this.selectedBox_Disks = new System.Windows.Forms.ListBox();
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
            this.flowLayout.Controls.Add(this.orderDateText);
            this.flowLayout.Controls.Add(this.label2);
            this.flowLayout.Controls.Add(this.returnDateText);
            this.flowLayout.Controls.Add(this.label11);
            this.flowLayout.Controls.Add(this.selectedBox_Deposit);
            this.flowLayout.Controls.Add(this.label4);
            this.flowLayout.Controls.Add(this.ownerLabel);
            this.flowLayout.Controls.Add(this.label3);
            this.flowLayout.Controls.Add(this.panel1);
            this.flowLayout.Controls.Add(this.selectedBox_Disks);
            this.flowLayout.Location = new System.Drawing.Point(12, 12);
            this.flowLayout.Name = "flowLayout";
            this.flowLayout.Size = new System.Drawing.Size(476, 238);
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
            this.label1.Text = "Дата заказа";
            // 
            // orderDateText
            // 
            this.orderDateText.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.orderDateText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.orderDateText.Location = new System.Drawing.Point(241, 3);
            this.orderDateText.MaxDate = new System.DateTime(2090, 12, 31, 0, 0, 0, 0);
            this.orderDateText.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.orderDateText.Name = "orderDateText";
            this.orderDateText.Size = new System.Drawing.Size(232, 25);
            this.orderDateText.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.MinimumSize = new System.Drawing.Size(232, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "Дата возврата";
            // 
            // returnDateText
            // 
            this.returnDateText.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.returnDateText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.returnDateText.Location = new System.Drawing.Point(241, 34);
            this.returnDateText.MaxDate = new System.DateTime(2090, 12, 31, 0, 0, 0, 0);
            this.returnDateText.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.returnDateText.Name = "returnDateText";
            this.returnDateText.Size = new System.Drawing.Size(232, 25);
            this.returnDateText.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(3, 65);
            this.label11.Margin = new System.Windows.Forms.Padding(3);
            this.label11.MinimumSize = new System.Drawing.Size(232, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(232, 25);
            this.label11.TabIndex = 4;
            this.label11.Text = "Залог";
            // 
            // selectedBox_Deposit
            // 
            this.selectedBox_Deposit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectedBox_Deposit.FormattingEnabled = true;
            this.selectedBox_Deposit.IntegralHeight = false;
            this.selectedBox_Deposit.ItemHeight = 17;
            this.selectedBox_Deposit.Location = new System.Drawing.Point(241, 65);
            this.selectedBox_Deposit.Name = "selectedBox_Deposit";
            this.selectedBox_Deposit.Size = new System.Drawing.Size(232, 25);
            this.selectedBox_Deposit.TabIndex = 22;
            this.selectedBox_Deposit.Click += new System.EventHandler(this.selectedBox_Deposit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(3, 96);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.MinimumSize = new System.Drawing.Size(232, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 25);
            this.label4.TabIndex = 21;
            this.label4.Text = "Покупатель";
            // 
            // ownerLabel
            // 
            this.ownerLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ownerLabel.Location = new System.Drawing.Point(241, 93);
            this.ownerLabel.Name = "ownerLabel";
            this.ownerLabel.Size = new System.Drawing.Size(232, 25);
            this.ownerLabel.TabIndex = 23;
            this.ownerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(3, 127);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.MinimumSize = new System.Drawing.Size(232, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Диски";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.removeSelectedBtn);
            this.panel1.Controls.Add(this.selectBtn);
            this.panel1.Location = new System.Drawing.Point(241, 127);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(75, 49);
            this.panel1.TabIndex = 17;
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
            this.selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
            // 
            // selectedBox_Disks
            // 
            this.selectedBox_Disks.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectedBox_Disks.FormattingEnabled = true;
            this.selectedBox_Disks.IntegralHeight = false;
            this.selectedBox_Disks.ItemHeight = 17;
            this.selectedBox_Disks.Location = new System.Drawing.Point(322, 127);
            this.selectedBox_Disks.Name = "selectedBox_Disks";
            this.selectedBox_Disks.Size = new System.Drawing.Size(151, 87);
            this.selectedBox_Disks.TabIndex = 16;
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(12, 256);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(200, 30);
            this.resetBtn.TabIndex = 14;
            this.resetBtn.Text = "Сброс";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(288, 256);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(200, 30);
            this.saveBtn.TabIndex = 13;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // AddOrderF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 297);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.flowLayout);
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(516, 500);
            this.MinimumSize = new System.Drawing.Size(516, 200);
            this.Name = "AddOrderF";
            this.Text = "Добавить заказ";
            this.Load += new System.EventHandler(this.Form_Load);
            this.flowLayout.ResumeLayout(false);
            this.flowLayout.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayout;
        private DateTimePicker orderDateText;
        private Label label2;
        private DateTimePicker returnDateText;
        private Label label4;
        private Label ownerLabel;
        private ListBox selectedBox_Deposit;
        private Label label3;
        private Panel panel1;
        private Button removeSelectedBtn;
        private Button selectBtn;
        private ListBox selectedBox_Disks;
    }
}