using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Autoreport.Database;
using Autoreport.UI.Classes;
using Autoreport.Models;

namespace Autoreport.UI
{
    public partial class MainWindow : Form
    {
        Login Loginer;

        Button currentTabButton;
        Form currentAddForm;
        Action<int> currentDeleteAction;

        DataGridViewCellEventHandler tableItemDoubleClickEvent;
        EventHandler tableItemSelectEvent;
        EventHandler selectedItemSelectEvent;

        List<Button> permissions = new List<Button>();
        List<Button> secondaryTabs;
        
        public readonly Dictionary<string, Button> tabs;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            tableItemDoubleClickEvent = new DataGridViewCellEventHandler(DataGridItemDoubleClick);
            tableItemSelectEvent = new EventHandler(DataGridItemSelectd);
            selectedItemSelectEvent = new EventHandler(SelectBoxItemSelected);
            secondaryTabs = new List<Button>() { filmDirectorsSecondaryTab };

            SetAppearance(1200, 620, 50, 50);
            SetSelectionElementsActive(false);

            Connection.employeeService.Init();

            Login();

            if (permissions.Count > 0)
                permissions[0].PerformClick();
            else // срабатывает только когда закоменчиваем Login()
            {
                permissions.AddRange(new List<Button>()
                {
                    this.clientsTab, this.depositsTab, this.employeesTab,
                    this.disksTab, this.filmsTab, this.ordersTab
                });
                permissions[0].PerformClick();
            }

            HideSecondaryTabs();
        }

        private void SetAppearance(int w, int h, int x, int y)
        {
            this.Size = new Size(w, h);
            this.Location = new Point(x, y);
        }

        private void HideSecondaryTabs()
        {
            foreach (Button secondaryTab in secondaryTabs)
            {
                secondaryTab.Enabled = false;
                secondaryTab.Hide();
            }
        }

        private void Login()
        {
            Loginer = new Login();
            Loginer.ShowDialog();

            SetPermissions();
            ShowAvailableTabs();
            CalculateMinSize();
        }

        /// <summary>
        /// Подсчитывает минимальный размер окна на основе видимых табов
        /// </summary>
        private void CalculateMinSize()
        {
            int minWindowWidth = 6 + 16; // menupanel left and right margin + window borders

            foreach (Control obj in menuPanel.Controls)
            {
                if (obj.Visible)
                    minWindowWidth += obj.Size.Width;
            }

            Size size = new Size { Width = minWindowWidth, Height = this.MinimumSize.Height };
            this.MinimumSize = size;
        }

        /// <summary>
        /// После авторизации устанавливает табы, доступные текущему эмплоеру
        /// </summary>
        private void SetPermissions()
        {
            if (Connection.employeeService.CurrentEmployee.EmplPosition == Position.Admin)
            {
                permissions.AddRange(new List<Button>()
                {
                    this.clientsTab, this.depositsTab, this.employeesTab,
                    this.disksTab, this.filmsTab, this.ordersTab
                });
            } 
            else if (Connection.employeeService.CurrentEmployee.EmplPosition == Position.Cashier)
            {
                permissions.AddRange(new List<Button>()
                {
                    this.clientsTab, this.depositsTab, this.disksTab, 
                    this.filmsTab, this.ordersTab
                });
            }
        }

        /// <summary>
        /// Делает видимыми только те табы, которые находятся в списке permissions
        /// </summary>
        private void ShowAvailableTabs()
        {
            for (int i = 0; i < menuPanel.Controls.Count; i++)
            {
                if (menuPanel.Controls[i].GetType() == typeof(Button))
                {
                    if (!permissions.Contains(menuPanel.Controls[i]))
                    {
                        menuPanel.Controls[i].Enabled = false;
                        menuPanel.Controls[i].Hide();
                    }
                }
            }
        }

        private void TabClicked(Button btn)
        {
            currentTabButton = btn;
            dataGridView.Columns["Id"].DisplayIndex = 0;
            dataGridView.Columns["Id"].Visible = false;
        }

        private void EmployeesTab_Click(object sender, EventArgs e)
        {
            deleteBtn.Enabled = false;
            currentAddForm = new AddEmployeeForm();
            currentDeleteAction = Connection.employeeService.Delete;
            dataGridView.DataSource = Connection.employeeService.GetAll();

            TabClicked((Button)sender);
            Action<DataGridViewColumn> SetCharacteristic = CharacteristicSetter();

            SetCharacteristic(dataGridView.Columns["First_name"]);
            SetCharacteristic(dataGridView.Columns["Last_name"]);
            SetCharacteristic(dataGridView.Columns["Middle_name"]);
            SetCharacteristic(dataGridView.Columns["EmplPosition"]);
        }

        private void ClientsTab_Click(object sender, EventArgs e)
        {
            deleteBtn.Enabled = false;
            currentAddForm = new AddClientForm();
            dataGridView.DataSource = Connection.clientService.GetAll();

            TabClicked((Button)sender);
            Action<DataGridViewColumn> SetCharacteristic = CharacteristicSetter();

            SetCharacteristic(dataGridView.Columns["First_name"]);
            SetCharacteristic(dataGridView.Columns["Last_name"]);
            SetCharacteristic(dataGridView.Columns["Middle_name"]);
            SetCharacteristic(dataGridView.Columns["Phone_number1"]);
        }

