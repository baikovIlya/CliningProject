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
        private ClientModelManager _clientModelManager = new ClientModelManager();
        private EmployeeModelManager _employeeModelManager = new EmployeeModelManager();
        private WorkTimeModelManager _workTimeModelManager = new WorkTimeModelManager();
        private EmployeeWorkTimeModelManager _employeeWorkTimeModelManager = new EmployeeWorkTimeModelManager();
        private OrderModelManager _orderModelManager = new OrderModelManager();
        private WorkAreaModelManager _workAreaModelManager = new WorkAreaModelManager();
        private ServiceModelManager _serviceModelManager = new ServiceModelManager();
        private ServiceOrderModelManager _serviceOrderModelManager = new ServiceOrderModelManager();
        private AddressModelManager _addressModelManager = new AddressModelManager();

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
            List<ClientModel> clients = _clientModelManager.GetAllClients();
            DataGrid_Clients.ItemsSource = clients;
        }

        private void DataGrid_Clients_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            ClientModel client = (ClientModel)e.Row.Item;
            var Element = (TextBox)e.EditingElement;
            if (String.IsNullOrWhiteSpace(Element.Text))
            {
                GetMessageBoxException(UITextElements.EmptyDiscription);
            }
            else
            {
                if (String.Equals((string)e.Column.Header, UITextElements.FirstName))
                {
                    client.FirstName = Element.Text;
                }
                else if (String.Equals((string)e.Column.Header, UITextElements.LastName))
                {
                    client.LastName = Element.Text;
                }
                else if (String.Equals((string)e.Column.Header, UITextElements.PhoneNomer))
                {
                    client.Phone = Element.Text;
                }
                else if (String.Equals((string)e.Column.Header, UITextElements.Email))
                {
                    client.Email = Element.Text;
                }

                _clientModelManager.UpdateClientById(client);
            }
        }

        private void Button_ClientAdd_Click(object sender, RoutedEventArgs e)
        {
            string phone = TextBox_Phone.Text;
           if (String.IsNullOrWhiteSpace(TextBox_Name.Text) || String.IsNullOrWhiteSpace(TextBox_LastName.Text)
                || String.IsNullOrWhiteSpace(TextBox_Email.Text) || String.IsNullOrWhiteSpace(TextBox_Phone.Text))
           {
                GetMessageBoxException(UITextElements.EmptyDiscription);
            }
           else if(System.Text.RegularExpressions.Regex.IsMatch(phone, @"[а-я]")
                || System.Text.RegularExpressions.Regex.IsMatch(phone, @"[a-z]")
                || System.Text.RegularExpressions.Regex.IsMatch(phone, @"[\/\@\#\%\^\*\(\)\;\:\'\<\>\$]$"))
           {
                GetMessageBoxException(UITextElements.WrongPhoneFormat);
           }
           else
           {
               ClientModel client = new ClientModel(TextBox_Name.Text,
               TextBox_LastName.Text,
               TextBox_Email.Text,
               TextBox_Phone.Text);
               _clientModelManager.AddClient(client);
               ClearClientAddTextBoxes();
               List<ClientModel> clients = _clientModelManager.GetAllClients();
               DataGrid_Clients.ItemsSource = clients;
           }
        }

        private void Button_ClientRefresh_Click(object sender, RoutedEventArgs e)
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
            List<EmployeeModel> employees = _employeeModelManager.GetAllEmployees();
            DataGrid_Employees.ItemsSource = employees;
        }

        private void DataGrid_Schedule_Loaded(object sender, RoutedEventArgs e)
        {
            List<EmployeeWorkTimeModel> employeesWorkTimes = _workTimeModelManager.GetEmployeesAndWorkTimes();
            DataGrid_Schedule.ItemsSource = employeesWorkTimes;
        }

        private void Button_EmployeeRefresh_Click(object sender, RoutedEventArgs e)
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
                GetMessageBoxException(UITextElements.EmptyDiscription);
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(phone, @"[а-я]")
                || System.Text.RegularExpressions.Regex.IsMatch(phone, @"[a-z]")
                || System.Text.RegularExpressions.Regex.IsMatch(phone, @"[\/\@\#\%\^\*\(\)\;\:\'\<\>\$]$"))
            {
                GetMessageBoxException(UITextElements.WrongPhoneFormat);
            }
            else
            {
                EmployeeModel employee = new EmployeeModel(TB_FirstNameEmployee.Text,
                TB_LastNameEmployee.Text,
                TB_PhoneEmployee.Text);
                _employeeModelManager.AddEmployee(employee);
                ClearEmployeeAddTextBoxes();
                List<EmployeeModel> employees = _employeeModelManager.GetAllEmployees();
                DataGrid_Employees.ItemsSource = employees;
            }
        }

        private void Button_EmployeeDelete_Click(object sender, RoutedEventArgs e)
        {
            EmployeeModel employee = (EmployeeModel)DataGrid_Employees.SelectedItem;
            _employeeModelManager.DeleteEmployeeById(employee.Id);
            List<EmployeeModel> employees = _employeeModelManager.GetAllEmployees();
            DataGrid_Employees.ItemsSource = employees;
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
                GetMessageBoxException(UITextElements.EmptyDiscription);
            }
            else
            {
                if (String.Equals((string)e.Column.Header, UITextElements.LastName))
                {
                    employee.LastName = element.Text;
                }
                else if (String.Equals((string)e.Column.Header, UITextElements.FirstName))
                {
                    employee.FirstName = element.Text;
                }
                else if (String.Equals((string)e.Column.Header, UITextElements.PhoneNomer))
                {
                    employee.Phone = element.Text;
                }

                _employeeModelManager.UpdateEmployeeById(employee);
            }
        }

        private void DataGrid_Employees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid_Employees.SelectedItem != null)
            {
                EmployeeModel employee = (EmployeeModel)DataGrid_Employees.SelectedItem;
                DataGrid_EmployeesWorkAreas.ItemsSource = _employeeModelManager.GetEmployeesWorkAreasById(employee!.Id);
                DataGrid_EmployeesServices.ItemsSource = _employeeModelManager.GetEmployeesServicesById(employee!.Id);
            }
            else
            {
                DataGrid_EmployeesWorkAreas.ItemsSource = null;
                DataGrid_EmployeesServices.ItemsSource = null;
            }
        }

        private void EmployeesWorkAreasAndServicesRefresh()
        {
            EmployeeModel employee = (EmployeeModel)DataGrid_Employees.SelectedItem;
            DataGrid_EmployeesWorkAreas.ItemsSource = _employeeModelManager.GetEmployeesWorkAreasById(employee!.Id);
            DataGrid_EmployeesServices.ItemsSource = _employeeModelManager.GetEmployeesServicesById(employee!.Id);
        }

        //РАЙОНЫ

        private void Button_EmployeesWorkAreasDelete_Click(object sender, RoutedEventArgs e)
        {
            EmployeeModel employee = (EmployeeModel)DataGrid_Employees.SelectedItem;
            WorkAreaModel employeesWorkArea = (WorkAreaModel)DataGrid_EmployeesWorkAreas.SelectedItem;
            _employeeModelManager.DeleteEmployeesWorkArea(employee.Id, employeesWorkArea.Id);
            EmployeesWorkAreasAndServicesRefresh();
        }


        //СЕРВИСЫ

        private void Button_EmployeesServicesDelete_Click(object sender, RoutedEventArgs e)
        {
            EmployeeModel employee = (EmployeeModel)DataGrid_Employees.SelectedItem;
            ServiceModel employeesService = (ServiceModel)DataGrid_EmployeesServices.SelectedItem;
            _serviceModelManager.DeleteEmployeesService(employee.Id, employeesService.Id);
            EmployeesWorkAreasAndServicesRefresh();
        }
        private void Button_ServicesDelete_Click(object sender, RoutedEventArgs e)
        {
            ServiceModel employee = (ServiceModel)DataGrid_Services.SelectedItem;
            _serviceModelManager.DeleteServiceyId(employee.Id);
            List<ServiceModel> services = _serviceModelManager.GetAllServices();
            DataGrid_Services.ItemsSource = services;
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
           CB_ChooseEstimatedTime.ItemsSource = EstimatedTime.employeesWorkTime;
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
                GetMessageBoxException(UITextElements.EmptyDiscription);
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
                    GetMessageBoxException(UITextElements.WrongPriceFormat);
                }
            }
            else
            {
                AddService();
            }
        }

        private void AddService()
        {
            ServiceModel employee = new ServiceModel((ServiceType)CB_ChooseServiceType.SelectedItem, TB_Name.Text, TB_Description.Text,
            Convert.ToDecimal(TB_Price.Text), Convert.ToDecimal(TB_CommercialPrice.Text), Convert.ToString(CB_ChooseUnitType.SelectedItem)!, (TimeSpan)CB_ChooseEstimatedTime.SelectedItem);
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
            decimal decimalFormat;
            TimeSpan estimatedTime;
            ServiceModel service = (ServiceModel)e.Row.Item;
            TextBox element = (TextBox)e.EditingElement;
            if (String.IsNullOrWhiteSpace(element.Text))
            {
                GetMessageBoxException(UITextElements.EmptyDiscription);
            }
            else
            {
                if (String.Equals((string)e.Column.Header, UITextElements.Service))
                {
                    service.Name = element.Text;
                }
                else if (String.Equals((string)e.Column.Header, UITextElements.Price))
                {
                    if(!Decimal.TryParse(element.Text, out decimalFormat))
                    {
                        GetMessageBoxException(UITextElements.WrongPriceFormat);
                        RefreshService();
                        return;
                    }
                    service.Price = Convert.ToDecimal(element.Text);
                }
                else if (String.Equals((string)e.Column.Header, UITextElements.CommercialPrice))
                {
                    if (!Decimal.TryParse(element.Text, out decimalFormat))
                    {
                        GetMessageBoxException(UITextElements.WrongPriceFormat);
                        RefreshService();
                        return;
                    }
                    service.CommercialPrice = Convert.ToDecimal(element.Text);
                }
                else if (String.Equals((string)e.Column.Header, UITextElements.Unit))
                {
                    service.Unit = element.Text;
                }
                else if (String.Equals((string)e.Column.Header, UITextElements.EstTime))
                {
                    if(!TimeSpan.TryParse(element.Text, out estimatedTime))
                    {
                        GetMessageBoxException(UITextElements.WrongTimeFormat);
                        return;
                    }
                    else
                    {
                        string tmp = estimatedTime.ToString();
                        if (tmp.IndexOf('.') != -1)
                        {
                            GetMessageBoxException(UITextElements.WrongTimeFormat);
                            RefreshService();
                            return;
                        }
                        service.EstimatedTime = TimeSpan.Parse(element.Text);
                    }
                }
                _serviceModelManager.UpdateServiceById(service);
                RefreshService();
                DataGrid_Services.SelectedIndex = -1;
            }
        }

        private void DataGrid_Services_Loaded(object sender, RoutedEventArgs e)
        {
            List<ServiceModel> services = _serviceModelManager.GetAllServices();
            DataGrid_Services.ItemsSource = services;
            e.Source = DataGrid_Services;
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
            if(String.IsNullOrWhiteSpace(TB_ServiceDescription.Text))
            {
                GetMessageBoxException(UITextElements.EmptyDiscription);
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
                GetMessageBoxException(UITextElements.EmptyDiscription);
            }
        }

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
            foreach(ServiceType st in Enum.GetValues(typeof(ServiceType)))
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
            ComboBox_ShiftStartTime.ItemsSource = Times.employeesWorkTime;
        }
        private void ComboBox_ShiftFinishTime_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox_ShiftFinishTime.ItemsSource = Times.employeesWorkTime;
        }
        private void Button_AddShift_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox_ShiftStartTime == null || ComboBox_ShiftFinishTime == null
                || ComboBox_EmployeeSchedule == null || DataPicker_EmployeeData == null)
            {
                GetMessageBoxException(UITextElements.EmptyDiscription);
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
                catch(System.Data.SqlClient.SqlException)
                {
                    GetMessageBoxException(UITextElements.ShiftAlreadyExist);
                }
            }
        }

        private void StartAndFinishLabelVisibilities()
        {
            Label_ShiftStart.Visibility = Visibility.Visible;
            Label_ShiftFinish.Visibility = Visibility.Visible;
        }

        private void AddShift()
        {
            EmployeeModel employee = (EmployeeModel)ComboBox_EmployeeSchedule.SelectedValue;
            TimeSpan newStartTime = TimeSpan.Parse(ComboBox_ShiftStartTime.Text);
            TimeSpan newFinishTime = TimeSpan.Parse(ComboBox_ShiftFinishTime.Text);
            DateTime dateTime = DateTime.Parse(DataPicker_EmployeeData.Text);
            if(newStartTime >= newFinishTime)
            {
                GetMessageBoxException(UITextElements.WrongScheduleStartEndTime);
            }
            else
            {
                WorkTimeModel workTime = new WorkTimeModel(dateTime, newStartTime, newFinishTime, employee.Id);
                _workTimeModelManager.AddWorkTime(workTime);
            }
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
                GetMessageBoxException(UITextElements.EmptyDiscription);
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
            WorkTimeModel workTimes = new WorkTimeModel(crnt.WorkTimeId, crnt.Date, crnt.StartTime, crnt.FinishTime, crnt.EmployeeId);
            var Element = (TextBox)e.EditingElement;
            TimeSpan finishTime;
            TimeSpan startTime;
            string nameColumnStartTime = UITextElements.SheduleStart;
            string nameColumnFinishTime = UITextElements.SheduleEnd;
            if (String.IsNullOrWhiteSpace(Element.Text))
            {
                GetMessageBoxException(UITextElements.EmptyDiscription);
            }
            else
            {
                if (String.Equals((string)e.Column.Header, nameColumnStartTime))
                {
                    if (!TimeSpan.TryParse(Element.Text, out startTime))
                    {
                        GetMessageBoxException(UITextElements.WrongTimeFormat);
                        return;
                    }
                    else
                    {
                        string tmp = startTime.ToString();
                        if (tmp.IndexOf('.') != -1)
                        {
                            GetMessageBoxException(UITextElements.WrongTimeFormat);
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
                        GetMessageBoxException(UITextElements.WrongTimeFormat);
                        return;
                    }
                    else
                    {
                        string tmp = finishTime.ToString();
                        if (tmp.IndexOf('.') != -1)
                        {
                            GetMessageBoxException(UITextElements.WrongTimeFormat);
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
            List<OrderModel> orders = _orderModelManager.GetAllOrder();
            DataGrid_AllOrders.ItemsSource = orders;
        }

        private void ComboBox_AddNewService_Loaded(object sender, RoutedEventArgs e)
        {
            List<ServiceModel> services = _serviceModelManager.GetAllServices();
            ComboBox_AddNewService.ItemsSource = services;
        }

        private void ComboBox_AddNewService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox_AddNewService.SelectedItem != null)
            {
                Label_AddNewService.Visibility = Visibility.Collapsed;
                if(ComboBox_OrderServiceCount != null)
                {
                    Button_AddServiseToOrder.IsEnabled = true;
                }
                else
                {
                    Button_AddServiseToOrder.IsEnabled = false;
                }
            }
            else
            {
                Label_AddNewService.Visibility = Visibility.Visible;
            }
        }

        private void ComboBox_OrderServiceCount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBox_OrderServiceCount.SelectedItem != null)
            {
                Label_ServiceCount.Visibility = Visibility.Collapsed;
                if(ComboBox_AddNewService.SelectedItem != null)
                {
                    Button_AddServiseToOrder.IsEnabled = true;
                }
                else
                {
                    Button_AddServiseToOrder.IsEnabled = false;
                }
            }
            else
            {
                Label_ServiceCount.Visibility = Visibility.Visible;
            }
        }

        private void ClearServiceOrder()
        {
            ComboBox_OrderServiceCount.SelectedItem = null;
            ComboBox_AddNewService.SelectedItem = null;
            Label_AddNewService.Visibility = Visibility.Visible;
            Label_ServiceCount.Visibility = Visibility.Visible;
        }

        private void Button_AddServiseToOrder_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid_AllOrders.SelectedItem != null && ComboBox_AddNewService.SelectedItem != null && ComboBox_OrderServiceCount.SelectedItem != null)
            {
                try
                {
                    OrderModel order = (OrderModel)DataGrid_AllOrders.SelectedItem;
                    ServiceModel service = (ServiceModel)ComboBox_AddNewService.SelectedItem;
                    int count = (int)ComboBox_OrderServiceCount.SelectedItem;
                    ServiceOrderModel serviceOrder = new ServiceOrderModel() { OrderId = order.Id, ServiceId = service.Id, Count = count };
                    _serviceOrderModelManager.AddServiceToOrder(serviceOrder);
                    ClearServiceOrder();
                    Button_AddServiseToOrder.IsEnabled = false;
                    RefreshServiceOrder();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    GetMessageBoxException(UITextElements.DoubleAddingService);
                    ClearServiceOrder();
                }
            }
            else
            {
                return;
            }            
        }

        private void DataGrid_AllOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DataGrid_AllOrders.SelectedItem != null)
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
                DataGrid_EmployeesInOrder.ItemsSource= null;
                ComboBox_OrderServiceCount.IsEnabled = false;
                ComboBox_AddNewService.IsEnabled = false;
                ComboBox_AddNewEmployeeToOrder.IsEnabled = false;
            }
        }

        private void RefreshOrdersDataGrids()
        {
            if(DataGrid_AllOrders.SelectedItem != null)
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
            ComboBox_OrderStartTime.ItemsSource = Times.ordersStartTimes;
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
                || (String.IsNullOrWhiteSpace(TextBox_OrderRoom.Text))))
            {
                GetMessageBoxException(UITextElements.EmptyDiscription);
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
                StatusType status = CliningContoraFromValera.Bll.StatusType.Выполняется;
                AddressModel newAddress = new AddressModel(street, building, room, workArea.Id);
                _addressModelManager.AddAddress(newAddress);
                List<AddressModel> allAddress = _addressModelManager.GetAllAddresses();
                AddressModel crntAddress = allAddress.Find(item => item.Street == street);
                TimeSpan estimatedTime = new TimeSpan(10, 00, 00);
                TimeSpan finishTime = new TimeSpan(12, 00, 00);
                decimal price = 1000;
                bool isCommercial = true;
                OrderModel orderModel = new OrderModel(date, startTime, estimatedTime, finishTime, price, status, isCommercial, client.Id, crntAddress!.Id, workArea.Id);
                _orderModelManager.AddOrder(orderModel);
            }
        }

        private void Button_ServiceFromOrderDelete_Click(object sender, RoutedEventArgs e)
        {
            ServiceOrderModel serviceOrder = (ServiceOrderModel)DataGrid_ServicesInOrder.SelectedItem;
            _serviceOrderModelManager.DeleteServiceFromOrder(serviceOrder);
            RefreshServiceOrder();
        }
        private void RefreshServiceOrder()
        {
            OrderModel order = (OrderModel)DataGrid_AllOrders.SelectedItem;
            List<ServiceOrderModel> servicesOrders = _serviceOrderModelManager.GetOrdersServices(order.Id);
            DataGrid_ServicesInOrder.ItemsSource = servicesOrders;
        }

        private void ComboBox_OrderServiceCount_Loaded(object sender, RoutedEventArgs e)
        {
            int[] count = new int[30];
            for(int i = 0; i < count.Length; i++)
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
                Label_AddNewEnployeeToOrder.Visibility = Visibility.Collapsed;
                Button_AddEmployeeToOrder.IsEnabled = true;
            }
            else
            {
                Label_AddNewEnployeeToOrder.Visibility = Visibility.Visible;
                Button_AddEmployeeToOrder.IsEnabled = false;
            }
        }

        private void Button_AddEmployeeToOrder_Click(object sender, RoutedEventArgs e)
        {   
            if (DataGrid_AllOrders.SelectedItem != null && ComboBox_AddNewEmployeeToOrder != null)
            {
                try
                {
                    OrderModel order = (OrderModel)DataGrid_AllOrders.SelectedItem;
                    EmployeeModel employee = (EmployeeModel)ComboBox_AddNewEmployeeToOrder.SelectedItem!;
                    _employeeModelManager.AddOrderToEmployee(employee.Id, order.Id);
                    ClearComboBoxWithEmployees();
                    RefreshOrdersDataGrids();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    GetMessageBoxException(UITextElements.DoubleAddingEmployee);
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
            Label_AddNewEnployeeToOrder.Visibility = Visibility.Visible;
        }

        public void GetMessageBoxException(string message)
        {
            MessageBox.Show(message);
        }

        private void Button_DeleteEmployeeInOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderModel order = (OrderModel)DataGrid_AllOrders.SelectedItem;
            EmployeeModel employee = (EmployeeModel)DataGrid_EmployeesInOrder.SelectedItem;
            _employeeModelManager.DeleteEmployeesFromOrder(employee.Id, order.Id);
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
            }
            else
            {
                return;
            }
            

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
    }
}
