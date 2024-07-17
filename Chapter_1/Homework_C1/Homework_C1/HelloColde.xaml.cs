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

namespace Homework_C1
{
    /// <summary>
    /// HelloColde.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class HelloColde : UserControl
    {
        public HelloColde()
        {
            InitializeComponent();

            TextBlock txtblk = new TextBlock();
            txtblk.Text = "Hello, Windows!";
            txtblk.FontFamily = new FontFamily("Times New Roman");
            txtblk.FontSize = 96;
            txtblk.Foreground = new SolidColorBrush(Colors.Yellow);
            txtblk.HorizontalAlignment = HorizontalAlignment.Center;
            txtblk.VerticalAlignment = VerticalAlignment.Center;

            contentGrid.Children.Add(txtblk);
        }
    }
}

