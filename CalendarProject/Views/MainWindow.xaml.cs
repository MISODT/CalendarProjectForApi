using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
using CalendarProject.Database;
using CalendarProject.Models;
using CalendarProject.Views;
using CalendarProject.Views.UserControls;
using MySql.Data.MySqlClient;

namespace CalendarProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Request request = new Request();

        public static List<User> users = new List<User>();
        public static List<Event> events = new List<Event>();

        public static string curUserId;
        public static string curUserName;

        public MainWindow()
        {
            InitializeComponent();

            FrameManager.Frame = mainFrame;
            FrameManager.Frame.Navigate(new LoginRegisterPage());
        }
    }
}
