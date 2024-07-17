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
    /// ScalableInternationalHelloWorld.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 
    
    public partial class ScalableInternationalHelloWorld : Window
    {
        public ScalableInternationalHelloWorld()
        {
            InitializeComponent();
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += OnTimerTick;
            timer.Start();
        }

        void OnTimerTick(object sender, object e)
        {
            txtblk.Text = DateTime.Now.ToString("h:mm:ss tt");
        }

    }
}
