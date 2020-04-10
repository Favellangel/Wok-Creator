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
    public class ViewModel : INotifyPropertyChanged
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
        public ViewModel()
        {
            elementO1A = new Element { Name = "O1A", AngularVelocity = 0, Length = 0, Velocity = 0 };
            elementO2 = new Element { Name = "O2B", AngularVelocity = 0, Length = 0, Velocity = 0 };
            elementO3 = new Element { Name = "O3F", AngularVelocity = 0, Length = 0, Velocity = 0 };
            element1 = new Element { Name = "11", AngularVelocity = 0, Length = 0, Velocity = 0 };
            element2 = new Element { Name = "22", AngularVelocity = 0, Length = 0, Velocity = 0 };
            element3 = new Element { Name = "33", AngularVelocity = 0, Length = 0, Velocity = 0 };
            element4 = new Element { Name = "44", AngularVelocity = 0, Length = 0, Velocity = 0 };
            element5 = new Element { Name = "55", AngularVelocity = 0, Length = 0, Velocity = 0 };
            element6 = new Element { Name = "66", AngularVelocity = 0, Length = 0, Velocity = 0 };
            /*element1 = new Element();
            element2 = new Element();
            element3 = new Element();
            element4 = new Element();
            element5 = new Element();
            element6 = new Element();*/
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
