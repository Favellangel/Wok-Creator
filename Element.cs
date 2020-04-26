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
        private float angularVelocity;
        private float velocity;
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
        public float AngularVelocity
        {
            get { return angularVelocity; }
            set
            {
                angularVelocity = value;
                OnPropertyChanged("AngularVelocity");
            }
        }
        public float Velocity
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
                pBegin = value;
                OnPropertyChanged("PBegin");
            }
        }
        public Point PEnd
        {
            get { return pEnd; }
            set
            {
                pEnd = value;
                OnPropertyChanged("PEnd");
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

        internal float CountVelocity()
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
