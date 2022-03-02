using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Autoreport.Database;
using Autoreport.UI.Classes;
using Autoreport.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Autoreport.UI
{
    public partial class MainWindow : Form
    {
        Login Loginer;
        Button currentButton;
        Form currentAddForm;
        DataGridViewCellEventHandler tableItemDoubleClickEvent;
        EventHandler selectEventHandler;
        
        public readonly Dictionary<string, Button> tabs;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1200, 620);
            tableItemDoubleClickEvent = new DataGridViewCellEventHandler(itemDoubleClick);

            SetSelectionActive(false);

            Connection.employeerService.Init();

            //Login();

            employeesBtn.PerformClick();
        }

        //public Button GetTab(string tabName)
        //{
        //    foreach (Control tab in menuPanel.Controls)
        //    {
        //        if (tab.GetType() == typeof(Button) && tab.Name == tabName)
        //        {
        //            return (Button)tab;
        //        }
        //    }

        //    return null;
        //}

        private void Login()
        {
            Loginer = new Login();
            Loginer.ShowDialog();
        }

        private void EmployeersBtn_Click(object sender, EventArgs e)
        {
            currentButton = (Button)sender;
            currentAddForm = new AddEmployeeForm();
            dataGridView.DataSource = Connection.employeerService.GetAll();
            dataGridView.Columns["Id"].Visible = false;
        }

        private void ClientsBtn_Click(object sender, EventArgs e)
        {
            currentButton = (Button)sender;
            dataGridView.DataSource = Connection.clientService.GetAll();
            dataGridView.Columns["Id"].Visible = false;
        }

        private void DisksBtn_Click(object sender, EventArgs e)
        {
            currentButton = (Button)sender;
            currentAddForm = new AddDiskForm();
            dataGridView.DataSource = Connection.diskService.GetAll();
            dataGridView.Columns["Id"].Visible = false;
        }

        private void FilmsBtn_Click(object sender, EventArgs e)
        {
            currentButton = (Button)sender;
            dataGridView.DataSource = Connection.filmService.GetAll();
            dataGridView.Columns["Id"].Visible = false;
        }

        private void OrdersBtn_Click(object sender, EventArgs e)
        {
            currentButton = (Button)sender;
            dataGridView.DataSource = Connection.orderService.GetAll();
            dataGridView.Columns["Id"].Visible = false;
        }

        private void DepositsBtn_Click(object sender, EventArgs e)
        {
            currentButton = (Button)sender;
            dataGridView.DataSource = Connection.depositService.GetAll();
            dataGridView.Columns["Id"].Visible = false;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            /*
             * реакция на нажатие кнопки Добавить
             */

            currentAddForm.ShowDialog(this);
            //currentButton.PerformClick();
        }

        private void itemDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
             * обрабатывает двойной клик по строке таблицы
             */

            if (e.RowIndex == -1) return;

            GridSelectedItem item = new GridSelectedItem()
            {
                Id = (int)dataGridView.Rows[e.RowIndex].Cells[0].Value,
                VisibleName = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString()
            };

            if (selectedItemsBox.Items.Cast<GridSelectedItem>().Select(_item => _item.Id == item.Id).Count() != 0)
                return;

            selectedItemsBox.Items.Add(item);
        }

        private void reloadBtn_Click(object sender, EventArgs e)
        {
            currentButton.PerformClick();
        }

        public Button GetCurrentTab()
        {
            return currentButton;
        }

        public void ConnectTableItemDblClick()
        {
            dataGridView.CellDoubleClick += tableItemDoubleClickEvent;
        }

        public void DisconnectTableItemDblClick()
        {
            dataGridView.CellDoubleClick -= tableItemDoubleClickEvent;
        }

        public void SetSelectionActive(bool active)
        {
            ShowSelectBtn(active);
            ShowSelectionBox(active);

            if (active)
                ConnectTableItemDblClick();
            else
                DisconnectTableItemDblClick();
        }

        public void ShowSelectBtn(bool show)
        {
            if (show)
                selectBtn.Show();
            else
                selectBtn.Hide();
        }

        public void ShowSelectionBox(bool show)
        {
            if (show)
            {
                selectedItemsBox.Items.Clear();
                selectedItemsPanel.Show();
            }
            else
                selectedItemsPanel.Hide();
        }

        public void EnableAllTabs()
        {
            foreach (Control tab in menuPanel.Controls)
            {
                tab.Enabled = true;
            }
        }

        public void DisableAllTabsExcept(Button excepted)
        {
            /*
             * делает неактивными все кнопки в панели menuPanel за исключением переданной
             * у переданной имитирует нажатие
             */

            foreach (Control tab in menuPanel.Controls)
            {
                if (tab != excepted)
                {
                    tab.Enabled = false;
                }
            }

            excepted.PerformClick();
        }

        public void DisableAllControlButtonsExcept(Control[] excepted)
        {
            /*
             * делает неактивными все кнопки в панели controlPanel за исключением переданных
             */
            foreach (Control button in controlPanel.Controls)
            {
                if (!excepted.Contains(button))
                {
                    button.Enabled = false;
                }
            }
        }

        public void EnableAllControlButtons()
        {
            foreach (Control button in controlPanel.Controls)
            {
                button.Enabled = false;
            }
        }

        public void ConnectSelectButton(Action<ListBox.ObjectCollection> Handler)
        {
            selectEventHandler = new EventHandler((object sender, EventArgs e) => Handler(selectedItemsBox.Items));
            selectBtn.Click += selectEventHandler;
        }

        public void RemoveSelectConnection()
        {
            selectBtn.Click -= selectEventHandler;
        }
    }
}
