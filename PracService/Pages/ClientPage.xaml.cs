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
using PracService.DB;
using System.Collections.ObjectModel;

namespace PracService.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public static ObservableCollection<Client> clients { get; set; }
        public ClientPage()
        {
            InitializeComponent();
            clients = new ObservableCollection<Client>(BdConnection.connection.Client.ToList());
            DataContext = this;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnADD_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddClientPage());
        }

        private void TbSearch_SelectionChanged(object sender, RoutedEventArgs e)
        {
            clients = new ObservableCollection<Client>(BdConnection.connection.Client.ToList());
            if(TbSearch.Text != "")
            {
                clients = new ObservableCollection<Client>(BdConnection.connection.Client.Where(x => x.Name.Contains(TbSearch.Text)).ToList());
            }
            lvCL.ItemsSource = clients;
        }

        private void lvCL_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var isSelected = lvCL.SelectedItem as Client;
            if(isSelected != null)
            {
                NavigationService.Navigate(new EditClientPage(isSelected));
            }
        }
    }
}
