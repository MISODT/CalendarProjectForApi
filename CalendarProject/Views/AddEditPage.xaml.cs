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
    /// Логика взаимодействия для NewObjectPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private bool isEditing;
        private string eventId;

        public AddEditPage(Event events)
        {
            InitializeComponent();

            EnDisConfirmButton();

            if(events != null)
            {
                isEditing = true;
                goBackButton.Visibility = Visibility.Hidden;
                eventId = events.Id;
            }
            else
            {
                isEditing = false;
            }

            DataContext = events;
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            if(!isEditing)
            {
                MainWindow.request.InsertEvent(themeTextBox.Text, dateDatePicker.SelectedDate.Value.Date.ToShortDateString(), MainWindow.curUserId);
                FrameManager.Frame.GoBack();
            }
            else
            {
                MainWindow.request.UpdateEvent(themeTextBox.Text, dateDatePicker.SelectedDate.Value.Date.ToShortDateString(), eventId);
                FrameManager.Frame.GoBack();
            }
        }

        private void goBackButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Frame.GoBack();
        }

        private void themeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckEmptyTheme();

            EnDisConfirmButton();
        }

        private void dateDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckEmptyDate();

            EnDisConfirmButton();
        }

        private void CheckEmptyTheme()
        {
            if (string.IsNullOrEmpty(themeTextBox.Text))
            {
                themeTextBox.Background = Brushes.DarkRed;
            }
            else
            {
                themeTextBox.Background = Brushes.White;
            }
        }

        private void CheckEmptyDate()
        {
            if (string.IsNullOrEmpty(dateDatePicker.Text))
            {
                dateDatePicker.BorderBrush = Brushes.DarkRed;
            }
            else
            {
                dateDatePicker.BorderBrush = Brushes.Transparent;
            }
        }

        private void EnDisConfirmButton()
        {
            if (themeTextBox.Text != "" && dateDatePicker.Text != "")
            {
                confirmButton.IsEnabled = true;
            }
            else
            {
                confirmButton.IsEnabled = false;
            }
        }
    }
}