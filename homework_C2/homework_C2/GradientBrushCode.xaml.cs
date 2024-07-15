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
    /// GradientBrushCode.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class GradientBrushCode : UserControl
    {
        public GradientBrushCode()
        {
            InitializeComponent();

            LinearGradientBrush foregroundBrush = new LinearGradientBrush();
            foregroundBrush.StartPoint = new Point(0, 0);
            foregroundBrush.EndPoint = new Point(1, 0);

            GradientStop gradientStop = new GradientStop();
            gradientStop.Offset = 0;
            gradientStop.Color = Colors.Blue;
            foregroundBrush.GradientStops.Add(gradientStop);

            gradientStop = new GradientStop();
            gradientStop.Offset = 0;
            gradientStop.Color = Colors.Blue;
            foregroundBrush.GradientStops.Add(gradientStop);

            gradientStop = new GradientStop();
            gradientStop.Offset = 1;
            gradientStop.Color = Colors.Red;
            foregroundBrush.GradientStops.Add(gradientStop);

            txtblk.Foreground = foregroundBrush;


            LinearGradientBrush backgroungBrush = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 0)
            };
            backgroungBrush.GradientStops.Add(new GradientStop
            {
                Offset = 0,
                Color = Colors.Red
            });
            backgroungBrush.GradientStops.Add(new GradientStop
            {
                Offset = 1,
                Color = Colors.Blue
            });
            contentGrid.Background = backgroungBrush;
        }
    }
}
