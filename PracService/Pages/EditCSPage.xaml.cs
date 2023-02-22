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
    /// Логика взаимодействия для EditCSPage.xaml
    /// </summary>
    public partial class EditCSPage : Page
    {
        public EditCSPage(Client_Servise client_Servise)
        {
            InitializeComponent();
        }
    }
}
