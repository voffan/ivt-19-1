﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Autoreport.Database;
using Autoreport.UI.Classes;
using Autoreport.UI.Add;
using Autoreport.UI.Edit;
using Autoreport.UI.Edit.Parents;
using Autoreport.Models;
using System.Reflection;
using System.ComponentModel;

namespace Autoreport.UI
{
    /// <summary>
    /// General - обычный режим окна с пролистыванием и модификацией данных
    /// Select - режим, в котором эта форма становится источником для выбора данных для других форм
    /// </summary>
    public enum Mode
    {
        General,
        Select
    }

    public partial class MainF : Form
    {
        Login Loginer;

        public Mode CurrentMode { get; set; } = Mode.General; // поле должно менять состояния только внутри метода WindowMode

        Button currentTabButton;
        Form currentAddForm;
        BaseEditForm currentEditForm;
        Action<int> currentDeleteAction;

        List<Button> permittedTabs = new List<Button>(); // вкладки, доступные пользователю
        List<Button> currentlyPermittedActions = new List<Button>(); // действия, доступные на какой-либо вкладке
        List<Button> secondaryTabs; // вкладки, отображающиеся только при определенных условиях

        // соответствие таба и связанного с ним метода
        // используется в методе TabClicked для того, чтоб не писать кучу if'ов
        Dictionary<Button, Action<Action<DataGridViewColumn>>> tabAction = new Dictionary<Button, Action<Action<DataGridViewColumn>>>();

        DataGridViewCellEventHandler tableItemDoubleClickEvent; // даблклик по строке таблицы
        EventHandler tableItemSelectEvent; // выбор строки из таблицы
        EventHandler selectedItemSelectEvent; // выбор строки из списка selectedItemBox

        // список навешанных на кнопку "Готово" слушателей
        // нужен для того, чтоб менять порядок вызова eventhandler'ов кнопки "Готово"
        // например, идет вызов форм: добавить заказ -> выбрать депозит -> добавить депозит -> выбрать клиента
        // в таком случае после стадии выбора клиента ПЕРВЫМ должен вызваться EventHandler,
        // навешанный формой добавления депозита, чтоб вернуть нас в эту форму, однако в реальности, что логично,
        // первым вызовется хэндлер навешанный первой вызванной формой - добавления заказа и тогда вместо формы депозита
        // нас вернет на форму заказа, что неправильно.
        List<EventHandler> doneBtnHandlers = new List<EventHandler>();

        public MainF()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            SetSecondaryTabs();
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

