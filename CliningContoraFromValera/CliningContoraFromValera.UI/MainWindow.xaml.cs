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
        ClientModelManager ClientModelManager = new ClientModelManager();
        WorkTimeModelManager WorkTimeModelManager = new WorkTimeModelManager();
        EmployeeWorkTimeModelManager EmployeeWorkTimeModelManager = new EmployeeWorkTimeModelManager();
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
                GetMassegeBoxEmptyTextBoxes();
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
                GetMassegeBoxEmptyTextBoxes();
           }
           else if(String.IsNullOrWhiteSpace(TextBox_Email.Text) || String.IsNullOrWhiteSpace(TextBox_Phone.Text))
           {
                GetMassegeBoxEmptyTextBoxes();
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

        private void GetMassegeBoxEmptyTextBoxes()
        {
            MessageBox.Show("Все поля обязательны к заполнению!");
        }

        private void Button_ClientRefresh_Click(object sender, RoutedEventArgs e)
        {
            List<ClientModel> clients = ClientModelManager.GetAllClients();
            DataGrid_Clients.ItemsSource = clients;
        }

        private void DataGrid_Schedule_Loaded(object sender, RoutedEventArgs e)
        {
            List<EmployeeWorkTimeModel> employeesWorkTimes = EmployeeWorkTimeModelManager.GetEmployeesAndWorkTimes();
            DataGrid_Schedule.ItemsSource = employeesWorkTimes;
        }

        private void ComboBox_EmployeeSchedule_Loaded(object sender, RoutedEventArgs e)
        {
            List<EmployeeModel> employees = EmployeeModelManager.GetAllEmployees();
            ComboBox_EmployeeSchedule.ItemsSource = employees;
        }

        private void Button_AddShift_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TextBox_EmployeeStartTime.Text) || String.IsNullOrWhiteSpace(TextBox_EmployeeFinishTime.Text))
            {
                GetMassegeBoxEmptyTextBoxes();
            }
            else if (ComboBox_EmployeeSchedule.SelectedValue is null)
            {
                GetMassegeBoxEmptyTextBoxes();
            }
            else if (String.IsNullOrWhiteSpace(DataPicker_EmployeeData.Text))
            {
                GetMassegeBoxEmptyTextBoxes();
            }
            else
            {
                try
                {
                    AddShift();
                    AddShiftItemsClear();
                    RefreshShifts();
                }
                catch (FormatException)
                {
                    GetMessageBoxFormatException();
                }
            }
        }

        private void AddShift()
        {
            EmployeeModel employee = ComboBox_EmployeeSchedule.SelectedValue as EmployeeModel;
            TimeSpan newStartTime = TimeSpan.Parse(TextBox_EmployeeStartTime.Text);
            TimeSpan newFinishTime = TimeSpan.Parse(TextBox_EmployeeFinishTime.Text);
            DateTime dateTime = DateTime.Parse(DataPicker_EmployeeData.Text);

            WorkTimeModel workTime = new WorkTimeModel(dateTime, newStartTime, newFinishTime, employee.Id);
            WorkTimeModelManager.AddWorkTime(workTime);
        }

        private void GetMessageBoxFormatException()
        {
            MessageBox.Show("Данные заполнены некорректно!");
        }


        private void RefreshShifts()
        {
            List<EmployeeWorkTimeModel> employeesWorkTimes = EmployeeWorkTimeModelManager.GetEmployeesAndWorkTimes();
            DataGrid_Schedule.ItemsSource = employeesWorkTimes;
        }

        private void Button_ShowSchedule_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(DatePicker_FromDate.Text) || String.IsNullOrWhiteSpace(DatePicker_ToDate.Text))
            {
                GetMassegeBoxEmptyTextBoxes();
            }
            else
            {
                DateTime startDate = DateTime.Parse(DatePicker_FromDate.Text);
                DateTime endDate = DateTime.Parse(DatePicker_ToDate.Text);
                List<EmployeeWorkTimeModel> employeesSchedule = EmployeeWorkTimeModelManager.GetEmployeesSchedule(startDate, endDate);
                DataGrid_Schedule.ItemsSource = employeesSchedule;
            }
        }

        private void Button_ShiftDelete_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWorkTimeModel shift = DataGrid_Schedule.SelectedItem as EmployeeWorkTimeModel;
            WorkTimeModelManager.DeleteWorkTimeById(shift.WorkTimeId);
            RefreshShifts();
        }

        private void AddShiftItemsClear()
        {
            TextBox_EmployeeStartTime.Clear();
            TextBox_EmployeeFinishTime.Clear();
            DataPicker_EmployeeData.Text = null;
            ComboBox_EmployeeSchedule.Text = null;
            Label_ChooseEmployee.Visibility = Visibility.Visible;
        }


        private void DataGrid_Schedule_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                WorkTimeModel shift = (WorkTimeModel)e.Row.Item;
                var Element = (TextBox)e.EditingElement;
                string nameColumnStartTime = "Начало смены";
                string nameColumnFinishTime = "Конец смены";
                if (String.IsNullOrWhiteSpace(Element.Text))
                {
                    GetMassegeBoxEmptyTextBoxes();
                }
                else
                {
                    if (String.Equals((string)e.Column.Header, nameColumnStartTime))
                    {
                        shift.StartTime = TimeSpan.Parse(Element.Text);
                    }
                    else if (String.Equals((string)e.Column.Header, nameColumnFinishTime))
                    {
                        shift.FinishTime = TimeSpan.Parse(Element.Text);
                    }

                    WorkTimeModelManager.UpdateWorkTimeById(shift);
                }
            }
            catch (FormatException)
            {
                GetMessageBoxFormatException();
            }
        }

        private void ComboBox_EmployeeSchedule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Label_ChooseEmployee.Visibility = Visibility.Hidden;
            ComboBox_EmployeeSchedule.Items.Refresh();
        }
    }
}
