using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Reflection;
using Office;
using System.IO;

namespace Work_Creator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string path = @"E:\New\test.docx";
        public MainWindow()
        {
            InitializeComponent();            
            // добавление версиии на форму
            labelAssembly.Content = "version: " + Convert.ToString(Assembly.GetExecutingAssembly().GetName().Version);
        }

        private void Button_Click_RGR (object sender, RoutedEventArgs e)
        {
            this.DataContext = new ViewModelRGRMechanic();
            BtnRGR.Visibility = Visibility.Hidden;
            GridRGR.Visibility = Visibility.Visible;
        }

        private void button_Click_Create_RGR(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            RGRMechanic rgr = new RGRMechanic(DataContext, path);
            rgr.addElements();
            rgr.createDocRGR();
            Cursor = Cursors.Arrow;
        }

        private void BtnCloseCreateRGR_Click(object sender, RoutedEventArgs e)
        {
            GridRGR.Visibility = Visibility.Hidden;
            BtnRGR.Visibility = Visibility.Visible;
        }
    }
}
