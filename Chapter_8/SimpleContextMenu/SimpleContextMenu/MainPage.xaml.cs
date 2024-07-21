using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 빈 페이지 항목 템플릿에 대한 설명은 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x412에 나와 있습니다.

namespace SimpleContextMenu
{
    /// <summary>
    /// 자체적으로 사용하거나 프레임 내에서 탐색할 수 있는 빈 페이지입니다.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        async void OntextBlockRightTapped(object sender, RightTappedRoutedEventArgs args)
        {
            PopupMenu popupMenu = new PopupMenu();
            popupMenu.Commands.Add(new UICommand("Larger Font", OnFontSizeChanged, 1.2));
            popupMenu.Commands.Add(new UICommand("Smaller Font", OnFontSizeChanged, 1/ 1.2));
            popupMenu.Commands.Add(new UICommandSeparator());
            popupMenu.Commands.Add(new UICommand("Red", OnColorChanged, Colors.Red));
            popupMenu.Commands.Add(new UICommand("Green", OnColorChanged, Colors.Green));
            popupMenu.Commands.Add(new UICommand("Blue", OnColorChanged, Colors.Blue));

            await popupMenu.ShowAsync(args.GetPosition(this));
        }

        void OnFontSizeChanged(IUICommand command)
        {
            textBlock.FontSize *= (double)command.Id;
        }

        void OnColorChanged(IUICommand command)
        {
            textBlock.Foreground = new SolidColorBrush((Color)command.Id);
        }
    }
}
