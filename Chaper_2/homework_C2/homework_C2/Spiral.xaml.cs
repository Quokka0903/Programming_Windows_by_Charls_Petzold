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

namespace homework_C2
{
    /// <summary>
    /// Spiral.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Spiral : UserControl
    {
        public Spiral()
        {
            this.InitializeComponent();
            for (int angle = 0; angle < 3600; angle++) 
            {
                double radians = Math.PI * angle / 180;
                double radius = angle / 10;
                double x = 360 + radius * Math.Sin(radians);
                double y = 360 + radius * Math.Cos(radians);
                polyline.Points.Add(new Point(x, y));
            }
        }
    }
}
