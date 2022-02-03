
namespace PROJECTKOROBKI
{
	partial class Form4
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.коробкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.выйтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.бригадаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.бригада1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.бригада2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.бригада3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Fullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.hbday = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.MistyRose;
			this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.коробкиToolStripMenuItem,
            this.выйтиToolStripMenuItem,
            this.бригадаToolStripMenuItem,
            this.добавитьToolStripMenuItem,
            this.редактироватьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(861, 27);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// коробкиToolStripMenuItem
			// 
			this.коробкиToolStripMenuItem.Name = "коробкиToolStripMenuItem";
			this.коробкиToolStripMenuItem.Size = new System.Drawing.Size(60, 23);
			this.коробкиToolStripMenuItem.Text = "Назад";
			this.коробкиToolStripMenuItem.Click += new System.EventHandler(this.коробкиToolStripMenuItem_Click);
			// 
			// выйтиToolStripMenuItem
			// 
			this.выйтиToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.выйтиToolStripMenuItem.BackColor = System.Drawing.Color.MistyRose;
			this.выйтиToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.выйтиToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
			this.выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
			this.выйтиToolStripMenuItem.Size = new System.Drawing.Size(71, 23);
			this.выйтиToolStripMenuItem.Text = "Выйти";
			this.выйтиToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
			this.выйтиToolStripMenuItem.Click += new System.EventHandler(this.выйтиToolStripMenuItem_Click);
			// 
			// бригадаToolStripMenuItem
			// 
			this.бригадаToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.бригадаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.бригада1ToolStripMenuItem,
            this.бригада2ToolStripMenuItem,
            this.бригада3ToolStripMenuItem});
			this.бригадаToolStripMenuItem.Name = "бригадаToolStripMenuItem";
			this.бригадаToolStripMenuItem.Size = new System.Drawing.Size(75, 23);
			this.бригадаToolStripMenuItem.Text = "Бригада";
			// 
			// бригада1ToolStripMenuItem
			// 
			this.бригада1ToolStripMenuItem.Name = "бригада1ToolStripMenuItem";
			this.бригада1ToolStripMenuItem.Size = new System.Drawing.Size(144, 24);
			this.бригада1ToolStripMenuItem.Text = "Бригада 1";
			this.бригада1ToolStripMenuItem.Click += new System.EventHandler(this.бригада1ToolStripMenuItem_Click);
			// 
			// бригада2ToolStripMenuItem
			// 
			this.бригада2ToolStripMenuItem.Name = "бригада2ToolStripMenuItem";
			this.бригада2ToolStripMenuItem.Size = new System.Drawing.Size(144, 24);
			this.бригада2ToolStripMenuItem.Text = "Бригада 2";
			this.бригада2ToolStripMenuItem.Click += new System.EventHandler(this.бригада2ToolStripMenuItem_Click);
			// 
			// бригада3ToolStripMenuItem
			// 
			this.бригада3ToolStripMenuItem.Name = "бригада3ToolStripMenuItem";
			this.бригада3ToolStripMenuItem.Size = new System.Drawing.Size(144, 24);
			this.бригада3ToolStripMenuItem.Text = "Бригада 3";
			this.бригада3ToolStripMenuItem.Click += new System.EventHandler(this.бригада3ToolStripMenuItem_Click);
			// 
			// добавитьToolStripMenuItem
			// 
			this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
			this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(86, 23);
			this.добавитьToolStripMenuItem.Text = "Добавить";
			this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
			// 
			// редактироватьToolStripMenuItem
			// 
			this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
			this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(120, 23);
			this.редактироватьToolStripMenuItem.Text = "Редактировать";
			this.редактироватьToolStripMenuItem.Click += new System.EventHandler(this.редактироватьToolStripMenuItem_Click);
			// 
			// удалитьToolStripMenuItem
			// 
			this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
			this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(76, 23);
			this.удалитьToolStripMenuItem.Text = "Удалить";
			this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeColumns = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView1.BackgroundColor = System.Drawing.Color.LightBlue;
			this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkCyan;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Fullname,
            this.hbday,
            this.Position});
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightBlue;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkCyan;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.EnableHeadersVisualStyles = false;
			this.dataGridView1.GridColor = System.Drawing.Color.DimGray;
			this.dataGridView1.Location = new System.Drawing.Point(0, 27);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkCyan;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridView1.RowHeadersWidth = 30;
			this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightBlue;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DarkCyan;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
			this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
			this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkCyan;
			this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			this.dataGridView1.Size = new System.Drawing.Size(861, 439);
			this.dataGridView1.TabIndex = 3;
			// 
			// id
			// 
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.Transparent;
			this.id.DefaultCellStyle = dataGridViewCellStyle3;
			this.id.HeaderText = "id";
			this.id.Name = "id";
			this.id.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.id.Width = 50;
			// 
			// Fullname
			// 
			this.Fullname.HeaderText = "ФИО";
			this.Fullname.Name = "Fullname";
			this.Fullname.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Fullname.Width = 400;
			// 
			// hbday
			// 
			this.hbday.HeaderText = "Год рождения";
			this.hbday.Name = "hbday";
			// 
			// Position
			// 
			this.Position.HeaderText = "Должность";
			this.Position.Name = "Position";
			this.Position.Width = 150;
			// 
			// Form4
			// 
			this.ClientSize = new System.Drawing.Size(861, 466);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.menuStrip1);
			this.Name = "Form4";
			this.Load += new System.EventHandler(this.Form4_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem коробкиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem выйтиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem бригадаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem бригада1ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem бригада2ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem бригада3ToolStripMenuItem;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn Fullname;
		private System.Windows.Forms.DataGridViewTextBoxColumn hbday;
		private System.Windows.Forms.DataGridViewTextBoxColumn Position;
	}
}
