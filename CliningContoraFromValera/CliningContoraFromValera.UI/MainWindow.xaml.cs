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
using CliningContoraFromValera.DAL;

namespace CliningContoraFromValera.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            //List<ClientDTO> clients = ClientManager.GetAllClients();
            //List<ClientModel> ClientModel = mapper.Map<List<ClientModel>>(clients);
            //DataGrid_AllOrders.ItemsSource = ClientModel;
        //ClientManager ClientManager = new ClientManager();


        AutoMapper.Mapper mapper = MapperConfigStorage.GetInstance();
        EmployeeManager EmployeeManager = new EmployeeManager();

        public MainWindow()
        {
            InitializeComponent();

            EmployeeDTO history = EmployeeManager.GetAllEmployeesInfoById(1);
            EmployeeModel EmployeeModel = mapper.Map<EmployeeModel>(history);
            DataGrid_AllOrders.ItemsSource = (System.Collections.IEnumerable)EmployeeModel;


        }

        private void DataGrid_AllOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_AllOrders_Loaded(object sender, RoutedEventArgs e)
        {
            

        }
    }
}
