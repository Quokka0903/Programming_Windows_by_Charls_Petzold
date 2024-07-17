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
using System.Windows.Shapes;

namespace homework_C3
{
    /// <summary>
    /// Window1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Window1 : Window
    {
        Random rand = new Random();
        byte[] rgb = new byte[3];

        public Window1()
        {
            InitializeComponent();
        }

        protected override void OnTapped(TappedRoutedEventArgs args)
        {
            rand.NextBytes(rgb);
            Color clr = Color.FromArgb(255, rgb[0], rgb[1], rgb[2]);
            SolidColorBrush brush = new SolidColorBrush(clr);

            if (args.OriginalSource is TextBlock)
                (args.OriginalSource as TextBlock).Foreground = brush;

            else if (args.OriginalSource is Grid)
                (args.OriginalSource as TextBlock).Background = brush;

            base.OnTapped(args);
            
        }
    }
}
