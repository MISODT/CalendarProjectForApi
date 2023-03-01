using CalendarProject.Database;
using CalendarProject.Models;
using CalendarProject.Views.UserControls;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public static ObservableCollection<EventUserControl> eventUserControl = new ObservableCollection<EventUserControl>(); 

        public MainPage()
        {
            InitializeComponent();

            UpdateData();

            nameTextBlock.Text = $"Привет, {MainWindow.curUserName}!";

            mainListView.ItemsSource = eventUserControl;
        }

        private void addEventButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Frame.Navigate(new AddEditPage(null));
        }

        public static void UpdateData()
        {
            eventUserControl.Clear();

            MainWindow.events = MainWindow.request.GetEvents();

            foreach (var item in MainWindow.events)
            {
                if (item.UserId == MainWindow.curUserId)
                {
                    eventUserControl.Add(new EventUserControl(item));
                }
            }
        }

        private void MainPage_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                UpdateData();
            }
        }
    }
}
