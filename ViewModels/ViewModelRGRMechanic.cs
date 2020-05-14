using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows; 
using System.Windows.Data;

namespace Work_Creator
{
    public class ViewModelRGRMechanic : INotifyPropertyChanged
    {
        private Element elementO1A;
        private Element elementO2;
        private Element elementO3;
        private Element element1;
        private Element element2;
        private Element element3;
        private Element element4;
        private Element element5;
        private Element element6;
        private double angle;
        
        public Element ElementO1A
        {
            get { return elementO1A; }
            set
            {
                elementO1A = value;
                OnPropertyChanged("ElementO1A");
            }
        }
        public Element ElementO2
        {
            get { return elementO2; }
            set
            {
                elementO2 = value;
                OnPropertyChanged("ElementO2");
            }
        }
        public Element ElementO3
        {
            get { return elementO3; }
            set
            {
                elementO3 = value;
                OnPropertyChanged("ElementO3");
            }
        }
        public Element Element1
        {
            get { return element1; }
            set
            {
                element1 = value;
                OnPropertyChanged("Element1");
            }
        }
        public Element Element2
        {
            get { return element2; }
            set
            {
                element2 = value;
                OnPropertyChanged("Element2");
            }
        }
        public Element Element3
        {
            get { return element3; }
            set
            {
                element3 = value;
                OnPropertyChanged("Element3");
            }
        }
        public Element Element4
        {
            get { return element4; }
            set
            {
                element4 = value;
                OnPropertyChanged("Element4");
            }
        }
        public Element Element5
        {
            get { return element5; }
            set
            {
                element5 = value;
                OnPropertyChanged("Element5");
            }
        }
        public Element Element6
        {
            get { return element6; }
            set
            {
                element6 = value;
                OnPropertyChanged("Element6");
            }
        }
        public double Angle
        {
            get { return angle; }
            set
            {
                angle = value;
                OnPropertyChanged("Angle");
            }
        }
        public ViewModelRGRMechanic()
        {
            elementO1A = new Element("O1A");
            elementO2 = new Element("O2B"); 
            elementO3 = new Element("O3F");
            element1 = new Element("ABC"); 
            element2 = new Element("CED"); 
            element3 = new Element("EF"); 
            element4 = new Element(""); 
            element5 = new Element("");
            element6 = new Element("");
            angle = 45;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
