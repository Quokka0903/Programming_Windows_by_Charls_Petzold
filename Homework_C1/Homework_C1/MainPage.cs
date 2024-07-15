using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_C1
{
    public partial class MainPage : Component
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public MainPage(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
