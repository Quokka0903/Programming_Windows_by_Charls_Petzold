using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SliderEvents
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

        void OnSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            Slider slider = sender as Slider;
            Panel parentPanel = slider.Parent as Panel;
            int childIndex = parentPanel.Children.IndexOf(slider);
            TextBlock txtblk = parentPanel.Children[childIndex + 1] as TextBlock;
            txtblk.Text = args.NewValue.ToString();
        }
    }
}
