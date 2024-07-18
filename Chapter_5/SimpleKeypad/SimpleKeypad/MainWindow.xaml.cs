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

namespace SimpleKeypad
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {

        string inputString = "";
        char[] specialChars = { '*', '#' };

        public MainWindow()
        {
            InitializeComponent();
        }

        void OnCharButtonClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            inputString += btn.Content as string;
            FormatText();
        }

        void OnDeleteButtonClick(object sender, RoutedEventArgs e)
        {
            inputString = inputString.Substring(0, inputString.Length - 1);
            FormatText();
        }

        void FormatText()
        {
            bool hasNonNumbers = inputString.IndexOfAny(specialChars) != -1;

            if (hasNonNumbers || inputString.Length < 4 || inputString.Length > 10)
                resultText.Text = inputString;

            else if (inputString.Length < 8)
                resultText.Text = String.Format("{0}-{1}", inputString.Substring(0, 3),
                                                           inputString.Substring(3));

            else
                resultText.Text = String.Format("({0}) {1}-{2}", inputString.Substring(0, 3),
                                                                 inputString.Substring(3, 3),
                                                                 inputString.Substring(6));

            deleteButton.IsEnabled = inputString.Length > 0;
        }
    }
}
