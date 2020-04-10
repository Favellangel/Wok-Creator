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
using System.IO;
using System.Reflection;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Work_Creator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private ViewModel vm = new ViewModel();
        /*private Word.Application wordApp; // для открытия приложения
        private Word.Documents wordDocuments; // для создания документа
        private Word.Document wordDocument;*/
        public MainWindow()
        {
            InitializeComponent();            
            // добавление версиии на форму
            labelAssembly.Content = "version: " + Convert.ToString(Assembly.GetExecutingAssembly().GetName().Version);
        }

        private void Button_Click_RGR (object sender, RoutedEventArgs e)
        {
            this.DataContext = new ViewModel();
        }

        private void button_Click_Create_RGR(object sender, RoutedEventArgs e)
        {
            ViewModel vm = (ViewModel)DataContext; // класс для взаимодействия логики и интерфейса
            FileWord word = new FileWord();// класс для работы с документом
            Queue<Element> elements = new Queue<Element>();
            Element tmpElem = new Element { Name = "", Length = 0, AngularVelocity = 0, Velocity = 0 };
            
            if(vm.Element1.Name != "")
                elements.Enqueue(vm.Element1);
            if(vm.Element2.Name != "")
                elements.Enqueue(vm.Element2);
            if(vm.Element3.Name != "")
                elements.Enqueue(vm.Element3);
            if (vm.Element4.Name != "")
                elements.Enqueue(vm.Element4);
            if (vm.Element5.Name != "")
                elements.Enqueue(vm.Element5);
            if (vm.Element6.Name != "")
                elements.Enqueue(vm.Element6);
            
            word.createDoc();
            word.setDefaultOptionRGR();
            word.addElementO1A(vm.ElementO1A.AngularVelocity, vm.ElementO1A.Length, vm.ElementO1A.CountVelocity());
            while (elements.Count != 0)
            {
                if (elements.First<Element>().Name[1] == vm.ElementO2.Name[2])
                    word.addElements(elements.Dequeue(), vm.ElementO2);
                else if (elements.First<Element>().Name[1] == vm.ElementO3.Name[2])
                    word.addElements(elements.Dequeue(), vm.ElementO3);
                else if(elements.First<Element>() != null)
                    word.addElements(elements.Dequeue(), tmpElem);
            }
            word.saveDoc();
            word.closeDoc();
            /*----------------------------------*/

            /*----------------------------------*/
            /*----------&&&-------------*/
            /*----------------------------------*/
        }

    }
}
