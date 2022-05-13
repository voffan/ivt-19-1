
namespace Korobki_project.UI
{
	partial class Filter
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
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "По дням",
            "По месяцам",
            "По годам",
            "По полгода",
            "По кварталам"});
			this.comboBox1.Location = new System.Drawing.Point(12, 12);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(319, 23);
			this.comboBox1.TabIndex = 1;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.CustomFormat = "yyyy";
			this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker2.Location = new System.Drawing.Point(71, 76);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(200, 23);
			this.dateTimePicker2.TabIndex = 2;
			this.dateTimePicker2.Value = new System.DateTime(2022, 5, 13, 15, 23, 39, 0);
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(33, 125);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(274, 23);
			this.comboBox2.TabIndex = 3;
			// 
			// Filter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(343, 363);
			this.Controls.Add(this.comboBox2);
			this.Controls.Add(this.dateTimePicker2);
			this.Controls.Add(this.comboBox1);
			this.Name = "Filter";
			this.Text = "Filter";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.ComboBox comboBox2;
	}
}