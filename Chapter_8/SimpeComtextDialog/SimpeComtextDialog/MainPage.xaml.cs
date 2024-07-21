using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Enumeration.Pnp;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 빈 페이지 항목 템플릿에 대한 설명은 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x412에 나와 있습니다.

namespace SimpeComtextDialog
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

        void OnTextBlockRightTapped(object sender, RightTappedRoutedEventArgs args)
        {
            StackPanel stackPanel = new StackPanel();

            Button btn1 = new Button
            {
                Content = "Larger font",
                Tag = 1.2,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(12)
            };
            btn1.Click += OnButtonClick;
            stackPanel.Children.Add(btn1);

            Button btn2 = new Button
            {
                Content = "Smaller font",
                Tag = 1/ 1.2,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(12)
            };
            btn2.Click += OnButtonClick;
            stackPanel.Children.Add(btn2);

            string[] names = { "Red", "Green", "Blue" };
            Color[] colors = { Colors.Red, Colors.Green, Colors.Blue };

            for (int i = 0; i < names.Length; i++)
            {
                RadioButton radioButton = new RadioButton
                {
                    Content = names[i],
                    Foreground = new SolidColorBrush(colors[i]),
                    IsChecked = (textBlock.Foreground as SolidColorBrush).Color == colors[i],
                    Margin = new Thickness(12)
                };
                radioButton.Checked += OnRadioButtonChecked;
                stackPanel.Children.Add(radioButton);
            }

            Border border = new Border
            {
                Child = stackPanel,
                Background = this.Resources["ApplicationPageBackgroundThemeBrush"] as SolidColorBrush,
                BorderBrush = this.Resources["ApplicationForegroundThemeBrush"] as SolidColorBrush,
                BorderThickness = new Thickness(1),
                Padding = new Thickness(24),
            };

            Popup popup = new Popup
            {
                Child = border,
                IsLightDismissEnabled = true
            };

            border.Loaded += (loadedSender, loadedArgs) =>
            {
                Point point = args.GetPosition(this);
                point.X -= border.ActualWidth / 2;
                point.Y -= border.ActualHeight;

                popup.HorizontalOffset = Math.Min(this.ActualWidth - border.ActualWidth - 24, Math.Max(24, point.X));
                popup.VerticalOffset = Math.Min(this.ActualHeight - border.ActualHeight - 24, Math.Max(24, point.Y));

                btn1.Focus(FocusState.Programmatic);
            };

            popup.IsOpen = true;
        }

        void OnButtonClick(object sender, RoutedEventArgs args)
        {
            textBlock.FontSize *= (double)(sender as Button).Tag;
        }

        void OnRadioButtonChecked(object sender, RoutedEventArgs args)
        {
            textBlock.Foreground = (sender as RadioButton).Foreground;
        }
    }
}
