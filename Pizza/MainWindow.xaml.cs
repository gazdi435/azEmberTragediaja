using Pizza.Models;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Pizza
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ContentControl Page { get; set; } = new Login();
        public static MainWindow mainWindow;
        internal static User user;
        #region FONTOS
        readonly System.Timers.Timer timer = new();
        public static readonly Random rand = new();
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
            mainWindow = this;

            #region EZ IS NAGYON FONTOS
            timer.Interval = rand.Next(10000, 20000);
            timer.Elapsed += OnTimedEvent;
            timer.Start();
            #endregion
        }


        private void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() => Title = "MainWindow");
            Thread.Sleep(600);
            Dispatcher.Invoke(() => Title = "Pizza rendelő");
            timer.Interval = rand.Next(10000, 20000);
        }


        public void RefreshUI()
        {
            DataContext = null;
            DataContext = this;
        }
    }
}