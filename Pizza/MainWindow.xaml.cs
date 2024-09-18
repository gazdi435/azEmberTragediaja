﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pizza
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ContentControl Login { get; set; } = new Login();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
        }

        private void RefreshUI()
        {
            DataContext = null;
            DataContext = this;
        }
    }
}