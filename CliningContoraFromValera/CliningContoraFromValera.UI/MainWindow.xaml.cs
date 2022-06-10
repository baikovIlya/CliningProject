using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CliningContoraFromValera.Bll;
using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.Bll.ModelsManager;

namespace CliningContoraFromValera.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TB_ServiceDescription.IsEnabled = false;
            TB_ServiceDescriptionSave.IsEnabled = false;
            ComboBox_OrderServiceCount.IsEnabled = false;
            ComboBox_AddNewService.IsEnabled = false;
            ComboBox_AddNewEmployeeToOrder.IsEnabled = false;
            Button_AddEmployeeToOrder.IsEnabled = false;
            Button_AddServiseToOrder.IsEnabled = false;
        }

        private ClientModelManager _clientModelManager = new ClientModelManager();
        private EmployeeModelManager _employeeModelManager = new EmployeeModelManager();
        private WorkTimeModelManager _workTimeModelManager = new WorkTimeModelManager();
        private EmployeeWorkTimeModelManager _employeeWorkTimeModelManager = new EmployeeWorkTimeModelManager();
        private OrderModelManager _orderModelManager = new OrderModelManager();
        private WorkAreaModelManager _workAreaModelManager = new WorkAreaModelManager();
        private ServiceModelManager _serviceModelManager = new ServiceModelManager();
        private ServiceOrderModelManager _serviceOrderModelManager = new ServiceOrderModelManager();
        private AddressModelManager _addressModelManager = new AddressModelManager();

        //КЛИЕНТЫ

        private void DataGrid_Clients_Loaded(object sender, RoutedEventArgs e)
        {
            List<ClientModel> clients = _clientModelManager.GetAllClients();
            DataGrid_Clients.ItemsSource = clients;
        }

        private void Button_ClientDelete_Click(object sender, RoutedEventArgs e)
        {
            ClientModel client = (ClientModel)DataGrid_Clients.SelectedItem;
            _clientModelManager.DeleteClientById(client.Id);
            ClientRefresh();
        }

        private void DataGrid_Clients_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            ClientModel client = (ClientModel)e.Row.Item;
            var element = (TextBox)e.EditingElement;
            if (String.IsNullOrWhiteSpace(element.Text))
            {
                ShowMessageBox(UiTextElements.AllFieldsSholdBeFilled);
                ClientRefresh();
                return;
            }
            if (String.Equals((string)e.Column.Header, UiTextElements.PhoneNomer))
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(element.Text, @"[а-я]")
                 || System.Text.RegularExpressions.Regex.IsMatch(element.Text, @"[a-z]")
                 || System.Text.RegularExpressions.Regex.IsMatch(element.Text, @"[\/\@\#\%\^\*\(\)\;\:\'\<\>\$]$"))
                {
                    ShowMessageBox(UiTextElements.WrongPhoneFormat);
                    ClientRefresh();
                    return;
                }
                else
                {
                    client.Phone = element.Text;
                }
            }
            _clientModelManager.UpdateClientById(client);
        }

        private void Button_ClientAdd_Click(object sender, RoutedEventArgs e)
        {
            string phone = TextBox_Phone.Text;
            if (String.IsNullOrWhiteSpace(TextBox_Name.Text) || String.IsNullOrWhiteSpace(TextBox_LastName.Text)
                 || String.IsNullOrWhiteSpace(TextBox_Email.Text) || String.IsNullOrWhiteSpace(TextBox_Phone.Text))
            {
                ShowMessageBox(UiTextElements.AllFieldsSholdBeFilled);
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(phone, @"[а-я]")
                 || System.Text.RegularExpressions.Regex.IsMatch(phone, @"[a-z]")
                 || System.Text.RegularExpressions.Regex.IsMatch(phone, @"[\/\@\#\%\^\*\(\)\;\:\'\<\>\$]$"))
            {
                ShowMessageBox(UiTextElements.WrongPhoneFormat);
            }
            else
            {
                ClientModel client = new ClientModel()
                {
                    FirstName = TextBox_Name.Text,
                    LastName = TextBox_LastName.Text,
                    Email = TextBox_Email.Text,
                    Phone = TextBox_Phone.Text,
                };
                _clientModelManager.AddClient(client);
                ClearClientAddTextBoxes();
                ClientRefresh();
            }
        }

        private void Button_ClientRefresh_Click(object sender, RoutedEventArgs e)
        {
            ClientRefresh();
        }
        private void ClientRefresh()
        {
            List<ClientModel> clients = _clientModelManager.GetAllClients();
            DataGrid_Clients.ItemsSource = clients;
        }

        private void ClearClientAddTextBoxes()
        {
            TextBox_Name.Clear();
            TextBox_LastName.Clear();
            TextBox_Email.Clear();
            TextBox_Phone.Clear();
        }

        //СОТРУДНИКИ

        private void DataGrid_Employees_Loaded(object sender, RoutedEventArgs e)
        {
            EmployeeRefresh();
        }

        private void DataGrid_Schedule_Loaded(object sender, RoutedEventArgs e)
        {
            List<EmployeeWorkTimeModel> employeesWorkTimes = _workTimeModelManager.GetEmployeesAndWorkTimes();
            DataGrid_Schedule.ItemsSource = employeesWorkTimes;
        }

        private void Button_EmployeeRefresh_Click(object sender, RoutedEventArgs e)
        {
            EmployeeRefresh();
        }
        private void EmployeeRefresh()
        {
            List<EmployeeModel> employees = _employeeModelManager.GetAllEmployees();
            DataGrid_Employees.ItemsSource = employees;
        }

        private void Button_EmployeeAdd_Click(object sender, RoutedEventArgs e)
        {
            String phone = TB_PhoneEmployee.Text;
            if (String.IsNullOrWhiteSpace(TB_LastNameEmployee.Text) || String.IsNullOrWhiteSpace(TB_FirstNameEmployee.Text)
                || String.IsNullOrWhiteSpace(TB_PhoneEmployee.Text))
            {
                ShowMessageBox(UiTextElements.AllFieldsSholdBeFilled);
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(phone, @"[а-я]")
                || System.Text.RegularExpressions.Regex.IsMatch(phone, @"[a-z]")
                || System.Text.RegularExpressions.Regex.IsMatch(phone, @"[\/\@\#\%\^\*\(\)\;\:\'\<\>\$]$"))
            {
                ShowMessageBox(UiTextElements.WrongPhoneFormat);
            }
            else
            {
                EmployeeModel employee = new EmployeeModel()
                {
                    FirstName = TB_FirstNameEmployee.Text,
                    LastName = TB_LastNameEmployee.Text,
                    Phone = TB_PhoneEmployee.Text,
                };
                _employeeModelManager.AddEmployee(employee);
                ClearEmployeeAddTextBoxes();
                EmployeeRefresh();
            }
        }

        private void Button_EmployeeDelete_Click(object sender, RoutedEventArgs e)
        {
            EmployeeModel employee = (EmployeeModel)DataGrid_Employees.SelectedItem;
            _employeeModelManager.DeleteEmployeeById(employee.Id);
            EmployeeRefresh();
        }

        private void ClearEmployeeAddTextBoxes()
        {
            TB_LastNameEmployee.Clear();
            TB_FirstNameEmployee.Clear();
            TB_PhoneEmployee.Clear();
        }

        private void DataGrid_Employees_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            EmployeeModel employee = (EmployeeModel)e.Row.Item;
            var element = (TextBox)e.EditingElement;
            if (String.IsNullOrWhiteSpace(element.Text))
            {
                ShowMessageBox(UiTextElements.AllFieldsSholdBeFilled);
                EmployeeRefresh();
                return;
            }
            if (String.Equals((string)e.Column.Header, UiTextElements.PhoneNomer))
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(element.Text, @"[а-я]")
                 || System.Text.RegularExpressions.Regex.IsMatch(element.Text, @"[a-z]")
                 || System.Text.RegularExpressions.Regex.IsMatch(element.Text, @"[\/\@\#\%\^\*\(\)\;\:\'\<\>\$]$"))
                {
                    ShowMessageBox(UiTextElements.WrongPhoneFormat);
                    EmployeeRefresh();
                    return;
                }
                else
                {
                    employee.Phone = element.Text;
                }
            }
            _employeeModelManager.UpdateEmployeeById(employee);
        }

        private void DataGrid_Employees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid_Employees.SelectedItem != null)
            {
                EmployeesWorkAreasAndServicesRefresh();
            }
            else
            {
                DataGrid_EmployeesWorkAreas.ItemsSource = null;
                DataGrid_EmployeesServices.ItemsSource = null;
            }
        }

        private void Button_EmployeesWorkAreasDelete_Click(object sender, RoutedEventArgs e)
        {
            EmployeeModel employee = (EmployeeModel)DataGrid_Employees.SelectedItem;
            WorkAreaModel employeesWorkArea = (WorkAreaModel)DataGrid_EmployeesWorkAreas.SelectedItem;
            _employeeModelManager.DeleteEmployeesWorkArea(employee.Id, employeesWorkArea.Id);
            EmployeesWorkAreasAndServicesRefresh();
        }

        private void Button_EmployeesServicesDelete_Click(object sender, RoutedEventArgs e)
        {
            EmployeeModel employee = (EmployeeModel)DataGrid_Employees.SelectedItem;
            ServiceModel employeesService = (ServiceModel)DataGrid_EmployeesServices.SelectedItem;
            _serviceModelManager.DeleteEmployeesService(employee.Id, employeesService.Id);
            EmployeesWorkAreasAndServicesRefresh();
        }

        private void EmployeesWorkAreasAndServicesRefresh()
        {
            EmployeeModel employee = (EmployeeModel)DataGrid_Employees.SelectedItem;
            DataGrid_EmployeesWorkAreas.ItemsSource = _employeeModelManager.GetEmployeesWorkAreasById(employee!.Id);
            DataGrid_EmployeesServices.ItemsSource = _employeeModelManager.GetEmployeesServicesById(employee!.Id);
        }

        //СЕРВИСЫ

        private void Button_ServicesDelete_Click(object sender, RoutedEventArgs e)
        {
            ServiceModel employee = (ServiceModel)DataGrid_Services.SelectedItem;
            _serviceModelManager.DeleteServiceyId(employee.Id);
            RefreshService();
        }

        private void CB_ChooseServiceType_Loaded(object sender, RoutedEventArgs e)
        {
            List<ServiceType> serviceTypes = new List<ServiceType>();
            foreach (ServiceType st in Enum.GetValues(typeof(ServiceType)))
            {
                serviceTypes.Add(st);
            }
            CB_ChooseServiceType.ItemsSource = serviceTypes;
        }
        private void CB_ChooseEstimatedTime_Loaded(object sender, RoutedEventArgs e)
        {
            CB_ChooseEstimatedTime.ItemsSource = Times._serviceDurationTime;
        }

        private void CB_ChooseUnitType_Loaded(object sender, RoutedEventArgs e)
        {
            List<UnitType> unitTypes = new List<UnitType>();
            foreach (UnitType ut in Enum.GetValues(typeof(UnitType)))
            {
                unitTypes.Add(ut);
            }
            CB_ChooseUnitType.ItemsSource = unitTypes;
        }

        private void Button_ServiceAdd_Click(object sender, RoutedEventArgs e)
        {
            decimal decimalFormat;
            if (String.IsNullOrWhiteSpace(TB_Description.Text) || String.IsNullOrWhiteSpace(TB_Name.Text)
                || String.IsNullOrWhiteSpace(TB_Price.Text) || String.IsNullOrWhiteSpace(TB_CommercialPrice.Text)
                || CB_ChooseUnitType.SelectedItem == null || CB_ChooseEstimatedTime.SelectedItem == null
                || CB_ChooseServiceType.SelectedItem == null)
            {
                ShowMessageBox(UiTextElements.AllFieldsSholdBeFilled);
            }
            else if (!Decimal.TryParse(TB_Price.Text, out decimalFormat)
                || !Decimal.TryParse(TB_CommercialPrice.Text, out decimalFormat))
            {
                try
                {
                    AddService();
                }
                catch (FormatException)
                {
                    ShowMessageBox(UiTextElements.WrongPriceFormat);
                }
            }
            else
            {
                AddService();
            }
        }

        private void AddService()
        {
            ServiceModel employee = new ServiceModel()
            {
                ServiceType = (ServiceType)CB_ChooseServiceType.SelectedItem,
                Name = TB_Name.Text,
                Description = TB_Description.Text,
                Price = Convert.ToDecimal(TB_Price.Text),
                CommercialPrice = Convert.ToDecimal(TB_CommercialPrice.Text),
                Unit = Convert.ToString(CB_ChooseUnitType.SelectedItem)!,
                EstimatedTime = (TimeSpan)CB_ChooseEstimatedTime.SelectedItem,
            };
            _serviceModelManager.AddService(employee);
            ClearServiceAddTextBoxes();
            RefreshService();
        }
        private void RefreshService()
        {
            List<ServiceModel> services = _serviceModelManager.GetAllServices();
            DataGrid_Services.ItemsSource = services;
        }

        private void ClearServiceAddTextBoxes()
        {
            TB_Description.Clear();
            TB_Name.Clear();
            TB_Price.Clear();
            TB_CommercialPrice.Clear();
            CB_ChooseUnitType.SelectedItem = null;
            CB_ChooseServiceType.SelectedItem = null;
            CB_ChooseEstimatedTime.SelectedItem = null;
        }

        private void Button_ServiceClear_Click(object sender, RoutedEventArgs e)
        {
            ClearServiceAddTextBoxes();
        }


        private void DataGrid_Services_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            TimeSpan estimatedTime;
            ServiceModel service = (ServiceModel)e.Row.Item;
            TextBox element = (TextBox)e.EditingElement;
            if (String.IsNullOrWhiteSpace(element.Text))
            {
                ShowMessageBox(UiTextElements.AllFieldsSholdBeFilled);
                RefreshService();
                return;
            }
            if (String.Equals((string)e.Column.Header, UiTextElements.EstTime))
            {
                if (!TimeSpan.TryParse(element.Text, out estimatedTime))
                {
                    ShowMessageBox(UiTextElements.WrongTimeFormat);
                    return;
                }
                else
                {
                    string tmp = estimatedTime.ToString();
                    if (tmp.IndexOf('.') != -1)
                    {
                        ShowMessageBox(UiTextElements.WrongTimeFormat);
                        RefreshService();
                        return;
                    }
                    service.EstimatedTime = TimeSpan.Parse(element.Text);
                }
            }
            _serviceModelManager.UpdateServiceById(service);
        }

        private void DataGrid_Services_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshService();
        }

        private void DataGrid_Services_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ServiceModel service = (ServiceModel)DataGrid_Services.SelectedItem;
            if (DataGrid_Services.SelectedItem != null)
            {
                TB_ServiceDescriptionSave.IsEnabled = true;
                TB_ServiceDescription.IsEnabled = true;
                TB_ServiceDescription.Text = service.Description;
            }
            else
            {
                TB_ServiceDescription.Clear();
                TB_ServiceDescription.IsEnabled = false;
                TB_ServiceDescriptionSave.IsEnabled = false;
            }
        }

        private void TB_ServiceDescriptionSave_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TB_ServiceDescription.Text))
            {
                ShowMessageBox(UiTextElements.EmptyDiscription);
            }
            else
            {
                ServiceModel service = (ServiceModel)DataGrid_Services.SelectedItem;
                service.Description = TB_ServiceDescription.Text.Trim();
                _serviceModelManager.UpdateServiceById(service);
                DataGrid_Services.SelectedItem = null;
                TB_ServiceDescriptionSave.IsEnabled = false;
            }
        }

        private void Button_ServiceRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshService();
        }


        private void Button_EmployeeSelection_Click(object sender, RoutedEventArgs e)
        {
            if (CB_DesiredWorkArea.SelectedItem != null && CB_DesiredService.SelectedItem != null
                && DP_OrdersDate.SelectedDate != null)
            {
                DateTime date = (DateTime)DP_OrdersDate.SelectedDate;
                WorkAreaModel wa = (WorkAreaModel)CB_DesiredWorkArea.SelectedItem;
                ServiceModel sa = (ServiceModel)CB_DesiredService.SelectedItem;
                List<EmployeeWorkTimeModel> emloyees = _employeeWorkTimeModelManager.GetSuitableEmployees(date, sa.Id, wa.Id);
                DataGrid_RelevantEmployees.ItemsSource = emloyees;
                DP_OrdersDate.IsEnabled = false;
            }
            else
            {
                ShowMessageBox(UiTextElements.AllFieldsSholdBeFilled);
            }
        }

        //ПОДБОР СОТРУДНИКОВ

        private void DataGrid_RelevantEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid_RelevantEmployees.SelectedItem != null)
            {
                EmployeeWorkTimeModel employee = (EmployeeWorkTimeModel)DataGrid_RelevantEmployees.SelectedItem;
                int employeeId = employee.Id;
                DateTime date = (DateTime)DP_OrdersDate.SelectedDate!;
                List<OrderModel> orders = _orderModelManager.GetAllEmployeesOrdersByDate(employeeId, date);
                DataGrid_CurrentOrders.ItemsSource = orders;
            }
        }

        private void CB_DesiredWorkArea_Loaded(object sender, RoutedEventArgs e)
        {
            List<WorkAreaModel> workAreas = _workAreaModelManager.GetAllWorkAreas();
            CB_DesiredWorkArea.ItemsSource = workAreas;
        }

        private void CB_DesiredService_Loaded(object sender, RoutedEventArgs e)
        {
            List<ServiceModel> allServices = _serviceModelManager.GetAllServices();
            CB_DesiredService.ItemsSource = allServices;
        }

        private void CB_DesiredServiceType_Loaded(object sender, RoutedEventArgs e)
        {
            List<ServiceType> serviceTypes = new List<ServiceType> { };
            foreach (ServiceType st in Enum.GetValues(typeof(ServiceType)))
            {
                serviceTypes.Add(st);
            }
            CB_DesiredServiceType.ItemsSource = serviceTypes;
        }

        private void Button_ResetAll_Click(object sender, RoutedEventArgs e)
        {
            DP_OrdersDate.SelectedDate = null;
            CB_DesiredServiceType.SelectedItem = null;
            CB_DesiredService.SelectedItem = null;
            CB_DesiredWorkArea.SelectedItem = null;
            DataGrid_RelevantEmployees.ItemsSource = null;
            DataGrid_CurrentOrders.ItemsSource = null;
            DP_OrdersDate.IsEnabled = true;
        }

        private void CB_DesiredServiceType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CB_DesiredService.ItemsSource = null;
            List<ServiceModel> allServices = _serviceModelManager.GetAllServices();
            if (CB_DesiredServiceType.SelectedItem == null)
            {
                CB_DesiredService.ItemsSource = allServices;
            }
            else
            {
                List<ServiceModel> services = _serviceModelManager.GetServicesByType(allServices,
                    (ServiceType)CB_DesiredServiceType.SelectedItem);
                CB_DesiredService.ItemsSource = services;
            }
        }

        //ГРАФИК 
        private void ComboBox_EmployeeSchedule_Loaded(object sender, RoutedEventArgs e)
        {
            List<EmployeeModel> employees = _employeeModelManager.GetAllEmployees();
            ComboBox_EmployeeSchedule.ItemsSource = employees;
        }
        private void ComboBox_ShiftStartTime__Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox_ShiftStartTime.ItemsSource = Times._employeesWorkTime;
        }
        private void ComboBox_ShiftFinishTime_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox_ShiftFinishTime.ItemsSource = Times._employeesWorkTime;
        }
        private void Button_AddShift_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(ComboBox_EmployeeSchedule.Text) || String.IsNullOrWhiteSpace(ComboBox_ShiftStartTime.Text)
                || String.IsNullOrWhiteSpace(ComboBox_ShiftFinishTime.Text) || String.IsNullOrWhiteSpace(DataPicker_EmployeeData.Text))
            {
                ShowMessageBox(UiTextElements.AllFieldsSholdBeFilled);
            }
            else
            {
                try
                {
                    AddShift();
                    AddShiftItemsClear();
                    RefreshShifts();
                    StartAndFinishLabelVisibilities();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    ShowMessageBox(UiTextElements.ShiftAlreadyExist);
                    AddShiftItemsClear();
                    StartAndFinishLabelVisibilities();
                }
            }
        }

        public void AddShift()
        {
            EmployeeModel employee = (EmployeeModel)ComboBox_EmployeeSchedule.SelectedValue;
            TimeSpan newStartTime = TimeSpan.Parse(ComboBox_ShiftStartTime.Text);
            TimeSpan newFinishTime = TimeSpan.Parse(ComboBox_ShiftFinishTime.Text);
            DateTime dateTime = DateTime.Parse(DataPicker_EmployeeData.Text);
            if (newStartTime >= newFinishTime)
            {
                ShowMessageBox(UiTextElements.StartTimeMustBeLessThanEndTime);
            }
            else
            {
                WorkTimeModel workTime = new WorkTimeModel() 
                {
                    Date = dateTime,
                    StartTime = newStartTime,
                    FinishTime = newFinishTime,
                    EmployeeId = employee.Id,
                };
                _workTimeModelManager.AddWorkTime(workTime);
            }
        }

        private void StartAndFinishLabelVisibilities()
        {
            Label_ShiftStart.Visibility = Visibility.Visible;
            Label_ShiftFinish.Visibility = Visibility.Visible;
        }

        
        private void RefreshShifts()
        {
            List<EmployeeWorkTimeModel> employeesWorkTimes = _employeeWorkTimeModelManager.GetEmployeesAndWorkTimes();
            DataGrid_Schedule.ItemsSource = employeesWorkTimes;
        }

        private void Button_ShowSchedule_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(DatePicker_FromDate.Text) || String.IsNullOrWhiteSpace(DatePicker_ToDate.Text))
            {
                ShowMessageBox(UiTextElements.AllFieldsSholdBeFilled);
            }
            else
            {
                DateTime startDate = DateTime.Parse(DatePicker_FromDate.Text);
                DateTime endDate = DateTime.Parse(DatePicker_ToDate.Text);
                List<EmployeeWorkTimeModel> employeesSchedule = _employeeWorkTimeModelManager.GetEmployeesSchedule(startDate, endDate);
                DataGrid_Schedule.ItemsSource = employeesSchedule;
            }
        }

        private void Button_ShiftDelete_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWorkTimeModel shift = (EmployeeWorkTimeModel)DataGrid_Schedule.SelectedItem;
            _workTimeModelManager.DeleteWorkTimeById(shift.WorkTimeId);
            RefreshShifts();
        }

        private void AddShiftItemsClear()
        {
            ComboBox_ShiftStartTime.Text = null;
            ComboBox_ShiftFinishTime.Text = null;
            DataPicker_EmployeeData.Text = null;
            ComboBox_EmployeeSchedule.Text = null;
            Label_ChooseEmployee.Visibility = Visibility.Visible;
        }

        private void DataGrid_Schedule_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            EmployeeWorkTimeModel crnt = (EmployeeWorkTimeModel)e.Row.Item;
            WorkTimeModel workTimes = new WorkTimeModel()
            {
                Id = crnt.WorkTimeId,
                Date = crnt.Date,
                StartTime = crnt.StartTime,
                FinishTime = crnt.FinishTime,
                EmployeeId = crnt.EmployeeId,
            };
            var Element = (TextBox)e.EditingElement;
            TimeSpan finishTime;
            TimeSpan startTime;
            string nameColumnStartTime = UiTextElements.SheduleStart;
            string nameColumnFinishTime = UiTextElements.SheduleEnd;
            if (String.IsNullOrWhiteSpace(Element.Text))
            {
                ShowMessageBox(UiTextElements.AllFieldsSholdBeFilled);
            }
            else
            {
                if (String.Equals((string)e.Column.Header, nameColumnStartTime))
                {
                    if (!TimeSpan.TryParse(Element.Text, out startTime))
                    {
                        ShowMessageBox(UiTextElements.WrongTimeFormat);
                        return;
                    }
                    else
                    {
                        string tmp = startTime.ToString();
                        if (tmp.IndexOf('.') != -1)
                        {
                            ShowMessageBox(UiTextElements.WrongTimeFormat);
                            RefreshShifts();
                            return;
                        }
                        workTimes.StartTime = TimeSpan.Parse(Element.Text);
                    }
                }
                else if (String.Equals((string)e.Column.Header, nameColumnFinishTime))
                {
                    if (!TimeSpan.TryParse(Element.Text, out finishTime))
                    {
                        ShowMessageBox(UiTextElements.WrongTimeFormat);
                        return;
                    }
                    else
                    {
                        string tmp = finishTime.ToString();
                        if (tmp.IndexOf('.') != -1)
                        {
                            ShowMessageBox(UiTextElements.WrongTimeFormat);
                            RefreshShifts();
                            return;
                        }

                        workTimes.FinishTime = TimeSpan.Parse(Element.Text);
                    }
                }
                _workTimeModelManager.UpdateWorkTimeById(workTimes);
                RefreshShifts();
            }
        }

        private void ComboBox_EmployeeSchedule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Label_ChooseEmployee.Visibility = Visibility.Hidden;
            ComboBox_EmployeeSchedule.Items.Refresh();
        }
        private void ComboBox_ShiftStartTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Label_ShiftStart.Visibility = Visibility.Hidden;
        }
        private void ComboBox_ShiftFinishTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Label_ShiftFinish.Visibility = Visibility.Hidden;
        }

        //ЗАКАЗЫ

        private void DataGrid_AllOrders_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridAllOrdersRefresh();
        }

        private void DataGridAllOrdersRefresh()
        {
            List<OrderModel> orders = _orderModelManager.GetAllOrder();
            DataGrid_AllOrders.ItemsSource = orders;
            Button_ResetStatusSelection.Visibility = Visibility.Hidden;
            Button_ResetStatusSelection.IsEnabled = false;
            Button_ResetEmployeeSelection.Visibility = Visibility.Hidden;
            Button_ResetEmployeeSelection.IsEnabled = false;
        }
        private void ComboBox_AddNewService_Loaded(object sender, RoutedEventArgs e)
        {
            List<ServiceModel> services = _serviceModelManager.GetAllServices();
            ComboBox_AddNewService.ItemsSource = services;
        }

        private void ComboBox_AddNewService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox_AddNewService.SelectedItem != null && ComboBox_OrderServiceCount.SelectedItem != null)
            {
                Button_AddServiseToOrder.IsEnabled = true;
            }
            else
            {
                Button_AddServiseToOrder.IsEnabled = false;
            }
        }

        private void ComboBox_OrderServiceCount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox_AddNewService.SelectedItem != null && ComboBox_OrderServiceCount.SelectedItem != null)
            {
                Button_AddServiseToOrder.IsEnabled = true;
            }
            else
            {
                Button_AddServiseToOrder.IsEnabled = false;
            }
        }

        private void ClearServiceOrder()
        {
            ComboBox_OrderServiceCount.SelectedItem = null;
            ComboBox_AddNewService.SelectedItem = null;
        }

        private void Button_AddServiseToOrder_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid_AllOrders.SelectedItem != null)
            {
                try
                {
                    OrderModel order = (OrderModel)DataGrid_AllOrders.SelectedItem;
                    ServiceModel service = (ServiceModel)ComboBox_AddNewService.SelectedItem;
                    int count = (int)ComboBox_OrderServiceCount.SelectedItem;
                    ServiceOrderModel serviceOrder = new ServiceOrderModel() { OrderId = order.Id, ServiceId = service.Id, Count = count };
                    _serviceOrderModelManager.AddServiceToOrder(serviceOrder);
                    TimeSpan oldEstTime = order.EstimatedEndTime;
                    TimeSpan oldFinishTime = order.FinishTime;
                    decimal oldPrice = order.Price;
                    try
                    {
                        UpdateOrdersPriceAndTimeAndRefresh(order);
                    }
                    catch(OverflowException)
                    {
                        ShowMessageBox(UiTextElements.TooManyServicesInOrder);
                        order.EstimatedEndTime = oldEstTime;
                        order.FinishTime = oldFinishTime;
                        order.Price = oldPrice;
                        _serviceOrderModelManager.DeleteServiceFromOrder(serviceOrder);
                    }
                    ClearServiceOrder();
                    Button_AddServiseToOrder.IsEnabled = false;
                    RefreshServiceOrder();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    ShowMessageBox(UiTextElements.DoubleAddingService);
                    ClearServiceOrder();
                }
            }
            else
            {
                return;
            }
        }
        private void UpdateOrdersPriceAndTimeAndRefresh(OrderModel order)
        {
            int index = DataGrid_AllOrders.SelectedIndex;
            _orderModelManager.GetOrdersPrice(order);
            _orderModelManager.UpdateOrdersTimes(order);
            _orderModelManager.UpdateOrder(order);
            DataGridAllOrdersRefresh();
            DataGrid_AllOrders.SelectedIndex = index;
        }
        private void UpdateOrdersCountOfEmployees(OrderModel order)
        {
            int index = DataGrid_AllOrders.SelectedIndex;
            order.CountOfEmployees = _employeeModelManager.GetEmployeesInOrderByOrdeerId(order.Id).Count;
            _orderModelManager.UpdateOrder(order);
            DataGridAllOrdersRefresh();
            DataGrid_AllOrders.SelectedIndex = index;
        }
        private void DataGrid_AllOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid_AllOrders.SelectedItem != null)
            {
                OrderModel order = (OrderModel)DataGrid_AllOrders.SelectedItem;
                List<ServiceOrderModel> servicesInOrder = _serviceOrderModelManager.GetOrdersServices(order.Id);
                List<EmployeeModel> employeesInOrder = _employeeModelManager.GetEmployeesInOrderByOrdeerId(order.Id);
                DataGrid_ServicesInOrder.ItemsSource = servicesInOrder;
                DataGrid_EmployeesInOrder.ItemsSource = employeesInOrder;
                ComboBox_AddNewEmployeeToOrder.IsEnabled = true;
                ComboBox_OrderServiceCount.IsEnabled = true;
                ComboBox_AddNewService.IsEnabled = true;
            }
            else
            {
                DataGrid_ServicesInOrder.ItemsSource = null;
                DataGrid_EmployeesInOrder.ItemsSource = null;
                ComboBox_OrderServiceCount.IsEnabled = false;
                ComboBox_AddNewService.IsEnabled = false;
                ComboBox_AddNewEmployeeToOrder.IsEnabled = false;
            }
        }

        private void RefreshOrdersDataGrids()
        {
            if (DataGrid_AllOrders.SelectedItem != null)
            {
                OrderModel order = (OrderModel)DataGrid_AllOrders.SelectedItem;
                List<ServiceOrderModel> servicesInOrder = _serviceOrderModelManager.GetOrdersServices(order.Id);
                List<EmployeeModel> employeesInOrder = _employeeModelManager.GetEmployeesInOrderByOrdeerId(order.Id);
                DataGrid_ServicesInOrder.ItemsSource = servicesInOrder;
                DataGrid_EmployeesInOrder.ItemsSource = employeesInOrder;
            }
            else
            {
                return;
            }
        }

        private void ComboBox_OrderClient_Loaded(object sender, RoutedEventArgs e)
        {
            List<ClientModel> clients = _clientModelManager.GetAllClients();
            ComboBox_OrderClient.ItemsSource = clients;
        }
        private void ComboBox_OrderStartTime_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox_OrderStartTime.ItemsSource = Times._ordersStartTimes;
        }
        private void ComboBox_OrderIsCommercial_Loaded(object sender, RoutedEventArgs e)
        {
            List<ClientOrderType> clientOrderTypes = new List<ClientOrderType> { };
            foreach (ClientOrderType clientOT in Enum.GetValues(typeof(ClientOrderType)))
            {
                clientOrderTypes.Add(clientOT);
            }
            ComboBox_OrderIsCommercial.ItemsSource = clientOrderTypes;
        }

        private void ComboBox_OrderWorkArea_Loaded(object sender, RoutedEventArgs e)
        {
            List<WorkAreaModel> workAreas = _workAreaModelManager.GetAllWorkAreas();
            ComboBox_OrderWorkArea.ItemsSource = workAreas;
        }

        private void Button_OrderAdd_Click(object sender, RoutedEventArgs e)
        {
            if ((String.IsNullOrWhiteSpace(TextBox_OrderStreet.Text)) || (String.IsNullOrWhiteSpace(TextBox_OrderBuilding.Text)
                || (String.IsNullOrWhiteSpace(TextBox_OrderRoom.Text)) || ComboBox_OrderClient.SelectedItem == null
                || ComboBox_OrderWorkArea.SelectedItem ==null || ComboBox_OrderStartTime.SelectedItem == null
                || ComboBox_OrderIsCommercial.SelectedItem == null || DatePicker_OrderDate.SelectedDate == null))
            {
                ShowMessageBox(UiTextElements.AllFieldsSholdBeFilled);
            }
            else
            {
                string street = TextBox_OrderStreet.Text;
                string building = TextBox_OrderBuilding.Text;
                string room = TextBox_OrderRoom.Text;
                WorkAreaModel workArea = (WorkAreaModel)ComboBox_OrderWorkArea.SelectedItem;
                ClientModel client = (ClientModel)ComboBox_OrderClient.SelectedItem;
                DateTime date = DateTime.Parse(DatePicker_OrderDate.Text);
                TimeSpan startTime = (TimeSpan)ComboBox_OrderStartTime.SelectedItem;
                StatusType status = CliningContoraFromValera.Bll.StatusType.Новый;
                AddressModel newAddress = new AddressModel()
                {
                    Street = street, Building = building, Room = room, WorkArea = workArea,
                };
                _addressModelManager.AddAddress(newAddress);
                List<AddressModel> allAddress = _addressModelManager.GetAllAddresses();
                AddressModel crntAddress = allAddress.Find(item => item.Street == street);
                TimeSpan estimatedTime = new TimeSpan(00, 00, 00);
                TimeSpan finishTime = startTime;
                decimal price = 0;
                bool isCommercial;
                if((ClientOrderType)ComboBox_OrderIsCommercial.SelectedItem == ClientOrderType.Юр_Лицо)
                {
                    isCommercial = true;
                }
                else
                {
                    isCommercial = false;
                }
                OrderModel orderModel = new OrderModel()
                { 
                    Date = date,
                    StartTime = startTime,
                    EstimatedEndTime = estimatedTime,
                    FinishTime = finishTime,
                    Price = price,
                    Status = status,
                    Client = client,
                    Address = crntAddress!,
                    IsCommercial = isCommercial,
                };
                _orderModelManager.AddOrder(orderModel);
                ShowMessageBox(UiTextElements.OrderСreated);
                ClrearAllFieldsInNewOrder();

            }
        }
        private void Button_ClearNewOrderFields_Click(object sender, RoutedEventArgs e)
        {
            ClrearAllFieldsInNewOrder();
        }
        private void ClrearAllFieldsInNewOrder()
        {
            TextBox_OrderStreet.Text = null;
            TextBox_OrderBuilding.Text = null;
            TextBox_OrderRoom.Text = null;
            ComboBox_OrderWorkArea.SelectedItem = null;
            ComboBox_OrderClient.SelectedItem = null;
            DatePicker_OrderDate.Text = null;
            ComboBox_OrderStartTime.SelectedItem = null;
            ComboBox_OrderIsCommercial.SelectedItem = null;
        }

        private void Button_DeleteServiceFromOrder_Click(object sender, RoutedEventArgs e)
        {
            ServiceOrderModel serviceOrder = (ServiceOrderModel)DataGrid_ServicesInOrder.SelectedItem;
            _serviceOrderModelManager.DeleteServiceFromOrder(serviceOrder);
            OrderModel order = (OrderModel)DataGrid_AllOrders.SelectedItem;
            UpdateOrdersPriceAndTimeAndRefresh(order);
        }
        private void RefreshServiceOrder()
        {
            if (DataGrid_AllOrders.SelectedItem != null)
            {
                OrderModel order = (OrderModel)DataGrid_AllOrders.SelectedItem;
                List<ServiceOrderModel> servicesOrders = _serviceOrderModelManager.GetOrdersServices(order.Id);
                DataGrid_ServicesInOrder.ItemsSource = servicesOrders;
            }
        }

        private void ComboBox_OrderServiceCount_Loaded(object sender, RoutedEventArgs e)
        {
            int[] count = new int[30];
            for (int i = 0; i < count.Length; i++)
            {
                count[i] = i + 1;
            }
            ComboBox_OrderServiceCount.ItemsSource = count;
        }

        private void ComboBox_AddNewEmployeeToOrder_Loaded(object sender, RoutedEventArgs e)
        {
            List<EmployeeModel> employees = _employeeModelManager.GetAllEmployees();
            ComboBox_AddNewEmployeeToOrder.ItemsSource = employees;
        }

        private void ComboBox_AddNewEmployeeToOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox_AddNewEmployeeToOrder.SelectedItem != null)
            {
                Button_AddEmployeeToOrder.IsEnabled = true;
            }
            else
            {
                Button_AddEmployeeToOrder.IsEnabled = false;
            }
        }

        private void Button_AddEmployeeToOrder_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid_AllOrders.SelectedItem != null)
            {
                try
                {
                    OrderModel order = (OrderModel)DataGrid_AllOrders.SelectedItem;
                    EmployeeModel employee = (EmployeeModel)ComboBox_AddNewEmployeeToOrder.SelectedItem!;
                    _employeeModelManager.AddOrderToEmployee(employee.Id, order.Id);
                    UpdateOrdersCountOfEmployees(order);
                    ClearComboBoxWithEmployees();
                    RefreshOrdersDataGrids();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    ShowMessageBox(UiTextElements.EmployeeNotUnique);
                    ClearComboBoxWithEmployees();
                }
            }
            else
            {
                return;
            }
        }

        public void ClearComboBoxWithEmployees()
        {
            ComboBox_AddNewEmployeeToOrder.Text = null;
        }

        public void ShowMessageBox(string message)
        {
            MessageBox.Show(message);
        }

        private void Button_DeleteEmployeeInOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderModel order = (OrderModel)DataGrid_AllOrders.SelectedItem;
            EmployeeModel employee = (EmployeeModel)DataGrid_EmployeesInOrder.SelectedItem;
            _employeeModelManager.DeleteEmployeesFromOrder(employee.Id, order.Id);
            UpdateOrdersCountOfEmployees(order);
            RefreshOrdersDataGrids();
        }

        private void ComboBox_HistoryOfEmployeesOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox_HistoryOfEmployeesOrders.SelectedItem != null)
            {
                EmployeeModel selectedEmployee = (EmployeeModel)ComboBox_HistoryOfEmployeesOrders.SelectedItem;
                List<OrderModel> employeesOrders = _orderModelManager.GetOrderHistoryOfTheEmployeeById(selectedEmployee.Id);
                DataGrid_AllOrders.ItemsSource = employeesOrders;
                RefreshOrdersDataGrids();
                Label_EmployeeOrdersHistory.Visibility = Visibility.Hidden;
                DataGrid_ServicesInOrder.ItemsSource = null;
                DataGrid_EmployeesInOrder.ItemsSource = null;
                Button_ResetEmployeeSelection.Visibility = Visibility.Visible;
                Button_ResetEmployeeSelection.IsEnabled = true;
            }
            else
            {
                return;
            }
        }
        private void Button_OrderDelete_Click(object sender, RoutedEventArgs e)
        {
            OrderModel selectedOrder = (OrderModel)DataGrid_AllOrders.SelectedItem;
            _orderModelManager.DeleteOrderById(selectedOrder.Id);
            UpdateAllOrdersDataGrid();
        }

        public void UpdateAllOrdersDataGrid()
        {
            List<OrderModel> orders = _orderModelManager.GetAllOrder();
            DataGrid_AllOrders.ItemsSource = orders;
        }

        private void ComboBox_HistoryOfEmployeesOrders_Loaded(object sender, RoutedEventArgs e)
        {
            List<EmployeeModel> employees = _employeeModelManager.GetAllEmployees();
            ComboBox_HistoryOfEmployeesOrders.ItemsSource = employees;
            Label_EmployeeOrdersHistory.Visibility = Visibility.Visible;
        }

        private void CB_SelectEmployee_Loaded(object sender, RoutedEventArgs e)
        {
            List<EmployeeModel> employees = _employeeModelManager.GetAllEmployees();
            CB_SelectEmployee.ItemsSource = employees;
        }

        private void RefreshEmployeesDG()
        {
            if (CB_SelectEmployee.SelectedItem != null)
            {
                EmployeeModel selectedEmployee = (EmployeeModel)CB_SelectEmployee.SelectedItem;
                List<ServiceModel> actualServices = _employeeModelManager.GetEmployeesServicesById(selectedEmployee.Id);
                DG_EmployeesActualServices.ItemsSource = actualServices;
                List<ServiceModel> unableServices = _employeeModelManager.GetEmployeesUnableServicesById(selectedEmployee.Id);
                DG_EmployeesUnableServices.ItemsSource = unableServices;
                List<WorkAreaModel> actualWorkAreas = _employeeModelManager.GetEmployeesWorkAreasById(selectedEmployee.Id);
                DG_EmployeesActualWorkAreas.ItemsSource = actualWorkAreas;
                List<WorkAreaModel> unableWorkAreas = _employeeModelManager.GetEmployeesUnableWorkAreasById(selectedEmployee.Id);
                DG_EmployeesUnableWorkAreas.ItemsSource = unableWorkAreas;
            }
            else
            {
                DG_EmployeesActualServices.ItemsSource = null;
                DG_EmployeesUnableServices.ItemsSource = null;
                DG_EmployeesActualWorkAreas.ItemsSource = null;
                DG_EmployeesUnableWorkAreas.ItemsSource = null;
            }

        }
        private void CB_SelectEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshEmployeesDG();
        }

        private void Button_DeleteEmployeesService_Click(object sender, RoutedEventArgs e)
        {
            if (CB_SelectEmployee.SelectedItem != null && DG_EmployeesActualServices.SelectedItem != null)
            {
                EmployeeModel employee = (EmployeeModel)CB_SelectEmployee.SelectedItem;
                ServiceModel service = (ServiceModel)DG_EmployeesActualServices.SelectedItem;
                _serviceModelManager.DeleteEmployeesService(employee.Id, service.Id);
                RefreshEmployeesDG();
            }
        }

        private void Button_DeleteWorkAreaFromEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (CB_SelectEmployee.SelectedItem != null && DG_EmployeesActualWorkAreas.SelectedItem != null)
            {
                EmployeeModel employee = (EmployeeModel)CB_SelectEmployee.SelectedItem;
                WorkAreaModel workArea = (WorkAreaModel)DG_EmployeesActualWorkAreas.SelectedItem;
                _employeeModelManager.DeleteEmployeesWorkArea(employee.Id, workArea.Id);
                RefreshEmployeesDG();
            }
        }

        private void Button_AddNewServiceToEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (CB_SelectEmployee.SelectedItem != null && DG_EmployeesUnableServices.SelectedItem != null)
            {
                EmployeeModel employee = (EmployeeModel)CB_SelectEmployee.SelectedItem;
                ServiceModel service = (ServiceModel)DG_EmployeesUnableServices.SelectedItem;
                _serviceModelManager.AddServiceToEmployee(employee.Id, service.Id);
                RefreshEmployeesDG();
            }
        }

        private void Button_DeleteEmployeesWorkArea_Click(object sender, RoutedEventArgs e)
        {
            if (CB_SelectEmployee.SelectedItem != null && DG_EmployeesUnableWorkAreas.SelectedItem != null)
            {
                EmployeeModel employee = (EmployeeModel)CB_SelectEmployee.SelectedItem;
                WorkAreaModel workArea = (WorkAreaModel)DG_EmployeesUnableWorkAreas.SelectedItem;
                _employeeModelManager.AddWorkAreaToEmployee(employee.Id, workArea.Id);
                RefreshEmployeesDG();
            }
        }

        private void CB_SelectOrderStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CB_SelectOrderStatus.SelectedItem != null)
            {
                StatusType status = (StatusType)CB_SelectOrderStatus.SelectedItem;
                DataGrid_AllOrders.ItemsSource = _orderModelManager.GetAllOrdersByStatus(status);
                Label_SortOrderByType.Visibility = Visibility.Hidden;
                Button_ResetStatusSelection.Visibility = Visibility.Visible;
                Button_ResetStatusSelection.IsEnabled = true;
            }
        }

        private void CB_SelectOrderStatus_Loaded(object sender, RoutedEventArgs e)
        {
            List<StatusType> statuses = new List<StatusType> { };
            foreach (StatusType st in Enum.GetValues(typeof(StatusType)))
            {
                statuses.Add(st);
            }
            CB_SelectOrderStatus.ItemsSource = statuses;
            CB_SelectOrderStatus.SelectedItem = null;
            Label_SortOrderByType.Visibility= Visibility.Visible;
        }

        //РАЙОНЫ

        private void DG_WorkArea_Loaded(object sender, RoutedEventArgs e)
        {
            List<WorkAreaModel> workAreas = _workAreaModelManager.GetAllWorkAreas();
            DG_WorkArea.ItemsSource = workAreas;
        }

        private void WorkAreaRefresh()
        {
            List<WorkAreaModel> workAreas = _workAreaModelManager.GetAllWorkAreas();
            DG_WorkArea.ItemsSource = workAreas;
        }

        private void Button_AddWorkArea_Click(object sender, RoutedEventArgs e)
        {
            if (TB_AddWorkArea.Text == "" || TB_AddWorkArea.Text == null)
            {
                ShowMessageBox(UiTextElements.EmptyWorkAreaName);
            }
            else
            {
                WorkAreaModel workArea = new WorkAreaModel() { Name = TB_AddWorkArea.Text };
                _workAreaModelManager.AddWorkArea(workArea);
                TB_AddWorkArea.Clear();
                WorkAreaRefresh();
            }
        }

        private void Button_DeleteWorkArea_Click(object sender, RoutedEventArgs e)
        {
            WorkAreaModel workArea = (WorkAreaModel)DG_WorkArea.SelectedItem;
            _workAreaModelManager.DeleteWorkAreaById(workArea.Id);
            WorkAreaRefresh();
        }

        private void Button_WorkAreaRefresh_Click(object sender, RoutedEventArgs e)
        {
            WorkAreaRefresh();
        }

        private void DG_WorkArea_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            WorkAreaModel workArea = (WorkAreaModel)e.Row.Item;
            var element = (TextBox)e.EditingElement;
            if (String.IsNullOrWhiteSpace(element.Text))
            {
                ShowMessageBox(UiTextElements.AllFieldsSholdBeFilled);
                EmployeeRefresh();
                return;
            }
            _workAreaModelManager.UpdateWorkAreaById(workArea);
        }

        private void DataGrid_AllOrders_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            OrderModel order = (OrderModel)e.Row.Item;
            try
            {
                TextBox element = (TextBox)e.EditingElement;
                TimeSpan startTime;
                if (String.IsNullOrWhiteSpace(element.Text))
                {
                    ShowMessageBox(UiTextElements.AllFieldsSholdBeFilled);
                }
                else
                {
                    if (String.Equals((string)e.Column.Header, UiTextElements.StartTime))
                    {
                        if (!TimeSpan.TryParse(element.Text, out startTime))
                        {
                            ShowMessageBox(UiTextElements.WrongTimeFormat);
                            return;
                        }
                        else
                        {
                            string tmp = startTime.ToString();
                            if (tmp.IndexOf('.') != -1)
                            {
                                ShowMessageBox(UiTextElements.WrongTimeFormat);
                                DataGridAllOrdersRefresh();
                                return;
                            }
                            order.StartTime = TimeSpan.Parse(element.Text);
                            UpdateOrdersPriceAndTimeAndRefresh(order);
                        }
                    }
                }
                List<AddressModel> allAddress = _addressModelManager.GetAllAddresses();
                AddressModel crntAddress = allAddress.Find(item => item.Street == order.Address.Street);
                if (String.Equals((string)e.Column.Header, UiTextElements.Building))
                {
                    crntAddress!.Building = element.Text;
                    crntAddress.WorkArea = order.Address.WorkArea;
                    _addressModelManager.UpdateAddressById(crntAddress);
                }              
                if (String.Equals((string)e.Column.Header, UiTextElements.Room))
                {
                    crntAddress!.Room= element.Text;
                    crntAddress.WorkArea = order.Address.WorkArea;
                    _addressModelManager.UpdateAddressById(crntAddress!);
                }
                _orderModelManager.UpdateOrder(order);
            }
            catch (InvalidCastException)
            {
                UpdateOrdersPriceAndTimeAndRefresh(order);
                _orderModelManager.UpdateOrder(order);
            }
            DataGridAllOrdersRefresh();
        }

        private void Button_ResetStatusSelection_Click(object sender, RoutedEventArgs e)
        {
            CB_SelectOrderStatus.SelectedItem = null;
            DataGridAllOrdersRefresh();
            Button_ResetStatusSelection.Visibility = Visibility.Hidden;
            Button_ResetStatusSelection.IsEnabled = false;
            Label_SortOrderByType.Visibility = Visibility.Visible;
        }

        private void Button_ResetEmployeeSelection_Click(object sender, RoutedEventArgs e)
        {
            ComboBox_HistoryOfEmployeesOrders.SelectedItem = null;
            DataGridAllOrdersRefresh();
            Button_ResetEmployeeSelection.Visibility = Visibility.Hidden;
            Button_ResetEmployeeSelection.IsEnabled = false;
            Label_EmployeeOrdersHistory.Visibility = Visibility.Visible;
        }
    }
}
