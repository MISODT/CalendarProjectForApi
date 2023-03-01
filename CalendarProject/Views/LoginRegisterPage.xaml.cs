using CalendarProject.Models;
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

namespace CalendarProject.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginRegisterPage.xaml
    /// </summary>
    public partial class LoginRegisterPage : Page
    {
        public LoginRegisterPage()
        {
            InitializeComponent();
        }

        private void goToLoginButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Frame.Navigate(new LoginPage());
        }

        private void goToRegisterButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Frame.Navigate(new RegisterPage());
        }
    }
}
