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
            Button_EmployeesWorkAreasAndServicesRefresh.IsEnabled = false;
        }

        ClientModelManager clientModelManager = new ClientModelManager();
        EmployeeModelManager employeeModelManager = new EmployeeModelManager();
        WorkTimeModelManager workTimeModelManager = new WorkTimeModelManager();
        EmployeeWorkTimeModelManager employeeWorkTimeModelManager = new EmployeeWorkTimeModelManager();
        OrderModelManager orderModelManager = new OrderModelManager();
        WorkAreaModelManager workAreaModelManager = new WorkAreaModelManager();
        ServiceModelManager serviceModelManager = new ServiceModelManager();
        ServiceOrderModelManager serviceOrderModelManager = new ServiceOrderModelManager();
        List<TimeSpan> employeesShifts = new List<TimeSpan>();

        private void DataGrid_Clients_Loaded(object sender, RoutedEventArgs e)
        {
            List<ClientModel> clients = clientModelManager.GetAllClients();
            DataGrid_Clients.ItemsSource = clients;
        }

        //КЛИЕНТЫ

        private void Button_ClientDelete_Click(object sender, RoutedEventArgs e)
        {
            ClientModel client = (ClientModel)DataGrid_Clients.SelectedItem;
            clientModelManager.DeleteClientById(client.Id);
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

        private void Button_ClientAdd_Click(object sender, RoutedEventArgs e)
        {
           if (String.IsNullOrWhiteSpace(TextBox_Name.Text) || String.IsNullOrWhiteSpace(TextBox_LastName.Text))
           {
                GetMessageBoxEmptyTextBoxes();
           }
           else if(String.IsNullOrWhiteSpace(TextBox_Email.Text) || String.IsNullOrWhiteSpace(TextBox_Phone.Text))
           {
                GetMessageBoxEmptyTextBoxes();
           }
           else
           {
             ClientModel client = new ClientModel(TextBox_Name.Text,
               TextBox_LastName.Text,
               TextBox_Email.Text,
               TextBox_Phone.Text);
             clientModelManager.AddClient(client);
             ClearClientAddTextBoxes();
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
            if (String.IsNullOrWhiteSpace(TB_LastNameEmployee.Text) || String.IsNullOrWhiteSpace(TB_FirstNameEmployee.Text))
            {
                GetMessageBoxEmptyTextBoxes();
            }
            else if (String.IsNullOrWhiteSpace(TB_PhoneEmployee.Text))
            {
                GetMessageBoxEmptyTextBoxes();
            }
            else
            {
                EmployeeModel employee = new EmployeeModel(TB_FirstNameEmployee.Text,
                    TB_LastNameEmployee.Text,
                    TB_PhoneEmployee.Text);
                employeeModelManager.AddEmployee(employee);
                ClearEmployeeAddTextBoxes();
            }
        }

        private void Button_EmployeeDelete_Click(object sender, RoutedEventArgs e)
        {
            EmployeeModel employee = (EmployeeModel)DataGrid_Employees.SelectedItem;
            employeeModelManager.DeleteEmployeeById(employee.Id);
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
            Button_EmployeesWorkAreasAndServicesRefresh.IsEnabled = true;
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
                Button_EmployeesWorkAreasAndServicesRefresh.IsEnabled = false;
            }
        }

        private void Button_EmployeesWorkAreasAndServicesRefresh_Click(object sender, RoutedEventArgs e)
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
        }


        //СЕРВИСЫ

        private void Button_EmployeesServicesDelete_Click(object sender, RoutedEventArgs e)
        {
            EmployeeModel employee = (EmployeeModel)DataGrid_Employees.SelectedItem;
            ServiceModel employeesService = (ServiceModel)DataGrid_EmployeesServices.SelectedItem;
            serviceModelManager.DeleteEmployeesService(employee.Id, employeesService.Id);
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
            if (String.IsNullOrWhiteSpace(ComboBox_ShiftStartTime.Text) || String.IsNullOrWhiteSpace(ComboBox_ShiftFinishTime.Text))
            {
                GetMessageBoxEmptyTextBoxes();
            }
            else if (ComboBox_EmployeeSchedule.SelectedValue is null)
            {
                GetMessageBoxEmptyTextBoxes();
            }
            else if (String.IsNullOrWhiteSpace(DataPicker_EmployeeData.Text))
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
            EmployeeModel employee = ComboBox_EmployeeSchedule.SelectedValue as EmployeeModel;
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
            EmployeeWorkTimeModel shift = DataGrid_Schedule.SelectedItem as EmployeeWorkTimeModel;
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
                        GetMessageBoxFormatException();
                        return;
                    }
                    else
                    {
                        string tmp = startTime.ToString();
                        if (tmp.IndexOf('.') != -1)
                        {
                            GetMessageBoxFormatException();
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
                        GetMessageBoxFormatException();
                        return;
                    }
                    else
                    {
                        string tmp = finishTime.ToString();
                        if (tmp.IndexOf('.') != -1)
                        {
                            GetMessageBoxFormatException();
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
            OrderModel order = DataGrid_AllOrders.SelectedItem as OrderModel;
            List<ServiceOrderModel> servicesInOrder = serviceOrderModelManager.GetOrdersServices(order.Id);
            DataGrid_ServicesInOrder.ItemsSource = servicesInOrder;
        }


        
    }
}
