using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CliningContoraFromValera.Bll;
using AutoMapper;
using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.Managers;
using CliningContoraFromValera.DAL.DTOs;
using System.Data;
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

        public MainWindow()
        {
            InitializeComponent();
            Button_EmployeesWorkAreasAndServicesRefresh.IsEnabled = false;
        }

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
                if (String.Equals((string)e.Column.Header, "Имя"))
                {
                    client.FirstName = Element.Text;

                }
                else if (String.Equals((string)e.Column.Header, "Фамилия"))
                {
                    client.LastName = Element.Text;
                }
                else if (String.Equals((string)e.Column.Header, "Телефон"))
                {
                    client.Phone = Element.Text;
                }
                else if (String.Equals((string)e.Column.Header, "Почта"))
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
            MessageBox.Show("Все поля обязательны к заполнению!");
        }

        //СОТРУДНИКИ

        private void DataGrid_Employees_Loaded(object sender, RoutedEventArgs e)
        {
            List<EmployeeModel> employees = employeeModelManager.GetAllEmployees();
            DataGrid_Employees.ItemsSource = employees;
        }

        private void DataGrid_Schedule_Loaded(object sender, RoutedEventArgs e)
        {
            List<EmployeeWorkTimeModel> datss = employeeWorkTimeModelManager.GetEmployeesAndWorkTimes();
            DataGrid_Schedule.ItemsSource = datss;
     
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
                if (String.Equals((string)e.Column.Header, "Фамилия"))
                {
                    employee.LastName = element.Text;
                }
                else if (String.Equals((string)e.Column.Header, "Имя"))
                {
                    employee.FirstName = element.Text;
                }
                else if (String.Equals((string)e.Column.Header, "Телефон"))
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

        //ЗАКАЗЫ

        private void DataGrid_AllOrders_Loaded(object sender, RoutedEventArgs e)
        {
            List<OrderModel> orders = orderModelManager.GetAllOrder();
            DataGrid_AllOrders.ItemsSource = orders;
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
        private void Button_ServicesDelete_Click(object sender, RoutedEventArgs e)
        {
            ServiceModel employee = (ServiceModel)DataGrid_Services.SelectedItem;
            serviceModelManager.DeleteServiceyId(employee.Id);
        }

        private void CB_ChooseEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CB_ChooseServiceType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //CB_ChooseServiceType.ItemsSource = 
        }
        private void GetMessageBoxFormatDemical()
        {
            MessageBox.Show("Все поля обязательны к заполнению!");
        }
        private void GetMessageBoxFormatTime()
        {
            MessageBox.Show("Все поля обязательны к заполнению!");
        }

        private void Button_ServiceAdd_Click(object sender, RoutedEventArgs e)
        {
            //char ch = '1';
            string str = TB_Price.Text;
            string str2 = TB_Price.Text;
            string str3 = TB_Price.Text;
            bool hasLetters = str.Any(char.IsLetter);

            if (String.IsNullOrWhiteSpace(TB_Description.Text) || String.IsNullOrWhiteSpace(TB_Name.Text)
                || String.IsNullOrWhiteSpace(TB_Price.Text) || String.IsNullOrWhiteSpace(TB_CommercialPrice.Text)
                || String.IsNullOrWhiteSpace(TB_Unit.Text) || String.IsNullOrWhiteSpace(TB_EstimatedTime.Text)
                || CB_ChooseServiceType.SelectedItem == null)
            {
                GetMessageBoxEmptyTextBoxes();
            }
            else if ((System.Text.RegularExpressions.Regex.IsMatch(str, @"[а-я]"))
                || (System.Text.RegularExpressions.Regex.IsMatch(str2, @"[а-я]")))
            {
                GetMessageBoxFormatDemical();
            }
            //else if (char.IsLetter(ch) || ch == '.' || ch == ',')
            //{
            //    GetMessageBoxFormatTime();
            //}
            else
            {
                TimeSpan estimatedTime = TimeSpan.Parse(TB_EstimatedTime.Text);
                ServiceModel employee = new ServiceModel((ServiceType)CB_ChooseServiceType.SelectedItem, TB_Name.Text, TB_Description.Text,
                Convert.ToDecimal(TB_Price.Text), Convert.ToDecimal(TB_CommercialPrice.Text), TB_Unit.Text, estimatedTime);
                serviceModelManager.AddService(employee);
                ClearServiceAddTextBoxes();
            }
        }

        private void ClearServiceAddTextBoxes()
        {
            TB_Description.Clear();
            TB_Name.Clear();
            TB_Price.Clear();
            TB_CommercialPrice.Clear();
            TB_Unit.Clear();
            TB_EstimatedTime.Clear();
            CB_ChooseServiceType.SelectedIndex = 0;
        }

        private void Button_ServiceClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_ServiceToEmployeeAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_Services_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            EmployeeModel service = (EmployeeModel)e.Row.Item;
            var element = (TextBox)e.EditingElement;
            if (String.IsNullOrWhiteSpace(element.Text))
            {
                GetMessageBoxEmptyTextBoxes();
            }
            else
            {
                if (String.Equals((string)e.Column.Header, "Тип сервиса"))
                {
                    service.FirstName = element.Text;
                }
                if (String.Equals((string)e.Column.Header, "Услуга"))
                {
                    service.LastName = element.Text;
                }
                else if (String.Equals((string)e.Column.Header, "Цена"))
                {
                    service.FirstName = element.Text;
                }
                else if (String.Equals((string)e.Column.Header, "Коммерч. цена"))
                {
                    service.Phone = element.Text;
                }
                else if (String.Equals((string)e.Column.Header, "Ед. измер."))
                {
                    service.FirstName = element.Text;
                }
                else if (String.Equals((string)e.Column.Header, "Ср. время."))
                {
                    service.FirstName = element.Text;
                }
                employeeModelManager.UpdateEmployeeById(service);
            }
        }

        private void DataGrid_Services_Loaded(object sender, RoutedEventArgs e)
        {
            List<EmployeeModel> employees = employeeModelManager.GetAllEmployees();
            DataGrid_Employees.ItemsSource = employees;
        }
    }
}
