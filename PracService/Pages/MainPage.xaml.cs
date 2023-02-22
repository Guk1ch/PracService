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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    { 
        public static ObservableCollection<Client_Servise> clientService { get; set; }
        public MainPage(User user)
        {
            InitializeComponent();
            clientService = new ObservableCollection<Client_Servise>(BdConnection.connection.Client_Servise.ToList());
            DataContext = this;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorisPage());
        }

        private void btnClient_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientPage());
        }

        private void btnService_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ServicePage());
        }

        private void lvCS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var isSelected = lvCS.SelectedItem as Client_Servise;
            if(isSelected != null)
            {
                NavigationService.Navigate(new EditCSPage());
            }
        }
    }
}
