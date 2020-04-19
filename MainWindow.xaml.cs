using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Reflection;
using Office;

namespace Work_Creator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
            // добавление версиии на форму
            labelAssembly.Content = "version: " + Convert.ToString(Assembly.GetExecutingAssembly().GetName().Version);
        }

        private void addElement(Element element, ref Queue<Element> elements)
        {
            if (element.Name != "")
                elements.Enqueue(element);
        }

        private void Button_Click_RGR (object sender, RoutedEventArgs e)
        {
            this.DataContext = new ViewModelRGRMechanic();
            BtnRGR.Visibility = Visibility.Hidden;
            GridRGR.Visibility = Visibility.Visible;
        }

        private void button_Click_Create_RGR(object sender, RoutedEventArgs e)
        {
            ViewModelRGRMechanic vm = (ViewModelRGRMechanic)DataContext; // класс для взаимодействия логики и интерфейса
            FileWord word = new FileWord();// класс для работы с документом
            Queue<Element> elements = new Queue<Element>();
            Element tmpElem = new Element("");

            addElement(vm.Element1, ref elements);
            addElement(vm.Element2, ref elements);
            addElement(vm.Element3, ref elements);
            addElement(vm.Element4, ref elements);
            addElement(vm.Element5, ref elements);
            addElement(vm.Element6, ref elements);          
            
            // работа с word файлом
            word.createDoc();
            word.setDefaultOptionRGR();
            word.addElementO1A(vm.ElementO1A.AngularVelocity, vm.ElementO1A.Length, vm.ElementO1A.CountVelocity());
            while (elements.Count != 0)
            {
                // если 2 буква звена соответствует 2 букве звена О2*
                if (elements.First<Element>().Name[1] == vm.ElementO2.Name[2]) { }
                    //word.addElements(elements.Dequeue(), vm.ElementO2);
                // если 2 буква звена соответствует 2 букве звена О3*
                else if (elements.First<Element>().Name[1] == vm.ElementO3.Name[2]) { }
                    //word.addElements(elements.Dequeue(), vm.ElementO3);
                else if(elements.First<Element>() != null) { }
                    //word.addElements(elements.Dequeue(), tmpElem);
            }
            word.saveDoc();
            word.closeDoc();
            /*----------------------------------*/

            /*----------------------------------*/
            /*----------&&&-------------*/
            /*----------------------------------*/
        }

        private void BtnCloseCreateRGR_Click(object sender, RoutedEventArgs e)
        {
            GridRGR.Visibility = Visibility.Hidden;
            BtnRGR.Visibility = Visibility.Visible;
        }
    }
}
