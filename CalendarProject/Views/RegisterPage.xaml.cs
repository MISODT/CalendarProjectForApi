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
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();

            EnDisConfirmButton();
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterUser();

            FrameManager.Frame.Navigate(new MainPage());
        }

        private void nameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckEmptyName();

            EnDisConfirmButton();
        }

        private void loginTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckEmptyLogin();

            EnDisConfirmButton();
        }

        private void passwordPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            CheckEmptyPassword();

            EnDisConfirmButton();
        }

        private void goBackButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Frame.GoBack();
        }

        private void RegisterUser()
        {
            MainWindow.request.InsertUser(nameTextBox.Text, loginTextBox.Text, passwordPasswordBox.Password);

           MainWindow.users = MainWindow.request.GetUsers();

            foreach (var user in MainWindow.users)
            {
                if (loginTextBox.Text == user.UserLogin && passwordPasswordBox.Password == user.UserPassword)
                {
                    MainWindow.curUserId = user.Id;
                    MainWindow.curUserName = user.Name;
                }
            }

            FrameManager.Frame.Navigate(new MainPage());
        }

        private void CheckEmptyName()
        {
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                nameTextBox.Background = Brushes.DarkRed;
            }
            else
            {
                nameTextBox.Background = Brushes.White;
            }
        }

        private void CheckEmptyLogin()
        {
            if (string.IsNullOrEmpty(loginTextBox.Text))
            {
                loginTextBox.Background = Brushes.DarkRed;
            }
            else
            {
                loginTextBox.Background = Brushes.White;
            }
        }

        private void CheckEmptyPassword()
        {
            if (string.IsNullOrEmpty(passwordPasswordBox.Password))
            {
                passwordPasswordBox.Background = Brushes.DarkRed;
            }
            else
            {
                passwordPasswordBox.Background = Brushes.White;
            }
        }

        private void EnDisConfirmButton()
        {
            if (loginTextBox.Text != "" && passwordPasswordBox.Password != "" && nameTextBox.Text != "")
            {
                registerButton.IsEnabled = true;
            }
            else
            {
                registerButton.IsEnabled = false;
            }
        }
    }
}
