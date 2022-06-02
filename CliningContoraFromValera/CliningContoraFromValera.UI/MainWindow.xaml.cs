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
        }

        private void DataGrid_Clients_Loaded(object sender, RoutedEventArgs e)
        {
            List<ClientDTO> clients = ClientManager.GetAllClients();
            List<ClientModel> CustomerModel = mapper.Map<List<ClientModel>>(clients);
            DataGrid_Clients.ItemsSource = clients;

        }

        private void Button_ClientDelete_Click(object sender, RoutedEventArgs e)
        {
            ClientDTO client = DataGrid_Clients.SelectedItem as ClientDTO;
            ClientManager.DeleteClientById(client.Id);
        }

        private void DataGrid_Clients_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            ClientDTO client = (ClientDTO)e.Row.Item;
            var Element = (TextBox)e.EditingElement;
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

            ClientManager.UpdateClientById(client);
        }

        private void Button_ClientAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
