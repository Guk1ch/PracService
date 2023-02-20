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

namespace PracService.Pages
{
	/// <summary>
	/// Логика взаимодействия для RegPage.xaml
	/// </summary>
	public partial class RegPage : Page
	{
		public RegPage()
		{
			InitializeComponent();
		}

		private void btnBack_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new AuthorisPage());
		}


		private void btnReg_Click(object sender, RoutedEventArgs e)
		{
			User user = new User();
			string Log = tbLog.Text.Trim();
			string Pass = tbPass.Password.Trim();
			user = BdConnection.connection.User.Where(x => x.Login == Log).FirstOrDefault();
			if (user == null)
			{
				User newUser = new User();
				newUser.Login = Log;
				newUser.Password = Pass;
				BdConnection.connection.User.Add(newUser);
				BdConnection.connection.SaveChanges();
				NavigationService.Navigate(new AuthorisPage());
			}
			else
			{
				MessageBox.Show("Что то не так");
			}
		}
	}
}
