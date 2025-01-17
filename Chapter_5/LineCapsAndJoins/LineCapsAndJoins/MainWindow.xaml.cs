﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LineCapsAndJoins
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += (sender, args) =>
            {
                foreach (UIElement child in startLineCapPanel.Children)
                    (child as RadioButton).IsChecked =
                    (PenLineCap)(child as RadioButton).Tag == polyline.StrokeStartLineCap;

                foreach (UIElement child in endLineCapPanel.Children)
                    (child as RadioButton).IsChecked =
                    (PenLineCap)(child as RadioButton).Tag == polyline.StrokeEndLineCap;

                foreach (UIElement child in lineJoinPanel.Children)
                    (child as RadioButton).IsChecked =
                    (PenLineJoin)(child as RadioButton).Tag == polyline.StrokeLineJoin;
            };
        }

        public void OnStartLineCapRadioButtonChecked(object sender, RoutedEventArgs args)
        {
            polyline.StrokeStartLineCap = (PenLineCap)(sender as RadioButton).Tag;
        }

        public void OnEndLineCapRadioButtonChecked(object sender, RoutedEventArgs args)
        {
            polyline.StrokeEndLineCap = (PenLineCap)(sender as RadioButton).Tag;
        }

        public void OnLineJoinRadioButtonChecked(object sender, RoutedEventArgs args)
        {
            polyline.StrokeLineJoin = (PenLineJoin)(sender as RadioButton).Tag;
        }
    }

    
}
