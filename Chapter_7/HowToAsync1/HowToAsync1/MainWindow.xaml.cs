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

namespace HowToAsync1
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {

        Color clr;

        public MainWindow()
        {
            InitializeComponent();
        }

        void OnButtonClick(object sender, RoutedEventArgs args)
        {
            MessageDialog msgdlg = new MessageDialog("Choose a color", "How to Async #1");
            msgdlg.Commands.Add(new RoutedUICommand("Red", null, Colors.Red));
            msgdlg.Commands.Add(new RoutedUICommand("Green", null, Colors.Green));
            msgdlg.Commands.Add(new RoutedUICommand("Blue", null, Colors.Blue));

            // Completd 핸들러 메시지
            IAsyncOperation<IUICommand> asyncOp = msgdlg.ShowAsync();
            asyncOp.Completed = OnMessageDialogShowAsyncCompleted;
        }

        void OnMessageDialogAsyncCompleted(IAsyncOperation<IUICommand> asyncInfo, AsyncStatus asyncStatus)
        {
            IUICommand command = asyncInfo.GetResults();
            clr = (Color)command.Id;

            IAsyncAction asyncAction = this.Dispatcher.RunAsync(CoreDisptcherPriority.Normal, OnDispatcherRunAsyncCallback);
        }

        void OnDispatcherRunAsyncCallback()
        {
            contentGrid.Background = new SolidColorBrush(clr);
        }
    }
}
