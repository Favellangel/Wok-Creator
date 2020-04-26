using System;
using System.Collections.Generic;
using Office;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_Creator
{
    /// <summary>
    /// Класс для создания документа РГР механика. 
    /// DataContext - данные от пользователя(то что введено в форму). 
    /// path - путь к файлу
    /// </summary>
    /// <remarks>
    /// </remarks>
    class RGRMechanic
    {
        private const string CM = "см/с";
        private const string RAD = "рад/с";
        private ViewModelRGRMechanic vm;
        Queue<Element> elements;
        Element tmpElem;
        FileWord fileWord;

        public RGRMechanic(object DataContext, string path)
        {
            vm = (ViewModelRGRMechanic)DataContext; // класс для взаимодействия логики и интерфейса
            elements = new Queue<Element>();
            tmpElem = new Element("");
            fileWord = new FileWord(path);
            addElements();
        }
        private void addElements()
        {
            if (vm.Element1.Name != "")
                elements.Enqueue(vm.Element1);
            if (vm.Element2.Name != "")
                elements.Enqueue(vm.Element2);
            if (vm.Element3.Name != "")
                elements.Enqueue(vm.Element3);
            if (vm.Element4.Name != "")
                elements.Enqueue(vm.Element4);
            if (vm.Element5.Name != "")
                elements.Enqueue(vm.Element5);
            if (vm.Element6.Name != "")
                elements.Enqueue(vm.Element6);
        }

        private string getVo1a()
        {
            return (vm.ElementO1A.AngularVelocity.ToString() + " + " +
                    vm.ElementO1A.Length.ToString() + " = "
                        + vm.ElementO1A.CountVelocity().ToString() + " " + CM + ";");
        }

        private void addElement(Element elementO)
        {
            fileWord.addParagraph("Звено " + elements.First<Element>().Name + 
                                    " " + elementO.Name + ": " + "точка " + 
                                        elements.First<Element>().Name[0] + " полюс");
            // V(вторая буква звена) = V(первая буква звена) + V(вторая и первая буква звена);
            fileWord.addParagraph("V" + elements.First<Element>().Name[1] + 
                                    " = " + "V" + elements.First<Element>().Name[0] + 
                                        " + V" + elements.First<Element>().Name[1] + 
                                            elements.First<Element>().Name[0] + ";");
            // V(вторая буква звена) = о(вторая буква звена) * 2 = значение * 2 = результат + см / с + ;
            fileWord.addParagraph("V" + elements.First<Element>().Name[1] + 
                                    " = " + "o" + elements.First<Element>().Name[1] + 
                                        " * 2 = " + elements.First<Element>().Length + 
                                            " * 2 = " + (elements.First<Element>().Length * 2) + ";"); // нужно подставить скорость, а не длину
        }

        public void createDocRGR()
        {
            fileWord.addParagraph("Звено O1A:");
            fileWord.addParagraph("VA = WO1A * O1A = " + getVo1a());
            while (elements.Count != 0)
            {
                // если 2 буква звена соответствует 2 букве звена О2*
                if (elements.First<Element>().Name[1] == vm.ElementO2.Name[2]) 
                {
                    addElement(vm.ElementO2);
                }
                // если 2 буква звена соответствует 2 букве звена О3*
                else if (elements.First<Element>().Name[1] == vm.ElementO3.Name[2]) 
                {
                    addElement(vm.ElementO3);
                }
                else if (elements.First<Element>() != null) 
                {
                    addElement(tmpElem);
                }
                elements.Dequeue();
            }
            fileWord.saveChangesAndClose();
        }
    }
}
