using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TextOnCanvas
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        void MouseCoordinateMethod(object sender, MouseEventArgs e)
        {
            var relativePosition = e.GetPosition(this);
            Console.WriteLine(relativePosition);
            var point = PointToScreen(relativePosition);
            // point.X와 point.Y를 사용하여 화면 좌표를 처리합니다.
            string x = point.X.ToString();
            string y = point.Y.ToString();
            Console.WriteLine(x, y);

        }
        
    }
}
