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
        ClientModelManager clientModelManager = new ClientModelManager();
        EmployeeModelManager employeeModelManager = new EmployeeModelManager();
        WorkTimeModelManager workTimeModelManager = new WorkTimeModelManager();
        EmployeeWorkTimeModelManager employeeWorkTimeModelManager = new EmployeeWorkTimeModelManager();
        OrderModelManager orderModelManager = new OrderModelManager();
        WorkAreaModelManager workAreaModelManager = new WorkAreaModelManager();
        ServiceModelManager serviceModelManager = new ServiceModelManager();
        ServiceOrderModelManager serviceOrderModelManager = new ServiceOrderModelManager();
        AddressModelManager addressModelManager = new AddressModelManager();

        public MainWindow()
        {
            InitializeComponent();
            Button_ServiceToEmployeeAdd.IsEnabled = false;
            CB_ChooseEmployee.IsEnabled = false;
            TB_ServiceDescription.IsEnabled = false;
            TB_ServiceDescriptionSave.IsEnabled = false;
        }

        //КЛИЕНТЫ

        private void DataGrid_Clients_Loaded(object sender, RoutedEventArgs e)
        {
            List<ClientModel> clients = clientModelManager.GetAllClients();
            DataGrid_Clients.ItemsSource = clients;
        }

        private void Button_ClientDelete_Click(object sender, RoutedEventArgs e)
        {
            ClientModel client = (ClientModel)DataGrid_Clients.SelectedItem;
            clientModelManager.DeleteClientById(client.Id);
            List<ClientModel> clients = clientModelManager.GetAllClients();
            DataGrid_Clients.ItemsSource = clients;
        }

        private void DataGrid_Clients_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            ClientModel client = (ClientModel)e.Row.Item;
            var Element = (TextBox)e.EditingElement;
            if (String.IsNullOrWhiteSpace(Element.Text))
            {
                GetMessageBoxEmptyTextBoxes();
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

                clientModelManager.UpdateClientById(client);
            }
        }

        private void GetMessageBoxFormatPhone()
        {
            MessageBox.Show("Введите номер по примеру '+7(951) 123-45-67'");
        }

        private void Button_ClientAdd_Click(object sender, RoutedEventArgs e)
        {
            string phone = TextBox_Phone.Text;
           if (String.IsNullOrWhiteSpace(TextBox_Name.Text) || String.IsNullOrWhiteSpace(TextBox_LastName.Text)
                || String.IsNullOrWhiteSpace(TextBox_Email.Text) || String.IsNullOrWhiteSpace(TextBox_Phone.Text))
           {
                GetMessageBoxEmptyTextBoxes();
           }
           else if(System.Text.RegularExpressions.Regex.IsMatch(phone, @"[а-я]")
                || System.Text.RegularExpressions.Regex.IsMatch(phone, @"[a-z]")
                || System.Text.RegularExpressions.Regex.IsMatch(phone, @"[\/\@\#\%\^\*\(\)\;\:\'\<\>\$]$"))
           {
                GetMessageBoxFormatPhone();
           }
           else
           {
               ClientModel client = new ClientModel(TextBox_Name.Text,
               TextBox_LastName.Text,
               TextBox_Email.Text,
               TextBox_Phone.Text);
               clientModelManager.AddClient(client);
               ClearClientAddTextBoxes();
               List<ClientModel> clients = clientModelManager.GetAllClients();
               DataGrid_Clients.ItemsSource = clients;
           }
        }

        private void Button_ClientRefresh_Click(object sender, RoutedEventArgs e)
        {
            List<ClientModel> clients = clientModelManager.GetAllClients();
            DataGrid_Clients.ItemsSource = clients;
        }

        private void ClearClientAddTextBoxes()
        {
            TextBox_Name.Clear();
            TextBox_LastName.Clear();
            TextBox_Email.Clear();
            TextBox_Phone.Clear();
        }

        private void GetMessageBoxEmptyTextBoxes()
        {
            MessageBox.Show(UITextElements.EmptyFieldsError);
        }

        //СОТРУДНИКИ

        private void DataGrid_Employees_Loaded(object sender, RoutedEventArgs e)
        {
            List<EmployeeModel> employees = employeeModelManager.GetAllEmployees();
            DataGrid_Employees.ItemsSource = employees;
        }

        private void DataGrid_Schedule_Loaded(object sender, RoutedEventArgs e)
        {
            List<EmployeeWorkTimeModel> employeesWorkTimes = workTimeModelManager.GetEmployeesAndWorkTimes();
            DataGrid_Schedule.ItemsSource = employeesWorkTimes;
        }

        private void Button_EmployeeRefresh_Click(object sender, RoutedEventArgs e)
        {
            List<EmployeeModel> employees = employeeModelManager.GetAllEmployees();
            DataGrid_Employees.ItemsSource = employees;
        }

        private void Button_EmployeeAdd_Click(object sender, RoutedEventArgs e)
        {
            String phone = TB_PhoneEmployee.Text;
            if (String.IsNullOrWhiteSpace(TB_LastNameEmployee.Text) || String.IsNullOrWhiteSpace(TB_FirstNameEmployee.Text)
                || String.IsNullOrWhiteSpace(TB_PhoneEmployee.Text))
            {
                GetMessageBoxEmptyTextBoxes();
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(phone, @"[а-я]")
                || System.Text.RegularExpressions.Regex.IsMatch(phone, @"[a-z]")
                || System.Text.RegularExpressions.Regex.IsMatch(phone, @"[\/\@\#\%\^\*\(\)\;\:\'\<\>\$]$"))
            {
                GetMessageBoxFormatPhone();
            }
            else
            {
                EmployeeModel employee = new EmployeeModel(TB_FirstNameEmployee.Text,
                TB_LastNameEmployee.Text,
                TB_PhoneEmployee.Text);
                employeeModelManager.AddEmployee(employee);
                ClearEmployeeAddTextBoxes();
                List<EmployeeModel> employees = employeeModelManager.GetAllEmployees();
                DataGrid_Employees.ItemsSource = employees;
            }
        }

        private void Button_EmployeeDelete_Click(object sender, RoutedEventArgs e)
        {
            EmployeeModel employee = (EmployeeModel)DataGrid_Employees.SelectedItem;
            employeeModelManager.DeleteEmployeeById(employee.Id);
            List<EmployeeModel> employees = employeeModelManager.GetAllEmployees();
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
                GetMessageBoxEmptyTextBoxes();
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

                employeeModelManager.UpdateEmployeeById(employee);
            }
        }

        private void DataGrid_Employees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid_Employees.SelectedItem != null)
            {
                EmployeeModel employee = (EmployeeModel)DataGrid_Employees.SelectedItem;
                DataGrid_EmployeesWorkAreas.ItemsSource = employeeModelManager.GetEmployeesWorkAreasById(employee!.Id);
                DataGrid_EmployeesServices.ItemsSource = employeeModelManager.GetEmployeesServicesById(employee!.Id);
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
            DataGrid_EmployeesWorkAreas.ItemsSource = employeeModelManager.GetEmployeesWorkAreasById(employee!.Id);
            DataGrid_EmployeesServices.ItemsSource = employeeModelManager.GetEmployeesServicesById(employee!.Id);
        }

        //РАЙОНЫ

        private void Button_EmployeesWorkAreasDelete_Click(object sender, RoutedEventArgs e)
        {
            EmployeeModel employee = (EmployeeModel)DataGrid_Employees.SelectedItem;
            WorkAreaModel employeesWorkArea = (WorkAreaModel)DataGrid_EmployeesWorkAreas.SelectedItem;
            workAreaModelManager.DeleteEmployeesWorkArea(employee.Id, employeesWorkArea.Id);
            EmployeesWorkAreasAndServicesRefresh();
        }


        //СЕРВИСЫ

        private void Button_EmployeesServicesDelete_Click(object sender, RoutedEventArgs e)
        {
            EmployeeModel employee = (EmployeeModel)DataGrid_Employees.SelectedItem;
            ServiceModel employeesService = (ServiceModel)DataGrid_EmployeesServices.SelectedItem;
            serviceModelManager.DeleteEmployeesService(employee.Id, employeesService.Id);
            EmployeesWorkAreasAndServicesRefresh();
        }
        private void Button_ServicesDelete_Click(object sender, RoutedEventArgs e)
        {
            ServiceModel employee = (ServiceModel)DataGrid_Services.SelectedItem;
            serviceModelManager.DeleteServiceyId(employee.Id);
            List<ServiceModel> services = serviceModelManager.GetAllServices();
            DataGrid_Services.ItemsSource = services;
        }

        private void CB_ChooseEmployee_Loaded(object sender, RoutedEventArgs e)
        {
            List<EmployeeModel> employees =  employeeModelManager.GetAllEmployees();
            CB_ChooseEmployee.ItemsSource = employees;
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

        private void GetMessageBoxFormatDemical()
        {
            MessageBox.Show("Введите чило в формате '10,00 в поля 'Цена', 'Коммерческая цена'");
        }
        private void GetMessageBoxFormatTime()
        {
            MessageBox.Show("Формат заполнения времени '10:00'");
        }

        private void Button_ServiceAdd_Click(object sender, RoutedEventArgs e)
        {
            decimal decimalFormat;
            if (String.IsNullOrWhiteSpace(TB_Description.Text) || String.IsNullOrWhiteSpace(TB_Name.Text)
                || String.IsNullOrWhiteSpace(TB_Price.Text) || String.IsNullOrWhiteSpace(TB_CommercialPrice.Text)
                || CB_ChooseUnitType.SelectedItem == null || CB_ChooseEstimatedTime.SelectedItem == null
                || CB_ChooseServiceType.SelectedItem == null)
            {
                GetMessageBoxEmptyTextBoxes();
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
                    GetMessageBoxFormatDemical();
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
            serviceModelManager.AddService(employee);
            ClearServiceAddTextBoxes();
            RefreshService();
        }
        private void RefreshService()
        {
            List<ServiceModel> services = serviceModelManager.GetAllServices();
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

        private void GetMessageBoxNoSelected()
        {
            MessageBox.Show("Сотрудник не выбран!");
        }

        private void Button_ServiceToEmployeeAdd_Click(object sender, RoutedEventArgs e)
        {
            EmployeeModel employee = (EmployeeModel)CB_ChooseEmployee.SelectedItem;
            ServiceModel employeesService = (ServiceModel)DataGrid_Services.SelectedItem;
            if (employee != null)
            {
                serviceModelManager.AddServiceToEmployee(employee.Id, employeesService.Id);
            }
            else
            {
                GetMessageBoxNoSelected();
            }
            CB_ChooseEmployee.SelectedItem = null;
            DataGrid_Services.SelectedItem = null;
            Button_ServiceToEmployeeAdd.IsEnabled = false;
        }

        private void DataGrid_Services_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            decimal decimalFormat;
            TimeSpan estimatedTime;
            ServiceModel service = (ServiceModel)e.Row.Item;
            TextBox element = (TextBox)e.EditingElement;
            if (String.IsNullOrWhiteSpace(element.Text))
            {
                GetMessageBoxEmptyTextBoxes();
            }
            else
            {
                if (String.Equals((string)e.Column.Header, "Услуга"))
                {
                    service.Name = element.Text;
                }
                else if (String.Equals((string)e.Column.Header, "Цена"))
                {
                    if(!Decimal.TryParse(element.Text, out decimalFormat))
                    {
                        GetMessageBoxFormatDemical();
                        RefreshService();
                        return;
                    }
                    service.Price = Convert.ToDecimal(element.Text);
                }
                else if (String.Equals((string)e.Column.Header, "Коммерч. цена"))
                {
                    if (!Decimal.TryParse(element.Text, out decimalFormat))
                    {
                        GetMessageBoxFormatDemical();
                        RefreshService();
                        return;
                    }
                    service.CommercialPrice = Convert.ToDecimal(element.Text);
                }
                else if (String.Equals((string)e.Column.Header, "Ед. измер."))
                {
                    service.Unit = element.Text;
                }
                else if (String.Equals((string)e.Column.Header, "Ср. время."))
                {
                    if(!TimeSpan.TryParse(element.Text, out estimatedTime))
                    {
                        GetMessageBoxFormatTime();
                        return;
                    }
                    else
                    {
                        string tmp = estimatedTime.ToString();
                        if (tmp.IndexOf('.') != -1)
                        {
                            GetMessageBoxFormatTime();
                            RefreshService();
                            return;
                        }
                        service.EstimatedTime = TimeSpan.Parse(element.Text);
                    }
                }
                serviceModelManager.UpdateServiceById(service);
                RefreshService();
                DataGrid_Services.SelectedIndex = -1;
            }
        }

        private void DataGrid_Services_Loaded(object sender, RoutedEventArgs e)
        {
            List<ServiceModel> services = serviceModelManager.GetAllServices();
            DataGrid_Services.ItemsSource = services;
            e.Source = DataGrid_Services;
        }
                
        private void DataGrid_Services_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ServiceModel service = (ServiceModel)DataGrid_Services.SelectedItem;
            if (DataGrid_Services.SelectedItem != null)
            {
                Button_ServiceToEmployeeAdd.IsEnabled = true;
                CB_ChooseEmployee.IsEnabled = true;
                TB_ServiceDescriptionSave.IsEnabled = true;
                TB_ServiceDescription.IsEnabled = true;
                TB_ServiceDescription.Text = service.Description;
            }
            else
            {
                TB_ServiceDescription.Clear();
                TB_ServiceDescription.IsEnabled = false;
                CB_ChooseEmployee.IsEnabled = false;
                Button_ServiceToEmployeeAdd.IsEnabled = false;
                TB_ServiceDescriptionSave.IsEnabled = false;
            }
        }

        private void GetMessageBoxNoDescription()
        {
            MessageBox.Show("Заполните поле описания услуги!");
        }

        private void TB_ServiceDescriptionSave_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrWhiteSpace(TB_ServiceDescription.Text))
            {
                GetMessageBoxNoDescription();
            }
            else
            {
                ServiceModel service = (ServiceModel)DataGrid_Services.SelectedItem;
                service.Description = TB_ServiceDescription.Text.Trim();
                serviceModelManager.UpdateServiceById(service);
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
                List<EmployeeWorkTimeModel> emloyees = employeeWorkTimeModelManager.GetSuitableEmployees(date, sa.Id, wa.Id);
                DataGrid_RelevantEmployees.ItemsSource = emloyees;
                DP_OrdersDate.IsEnabled = false;
            }
            else
            {
                GetMessageBoxEmptyTextBoxes();
            }
        }

        private void DataGrid_RelevantEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid_RelevantEmployees.SelectedItem != null)
            {
                EmployeeWorkTimeModel employee = (EmployeeWorkTimeModel)DataGrid_RelevantEmployees.SelectedItem;
                int employeeId = employee.Id;
                DateTime date = (DateTime)DP_OrdersDate.SelectedDate!;
                List<OrderModel> orders = orderModelManager.GetAllEmployeesOrdersByDate(employeeId, date);
                DataGrid_CurrentOrders.ItemsSource = orders;
            }
        }

        private void CB_DesiredWorkArea_Loaded(object sender, RoutedEventArgs e)
        {
            List<WorkAreaModel> workAreas = workAreaModelManager.GetAllWorkAreas();
            CB_DesiredWorkArea.ItemsSource = workAreas;
        }

        private void CB_DesiredService_Loaded(object sender, RoutedEventArgs e)
        {
            List<ServiceModel> allServices = serviceModelManager.GetAllServices();
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
            List<ServiceModel> allServices = serviceModelManager.GetAllServices();
            if (CB_DesiredServiceType.SelectedItem == null)
            {
                CB_DesiredService.ItemsSource = allServices;
            }
            else
            {
                List<ServiceModel> services = serviceModelManager.GetServicesByType(allServices,
                    (ServiceType)CB_DesiredServiceType.SelectedItem);
                CB_DesiredService.ItemsSource = services;
            }
        }


        //ГРАФИК 

        private void ComboBox_EmployeeSchedule_Loaded(object sender, RoutedEventArgs e)
        {
            List<EmployeeModel> employees = employeeModelManager.GetAllEmployees();
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
                GetMessageBoxEmptyTextBoxes();
            }
            else 
            {
                AddShift();
                AddShiftItemsClear();
                RefreshShifts();
                StartAndFinishLabelVisibilities();
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
                GetMessageBoxShiftTimeException();
            }
            else
            {
                WorkTimeModel workTime = new WorkTimeModel(dateTime, newStartTime, newFinishTime, employee.Id);
                workTimeModelManager.AddWorkTime(workTime);
            }
        }

        private void GetMessageBoxFormatException()
        {
            MessageBox.Show("Данные заполнены некорректно!");
        }

        private void GetMessageBoxShiftTimeException()
        {
            MessageBox.Show("Смена не может закончиться раньше своего начала!");
        }

        private void RefreshShifts()
        {
            List<EmployeeWorkTimeModel> employeesWorkTimes = employeeWorkTimeModelManager.GetEmployeesAndWorkTimes();
            DataGrid_Schedule.ItemsSource = employeesWorkTimes;
        }

        private void Button_ShowSchedule_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(DatePicker_FromDate.Text) || String.IsNullOrWhiteSpace(DatePicker_ToDate.Text))
            {
                GetMessageBoxEmptyTextBoxes();
            }
            else
            {
                DateTime startDate = DateTime.Parse(DatePicker_FromDate.Text);
                DateTime endDate = DateTime.Parse(DatePicker_ToDate.Text);
                List<EmployeeWorkTimeModel> employeesSchedule = employeeWorkTimeModelManager.GetEmployeesSchedule(startDate, endDate);
                DataGrid_Schedule.ItemsSource = employeesSchedule;
            }
        }

        private void Button_ShiftDelete_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWorkTimeModel shift = (EmployeeWorkTimeModel)DataGrid_Schedule.SelectedItem;
            workTimeModelManager.DeleteWorkTimeById(shift.WorkTimeId);
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
            string nameColumnStartTime = "Начало смены";
            string nameColumnFinishTime = "Конец смены";
            if (String.IsNullOrWhiteSpace(Element.Text))
            {
                GetMessageBoxEmptyTextBoxes();
            }
            else
            {
                if (String.Equals((string)e.Column.Header, nameColumnStartTime))
                {
                    if (!TimeSpan.TryParse(Element.Text, out startTime))
                    {
                        GetMessageBoxFormatTime();
                        return;
                    }
                    else
                    {
                        string tmp = startTime.ToString();
                        if (tmp.IndexOf('.') != -1)
                        {
                            GetMessageBoxFormatTime();
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
                        GetMessageBoxFormatTime();
                        return;
                    }
                    else
                    {
                        string tmp = finishTime.ToString();
                        if (tmp.IndexOf('.') != -1)
                        {
                            GetMessageBoxFormatTime();
                            RefreshShifts();
                            return;
                        }

                        workTimes.FinishTime = TimeSpan.Parse(Element.Text);
                    }
                }
                workTimeModelManager.UpdateWorkTimeById(workTimes);
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
            List<OrderModel> orders = orderModelManager.GetAllOrder();
            DataGrid_AllOrders.ItemsSource = orders;
        }

        private void ComboBox_AddNewService_Loaded(object sender, RoutedEventArgs e)
        {
            List<ServiceModel> services = serviceModelManager.GetAllServices();
            ComboBox_AddNewService.ItemsSource = services;
        }

        private void ComboBox_AddNewService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Label_AddNewService.Visibility = Visibility.Hidden;
            ComboBox_AddNewService.Items.Refresh();
        }

        private void Button_AddServiseToOrder_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void DataGrid_ServicesInOrder_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        private void DataGrid_AllOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OrderModel order = (OrderModel)DataGrid_AllOrders.SelectedItem;
            List<ServiceOrderModel> servicesInOrder = serviceOrderModelManager.GetOrdersServices(order.Id);
            DataGrid_ServicesInOrder.ItemsSource = servicesInOrder;
        }
        private void ComboBox_OrderClient_Loaded(object sender, RoutedEventArgs e)
        {
            List<ClientModel> clients = clientModelManager.GetAllClients();
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

        private void ComboBox_OrderEmployees_Loaded(object sender, RoutedEventArgs e)
        {
            List<EmployeeModel> employees = employeeModelManager.GetAllEmployees();
            ComboBox_OrderEmployees.ItemsSource = employees;
        }

        private void ComboBox_OrderWorkArea_Loaded(object sender, RoutedEventArgs e)
        {
            List<WorkAreaModel> workAreas = workAreaModelManager.GetAllWorkAreas();
            ComboBox_OrderWorkArea.ItemsSource = workAreas;
        }

        private void ComboBox_OrderService_Loaded(object sender, RoutedEventArgs e)
        {
            List<ServiceModel> services = serviceModelManager.GetAllServices();
            ComboBox_OrderService.ItemsSource = services;
        }

        private void Button_OrderAdd_Click(object sender, RoutedEventArgs e)
        {
            string street = TextBox_OrderStreet.Text;
            string building = TextBox_OrderBuilding.Text;
            string room = TextBox_OrderRoom.Text;
            WorkAreaModel workArea = (WorkAreaModel)ComboBox_OrderWorkArea.SelectedItem;
            AddressModel newAddress = new AddressModel(street, building, room, workArea.Id);
            addressModelManager.AddAddress(newAddress);
            List<AddressModel> allAddress =  addressModelManager.GetAllAddresses();
            AddressModel crntAddress = allAddress.Find(item => item.Street == street);
            ClientModel client = (ClientModel)ComboBox_OrderClient.SelectedItem;
            DateTime date = DateTime.Parse(DatePicker_OrderDate.Text);
            TimeSpan startTime = (TimeSpan)ComboBox_OrderStartTime.SelectedItem;
            TimeSpan estimatedTime = new TimeSpan(10, 00, 00);
            TimeSpan finishTime = new TimeSpan(12, 00, 00);
            decimal price = 1000;
            StatusType status = CliningContoraFromValera.Bll.StatusType.Выполняется;
            bool isCommercial = true;
            OrderModel orderModel = new OrderModel(date, startTime, estimatedTime, finishTime, price, status, isCommercial, client.Id, crntAddress!.Id, workArea.Id);
            orderModelManager.AddOrder(orderModel);
        }

        private void Button_AddEmployeesToOrder_Click(object sender, RoutedEventArgs e)
        {
            ServiceOrderModel serviceOrder = (ServiceOrderModel)ComboBox_OrderService.SelectedItem;
            serviceOrderModelManager.AddServiceToOrder(serviceOrder);
        }

        private void Button_AddServicesToOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void VisibilityAddingEmployeesAndServicesToOrder()
        {
            Label_OrderEmployees.Visibility = Visibility.Visible;
            ComboBox_OrderEmployees.Visibility = Visibility.Visible;
            Label_OrderServices.Visibility = Visibility.Visible;
            ComboBox_OrderService.Visibility = Visibility.Visible;
            Button_AddEmployeesToOrder.Visibility = Visibility.Visible;
            Button_AddServicesToOrder.Visibility = Visibility.Visible;
        }
    }
}
