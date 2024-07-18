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

namespace SliderSketch
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

        void OnSliderValueChanged(object sender, RoutedEventArgs args)
        {
            polyline.Points.Add(new Point(xSlider.Value, ySlider.Value));
        }

        void OnBorderValueChanged(object sender, SizeChangedEventArgs args)
        {
            Border border = sender as Border;
            xSlider.Maximum = args.NewSize.Width - border.Padding.Left
                                                 - border.Padding.Right
                                                 - polyline.StrokeThickness;

            ySlider.Maximum = args.NewSize.Width - border.Padding.Top
                                                 - border.Padding.Bottom
                                                 - polyline.StrokeThickness;
        }
    }
}
