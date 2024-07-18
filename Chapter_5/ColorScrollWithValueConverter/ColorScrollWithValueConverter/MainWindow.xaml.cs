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

namespace ColorScrollWithValueConverter
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
            byte r = (byte)redSlider.Value;
            byte g = (byte)greenSlider.Value;
            byte b = (byte)blueSlider.Value;

            brushResult.Color = Color.FromArgb(255, r, g, b);
        }

        void OnGridSizeChanged(object sender, SizeChangedEventArgs args)
        {
            if (args.NewSize.Width > args.NewSize.Height)
            {
                secondColDef.Width = new GridLength(1, GridUnitType.Star);
                secondRowDef.Height = new GridLength(0);

                Grid.SetColumn(rectangleResult, 1);
                Grid.SetRow(rectangleResult, 0);
            }

            else
            {
                secondColDef.Width = new GridLength(0);
                secondRowDef.Height = new GridLength(1, GridUnitType.Star);

                Grid.SetColumn(rectangleResult, 0);
                Grid.SetRow(rectangleResult, 1);
            }
        }
    }
}
