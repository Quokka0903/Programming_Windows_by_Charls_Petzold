using System;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Controls;

// 빈 페이지 항목 템플릿에 대한 설명은 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x412에 나와 있습니다.

namespace HowToCancelAsync
{
    /// <summary>
    /// 자체적으로 사용하거나 프레임 내에서 탐색할 수 있는 빈 페이지입니다.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        IAsyncOperation<IUICommand> asyncOp;

        public MainPage()
        {
            this.InitializeComponent();
        }

        async void OnButtonClick(object sender, RoutedEventArgs args)
        {
            MessageDialog msgdlg = new MessageDialog ("Choose a color", "How To Cancel Async");
            msgdlg.Commands.Add(new UICommand("Red", null, Colors.Red));
            msgdlg.Commands.Add(new UICommand("Green", null, Colors.Green));
            msgdlg.Commands.Add(new UICommand("Blue", null, Colors.Blue));

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = System.TimeSpan.FromSeconds(5);
            timer.Tick += OnTimerTick;
            timer.Start();

            asyncOp = msgdlg.ShowAsync();
            IUICommand command = null;

            try
            {
                command = await asyncOp;
            }
            catch (Exception)
            {

            }

            timer.Stop();

            if (command == null)
                return;

            Color clr = (Color)command.Id;
            contentGrid.Background = new SolidColorBrush(clr);
        }

        void OnTimerTick(object sender, object args)
        {
            asyncOp.Cancel();
        }

    }
}
