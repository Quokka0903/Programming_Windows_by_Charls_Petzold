using System;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// 빈 페이지 항목 템플릿에 대한 설명은 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x412에 나와 있습니다.

namespace SuspendResumeLog
{
    /// <summary>
    /// 자체적으로 사용하거나 프레임 내에서 탐색할 수 있는 빈 페이지입니다.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        StorageFile logfile;

        public MainPage()

        {
            this.InitializeComponent();

            Loaded += OnLoaded;
            Application.Current.Suspending += OnAppSuspending;
            Application.Current.Resuming += OnAppResuming;
        }

        async void OnLoaded(object sender, RoutedEventArgs args)
        {
            //로그파일 생성 읽기
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            logfile = await localFolder.CreateFileAsync("logfile.txt", CreationCollisionOption.OpenIfExists);

            //파일불러오고표시
            txtbox.Text = await FileIO.ReadTextAsync(logfile);

            //앱 시작을 기록
            txtbox.Text += String.Format("Launching at {0}\r\n", DateTime.Now.ToString());
            await FileIO.WriteTextAsync(logfile, txtbox.Text);
        }

        async void OnAppSuspending(object sender, SuspendingEventArgs args)
        {
            SuspendingDeferral deferral = args.SuspendingOperation.GetDeferral();

            //앱 중단 기록
            txtbox.Text += String.Format("Suspending at {0}\r\n", DateTime.Now.ToString());
            await FileIO.WriteTextAsync(logfile, txtbox.Text);
            deferral.Complete();
        }

        async void OnAppResuming(object sender, object args)
        {
            txtbox.Text += String.Format("Resuming at {0}\r\n", DateTime.Now.ToString());
            await FileIO.WriteTextAsync(logfile, txtbox.Text);
        }
    }
}
