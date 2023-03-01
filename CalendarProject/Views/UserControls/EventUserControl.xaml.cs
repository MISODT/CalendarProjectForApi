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

namespace CalendarProject.Views.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Event.xaml
    /// </summary>
    public partial class EventUserControl : UserControl
    {
        private string eventId;

        public EventUserControl(Event events)
        {
            InitializeComponent();

            eventId = events.Id;

            DataContext = events;
        }

        private void editEventButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Frame.Navigate(new AddEditPage((sender as Button).DataContext as Event));
            MainPage.UpdateData();
        }

        private void deleteEventButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.request.DeleteEvent(eventId);
            MainPage.UpdateData();
        }
    }
}
