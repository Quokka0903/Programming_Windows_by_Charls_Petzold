﻿using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Threading.Tasks;


namespace ColorScrollWithViewModel
{
    class RgbViewModel : INotifyPropertyChanged
    {
        double red, green, blue;
        Color color = Color.FromArgb(255, 0, 0, 0);

        public event PropertyChangedEventHandler PropertyChanged;

        public double Red
        {
            set
            {
                if (red != value)
                {
                    red = value;
                    OnPropertyChanged("Red");
                    Calculate();
                }
            }
            
            get
            {
                return red;
            }
        }

        public double Green
        {
            set
            {
                if (green != value)
                {
                    green = value;
                    OnPropertyChanged("Green");
                    Calculate();
                }
            }

            get
            {
                return green;
            }
        }

        public double Blue
        {
            set
            {
                if (blue != value)
                {
                    blue = value;
                    OnPropertyChanged("Blue");
                    Calculate();
                }
            }

            get
            {
                return blue;
            }
        }


        public Color Color
        {
            protected set
            {
                if (color != value)
                {
                    color = value;
                    OnPropertyChanged("Color");
                    this.Red = value.R;
                    this.Green = value.G;
                    this.Blue = value.B;
                }
            }

            get
            {
                return color;
            }
        }

        void Calculate()
        {
            this.Color = Color.FromArgb(255, (byte)this.Red, (byte)this.Green, (byte)this.Blue);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
