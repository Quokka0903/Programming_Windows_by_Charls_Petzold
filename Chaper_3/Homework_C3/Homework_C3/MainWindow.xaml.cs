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

namespace Homework_C3
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        double txtblkBaseSize;

        public MainWindow()
        {
            this.InitializeComponent();
            Loaded += OnPageLoaded;
        }

        void OnPageLoaded(object sender, RoutedEventArgs args)
        {
            txtblkBaseSize = txtblk.ActualHeight;
            CompositionTarget.Rendering += OnComsitionTargetRendering;
        }

        void OnComsitionTargetRendering(object sender, object args)
        {
            txtblk.FontSize = this.ActualHeight / txtblkBaseSize;

            RenderingEventArgs renderingArgs = args as RenderingEventArgs;
            double t = (0.25 * renderingArgs.RenderingTime.TotalSeconds) % 1;

            for (int index = 0; index < gradientBrush.GradientStops.Count; index++)
                gradientBrush.GradientStops[index].Offset = index / 7.0 - t;
        }
    }
}