        private void DisksTab_Click(object sender, EventArgs e)
        {
            deleteBtn.Enabled = false;
            currentAddForm = new AddDiskForm(filmsTab, reloadBtn.PerformClick);
            dataGridView.DataSource = Connection.diskService.GetAll();

            TabClicked((Button)sender);
            Action<DataGridViewColumn> SetCharacteristic = CharacteristicSetter();

            SetCharacteristic(dataGridView.Columns["Article"]);
        }

        private void FilmsTab_Click(object sender, EventArgs e)
        {
            deleteBtn.Enabled = false;
            currentAddForm = new AddFilmForm(filmDirectorsSecondaryTab, reloadBtn.PerformClick);
            dataGridView.DataSource = Connection.filmService.GetAll();

            TabClicked((Button)sender);
            Action<DataGridViewColumn> SetCharacteristic = CharacteristicSetter();

            SetCharacteristic(dataGridView.Columns["Name"]);
            SetCharacteristic(dataGridView.Columns["Date"]);
        }

        private void OrdersTab_Click(object sender, EventArgs e)
        {
            deleteBtn.Enabled = false;
            dataGridView.DataSource = Connection.orderService.GetAll();

            TabClicked((Button)sender);
        }

        private void DepositsTab_Click(object sender, EventArgs e)
        {
            deleteBtn.Enabled = false;
            currentAddForm = new AddDepositForm(clientsTab, reloadBtn.PerformClick);
            dataGridView.DataSource = Connection.depositService.GetAll();
            TabClicked((Button)sender);
            dataGridView.Columns["Id"].DisplayIndex = 0;
            dataGridView.Columns["Id"].Visible = false;

            Action<DataGridViewColumn> SetCharacteristic = CharacteristicSetter();

            SetCharacteristic(dataGridView.Columns["Data"]);
        }

        private void filmDirectorsSecondaryTab_Click(object sender, EventArgs e)
        {
            deleteBtn.Enabled = false;
            dataGridView.DataSource = Connection.filmService.GetFilmsDirectors();

            TabClicked((Button)sender);
            Action<DataGridViewColumn> SetCharacteristic = CharacteristicSetter();

            SetCharacteristic(dataGridView.Columns["First_name"]);
            SetCharacteristic(dataGridView.Columns["Last_name"]);
            SetCharacteristic(dataGridView.Columns["Middle_name"]);
        }

