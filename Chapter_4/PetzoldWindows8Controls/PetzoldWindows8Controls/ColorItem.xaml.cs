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

namespace PetzoldWindows8Controls
{
    /// <summary>
    /// ColorItem.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ColorItem : UserControl
    {
        public ColorItem(string name, Color clr)
        {
            //this.InitializeComponent();
            Console.WriteLine(name);
            Console.WriteLine(clr.ColorContext);
            rectangle.Fill = new SolidColorBrush(clr); // 왜 여기에서 null exception이 발생하는가.. 왜 clr이 안넘어올까
            txtblkName.Text = name;
            txtblkRgb.Text = String.Format("{0:X2}-{1:X2}-{2:X2}-{3:X2}", clr.A, clr.R, clr.G, clr.B);
        }
    }
}
