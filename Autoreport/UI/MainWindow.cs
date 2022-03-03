using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Autoreport.Database;
using Autoreport.UI.Classes;

namespace Autoreport.UI
{
    public partial class MainWindow : Form
    {
        Login Loginer;
        Button currentTabButton;
        Form currentAddForm;
        DataGridViewCellEventHandler tableItemDoubleClickEvent;
        
        public readonly Dictionary<string, Button> tabs;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            tableItemDoubleClickEvent = new DataGridViewCellEventHandler(ItemDoubleClick);

            SetAppearance(1200, 620, 50, 50);
            SetSelectionElementsActive(false);

            Connection.employeerService.Init();

            //Login();

            employeesTab.PerformClick();
        }

        private void SetAppearance(int w, int h, int x, int y)
        {
            this.Size = new Size(w, h);
            this.Location = new Point(x, y);
        }

        private void Login()
        {
            Loginer = new Login();
            Loginer.ShowDialog();
        }

        private void EmployeesTab_Click(object sender, EventArgs e)
        {
            currentTabButton = (Button)sender;
            currentAddForm = new AddEmployeeForm();
            dataGridView.DataSource = Connection.employeerService.GetAll();
            dataGridView.Columns["Id"].Visible = false;
        }

        private void ClientsBtn_Click(object sender, EventArgs e)
        {
            currentTabButton = (Button)sender;
            dataGridView.DataSource = Connection.clientService.GetAll();
            dataGridView.Columns["Id"].Visible = false;
        }

        private void DisksTab_Click(object sender, EventArgs e)
        {
            Console.WriteLine("hehehe");
            currentTabButton = (Button)sender;
            currentAddForm = new AddDiskForm(filmsTab, UpdateTableOnSaveChild);
            dataGridView.DataSource = Connection.diskService.GetAll();
            dataGridView.Columns["Id"].Visible = false;
        }

        private void FilmsTab_Click(object sender, EventArgs e)
        {
            currentTabButton = (Button)sender;
            currentAddForm = new AddFilmForm();
            dataGridView.DataSource = Connection.filmService.GetAll();
            dataGridView.Columns["Id"].Visible = false;
        }

        private void OrdersTab_Click(object sender, EventArgs e)
        {
            currentTabButton = (Button)sender;
            dataGridView.DataSource = Connection.orderService.GetAll();
            dataGridView.Columns["Id"].Visible = false;
        }

        private void DepositsTab_Click(object sender, EventArgs e)
        {
            currentTabButton = (Button)sender;
            dataGridView.DataSource = Connection.depositService.GetAll();
            dataGridView.Columns["Id"].Visible = false;
        }

        /// <summary>
        /// реакция на нажатие кнопки Добавить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBtn_Click(object sender, EventArgs e)
        {
            currentAddForm.ShowDialog(this);
            currentTabButton.PerformClick();
        }

        private void UpdateTableOnSaveChild()
        {
            reloadBtn.PerformClick();
        }

        /// <summary>
        /// Обрабатывает двойной клик по строке таблицы
        /// Создает объект GridSelectedItem, полю Id которого устанавливает значение
        /// элемента выбранной строки с индексом 0, полю VisibleName - значением
        /// элемента с индексом 1
        /// Добавляет созданный объект в ListBox selectedItemsBox,
        /// при условии, что там нет GridSelectedItem с таким же индексом)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
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

        private void ReloadBtn_Click(object sender, EventArgs e)
        {
            currentTabButton.PerformClick();
        }

        /// <summary>
        /// Показывает/скрывает кнопку selectBtn
        /// </summary>
        /// <param name="show"></param>
        private void ShowSelectBtn(bool show)
        {
            if (show)
                selectBtn.Show();
            else
                selectBtn.Hide();
        }

        /// <summary>
        /// Показывает/скрывает панель selectedItemsPanel с ComboBox, 
        /// в который заносятся выбираемые из таблицы строки
        /// </summary>
        /// <param name="show">показать если true / скрыть если false</param>
        private void ShowSelectionBox(bool show)
        {
            if (show)
            {
                selectedItemsBox.Items.Clear();
                selectedItemsPanel.Show();
            }
            else
                selectedItemsPanel.Hide();
        }

        /// <summary>
        /// Показывает/скрывает элементы selectedItemsBox и selectBtn
        /// </summary>
        /// <param name="active"></param>
        private void SetSelectionElementsActive(bool active)
        {
            ShowSelectBtn(active);
            ShowSelectionBox(active);

            if (active)
                ConnectTableItemDblClick();
            else
                DisconnectTableItemDblClick();
        }

        /// <summary>
        /// Делает активными все элементы в панели menuPanel
        /// </summary>
        private void EnableAllTabs()
        {
            foreach (Control tab in menuPanel.Controls)
            {
                tab.Enabled = true;
            }
        }

        /// <summary>
        /// Делает неактивными все кнопки в панели menuPanel за исключением переданной.
        /// У переданной имитирует нажатие
        /// </summary>
        /// <param name="excepted">Кнопка - исключение</param>
        private void DisableAllTabsExcept(Button excepted)
        {
            foreach (Control tab in menuPanel.Controls)
            {
                if (tab != excepted)
                {
                    tab.Enabled = false;
                }
            }

            excepted.PerformClick();
        }

        /// <summary>
        /// Делает неактивными все кнопки в панели controlPanel за исключением массива Control'ов,
        /// которые передаются функции
        /// </summary>
        /// <param name="excepted">Массив кнопок исплючений</param>
        private void DisableAllControlButtonsExcept(Control[] excepted)
        {
            foreach (Control button in controlPanel.Controls)
            {
                if (!excepted.Contains(button))
                {
                    button.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Делает активными все элементы в панели controlPanel
        /// </summary>
        private void EnableAllControlButtons()
        {
            foreach (Control button in controlPanel.Controls)
            {
                button.Enabled = false;
            }
        }

        public void ConnectTableItemDblClick()
        {
            dataGridView.CellDoubleClick += tableItemDoubleClickEvent;
        }

        public void DisconnectTableItemDblClick()
        {
            dataGridView.CellDoubleClick -= tableItemDoubleClickEvent;
        }

        private void ConnectSelectButton(EventHandler Handler)
        {
            selectBtn.Click += Handler;
        }

        private void RemoveSelectConnection(EventHandler Handler)
        {
            selectBtn.Click -= Handler;
        }

        /// <summary>
        /// Замыкающая функция, возвращающая процедуру, переводящую окно 
        /// из начального режима в режим выбора значений из таблицы, 
        /// либо обратно в начальный режим.
        /// </summary>
        /// <param name="Handler"></param>
        /// <returns name="Enabled" type="Action<bool, Button>">
        ///     Функция, примающая аргументы:
        ///         bool - активировать режим выбора если true, иначе - деактивировать
        ///         Button - ссылка на кнопку-вкладку, связанную с таблицей, из которой будут 
        ///         выбираться элементы
        /// </returns>
        public Action<bool, Button> SelectMode(Action<ListBox.ObjectCollection> Handler)
        {
            Button lastTab = currentTabButton;
            EventHandler selectEventHandler = new EventHandler(
                (object sender, EventArgs e) => Handler(selectedItemsBox.Items));

            void Enabled(bool enabled, Button selectTab)
            {
                SetSelectionElementsActive(enabled);

                if (enabled)
                {
                    DisableAllTabsExcept(selectTab);
                    ConnectSelectButton(selectEventHandler);
                }
                else
                {
                    EnableAllTabs();
                    RemoveSelectConnection(selectEventHandler);
                    
                    lastTab.PerformClick();
                }
            }

            return Enabled;
        }
    }
}
