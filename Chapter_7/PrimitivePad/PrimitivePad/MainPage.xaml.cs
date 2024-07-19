using System;
using System.Collections.Generic;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// 빈 페이지 항목 템플릿에 대한 설명은 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x412에 나와 있습니다.

namespace PrimitivePad
{
    /// <summary>
    /// 자체적으로 사용하거나 프레임 내에서 탐색할 수 있는 빈 페이지입니다.
    /// </summary>
    public sealed partial class MainPage : Page

    {
        ApplicationDataContainer appData = ApplicationData.Current.LocalSettings;

        public MainPage()
        {
            this.InitializeComponent();

            Loaded += (sender, args) =>
            {
                if (appData.Values.ContainsKey("TextWrapping"))
                    txtbox.TextWrapping = (TextWrapping)appData.Values["TextWrapping"];
            };
        }

        async void OnFileOpenButtonClick(object sender, RoutedEventArgs args)
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".txt");
            StorageFile storageFile = await picker.PickSingleFileAsync();

            if (storageFile == null)
                return;


            Exception exception = null;
            try
            {
                using (IRandomAccessStream stream = await storageFile.OpenReadAsync())
                {
                    using (DataReader dataReader = new DataReader(stream))
                    {
                        uint length = (uint)stream.Size;
                        await dataReader.LoadAsync(length);
                        txtbox.Text = dataReader.ReadString(length);
                    }
                }
            }
            catch (Exception exc)
            {
                exception = exc;
            }

            if (exception != null)
            {
                MessageDialog msgdlg = new MessageDialog(exception.Message, "File Read Error");
                await msgdlg.ShowAsync();
            }

            
        }

        async void OnFileSaveAsButtonClick(object sender, RoutedEventArgs args)
        {
            FileSavePicker picker = new FileSavePicker();
            picker.DefaultFileExtension = (".txt");
            picker.FileTypeChoices.Add("Text", new List<String> { ".txt" });
            StorageFile storageFile = await picker.PickSaveFileAsync();

            if (storageFile == null)
                return;

            using (IRandomAccessStream stream = await storageFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                using (DataWriter dataWriter = new DataWriter(stream))
                {
                    dataWriter.WriteString(txtbox.Text);
                    await dataWriter.StoreAsync();
                }
            }
        }

        void OnWrapButtonChecked(object sender, RoutedEventArgs args)
        {
            txtbox.TextWrapping = (bool)wrapButton.IsChecked ? TextWrapping.Wrap : TextWrapping.NoWrap;
            wrapButton.Content = (bool)wrapButton.IsChecked ? "Wrap" : "No Wrap";
            appData.Values["TextWrapping"] = (int)txtbox.TextWrapping;
        }

    }
}
