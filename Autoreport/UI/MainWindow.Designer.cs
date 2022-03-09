
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
            this.reportPanel = new System.Windows.Forms.Panel();
            this.reportBtn = new System.Windows.Forms.Button();
            this.depositsTab = new System.Windows.Forms.Button();
            this.ordersTab = new System.Windows.Forms.Button();
            this.filmsTab = new System.Windows.Forms.Button();
            this.disksTab = new System.Windows.Forms.Button();
            this.clientsTab = new System.Windows.Forms.Button();
            this.employeesTab = new System.Windows.Forms.Button();
            this.dataPanel = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.addBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.searchBtn = new System.Windows.Forms.Button();
            this.reloadBtn = new System.Windows.Forms.Button();
            this.selectBtn = new System.Windows.Forms.Button();
            this.infoBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.selectedItemsBox = new System.Windows.Forms.ListBox();
            this.selectedItemsPanel = new System.Windows.Forms.Panel();
            this.menuPanel.SuspendLayout();
            this.reportPanel.SuspendLayout();
            this.dataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.controlPanel.SuspendLayout();
            this.selectedItemsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.AutoSize = true;
            this.menuPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.menuPanel.BackColor = System.Drawing.Color.DarkGray;
            this.menuPanel.Controls.Add(this.reportPanel);
            this.menuPanel.Controls.Add(this.depositsTab);
            this.menuPanel.Controls.Add(this.ordersTab);
            this.menuPanel.Controls.Add(this.filmsTab);
            this.menuPanel.Controls.Add(this.disksTab);
            this.menuPanel.Controls.Add(this.clientsTab);
            this.menuPanel.Controls.Add(this.employeesTab);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(816, 37);
            this.menuPanel.TabIndex = 0;
            // 
            // reportPanel
            // 
            this.reportPanel.Controls.Add(this.reportBtn);
            this.reportPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.reportPanel.Location = new System.Drawing.Point(734, 0);
            this.reportPanel.Name = "reportPanel";
            this.reportPanel.Size = new System.Drawing.Size(82, 37);
            this.reportPanel.TabIndex = 7;
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
            // depositsTab
            // 
            this.depositsTab.Image = global::Autoreport.UI.Resources.deposit;
            this.depositsTab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.depositsTab.Location = new System.Drawing.Point(472, 3);
            this.depositsTab.Name = "depositsTab";
            this.depositsTab.Size = new System.Drawing.Size(80, 31);
            this.depositsTab.TabIndex = 5;
            this.depositsTab.Text = "Залоги";
            this.depositsTab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.depositsTab.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.depositsTab.UseVisualStyleBackColor = true;
            this.depositsTab.Click += new System.EventHandler(this.DepositsTab_Click);
            // 
            // ordersTab
            // 
            this.ordersTab.Image = global::Autoreport.UI.Resources.cart;
            this.ordersTab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ordersTab.Location = new System.Drawing.Point(386, 3);
            this.ordersTab.Name = "ordersTab";
            this.ordersTab.Size = new System.Drawing.Size(80, 31);
            this.ordersTab.TabIndex = 4;
            this.ordersTab.Text = "Заказы";
            this.ordersTab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ordersTab.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ordersTab.UseVisualStyleBackColor = true;
            this.ordersTab.Click += new System.EventHandler(this.OrdersTab_Click);
            // 
            // filmsTab
            // 
            this.filmsTab.Image = global::Autoreport.UI.Resources.film_projector;
            this.filmsTab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.filmsTab.Location = new System.Drawing.Point(292, 3);
            this.filmsTab.Name = "filmsTab";
            this.filmsTab.Size = new System.Drawing.Size(88, 31);
            this.filmsTab.TabIndex = 3;
            this.filmsTab.Text = "Фильмы";
            this.filmsTab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.filmsTab.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.filmsTab.UseVisualStyleBackColor = true;
            this.filmsTab.Click += new System.EventHandler(this.FilmsTab_Click);
            // 
            // disksTab
            // 
            this.disksTab.Image = global::Autoreport.UI.Resources.disk;
            this.disksTab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.disksTab.Location = new System.Drawing.Point(211, 3);
            this.disksTab.Name = "disksTab";
            this.disksTab.Size = new System.Drawing.Size(75, 31);
            this.disksTab.TabIndex = 2;
            this.disksTab.Text = "Диски";
            this.disksTab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.disksTab.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.disksTab.UseVisualStyleBackColor = true;
            this.disksTab.Click += new System.EventHandler(this.DisksTab_Click);
            // 
            // clientsTab
            // 
            this.clientsTab.Image = global::Autoreport.UI.Resources.user_group;
            this.clientsTab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clientsTab.Location = new System.Drawing.Point(116, 4);
            this.clientsTab.Name = "clientsTab";
            this.clientsTab.Size = new System.Drawing.Size(89, 30);
            this.clientsTab.TabIndex = 1;
            this.clientsTab.Text = "Клиенты";
            this.clientsTab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clientsTab.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.clientsTab.UseVisualStyleBackColor = true;
            this.clientsTab.Click += new System.EventHandler(this.ClientsTab_Click);
            // 
            // employeesTab
            // 
            this.employeesTab.Image = global::Autoreport.UI.Resources.worker;
            this.employeesTab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.employeesTab.Location = new System.Drawing.Point(3, 3);
            this.employeesTab.Name = "employeesTab";
            this.employeesTab.Size = new System.Drawing.Size(107, 31);
            this.employeesTab.TabIndex = 0;
            this.employeesTab.Text = "Сотрудники";
            this.employeesTab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.employeesTab.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.employeesTab.UseVisualStyleBackColor = true;
            this.employeesTab.Click += new System.EventHandler(this.EmployeesTab_Click);
            // 
            // dataPanel
            // 
            this.dataPanel.Controls.Add(this.dataGridView);
            this.dataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataPanel.Location = new System.Drawing.Point(0, 37);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(464, 474);
            this.dataPanel.TabIndex = 3;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 60;
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(464, 474);
            this.dataGridView.TabIndex = 0;
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
            this.addBtn.Click += new System.EventHandler(this.AddBtn_Click);
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
            // reloadBtn
            // 
            this.reloadBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.reloadBtn.Location = new System.Drawing.Point(5, 431);
            this.reloadBtn.Name = "reloadBtn";
            this.reloadBtn.Size = new System.Drawing.Size(136, 38);
            this.reloadBtn.TabIndex = 4;
            this.reloadBtn.Text = "Обновить";
            this.reloadBtn.UseVisualStyleBackColor = true;
            this.reloadBtn.Click += new System.EventHandler(this.ReloadBtn_Click);
            // 
            // selectBtn
            // 
            this.selectBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.selectBtn.Location = new System.Drawing.Point(5, 393);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(136, 38);
            this.selectBtn.TabIndex = 5;
            this.selectBtn.Text = "Выбрать";
            this.selectBtn.UseVisualStyleBackColor = true;
            // 
            // infoBtn
            // 
            this.infoBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoBtn.Enabled = false;
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
            this.deleteBtn.Enabled = false;
            this.deleteBtn.Location = new System.Drawing.Point(5, 355);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(136, 38);
            this.deleteBtn.TabIndex = 7;
            this.deleteBtn.Text = "Удалить";
            this.deleteBtn.UseVisualStyleBackColor = true;
            // 
            // controlPanel
            // 
            this.controlPanel.BackColor = System.Drawing.Color.Silver;
            this.controlPanel.Controls.Add(this.deleteBtn);
            this.controlPanel.Controls.Add(this.infoBtn);
            this.controlPanel.Controls.Add(this.selectBtn);
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
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.MaximumSize = new System.Drawing.Size(0, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выбранные элементы";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // selectedItemsBox
            // 
            this.selectedItemsBox.BackColor = System.Drawing.Color.Silver;
            this.selectedItemsBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.selectedItemsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedItemsBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectedItemsBox.FormattingEnabled = true;
            this.selectedItemsBox.ItemHeight = 20;
            this.selectedItemsBox.Location = new System.Drawing.Point(5, 30);
            this.selectedItemsBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.selectedItemsBox.Name = "selectedItemsBox";
            this.selectedItemsBox.Size = new System.Drawing.Size(196, 439);
            this.selectedItemsBox.TabIndex = 1;
            // 
            // selectedItemsPanel
            // 
            this.selectedItemsPanel.BackColor = System.Drawing.Color.Silver;
            this.selectedItemsPanel.Controls.Add(this.selectedItemsBox);
            this.selectedItemsPanel.Controls.Add(this.label1);
            this.selectedItemsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.selectedItemsPanel.Location = new System.Drawing.Point(464, 37);
            this.selectedItemsPanel.Name = "selectedItemsPanel";
            this.selectedItemsPanel.Padding = new System.Windows.Forms.Padding(5);
            this.selectedItemsPanel.Size = new System.Drawing.Size(206, 474);
            this.selectedItemsPanel.TabIndex = 8;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(816, 511);
            this.Controls.Add(this.dataPanel);
            this.Controls.Add(this.selectedItemsPanel);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.menuPanel);
            this.Location = new System.Drawing.Point(50, 50);
            this.MinimumSize = new System.Drawing.Size(650, 400);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuPanel.ResumeLayout(false);
            this.reportPanel.ResumeLayout(false);
            this.reportPanel.PerformLayout();
            this.dataPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.controlPanel.ResumeLayout(false);
            this.selectedItemsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Button reportBtn;
        private System.Windows.Forms.Panel reportPanel;
        private System.Windows.Forms.Panel dataPanel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Button reloadBtn;
        private System.Windows.Forms.Button selectBtn;
        private System.Windows.Forms.Button infoBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox selectedItemsBox;
        private System.Windows.Forms.Panel selectedItemsPanel;
        public System.Windows.Forms.Button employeesTab;
        public System.Windows.Forms.Button depositsTab;
        public System.Windows.Forms.Button ordersTab;
        public System.Windows.Forms.Button filmsTab;
        public System.Windows.Forms.Button disksTab;
        public System.Windows.Forms.Button clientsTab;
    }
}

