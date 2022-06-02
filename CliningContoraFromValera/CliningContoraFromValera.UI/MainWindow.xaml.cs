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
        AutoMapper.Mapper mapper = MapperConfigStorage.GetInstance();
        ClientManager ClientManager = new ClientManager();
        EmployeeManager EmployeeManager = new EmployeeManager();
        ClientModelManager ClientModelManager = new ClientModelManager();
        EmployeeModelManager EmployeeModelManager = new EmployeeModelManager();



        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_Clients_Loaded(object sender, RoutedEventArgs e)
        {
            List<ClientModel> clients = ClientModelManager.GetAllClients();
            DataGrid_Clients.ItemsSource = clients;
        }

        private void Button_ClientDelete_Click(object sender, RoutedEventArgs e)
        {
            ClientModel client = DataGrid_Clients.SelectedItem as ClientModel;
            ClientModelManager.DeleteClientById(client.Id);
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

                ClientModelManager.UpdateClientById(client);
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
             ClientModelManager.AddClient(client);
             ClearClientAddTextBoxes();
           }
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

        private void DataGrid_Employees_Loaded(object sender, RoutedEventArgs e)
        {
            List<EmployeeModel> employees = EmployeeModelManager.GetAllEmployees();
            DataGrid_Employees.ItemsSource = employees;
        }

        private void Button_ClientRefresh_Click(object sender, RoutedEventArgs e)
        {
            List<ClientModel> clients = ClientModelManager.GetAllClients();
            DataGrid_Clients.ItemsSource = clients;
        }

        private void Button_EmployeeRefresh_Click(object sender, RoutedEventArgs e)
        {
            List<EmployeeModel> employees = EmployeeModelManager.GetAllEmployees();
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
                EmployeeModelManager.AddEmployee(employee);
                ClearEmployeeAddTextBoxes();
            }
        }

        private void Button_EmployeeDelete_Click(object sender, RoutedEventArgs e)
        {
            EmployeeModel employee = DataGrid_Employees.SelectedItem as EmployeeModel;
            EmployeeModelManager.DeleteEmployeeById(employee.Id);
        }

        private void ClearEmployeeAddTextBoxes()
        {
            TB_LastNameEmployee.Clear();
            TB_FirstNameEmployee.Clear();
            TB_PhoneEmployee.Clear();
        }
    }
}