        private void SetSecondaryTabs()
        {
            secondaryTabs = new List<Button>() { filmDirectorsSecondaryTab };
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

            if (!Loginer.loggedIn)
            {
                // Connection.employeeService.CurrentEmployee == null - говорит о том, что авторизации до этого
                // не происходило, значит приложение только запущено, тогда в ответ на закрытие окна авторизации
                // приложение должно прекратить работу
                // иначе оставляем авторизированным тот профиль, под которым был совершен вход ранее, тогда
                // установка полномочий и прочее не требуется
                if (Connection.employeeService.CurrentEmployee == null)
                {
                    Close();
                }
                else
                    return;
            }

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

        /// <summary>
        /// Общий метод для обработки кликов по табам, который вызывает частные методы для каждой отдельной вкладки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabClicked(object sender, EventArgs e)
        {
            currentlyPermittedActions.Clear(); // чистим список доступных на вкладке кнопок, чтоб добавить новые данные

            if (currentTabButton != null) // восстанавливаем для предыдущей кнопки дефолтный цвет
                currentTabButton.BackColor = Color.FromArgb(240, 240, 240); ;

            currentTabButton = (Button)sender;
            currentTabButton.BackColor = Color.FromArgb(205, 205, 205);

            Action<DataGridViewColumn> GoFirst = CharacteristicSetter();
            tabAction[currentTabButton](GoFirst); // вызываем метод, связанный с вкладкой

            // выключаем все кнопки-действия за исключением тех, что были добавлены в currentlyPermittedActions
            DisableAllControlButtonsExcept(currentlyPermittedActions.ToArray());

            // если таблица пустая, то выключаем кнопки-действия, оставляя необходимые
            // при этом беря во внимание, что некоторые из "необходимых" могут не входить в currentlyPermittedActions,
            // тогда их оставлять не нужно
            if (dataGridView.SelectedRows.Count == 0)
            {
                Button[] necessary = new Button[] { addBtn, reloadBtn, doneBtn }
                                        .Where(b => currentlyPermittedActions.Contains(b))
                                        .ToArray();
                DisableAllControlButtonsExcept(necessary);
            } else if (!currentlyPermittedActions.Contains(deleteBtn))
            {
                deleteBtn.Enabled = false;
            }

            dataGridView.Columns["Id"].DisplayIndex = 0;
            dataGridView.Columns["Id"].Visible = false;
        }

        private void EmployeesTab_Click(Action<DataGridViewColumn> GoFirst)
        {
            currentlyPermittedActions.AddRange(new List<Button>() { addBtn, editBtn, searchBtn, reloadBtn });

            currentAddForm = new AddEmployeeF();
            currentEditForm = new EditEmployeeF();
            dataGridView.DataSource = Connection.employeeService.GetAll();

            GoFirst(dataGridView.Columns["First_name"]);
            GoFirst(dataGridView.Columns["Last_name"]);
            GoFirst(dataGridView.Columns["Middle_name"]);
            GoFirst(dataGridView.Columns["EmplPosition"]);
        }

        private void ClientsTab_Click(Action<DataGridViewColumn> GoFirst)
        {
            currentlyPermittedActions.AddRange(new List<Button>() { 
                addBtn, editBtn, searchBtn, reloadBtn, infoBtn, doneBtn, deleteBtn
            });

            currentDeleteAction = Connection.clientService.Delete;
            currentAddForm = new AddClientF();
            currentEditForm = new EditClientF();
            dataGridView.DataSource = Connection.clientService.GetAll();
            
            GoFirst(dataGridView.Columns["First_name"]);
            GoFirst(dataGridView.Columns["Last_name"]);
            GoFirst(dataGridView.Columns["Middle_name"]);
            GoFirst(dataGridView.Columns["Phone_number1"]);
        }

        private void DisksTab_Click(Action<DataGridViewColumn> GoFirst)
        {
            List<Button> permittedActions = null;

            if (CurrentMode == Mode.General)
                permittedActions = new List<Button>() { addBtn, editBtn, searchBtn, reloadBtn, infoBtn, deleteBtn, doneBtn };
            else if (CurrentMode == Mode.Select)
                permittedActions = new List<Button>() { addBtn, editBtn, searchBtn, reloadBtn, infoBtn, doneBtn };

            currentlyPermittedActions.AddRange(permittedActions);

            currentAddForm = new AddDiskF(filmsTab, reloadBtn.PerformClick);
            currentEditForm = new EditDiskF(filmsTab, reloadBtn.PerformClick);
            currentDeleteAction = Connection.diskService.Delete;
            dataGridView.DataSource = Connection.diskService.GetAll();

            GoFirst(dataGridView.Columns["Article"]);
            GoFirst(dataGridView.Columns["Cost"]);
        }

        private void FilmsTab_Click(Action<DataGridViewColumn> GoFirst)
        {
            currentlyPermittedActions.AddRange(new List<Button>() { 
                addBtn, editBtn, deleteBtn, searchBtn, reloadBtn, infoBtn, doneBtn 
            });

            currentAddForm = new AddFilmF(filmDirectorsSecondaryTab, reloadBtn.PerformClick);
            currentEditForm = new EditFilmF(filmDirectorsSecondaryTab, reloadBtn.PerformClick);
            currentDeleteAction = Connection.filmService.Delete;
            dataGridView.DataSource = Connection.filmService.GetAll();

            GoFirst(dataGridView.Columns["Name"]);
            GoFirst(dataGridView.Columns["Date"]);
        }

        private void OrdersTab_Click(Action<DataGridViewColumn> GoFirst)
        {
            currentlyPermittedActions.AddRange(new List<Button>() { 
                addBtn, editBtn, searchBtn, reloadBtn, infoBtn, deleteBtn
            });

            dataGridView.DataSource = Connection.orderService.GetAll();

            currentDeleteAction = Connection.orderService.Delete;
            currentAddForm = new AddOrderF(depositsTab, disksTab, reloadBtn.PerformClick);
            currentEditForm = new EditOrderF(depositsTab, disksTab, reloadBtn.PerformClick);
        }

        private void DepositsTab_Click(Action<DataGridViewColumn> GoFirst)
        {
            List<Button> permittedActions = null;

            if (CurrentMode == Mode.General)
                permittedActions = new List<Button>() { editBtn, searchBtn, reloadBtn, deleteBtn, infoBtn, doneBtn };
            else if (CurrentMode == Mode.Select)
                permittedActions = new List<Button>() { addBtn, editBtn, searchBtn, reloadBtn, infoBtn, doneBtn };

            currentlyPermittedActions.AddRange(permittedActions);

            currentDeleteAction = Connection.depositService.Delete;
            currentAddForm = new AddDepositF(clientsTab, reloadBtn.PerformClick);
            currentEditForm = new EditDepositF(clientsTab, reloadBtn.PerformClick);
            dataGridView.DataSource = Connection.depositService.GetAll();

            GoFirst(dataGridView.Columns["DocumentData"]);
            GoFirst(dataGridView.Columns["MoneyValue"]);
            GoFirst(dataGridView.Columns["DepositType"]);
        }

        private void FilmDirectorsSecondaryTab_Click(Action<DataGridViewColumn> GoFirst)
        {
            currentlyPermittedActions.AddRange(new List<Button>() { addBtn, editBtn, searchBtn, reloadBtn, selectBtn, doneBtn });
            
            currentAddForm = new AddFilmDirectorF();
            currentEditForm = new EditFilmDirectorF();
            dataGridView.DataSource = Connection.filmService.GetFilmsDirectors();

            GoFirst(dataGridView.Columns["First_name"]);
            GoFirst(dataGridView.Columns["Last_name"]);
            GoFirst(dataGridView.Columns["Middle_name"]);
        }

        /// <summary>
        /// Замыкающая функция, устанавливающая значение "Characteristic" для
        /// свойства Tag столбцов таблицы.
        /// Столбцы с тэгом Characteristic имеют приоритет, поэтому они расположены
        /// друг за другом и идут по порядку(1,2,...) после невидимого поля Id, индекс которого 0.
        /// </summary>
        /// <param name="startIndex">Какая первая позиция по порядку</param>
        /// <returns></returns>
        private Action<DataGridViewColumn> CharacteristicSetter(int startIndex = 1)
        {
            int index = startIndex;

            void Set(DataGridViewColumn column)
            {
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

        private void EditBtn_Click(object sender, EventArgs e)
        {
            currentEditForm.LoadField(Int32.Parse(dataGridView.SelectedRows[0].Cells["Id"].Value.ToString()));
            currentEditForm.ShowDialog(this);
            currentTabButton.PerformClick();
        }

        private void DataGridItemSelectd(object sender, EventArgs e)
        {
            int index;

            if (dataGridView.SelectedCells.Count == 0)
            {
                index = -1;
            } else
            {
                index = dataGridView.SelectedCells[0].RowIndex;
            }

            
            bool correctRow = index != -1;
            selectBtn.Enabled = correctRow;

            if (currentlyPermittedActions.Contains(editBtn))
            {
                editBtn.Enabled = correctRow;
            }
        }

        private void SelectBoxItemSelected(object sender, EventArgs e)
        {
            removeFromSelectedBtn.Enabled = selectedItemsBox.SelectedIndex != -1;
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

            //Type itemType = dataGridView.DataSource.GetType().GetGenericArguments().Single();
            var relatedItem = dataGridView.Rows[e.RowIndex].DataBoundItem;

            if (selectedItemsBox.Items.Cast<object>().Count(_item => _item == relatedItem) != 0)
                return;

            Console.WriteLine("adding");

            selectedItemsBox.Items.Add(relatedItem);
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    DataGridItemDoubleClick(null, new DataGridViewCellEventArgs(cell.ColumnIndex, cell.RowIndex));
                    break;
                }
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
        /// Показывает/скрывает кнопку doneBtn
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
                selectedItemsPanel.Show();
            }
            else
                selectedItemsPanel.Hide();
        }

        private void ConnectTableItemClick()
        {
            dataGridView.CellDoubleClick -= tableItemDoubleClickEvent;
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
            //Console.WriteLine("connecting this method as {0}", Handler.GetHashCode());

            doneBtnHandlers.Insert(0, Handler);

            foreach (EventHandler eh in doneBtnHandlers)
            {
                doneBtn.Click -= eh;
            }

            doneBtn.Click += doneBtnHandlers.First();

            //Console.Write("connect reuslt handlers: ");
            //foreach (EventHandler eh in doneBtnHandlers)
            //{
            //    Console.Write("{0}, ", eh.GetHashCode());
            //}
            //Console.WriteLine("");
        }

        private void DisconnectDoneButton(EventHandler Handler)
        {
            //Console.WriteLine("disconnecting method: {0}", Handler.GetHashCode());

            doneBtn.Click -= Handler;
            doneBtnHandlers.Remove(Handler);

            if (doneBtnHandlers.Count > 0)
            {
                doneBtn.Click += doneBtnHandlers.First();
            }

            //Console.Write("disconnect reuslt handlers: ");
            //foreach (EventHandler eh in doneBtnHandlers)
            //{
            //    Console.Write("{0}, ", eh.GetHashCode());
            //}
            //Console.WriteLine("");
        }

        /// <summary>
        /// 
        /// Замыкающая функция, возвращающая процедуру, переводящую окно 
        /// из начального режима в режим выбора значений из таблицы, 
        /// либо обратно в начальный режим.
        /// </summary>
        /// <param name="Handler">Функция дочерней формы, которая вызывается при нажатии кнопки "Готово"</param>
        /// <returns name="Set" type="Action<Mode, Button, List<object>>">
        ///     Button - ссылка на кнопку-вкладку, связанную с таблицей, из которой будут 
        ///     выбираться элементы
        ///     object(`Model`)[] - элементы, который были выбраны при предыдущем входе в режим выбора
        /// </returns>
        public Action<Mode, Button, object[]> WindowMode(Action<ListBox.ObjectCollection> Handler)
        {
            Button lastTab = currentTabButton;
            EventHandler doneEventHandler = new EventHandler(
                (object sender, EventArgs e) => Handler(selectedItemsBox.Items));
            bool fromSelectedMode = CurrentMode == Mode.Select;

            void Turn(Mode state, Button selectTab = null, object[] previewSelected = null)
            {
                bool isSelectEnabled = state == Mode.Select;
                CurrentMode = state;

                if (isSelectEnabled)
                {
                    if (selectTab == null || previewSelected == null)
                    {
                        throw new ArgumentNullException("Когда state равен Mode.Select, второй и третий аргументы не могут быть null");
                    }

                    Console.WriteLine("bbb");
                    selectedItemsBox.Items.Clear();
                    selectedItemsBox.Items.AddRange(previewSelected);
                    DisableAllTabsExcept(selectTab);
                    ConnectDoneButton(doneEventHandler);
                    SetSelectionElementsActive(isSelectEnabled);
                }
                else
                {
                    if (!fromSelectedMode)
                    {
                        EnableAllTabs();
                        SetSelectionElementsActive(isSelectEnabled);
                    } else
                    {
                        DisableAllTabsExcept(lastTab);
                    }

                    DisconnectDoneButton(doneEventHandler);
                    selectedItemsBox.Items.Clear();
                    lastTab.PerformClick();
                }
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
