using Windows.Foundation;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Controls;

// 빈 페이지 항목 템플릿에 대한 설명은 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x412에 나와 있습니다.

namespace Async_UWP
{
    /// <summary>
    /// 자체적으로 사용하거나 프레임 내에서 탐색할 수 있는 빈 페이지입니다.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Color clr;

        public MainPage()
        {
            this.InitializeComponent();
        }

        void OnButtonClick(object sender, RoutedEventArgs args)
        {
            MessageDialog msgdlg = new MessageDialog("Choose a color", "How to Async #1");
            msgdlg.Commands.Add(new UICommand("Red", null, Colors.Red));
            msgdlg.Commands.Add(new UICommand("Green", null, Colors.Green));
            msgdlg.Commands.Add(new UICommand("Blue", null, Colors.Blue));

            // Completd 핸들러 메시지
            IAsyncOperation<IUICommand> asyncOp = msgdlg.ShowAsync();
            asyncOp.Completed = OnMessageDialogShowAsyncCompleted;
        }

        void OnMessageDialogShowAsyncCompleted(IAsyncOperation<IUICommand> asyncInfo, AsyncStatus asyncStatus)
        {
            IUICommand command = asyncInfo.GetResults();
            clr = (Color)command.Id;

            IAsyncAction asyncAction = this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, OnDispatcherRunAsyncCallback);
        }

        void OnDispatcherRunAsyncCallback()
        {
            contentGrid.Background = new SolidColorBrush(clr);
        }
    }
}
