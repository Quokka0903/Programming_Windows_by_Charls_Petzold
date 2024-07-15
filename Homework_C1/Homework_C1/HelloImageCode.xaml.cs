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
    /// HelloImageCode.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class HelloImageCode : UserControl
    {
        public HelloImageCode()
        {
            InitializeComponent();
            Uri uri = new Uri("http://www.charlespetzold.com/pw6/PetzoldJersey.jpg");
            BitmapImage bitmap = new BitmapImage(uri);
            Image image = new Image();
            image.Source = bitmap;
            contentGrid.Children.Add(image);
        }
    }
}
