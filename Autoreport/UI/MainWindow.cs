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
    public enum SelectMode
    {
        Enabled,
        Disabled
    }

    public partial class MainWindow : Form
    {
        Login Loginer;

        Button currentTabButton;
        Form currentAddForm;
        Action<int> currentDeleteAction;

        List<Button> permittedTabs = new List<Button>(); // вкладки, доступные пользователю
        List<Button> currentlyPermittedActions = new List<Button>(); // действия, доступные на какой-либо вкладке
        List<Button> secondaryTabs; // вкладки, отображающиеся только при определенных условиях

        Dictionary<Button, Action> tabAction = new Dictionary<Button, Action>();

        DataGridViewCellEventHandler tableItemDoubleClickEvent; // даблклик по строке таблицы
        EventHandler tableItemSelectEvent; // выбор строки из таблицы
        EventHandler selectedItemSelectEvent; // выбор строки из списка selectedItemBox

        public readonly Dictionary<string, Button> tabs;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            secondaryTabs = new List<Button>() { filmDirectorsSecondaryTab };

            SetTabAction();
            SetEventHandlers();
            SetAppearance(1200, 620, 50, 50);
            SetSelectionElementsActive(false);

            Connection.employeeService.Init();
            Login();

            if (permittedTabs.Count > 0)
                permittedTabs[0].PerformClick();
            else // срабатывает только когда закоменчиваем Login()
            {
                permittedTabs.AddRange(new List<Button>()
                {
                    this.clientsTab, this.depositsTab, this.employeesTab,
                    this.disksTab, this.filmsTab, this.ordersTab
                });
                permittedTabs[0].PerformClick();
            }

            HideSecondaryTabs();
        }

        private void SetTabAction()
        {
            tabAction.Add(employeesTab, EmployeesTab_Click);
            tabAction.Add(clientsTab, ClientsTab_Click);
            tabAction.Add(disksTab, DisksTab_Click);
            tabAction.Add(filmsTab, FilmsTab_Click);
            tabAction.Add(ordersTab, OrdersTab_Click);
            tabAction.Add(depositsTab, DepositsTab_Click);
            tabAction.Add(filmDirectorsSecondaryTab, FilmDirectorsSecondaryTab_Click);
        }

        private void SetEventHandlers()
        {
            tableItemDoubleClickEvent = new DataGridViewCellEventHandler(DataGridItemDoubleClick);
            tableItemSelectEvent = new EventHandler(DataGridItemSelectd);
            selectedItemSelectEvent = new EventHandler(SelectBoxItemSelected);
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

            CalculateMinSize(); // т.к. количество табов могло уменьшиться, пересчитываем размер
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

            minWindowWidth += reportPanel.Width;

            foreach (Control obj in tabsLayout.Controls)
            {
                if (obj.Visible)
                    minWindowWidth += obj.Size.Width + 6;
            }

            Size size = new Size { Width = minWindowWidth, Height = this.MinimumSize.Height };
            this.MinimumSize = size;

            if (this.Size.Width < size.Width)
            {
                this.Size = size;
            }
        }

        /// <summary>
        /// После авторизации устанавливает табы, доступные текущему эмплоеру
        /// </summary>
        private void SetPermissions()
        {
            if (Connection.employeeService.CurrentEmployee.EmplPosition == Position.Admin)
            {
                permittedTabs.AddRange(new List<Button>()
                {
                    this.clientsTab, this.depositsTab, this.employeesTab,
                    this.disksTab, this.filmsTab, this.ordersTab
                });
            } 
            else if (Connection.employeeService.CurrentEmployee.EmplPosition == Position.Cashier)
            {
                permittedTabs.AddRange(new List<Button>()
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
            for (int i = 0; i < tabsLayout.Controls.Count; i++)
            {
                if (!permittedTabs.Contains(tabsLayout.Controls[i]))
                {
                    tabsLayout.Controls[i].Enabled = false;
                    tabsLayout.Controls[i].Hide();
                }
            }
        }

        private void TabClicked(object sender, EventArgs e)
        {
            currentlyPermittedActions.Clear();

            if (currentTabButton != null)
                currentTabButton.BackColor = Color.Gainsboro;

            currentTabButton = (Button)sender;
            currentTabButton.BackColor = Color.WhiteSmoke;

            tabAction[currentTabButton](); // вызываем метод, связанный с вкладкой
            DisableAllControlButtonsExcept(currentlyPermittedActions.ToArray());

            if (dataGridView.SelectedRows.Count == 0 || !currentlyPermittedActions.Contains(deleteBtn))
                deleteBtn.Enabled = false;

            dataGridView.Columns["Id"].DisplayIndex = 0;
            dataGridView.Columns["Id"].Visible = false;
        }

        private void EmployeesTab_Click()
        {
            currentlyPermittedActions.AddRange(new List<Button>() { addBtn, editBtn, searchBtn, reloadBtn });

            //deleteBtn.Enabled = false;
            currentAddForm = new AddEmployeeForm();
            currentDeleteAction = Connection.employeeService.Delete;
            dataGridView.DataSource = Connection.employeeService.GetAll();

            Action<DataGridViewColumn> SetCharacteristic = CharacteristicSetter();

            SetCharacteristic(dataGridView.Columns["First_name"]);
            SetCharacteristic(dataGridView.Columns["Last_name"]);
            SetCharacteristic(dataGridView.Columns["Middle_name"]);
            SetCharacteristic(dataGridView.Columns["EmplPosition"]);
        }

        private void ClientsTab_Click()
        {
            currentlyPermittedActions.AddRange(new List<Button>() { 
                addBtn, editBtn, searchBtn, reloadBtn, deleteBtn, doneBtn 
            });

            currentAddForm = new AddClientForm();
            currentDeleteAction = Connection.clientService.Delete;
            dataGridView.DataSource = Connection.clientService.GetAll();

            Action<DataGridViewColumn> SetCharacteristic = CharacteristicSetter();

            SetCharacteristic(dataGridView.Columns["First_name"]);
            SetCharacteristic(dataGridView.Columns["Last_name"]);
            SetCharacteristic(dataGridView.Columns["Middle_name"]);
            SetCharacteristic(dataGridView.Columns["Phone_number1"]);
        }

        private void DisksTab_Click()
        {
            currentlyPermittedActions.AddRange(new List<Button>() { 
                addBtn, editBtn, searchBtn, reloadBtn, infoBtn, deleteBtn, doneBtn 
            });

            currentAddForm = new AddDiskForm(filmsTab, reloadBtn.PerformClick);
            currentDeleteAction = Connection.diskService.Delete;
            dataGridView.DataSource = Connection.diskService.GetAll();

            Action<DataGridViewColumn> SetCharacteristic = CharacteristicSetter();

            SetCharacteristic(dataGridView.Columns["Article"]);
        }

        private void FilmsTab_Click()
        {
            currentlyPermittedActions.AddRange(new List<Button>() { 
                addBtn, editBtn, searchBtn, reloadBtn, infoBtn, doneBtn 
            });

            currentAddForm = new AddFilmForm(filmDirectorsSecondaryTab, reloadBtn.PerformClick);
            currentDeleteAction = Connection.filmService.Delete;
            dataGridView.DataSource = Connection.filmService.GetAll();

            Action<DataGridViewColumn> SetCharacteristic = CharacteristicSetter();

            SetCharacteristic(dataGridView.Columns["Name"]);
            SetCharacteristic(dataGridView.Columns["Date"]);
        }

        private void OrdersTab_Click()
        {
            currentlyPermittedActions.AddRange(new List<Button>() { 
                addBtn, editBtn, searchBtn, reloadBtn, infoBtn 
            });

            currentDeleteAction = Connection.orderService.Delete;
            dataGridView.DataSource = Connection.orderService.GetAll();
        }

        private void DepositsTab_Click()
        {
            currentlyPermittedActions.AddRange(new List<Button>() {
                addBtn, editBtn, searchBtn, reloadBtn, infoBtn, doneBtn 
            });

            currentAddForm = new AddDepositForm(clientsTab, reloadBtn.PerformClick);
            currentDeleteAction = Connection.depositService.Delete;
            dataGridView.DataSource = Connection.depositService.GetAll();

            dataGridView.Columns["Id"].DisplayIndex = 0;
            dataGridView.Columns["Id"].Visible = false;

            Action<DataGridViewColumn> SetCharacteristic = CharacteristicSetter();

            SetCharacteristic(dataGridView.Columns["Data"]);
        }

        private void FilmDirectorsSecondaryTab_Click()
        {
            currentlyPermittedActions.AddRange(new List<Button>() { 
                addBtn, editBtn, searchBtn, reloadBtn, selectBtn, doneBtn
            });
            
            currentAddForm = new AddFilmDirectorForm();
            dataGridView.DataSource = Connection.filmService.GetFilmsDirectors();

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
            foreach (Control tab in tabsLayout.Controls)
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
            if (!excepted.Visible)
            {
                excepted.Show(); // вкладка Режиссеров скрыта, ее надо показать
                CalculateMinSize(); // т.к. появилась новая вкладка, то надо пересчитать минимальный размер
            }

            DisableButtonsOfPanelExcept(new Button[] { excepted }, tabsLayout);
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
        /// Делает неактивными все видимые кнопки внутри переданной панели,
        /// это касается также тех кнопок, которые находятся внутри других
        /// панелей переданной панели
        /// </summary>
        /// <param name="excepted">Массив кнопок, которые нужно оставить активными</param>
        /// <param name="panel">Панель, внутри которой требуется искать кнопки</param>
        private void DisableButtonsOfPanelExcept(Button[] excepted, Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                if (control.GetType() == typeof(Button) && control.Visible)
                {
                    control.Enabled = excepted.Contains(control);
                }
                else if (typeof(Panel).IsAssignableFrom(control.GetType()))
                {
                    DisableButtonsOfPanelExcept(excepted, (Panel)control);
                }
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
        /// <returns name="Set" type="Action<SelectMode, Button>">
        ///     Функция, примающая аргументы:
        ///         bool - активировать режим выбора если true, иначе - деактивировать
        ///         Button - ссылка на кнопку-вкладку, связанную с таблицей, из которой будут 
        ///         выбираться элементы
        /// </returns>
        public Action<SelectMode, Button> SelectMode(Action<ListBox.ObjectCollection> Handler)
        {
            Button lastTab = currentTabButton;
            EventHandler doneEventHandler = new EventHandler(
                (object sender, EventArgs e) => Handler(selectedItemsBox.Items));

            void Turn(SelectMode state, Button selectTab)
            {
                bool is_enabled = state == UI.SelectMode.Enabled;

                if (is_enabled)
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

                SetSelectionElementsActive(is_enabled);
            }

            return Turn;
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (!currentlyPermittedActions.Contains(deleteBtn))
                return;

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
