using CalendarProject.Database;
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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();

            EnDisConfirmButton();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsUserExists())
            {
                FrameManager.Frame.Navigate(new MainPage());
            }
            else
            {
                MessageBox.Show("Неверно указаны логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
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

        private bool IsUserExists()
        {
            MainWindow.users = MainWindow.request.GetUsers();

            foreach (var user in MainWindow.users)
            {
                if (loginTextBox.Text == user.UserLogin && passwordPasswordBox.Password == user.UserPassword)
                {
                    MainWindow.curUserId = user.Id;
                    MainWindow.curUserName = user.Name;

                    return true;
                }
            }

            return false;
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
            if (loginTextBox.Text != "" && passwordPasswordBox.Password != "")
            {
                loginButton.IsEnabled = true;
            }
            else
            {
                loginButton.IsEnabled = false;
            }
        }
    }
}