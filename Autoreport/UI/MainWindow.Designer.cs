
namespace Autoreport.UI
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.reportBtn = new System.Windows.Forms.Button();
            this.depositsBtn = new System.Windows.Forms.Button();
            this.ordersBtn = new System.Windows.Forms.Button();
            this.filmsBtn = new System.Windows.Forms.Button();
            this.disksBtn = new System.Windows.Forms.Button();
            this.clientsBtn = new System.Windows.Forms.Button();
            this.employeesBtn = new System.Windows.Forms.Button();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.infoBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.reloadBtn = new System.Windows.Forms.Button();
            this.searchBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.menuPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.AutoSize = true;
            this.menuPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.menuPanel.BackColor = System.Drawing.Color.DarkGray;
            this.menuPanel.Controls.Add(this.panel2);
            this.menuPanel.Controls.Add(this.depositsBtn);
            this.menuPanel.Controls.Add(this.ordersBtn);
            this.menuPanel.Controls.Add(this.filmsBtn);
            this.menuPanel.Controls.Add(this.disksBtn);
            this.menuPanel.Controls.Add(this.clientsBtn);
            this.menuPanel.Controls.Add(this.employeesBtn);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(816, 37);
            this.menuPanel.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.reportBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(734, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(82, 37);
            this.panel2.TabIndex = 7;
            // 
            // reportBtn
            // 
            this.reportBtn.AutoSize = true;
            this.reportBtn.Image = global::Autoreport.UI.Resources.report;
            this.reportBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reportBtn.Location = new System.Drawing.Point(5, 3);
            this.reportBtn.Name = "reportBtn";
            this.reportBtn.Size = new System.Drawing.Size(73, 31);
            this.reportBtn.TabIndex = 6;
            this.reportBtn.Text = "Отчет";
            this.reportBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reportBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.reportBtn.UseVisualStyleBackColor = true;
            // 
            // depositsBtn
            // 
            this.depositsBtn.Image = global::Autoreport.UI.Resources.deposit;
            this.depositsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.depositsBtn.Location = new System.Drawing.Point(472, 3);
            this.depositsBtn.Name = "depositsBtn";
            this.depositsBtn.Size = new System.Drawing.Size(80, 31);
            this.depositsBtn.TabIndex = 5;
            this.depositsBtn.Text = "Залоги";
            this.depositsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.depositsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.depositsBtn.UseVisualStyleBackColor = true;
            this.depositsBtn.Click += new System.EventHandler(this.depositsBtn_Click);
            // 
            // ordersBtn
            // 
            this.ordersBtn.Image = global::Autoreport.UI.Resources.cart;
            this.ordersBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ordersBtn.Location = new System.Drawing.Point(386, 3);
            this.ordersBtn.Name = "ordersBtn";
            this.ordersBtn.Size = new System.Drawing.Size(80, 31);
            this.ordersBtn.TabIndex = 4;
            this.ordersBtn.Text = "Заказы";
            this.ordersBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ordersBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ordersBtn.UseVisualStyleBackColor = true;
            this.ordersBtn.Click += new System.EventHandler(this.ordersBtn_Click);
            // 
            // filmsBtn
            // 
            this.filmsBtn.Image = global::Autoreport.UI.Resources.film_projector;
            this.filmsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.filmsBtn.Location = new System.Drawing.Point(292, 3);
            this.filmsBtn.Name = "filmsBtn";
            this.filmsBtn.Size = new System.Drawing.Size(88, 31);
            this.filmsBtn.TabIndex = 3;
            this.filmsBtn.Text = "Фильмы";
            this.filmsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.filmsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.filmsBtn.UseVisualStyleBackColor = true;
            this.filmsBtn.Click += new System.EventHandler(this.filmsBtn_Click);
            // 
            // disksBtn
            // 
            this.disksBtn.Image = global::Autoreport.UI.Resources.disk;
            this.disksBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.disksBtn.Location = new System.Drawing.Point(211, 3);
            this.disksBtn.Name = "disksBtn";
            this.disksBtn.Size = new System.Drawing.Size(75, 31);
            this.disksBtn.TabIndex = 2;
            this.disksBtn.Text = "Диски";
            this.disksBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.disksBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.disksBtn.UseVisualStyleBackColor = true;
            this.disksBtn.Click += new System.EventHandler(this.disksBtn_Click);
            // 
            // clientsBtn
            // 
            this.clientsBtn.Image = global::Autoreport.UI.Resources.user_group;
            this.clientsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clientsBtn.Location = new System.Drawing.Point(116, 4);
            this.clientsBtn.Name = "clientsBtn";
            this.clientsBtn.Size = new System.Drawing.Size(89, 30);
            this.clientsBtn.TabIndex = 1;
            this.clientsBtn.Text = "Клиенты";
            this.clientsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clientsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.clientsBtn.UseVisualStyleBackColor = true;
            this.clientsBtn.Click += new System.EventHandler(this.clientsBtn_Click);
            // 
            // employeesBtn
            // 
            this.employeesBtn.Image = global::Autoreport.UI.Resources.worker;
            this.employeesBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.employeesBtn.Location = new System.Drawing.Point(3, 3);
            this.employeesBtn.Name = "employeesBtn";
            this.employeesBtn.Size = new System.Drawing.Size(107, 31);
            this.employeesBtn.TabIndex = 0;
            this.employeesBtn.Text = "Сотрудники";
            this.employeesBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.employeesBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.employeesBtn.UseVisualStyleBackColor = true;
            this.employeesBtn.Click += new System.EventHandler(this.employeersBtn_Click);
            // 
            // controlPanel
            // 
            this.controlPanel.BackColor = System.Drawing.Color.Silver;
            this.controlPanel.Controls.Add(this.infoBtn);
            this.controlPanel.Controls.Add(this.deleteBtn);
            this.controlPanel.Controls.Add(this.reloadBtn);
            this.controlPanel.Controls.Add(this.searchBtn);
            this.controlPanel.Controls.Add(this.editBtn);
            this.controlPanel.Controls.Add(this.addBtn);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.controlPanel.Location = new System.Drawing.Point(670, 37);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Padding = new System.Windows.Forms.Padding(5);
            this.controlPanel.Size = new System.Drawing.Size(146, 474);
            this.controlPanel.TabIndex = 2;
            // 
            // infoBtn
            // 
            this.infoBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoBtn.Location = new System.Drawing.Point(5, 119);
            this.infoBtn.Name = "infoBtn";
            this.infoBtn.Size = new System.Drawing.Size(136, 38);
            this.infoBtn.TabIndex = 6;
            this.infoBtn.Text = "Подробнее";
            this.infoBtn.UseVisualStyleBackColor = true;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.deleteBtn.Location = new System.Drawing.Point(5, 393);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(136, 38);
            this.deleteBtn.TabIndex = 5;
            this.deleteBtn.Text = "Удалить";
            this.deleteBtn.UseVisualStyleBackColor = true;
            // 
            // reloadBtn
            // 
            this.reloadBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.reloadBtn.Location = new System.Drawing.Point(5, 431);
            this.reloadBtn.Name = "reloadBtn";
            this.reloadBtn.Size = new System.Drawing.Size(136, 38);
            this.reloadBtn.TabIndex = 4;
            this.reloadBtn.Text = "Обновить";
            this.reloadBtn.UseVisualStyleBackColor = true;
            this.reloadBtn.Click += new System.EventHandler(this.reloadBtn_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchBtn.Location = new System.Drawing.Point(5, 81);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(136, 38);
            this.searchBtn.TabIndex = 3;
            this.searchBtn.Text = "Поиск";
            this.searchBtn.UseVisualStyleBackColor = true;
            // 
            // editBtn
            // 
            this.editBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.editBtn.Location = new System.Drawing.Point(5, 43);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(136, 38);
            this.editBtn.TabIndex = 2;
            this.editBtn.Text = "Редактировать";
            this.editBtn.UseVisualStyleBackColor = true;
            // 
            // addBtn
            // 
            this.addBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.addBtn.Location = new System.Drawing.Point(5, 5);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(136, 38);
            this.addBtn.TabIndex = 0;
            this.addBtn.Text = "Добавить";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridView);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 37);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(670, 474);
            this.panel4.TabIndex = 3;
            // 
            // dataGridView
            // 
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(670, 474);
            this.dataGridView.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(816, 511);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.menuPanel);
            this.MinimumSize = new System.Drawing.Size(650, 400);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.controlPanel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Button employeesBtn;
        private System.Windows.Forms.Button depositsBtn;
        private System.Windows.Forms.Button ordersBtn;
        private System.Windows.Forms.Button filmsBtn;
        private System.Windows.Forms.Button disksBtn;
        private System.Windows.Forms.Button clientsBtn;
        private System.Windows.Forms.Button reportBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button reloadBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button infoBtn;
    }
}

