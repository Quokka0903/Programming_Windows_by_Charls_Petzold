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
using System.Reflection;

namespace ColorList
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IEnumerable<PropertyInfo> properties = typeof(Colors).GetTypeInfo().DeclaredProperties;

            foreach (PropertyInfo property in properties)
            {
                Color clr = (Color)property.GetValue(null);

                StackPanel vertStackPanel = new StackPanel
                {
                    VerticalAlignment = VerticalAlignment.Center
                };

                TextBlock txtblkName = new TextBlock
                {
                    Text = property.Name,
                    FontSize = 24
                };
                vertStackPanel.Children.Add(txtblkName);

                TextBlock txtblkRgb = new TextBlock
                {
                    Text = String.Format("{0:X2}-{1:X2}-{2:X2}-{3:X2},",
                    clr.A, clr.R, clr.G, clr.B),
                    FontSize = 18
                };
                vertStackPanel.Children.Add(txtblkRgb);

                StackPanel horzStackPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal
                };

                Rectangle rectangle = new Rectangle
                {
                    Width = 72,
                    Height = 72,
                    Fill = new SolidColorBrush(clr),
                    Margin = new Thickness(6)
                };
                horzStackPanel.Children.Add(rectangle);
                horzStackPanel.Children.Add(vertStackPanel);
                stackPanel.Children.Add(horzStackPanel);
            }
        }
    }
}
