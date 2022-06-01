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

namespace CliningContoraFromValera.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AutoMapper.Mapper mapper = MapperConfigStorage.GetInstance();
        ClientManager ClientManager = new ClientManager();



        public MainWindow()
        {
            InitializeComponent();
            List<ClientDTO> clients = ClientManager.GetAllClients();
            List<ClientModel> ClientModel = mapper.Map<List<ClientModel>>(clients);
            DataGrid_AllOrders.ItemsSource = ClientModel;
        }

        private void DataGrid_AllOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_AllOrders_Loaded(object sender, RoutedEventArgs e)
        {
            

        }
    }
}
