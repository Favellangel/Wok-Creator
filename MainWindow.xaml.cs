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

        private void ElementExists(Element element, ref Queue<Element> elements)
        {
            if (element.Name != "")
                elements.Enqueue(element);
                
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
            Element tmpElem = new Element("");

            ElementExists(vm.Element1, ref elements);
            ElementExists(vm.Element2, ref elements);
            ElementExists(vm.Element3, ref elements);
            ElementExists(vm.Element4, ref elements);
            ElementExists(vm.Element5, ref elements);
            ElementExists(vm.Element6, ref elements);          
            
            // работа с word файлом
            word.createDoc();
            word.setDefaultOptionRGR();
            word.addElementO1A(vm.ElementO1A.AngularVelocity, vm.ElementO1A.Length, vm.ElementO1A.CountVelocity());
            while (elements.Count != 0)
            {
                // если 2 буква звена соответствует 2 букве звена О2*
                if (elements.First<Element>().Name[1] == vm.ElementO2.Name[2])
                    word.addElements(elements.Dequeue(), vm.ElementO2);
                // если 2 буква звена соответствует 2 букве звена О3*
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
