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

namespace WhatSizeWithBindings
{
    /// <summary>
    /// WhatSize_1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WhatSize_1 : Window
    {
        public WhatSize_1()
        {
            InitializeComponent();
        }
        void OnPageSizeChanged(object sender, SizeChangedEventArgs args)
        {
            widthText.Text = args.NewSize.Width.ToString();
            heightText.Text = args.NewSize.Height.ToString();
        }
    }
}
