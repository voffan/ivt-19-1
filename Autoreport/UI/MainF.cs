using System;
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
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections;

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

    public partial class MainF : BaseForm
    {
        Login Loginer;

        public Mode CurrentMode { get; set; } = Mode.General; // поле должно менять состояния только внутри метода WindowMode

        Button currentTabButton;
        Form currentAddForm;
        BaseEditForm currentEditForm;
        Action<int> currentDeleteAction;
        Func<List<object>> currentFindFunction;
        Func<List<object>> currentGetFunction;

        List<Button> permittedTabs = new List<Button>(); // вкладки, доступные пользователю
        List<Button> currentlyPermittedActions = new List<Button>(); // действия, доступные на какой-либо вкладке
        List<Button> secondaryTabs; // вкладки, отображающиеся только при определенных условиях

        // соответствие таба и связанного с ним обработчика нажатия
        // используется в методе TabClicked
        Dictionary<Button, Action< bool>> tabAction = new Dictionary<Button, Action<bool>>();

        // соответствие таба и связанного с ним метода получения данных
        // нужен для того, чтоб можно было к currentGetFunction приравнивать метод поиска
        Dictionary<Button, Func<List<object>>> tabGetAllFunction = new Dictionary<Button, Func<List<object>>>();

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
            SetTableEventHandlers();
            SetAppearance(1200, 620, 50, 50);
            SetSelectionElementsActive(false);
            SetSearchPanelActive(false);

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

        private void SetSearchPanelActive(bool v)
        {
            if (v)
            {
                searchPanel.Show();
                TurnVisibleButtons(true, searchPanel);
            }
            else
                searchPanel.Hide();
        }

        /// <summary>
        /// Устанавливает список secondary вкладок
        /// </summary>
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

            tabGetAllFunction.Add(employeesTab, () => Connection.employeeService.GetAll().Cast<object>().ToList());
            tabGetAllFunction.Add(clientsTab, () => Connection.clientService.GetAll().Cast<object>().ToList());
            tabGetAllFunction.Add(disksTab, () => Connection.diskService.GetAll().Cast<object>().ToList());
            tabGetAllFunction.Add(filmsTab, () => Connection.filmService.GetAll().Cast<object>().ToList());
            tabGetAllFunction.Add(ordersTab, () => Connection.orderService.GetAll().Cast<object>().ToList());
            tabGetAllFunction.Add(depositsTab, () => Connection.depositService.GetAll().Cast<object>().ToList());
            tabGetAllFunction.Add(filmDirectorsSecondaryTab, () => Connection.filmService.GetFilmsDirectors().Cast<object>().ToList());
        }

        private void SetTableEventHandlers()
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

            currentGetFunction = tabGetAllFunction[currentTabButton];

            tabAction[currentTabButton](true); // вызываем метод, связанный с вкладкой

            // выключаем все кнопки-действия за исключением тех, что были добавлены в currentlyPermittedActions
            TurnVisibleButtons(false, controlPanel, currentlyPermittedActions.ToArray());

            // если таблица пустая, то выключаем кнопки-действия, оставляя необходимые
            // при этом беря во внимание, что некоторые из "необходимых" могут не входить в currentlyPermittedActions,
            // тогда их оставлять не нужно
            if (dataGridView.SelectedRows.Count == 0)
            {
                Button[] necessary = new Button[] { addBtn, reloadBtn, doneBtn }
                                        .Where(b => currentlyPermittedActions.Contains(b))
                                        .ToArray();
                TurnVisibleButtons(false, controlPanel, necessary);
            } else if (!currentlyPermittedActions.Contains(deleteBtn))
            {
                deleteBtn.Enabled = false;
            }

            dataGridView.Columns["Id"].DisplayIndex = 0;

            foreach (DataGridViewColumn dgc in dataGridView.Columns)
            {
                if (dgc.Name.Contains("Id"))
                    dgc.Visible = false;
            }
        }

        private void EmployeesTab_Click(bool updateSearchPanel = true)
        {
            currentlyPermittedActions.AddRange(new List<Button>() { addBtn, editBtn, searchBtn, reloadBtn });

            if (updateSearchPanel)
                UpdateSearchPanel(typeof(Employee));

            currentAddForm = new AddEmployeeF();
            currentEditForm = new EditEmployeeF();
            dataGridView.DataSource = currentGetFunction().Cast<Employee>().ToList();
            currentFindFunction = () => Find(Connection.employeeService.GetAll().Cast<object>()).ToList();

            CharacteristicSetter(1,
                dataGridView.Columns["First_name"],
                dataGridView.Columns["Last_name"],
                dataGridView.Columns["Middle_name"],
                dataGridView.Columns["EmplPosition"]);
        }

        private void ClientsTab_Click(bool updateSearchPanel = true)
        {
            currentlyPermittedActions.AddRange(new List<Button>() {
                addBtn, editBtn, searchBtn, reloadBtn, infoBtn, doneBtn, deleteBtn
            });

            if (updateSearchPanel)
                UpdateSearchPanel(typeof(Client));

            currentDeleteAction = Connection.clientService.Delete;
            currentAddForm = new AddClientF();
            currentEditForm = new EditClientF();
            dataGridView.DataSource = currentGetFunction().Cast<Client>().ToList();
            currentFindFunction = () => Find(Connection.clientService.GetAll().Cast<object>()).ToList();

            CharacteristicSetter(1,
                dataGridView.Columns["First_name"],
                dataGridView.Columns["Last_name"],
                dataGridView.Columns["Middle_name"],
                dataGridView.Columns["Phone_number1"]);
        }

        private void DisksTab_Click(bool updateSearchPanel = true)
        {
            List<Button> permittedActions = null;

            if (CurrentMode == Mode.General)
                permittedActions = new List<Button>() { addBtn, editBtn, searchBtn, reloadBtn, infoBtn, deleteBtn, doneBtn };
            else if (CurrentMode == Mode.Select)
                permittedActions = new List<Button>() { addBtn, editBtn, searchBtn, reloadBtn, infoBtn, doneBtn };

            currentlyPermittedActions.AddRange(permittedActions);

            if (updateSearchPanel)
                UpdateSearchPanel(typeof(Disk));

            currentAddForm = new AddDiskF(filmsTab, reloadBtn.PerformClick);
            currentEditForm = new EditDiskF(filmsTab, reloadBtn.PerformClick);
            currentDeleteAction = Connection.diskService.Delete;
            dataGridView.DataSource = currentGetFunction().Cast<Disk>().ToList();
            currentFindFunction = () => Find(Connection.diskService.GetAll().Cast<object>()).ToList();

            CharacteristicSetter(1,
                dataGridView.Columns["Article"],
                dataGridView.Columns["Cost"]);
        }

        private void FilmsTab_Click(bool updateSearchPanel = true)
        {
            currentlyPermittedActions.AddRange(new List<Button>() {
                addBtn, editBtn, deleteBtn, searchBtn, reloadBtn, infoBtn, doneBtn
            });

            if (updateSearchPanel)
                UpdateSearchPanel(typeof(Film));

            currentAddForm = new AddFilmF(filmDirectorsSecondaryTab, reloadBtn.PerformClick);
            currentEditForm = new EditFilmF(filmDirectorsSecondaryTab, reloadBtn.PerformClick);
            currentDeleteAction = Connection.filmService.Delete;
            dataGridView.DataSource = currentGetFunction().Cast<Film>().ToList();
            currentFindFunction = () => Find(Connection.filmService.GetAll().Cast<object>()).ToList();

            CharacteristicSetter(1,
                dataGridView.Columns["Name"],
                dataGridView.Columns["Year"]);
        }

        private void OrdersTab_Click(bool updateSearchPanel = true)
        {
            currentlyPermittedActions.AddRange(new List<Button>() {
                addBtn, editBtn, searchBtn, reloadBtn, infoBtn, deleteBtn
            });

            if (updateSearchPanel)
                UpdateSearchPanel(typeof(Order));

            dataGridView.DataSource = currentGetFunction().Cast<Order>().ToList();
            currentFindFunction = () => Find(Connection.orderService.GetAll().Cast<object>()).ToList();

            currentDeleteAction = Connection.orderService.Delete;
            currentAddForm = new AddOrderF(depositsTab, disksTab, reloadBtn.PerformClick);
            currentEditForm = new EditOrderF(depositsTab, disksTab, reloadBtn.PerformClick);
        }

        private void DepositsTab_Click(bool updateSearchPanel = true)
        {
            List<Button> permittedActions = null;

            if (CurrentMode == Mode.General)
                permittedActions = new List<Button>() { editBtn, searchBtn, reloadBtn, deleteBtn, infoBtn, doneBtn };
            else if (CurrentMode == Mode.Select)
                permittedActions = new List<Button>() { addBtn, editBtn, searchBtn, reloadBtn, infoBtn, doneBtn };

            currentlyPermittedActions.AddRange(permittedActions);

            if (updateSearchPanel)
                UpdateSearchPanel(typeof(Deposit));

            currentDeleteAction = Connection.depositService.Delete;
            currentAddForm = new AddDepositF(clientsTab, reloadBtn.PerformClick);
            currentEditForm = new EditDepositF(clientsTab, reloadBtn.PerformClick);
            dataGridView.DataSource = currentGetFunction().Cast<Deposit>().ToList();
            currentFindFunction = () => Find(Connection.depositService.GetAll().Cast<object>()).ToList();

            CharacteristicSetter(1,
                dataGridView.Columns["DocumentData"],
                dataGridView.Columns["MoneyValue"],
                dataGridView.Columns["DepositType"]);
        }

        private void FilmDirectorsSecondaryTab_Click(bool updateSearchPanel = true)
        {
            currentlyPermittedActions.AddRange(new List<Button>() { addBtn, editBtn, searchBtn, reloadBtn, selectBtn, doneBtn });

            if (updateSearchPanel)
                UpdateSearchPanel(typeof(Person), new string[] { "First_name", "Last_name", "Middle_name" });

            currentAddForm = new AddFilmDirectorF();
            currentEditForm = new EditFilmDirectorF();
            dataGridView.DataSource = currentGetFunction().Cast<Person>().ToList();
            currentFindFunction = () => Find(Connection.filmService.GetFilmsDirectors().Cast<object>()).ToList();

            CharacteristicSetter(1,
                dataGridView.Columns["First_name"],
                dataGridView.Columns["Last_name"],
                dataGridView.Columns["Middle_name"]);
        }

        /// <summary>
        /// Выстраивает переданные колонны из DataGridView в том порядке, в котором они были переданы
        /// </summary>
        /// <param name="startIndex">Индекс первой колонны</param>
        /// <param name="columns"></param>
        private void CharacteristicSetter(int startIndex = 1, params DataGridViewColumn[] columns)
        {
            for (int i = 0; i < columns.Length; i++)
            {
                columns[i].DisplayIndex = startIndex + i;
            }
        }

        private IEnumerable<object> Find(IEnumerable<object> processList)
        {
            IEnumerable<Control> ctrls = GetPanelInputControls(searchControlsPanel);
            int filledControls = ctrls.Count(x => x.Text.Length > 0);

            foreach (object Obj in processList)
            {
                if (GetAppropriate(Obj, ctrls).Count() == filledControls)
                    yield return Obj;
            }
        }

        private IEnumerable<object> GetAppropriate(object Obj, IEnumerable<Control> ctrls)
        {
            foreach (PropertyInfo property in Obj.GetType().GetProperties())
            {
                // ищем поле, имя которого совпадает с названием свойства
                Control relatedControl = ctrls.FirstOrDefault(x => x.Name == property.Name);

                // если не нашли, значит по этому свойству поиск не производится, пропускаем
                if (relatedControl == null)
                    continue;

                // проверяем, было ли поле заполнено
                if (relatedControl.Text.Length > 0)
                {
                    if (Compare(property.GetValue(Obj, null).ToString(), relatedControl.Text))
                    {
                        yield return Obj;
                    }
                }
            }
        }

        private bool Compare(string left, string right)
        {
            return left.ToLower().Contains(right.ToLower());
        }

        /// <summary>
        /// Добавляет/обновляет поля для ввода данных, по которым будет производиться поиск
        /// </summary>
        /// <param name="T"></param>
        private void UpdateSearchPanel(Type T, string[] concreteFields = null, string[] exceptFields = null)
        {
            searchControlsPanel.Controls.Clear();

            foreach (MemberInfo member in T.GetMembers())
            {
                if (member.MemberType == MemberTypes.Property)
                {
                    if (exceptFields != null && exceptFields.Contains(member.Name))
                        continue;

                    if (concreteFields != null && !concreteFields.Contains(member.Name))
                        continue;

                    PropertyInfo property = T.GetProperties().First(x => x.Name == member.Name);
                    
                    // отсеиваем key-value поля и поля, являющиеся списками
                    if (member.GetCustomAttributes().OfType<KeyAttribute>().Count() > 0 ||
                            property.PropertyType != typeof(string) &&
                            typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                        continue;

                    foreach (Attribute attribute in member.GetCustomAttributes())
                    {
                        if (attribute is DisplayNameAttribute)
                        {
                            int index = searchControlsPanel.RowCount - 1;

                            Label textLabel = new Label();
                            textLabel.AutoSize = false;
                            textLabel.Dock = DockStyle.Top;
                            textLabel.Margin = new Padding(0, 0, 0, 2);
                            textLabel.TextAlign = ContentAlignment.MiddleLeft;
                            textLabel.Text = ((DisplayNameAttribute)attribute).DisplayName;

                            TextBox searchDataInput = new TextBox();
                            searchDataInput.Dock = DockStyle.Top;
                            searchDataInput.Name = member.Name;
                            searchDataInput.Margin = new Padding(0, 0, 0, 2);
                            searchDataInput.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);

                            searchControlsPanel.Controls.Add(textLabel);
                            searchControlsPanel.Controls.Add(searchDataInput);
                            searchControlsPanel.RowStyles[index].SizeType = SizeType.Absolute;
                            searchControlsPanel.RowStyles[index].Height = 26;
                        }
                    }
                }
            }
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
            int selectedItemId = Int32.Parse(dataGridView.SelectedRows[0].Cells["Id"].Value.ToString());
            currentEditForm.LoadField(selectedItemId);
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

            TurnVisibleButtons(false, tabsLayout, new Button[] { excepted });
            excepted.PerformClick();
        }

        /// <summary>
        /// Рекурсивно меняет состояния всем видимым кнопкам внутри переданной панели,
        /// и прочих панелей, содержащихся внутри переданной
        /// </summary>
        /// <param name="enabled">Состояние, в которое следует перевести кнопку</param>
        /// <param name="panel">Панель, кнопки которой будут затронуты</param>
        /// <param name="reverse">Кнопки, которые перейдут в противоположное состояние от того, что передано</param>
        private void TurnVisibleButtons(bool enabled, Panel panel, Button[] reverse = null)
        {
            foreach (Button btn in GetAllButtons(panel).Where(x => x.Visible))
            {
                btn.Enabled = enabled || (reverse != null && reverse.Contains(btn));
            }
        }

        /// <summary>
        /// Добавляет слушателя события клика для кнопки "Готово"
        /// </summary>
        /// <param name="Handler"></param>
        private void ConnectDoneButton(EventHandler Handler)
        {
            doneBtnHandlers.Insert(0, Handler);

            foreach (EventHandler eh in doneBtnHandlers)
            {
                doneBtn.Click -= eh;
            }

            doneBtn.Click += doneBtnHandlers.First();
        }

        /// <summary>
        /// Удаляет слушателя события клик для кнопки "Готово"
        /// </summary>
        /// <param name="Handler"></param>
        private void DisconnectDoneButton(EventHandler Handler)
        {
            doneBtn.Click -= Handler;
            doneBtnHandlers.Remove(Handler);

            if (doneBtnHandlers.Count > 0)
            {
                doneBtn.Click += doneBtnHandlers.First();
            }
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

            deleteBtn.Enabled = dataGridView.SelectedRows.Count != 0;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                currentDeleteAction((int)row.Cells["Id"].Value);
            }

            reloadBtn.PerformClick();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            SetSearchPanelActive(true);
        }

        private void closeSearchPanelBtn_Click(object sender, EventArgs e)
        {
            SetSearchPanelActive(false);
            currentTabButton.PerformClick();
        }

        private void findBtn_Click(object sender, EventArgs e)
        {
            currentlyPermittedActions.Clear();
            currentGetFunction = currentFindFunction;

            tabAction[currentTabButton](false);
        }

        private void resetFoundBtn_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in GetPanelInputControls(searchControlsPanel))
            {
                ClearField(ctrl);
            }

            reloadBtn.PerformClick();
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            (new Detailed(dataGridView.SelectedRows[0].DataBoundItem)).Show();
        }
    }
}
