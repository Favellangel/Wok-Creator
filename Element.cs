using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Work_Creator
{
    public class Element : INotifyPropertyChanged
    {
        private string name;
        private int length;
        private float angularVelocity;
        private float velocity;
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

        public Element(String Elementname)
        {
            this.name = Elementname;
            this.length = 0;
            this.angularVelocity = 0;
            this.velocity = 0;
        }

        internal float CountVelocity()
        {
            return (length * angularVelocity);
        }
        internal float DoubleLength(float length)
        {
            return length * 2;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
