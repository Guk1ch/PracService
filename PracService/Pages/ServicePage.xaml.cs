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
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
		public static ObservableCollection<Service> services { get; set; }
        public ServicePage()
        {
            InitializeComponent();
			services = new ObservableCollection<Service>(BdConnection.connection.Service.ToList());
			DataContext = this;
        }

		private void btnBack_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.GoBack();
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new AddServicePage());
		}

		private void lvS_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var isSelected = lvS.SelectedItem as Service;
			if (isSelected != null)
			{
				NavigationService.Navigate(new EditCSPage(isSelected));
			}
		}

		private void TbSearch_SelectionChanged(object sender, RoutedEventArgs e)
		{
			services = new ObservableCollection<Service>(BdConnection.connection.Service.ToList());
			if (TbSearch.Text != "")
			{
				services = new ObservableCollection<Service>(BdConnection.connection.Service.Where(x => x.Name.Contains(TbSearch.Text)).ToList());
			}
			lvS.ItemsSource = services;
		}
	}
}
