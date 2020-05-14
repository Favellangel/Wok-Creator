using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Work_Creator
{
    public struct Point
    {
        public double x;
        public double y;
    }
    public class Element : INotifyPropertyChanged
    {
        private string name;
        private int length;
        private double angularVelocity;
        private double velocity;
        private Point pBegin;
        private Point pEnd;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public int Length
        {
            get { return length; }
            set
            {
                length = value;
                OnPropertyChanged("Length");
            }
        }
        public double AngularVelocity
        {
            get { return angularVelocity; }
            set
            {
                angularVelocity = value;
                OnPropertyChanged("AngularVelocity");
            }
        }
        public double Velocity
        {
            get { return velocity; }
            set
            {
                velocity = value;
                OnPropertyChanged("Velocity");
            }
        }
        public Point PBegin
        {
            get { return pBegin; }
            set
            {
                pBegin.x = value.x;
                pBegin.y = value.y;
                OnPropertyChanged("PBegin");
            }
        }
        public Point PEnd
        {
            get { return pEnd; }
            set
            {
                pBegin.x = value.x;
                pBegin.y = value.y;
                OnPropertyChanged("PEnd");
            }
        } 
        public double PBeginX
        {
            get { return pBegin.x; }
            set
            {
                pBegin.x = value;
                OnPropertyChanged("PBeginX");
            }
        }
        public double PBeginY
        {
            get { return pBegin.y; }
            set
            {
                pBegin.y = value;
                OnPropertyChanged("PBeginY");
            }
        }
        public double PEndX
        {
            get { return pEnd.x; }
            set
            {
                pEnd.x = value;
                OnPropertyChanged("PEndX");
            }
        }
        public double PEndY
        {
            get { return pEnd.y; }
            set
            {
                pEnd.y = value;
                OnPropertyChanged("PEndY");
            }
        }

        public Element(String ElementName)
        {
            this.name = ElementName;
            this.length = 0;
            this.angularVelocity = 0;
            this.velocity = 0;
            this.pBegin.x = 0;
            this.pBegin.y = 0;
            this.pEnd.x = 0;
            this.pEnd.y = 0;
        }

        internal double CountVelocity() // перенести в Math Exeptions
        {
            return (length * angularVelocity);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