        /// <summary>
        /// Замыкающая функция, устанавливающая значение "Characteristic" для
        /// свойства Tag столбцов таблицы. Столбцы с тэгом Characteristic
        /// могут понадобиться пользователю в первую очередь, поэтому они расположены
        /// друг за другом и идут первыми после невидимого поля Id, индекс которого 0.
        /// </summary>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        private Action<DataGridViewColumn> CharacteristicSetter(int startIndex = 1)
        {
            int index = startIndex;

            void Set(DataGridViewColumn column)
            {
                column.Tag = "Characteristic";
                column.DisplayIndex = index;
                index++;
            }

            return Set;
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

        private void DataGridItemSelectd(object sender, EventArgs e)
        {
            selectBtn.Enabled = true;
        }

        private void SelectBoxItemSelected(object sender, EventArgs e)
        {
            removeFromSelectedBtn.Enabled = true;
        }

        /// <summary>
        /// Обрабатывает двойной клик по строке таблицы
        /// Создает объект GridSelectedItem
        /// Полю GridSelectedItem.Id устанавливается значение Id выбранной строки
        /// Поле GridSelectedItem.visibleName соответствует конкатенация значений тех полей,
        /// свойство Tag которых установлено в значение "Characteristic"
        /// Добавляет созданный объект в ListBox selectedItemsBox,
        /// при условии, что там нет GridSelectedItem с таким же индексом)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridItemDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            int Id = (int)dataGridView.Rows[e.RowIndex].Cells["Id"].Value;

            if (selectedItemsBox.Items.Cast<GridSelectedItem>().Count(_item => _item.Id == Id) != 0)
                return;

            string visibleName = "";

            foreach (DataGridViewCell cell in dataGridView.Rows[e.RowIndex].Cells) {
                if (cell.OwningColumn.Tag != null &&
                    cell.OwningColumn.Tag.ToString() == "Characteristic")
                {
                    visibleName += cell.FormattedValue + " ";
                }
            }

            visibleName.TrimEnd(); // удаляем последний пробел

            GridSelectedItem item = new GridSelectedItem()
            {
                Id = Id,
                VisibleName = visibleName
            };

            selectedItemsBox.Items.Add(item);
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dataGridView.SelectedCells)
            {
                DataGridItemDoubleClick(null, new DataGridViewCellEventArgs(cell.ColumnIndex, cell.RowIndex));
            }
        }

        private void removeFromSelectedBtn_Click(object sender, EventArgs e)
        {
            selectedItemsBox.Items.RemoveAt(selectedItemsBox.SelectedIndex);
        }

        private void ReloadBtn_Click(object sender, EventArgs e)
        {
            currentTabButton.PerformClick();
        }

        /// <summary>
        /// Показывает/скрывает кнопку selectBtn
        /// </summary>
        /// <param name="show"></param>
        private void ShowDoneBtn(bool show)
        {
            if (show)
                doneBtn.Show();
            else
                doneBtn.Hide();
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

        private void ConnectTableItemClick()
        {
            dataGridView.CellDoubleClick += tableItemDoubleClickEvent;
            dataGridView.SelectionChanged += tableItemSelectEvent;
        }

        private void DisconnectTableItemClick()
        {
            dataGridView.CellDoubleClick -= tableItemDoubleClickEvent;
            dataGridView.SelectionChanged -= tableItemSelectEvent;
        }

        private void ConnectSelectedItemClick()
        {
            selectedItemsBox.SelectedIndexChanged += selectedItemSelectEvent;
        }

        private void DisonnectSelectedItemClick()
        {
            selectedItemsBox.SelectedIndexChanged -= selectedItemSelectEvent;
        }

        /// <summary>
        /// Показывает/скрывает элементы selectedItemsBox и selectBtn
        /// </summary>
        /// <param name="active"></param>
        private void SetSelectionElementsActive(bool active)
        {
            ShowDoneBtn(active);
            ShowSelectionBox(active);

            if (active)
            {
                ConnectTableItemClick();
                ConnectSelectedItemClick();
            }
            else
            {
                DisconnectTableItemClick();
                DisonnectSelectedItemClick();

                selectBtn.Enabled = false;
                removeFromSelectedBtn.Enabled = false;
            }    
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

            HideSecondaryTabs();
        }

        /// <summary>
        /// Делает неактивными все кнопки в панели menuPanel за исключением переданной.
        /// У переданной имитирует нажатие
        /// </summary>
        /// <param name="excepted">Кнопка - исключение</param>
        private void DisableAllTabsExcept(Button excepted)
        {
            DisableButtonsOfPanelExcept(new Button[] { excepted }, menuPanel);

            excepted.Show(); // вкладка Режиссеров скрыта, ее надо показать
            excepted.PerformClick();
        }

        /// <summary>
        /// Делает неактивными все кнопки в панели controlPanel
        /// </summary>
        /// <param name="excepted"></param>
        private void DisableAllControlButtonsExcept(Button[] excepted)
        {
            DisableButtonsOfPanelExcept(excepted, controlPanel);
        }

        /// <summary>
        /// Делает неактивными все кнопки внутри переданной панели,
        /// это касается также тех кнопок, которые находятся внутри других
        /// панелей переданной панели
        /// </summary>
        /// <param name="excepted">Массив кнопок, которые нужно оставить активными</param>
        /// <param name="panel">Панель, внутри которой требуется искать кнопки</param>
        private void DisableButtonsOfPanelExcept(Button[] excepted, Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    control.Enabled = excepted.Contains(control);
                }
                else if (control.GetType() == typeof(Panel))
                {
                    DisableButtonsOfPanelExcept(excepted, (Panel)control);
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

        private void ConnectDoneButton(EventHandler Handler)
        {
            doneBtn.Click += Handler;
        }

        private void DisconnectDoneButton(EventHandler Handler)
        {
            doneBtn.Click -= Handler;
        }

        /// <summary>
        /// Замыкающая функция, возвращающая процедуру, переводящую окно 
        /// из начального режима в режим выбора значений из таблицы, 
        /// либо обратно в начальный режим.
        /// </summary>
        /// <param name="Handler">Функция дочерней формы, которая вызывается при нажатии кнопки "Готово"</param>
        /// <returns name="Set" type="Action<bool, Button>">
        ///     Функция, примающая аргументы:
        ///         bool - активировать режим выбора если true, иначе - деактивировать
        ///         Button - ссылка на кнопку-вкладку, связанную с таблицей, из которой будут 
        ///         выбираться элементы
        /// </returns>
        public Action<bool, Button> SelectMode(Action<ListBox.ObjectCollection> Handler)
        {
            Button lastTab = currentTabButton;
            EventHandler doneEventHandler = new EventHandler(
                (object sender, EventArgs e) => Handler(selectedItemsBox.Items));

            void Turn(bool enabled, Button selectTab)
            {
                SetSelectionElementsActive(enabled);

                if (enabled)
                {
                    if (selectTab == null)
                    {
                        throw new ArgumentNullException("Когда первый аргумент равен true, второй аргумент не может быть null");
                    }

                    DisableAllTabsExcept(selectTab);
                    ConnectDoneButton(doneEventHandler);
                }
                else
                {
                    EnableAllTabs();
                    DisconnectDoneButton(doneEventHandler);
                    
                    lastTab.PerformClick();
                }
            }

            return Turn;
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
                deleteBtn.Enabled = false;
            else
                deleteBtn.Enabled = true;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                currentDeleteAction((int)row.Cells["Id"].Value);
            }

            reloadBtn.PerformClick();
        }
    }
}
