namespace PROJECTKOROBKI
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.сотрудникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.отчётToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.отчётToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.выйтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.MistyRose;
			this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сотрудникиToolStripMenuItem,
            this.отчётToolStripMenuItem,
            this.отчётToolStripMenuItem1,
            this.выйтиToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(576, 27);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// сотрудникиToolStripMenuItem
			// 
			this.сотрудникиToolStripMenuItem.Name = "сотрудникиToolStripMenuItem";
			this.сотрудникиToolStripMenuItem.Size = new System.Drawing.Size(103, 23);
			this.сотрудникиToolStripMenuItem.Text = "Сотрудники";
			this.сотрудникиToolStripMenuItem.Click += new System.EventHandler(this.сотрудникиToolStripMenuItem_Click);
			// 
			// отчётToolStripMenuItem
			// 
			this.отчётToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
			this.отчётToolStripMenuItem.Name = "отчётToolStripMenuItem";
			this.отчётToolStripMenuItem.Size = new System.Drawing.Size(79, 23);
			this.отчётToolStripMenuItem.Text = "Коробки";
			this.отчётToolStripMenuItem.Click += new System.EventHandler(this.отчётToolStripMenuItem_Click);
			// 
			// отчётToolStripMenuItem1
			// 
			this.отчётToolStripMenuItem1.Name = "отчётToolStripMenuItem1";
			this.отчётToolStripMenuItem1.Size = new System.Drawing.Size(62, 23);
			this.отчётToolStripMenuItem1.Text = "Отчёт";
			// 
			// выйтиToolStripMenuItem
			// 
			this.выйтиToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.выйтиToolStripMenuItem.BackColor = System.Drawing.Color.MistyRose;
			this.выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
			this.выйтиToolStripMenuItem.Size = new System.Drawing.Size(67, 23);
			this.выйтиToolStripMenuItem.Text = "Выйти";
			this.выйтиToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
			this.выйтиToolStripMenuItem.Click += new System.EventHandler(this.выйтиToolStripMenuItem_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightBlue;
			this.ClientSize = new System.Drawing.Size(576, 373);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Фабрика коробок";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem сотрудникиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem отчётToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem отчётToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem выйтиToolStripMenuItem;
	}
}

