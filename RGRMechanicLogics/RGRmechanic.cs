﻿using System;
using System.Collections.Generic;
using Office;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Work_Creator.RGRMechanic;

namespace Work_Creator
{
    /// <summary>
    /// Класс для создания документа РГР механика. 
    /// </summary>
    /// <remarks>
    /// </remarks>
    public class RGRmechanic 
    {
        private const string CM = "см/с";
        private const string RAD = "рад/с";
        private ViewModelRGRMechanic vm;
        Queue<Element> elements;
        Element tmpElem;
        FileWord fileWord;
        Triangle trianglePabc;
        Triangle triangleTmp;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DataContext">данные от пользователя(то что введено в форму)</param>
        /// <param name="path">путь к файлу</param>
        public RGRmechanic(object DataContext, string path)
        {
            vm = (ViewModelRGRMechanic)DataContext; // класс для взаимодействия логики и интерфейса
            elements = new Queue<Element>();
            tmpElem = new Element("");
            fileWord = new FileWord(path);
            trianglePabc = new Triangle();
            triangleTmp = new Triangle();
            addElementsInList();
        }
        private void addElementsInList()
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
        private void addElement01A()
        {
            vm.ElementO1A.Velocity = vm.ElementO1A.CountVelocity();
            fileWord.addParagraph("Звено O1A:");
            fileWord.addParagraph("VA = WO1A * O1A = " + 
                (vm.ElementO1A.AngularVelocity.ToString() +
                    " + " + vm.ElementO1A.Length.ToString() + " = "
                        + vm.ElementO1A.Velocity.ToString() + " " + CM + ";"));
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
            elements.First<Element>().Velocity = GetVelocity(vm.NumScheme);
            fileWord.addParagraph("V" + elements.First<Element>().Name[1] + 
                                    " = " + "o" + elements.First<Element>().Name[1] + 
                                        " * 2 = " + (elements.First<Element>().Velocity / 2).ToString() + 
                                            " * 2 = " + elements.First<Element>().Velocity.ToString() + ";");
        }
        private void GetElementO1APEnd()
        {
            vm.ElementO1A.PEndX = Triangle.GetX(vm.ElementO1A.Length, vm.Angle);
            vm.ElementO1A.PEndY = Triangle.GetY(vm.ElementO1A.Length, vm.Angle);
        }
        private double GetVelocity(int scheme)
        {
            switch(scheme)
            {
                case 10: case 12: case 18: case 19: case 21: case 25:
                   return VelocityThroughThreePoints();
                case 20:
                   return VelocityThroughFourPoints();
                default:
                    return 0;
            }
        }
        private double VelocityThroughFourPoints()
        {
            triangleTmp.SideC = Triangle.GetSide(vm.ElementO1A.Length, vm.ElementO2.PEnd.x, vm.Angle);
            trianglePabc.AngleAlpha = Triangle.GetAngle(vm.Element1.Length, vm.ElementO2.Length, triangleTmp.SideC);
            triangleTmp.AngleAlpha = Triangle.GetAngle(vm.ElementO1A.Length, triangleTmp.SideC, vm.ElementO2.PEndX);
            triangleTmp.AngleBeta = Triangle.GetAngle(vm.Element1.Length, triangleTmp.SideC, vm.ElementO2.Length);
            trianglePabc.AngleBeta = triangleTmp.AngleAlpha + triangleTmp.AngleBeta;
            trianglePabc.AngleSigma = 180 - trianglePabc.AngleAlpha - trianglePabc.AngleBeta;
            trianglePabc.SideA = Triangle.GetSide1(vm.Element1.Length, trianglePabc.AngleAlpha, trianglePabc.AngleSigma);
            trianglePabc.SideB = Triangle.GetSide1(vm.Element1.Length, trianglePabc.AngleBeta, trianglePabc.AngleSigma);
            return (vm.ElementO1A.Velocity * trianglePabc.SideB / trianglePabc.SideA); 
        }
        private double VelocityThroughThreePoints()
        {
            triangleTmp.AngleAlpha = Triangle.GetAngle1(vm.ElementO1A.Length, vm.Element1.Length, vm.Angle);
            if (vm.Angle > 90)
            {
                trianglePabc.AngleBeta = 180 - vm.Angle - triangleTmp.AngleAlpha;
                trianglePabc.AngleAlpha = 90 + triangleTmp.AngleAlpha;
            }
            else if (vm.Angle < 90)
            {
                trianglePabc.AngleBeta = vm.Angle + triangleTmp.AngleAlpha;
                trianglePabc.AngleAlpha = 90 - triangleTmp.AngleAlpha;
            }
            else if (vm.Angle == 90) return 0;
            trianglePabc.AngleSigma = 180 - trianglePabc.AngleAlpha - trianglePabc.AngleBeta;
            trianglePabc.SideA = vm.Element1.Length * trianglePabc.AngleAlpha / trianglePabc.AngleSigma;
            trianglePabc.SideB = vm.Element1.Length * trianglePabc.AngleBeta / trianglePabc.AngleSigma;
            return (vm.ElementO1A.Velocity * trianglePabc.SideB / trianglePabc.SideA);
        }
        public void createDocRGR()
        {
            addElement01A();
            while (elements.Count != 0)
            {   // если 2 буква звена соответствует 2 букве звена О2*
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
