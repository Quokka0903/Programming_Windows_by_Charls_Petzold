using System;
using System.Collections.Generic;
using System.Reflection;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace AnimationEaseGrapher
{
    public sealed partial class MainPage : Page
    {
        EasingFunctionBase easingFunction;

        public MainPage()
        {
            this.InitializeComponent();
            Loaded += OnMainPageLoaded;
        }

        void OnMainPageLoaded(object sender, RoutedEventArgs args)
        {
            Type baseType = typeof(EasingFunctionBase);
            TypeInfo baseTypeInfo = baseType.GetTypeInfo();
            Assembly assembly = baseTypeInfo.Assembly;

            foreach (Type type in assembly.ExportedTypes)
            {
                TypeInfo typeInfo = type.GetTypeInfo();

                if (typeInfo.IsPublic &&
                    baseTypeInfo.IsAssignableFrom(typeInfo) &&
                    type != baseType)
                {
                    RadioButton radioButton = new RadioButton
                    {
                        Content = type.Name,
                        Tag = type,
                        Margin = new Thickness(6),

                    };
                    radioButton.Checked += OnEasingFunctionRadioButtonChecked;
                    easingFunctionStackPanel.Children.Add(radioButton);
                }
            }

            (easingFunctionStackPanel.Children[0] as RadioButton).IsChecked = true;
        }

        void OnEasingFunctionRadioButtonChecked(object sender, RoutedEventArgs args)
        {
            RadioButton radioButton = sender as RadioButton;
            Type type = radioButton.Tag as Type;
            easingFunction = null;
            propertiesStackPanel.Children.Clear();

            if (type != null)
            {
                TypeInfo typeInfo = type.GetTypeInfo();

                foreach (ConstructorInfo constructorInfo in typeInfo.DeclaredConstructors)
                {
                    if (constructorInfo.IsPublic && constructorInfo.GetParameters().Length == 0)
                    {
                        easingFunction = constructorInfo.Invoke(null) as EasingFunctionBase;
                        break;
                    }
                }

                foreach (PropertyInfo property in typeInfo.DeclaredProperties)
                {
                    if (property.PropertyType != typeof(int) &&
                        property.PropertyType != typeof(double))
                    {
                        continue;
                    }

                    TextBlock txtblk = new TextBlock
                    {
                        Text = property.Name + ":"
                    };
                    propertiesStackPanel.Children.Add(txtblk);

                    Slider slider = new Slider
                    {
                        Width = 144,
                        Minimum = 0,
                        Maximum = 10,
                        Tag = property
                    };

                    if (property.PropertyType == typeof(int))
                    {
                        slider.StepFrequency = 1;
                        slider.Value = (int)property.GetValue(easingFunction);
                    }
                    else
                    {
                        slider.StepFrequency = 0.1;
                        slider.Value = (double)property.GetValue(easingFunction);
                    }

                    slider.ValueChanged += (sliderSender, sliderArgs) =>
                    {
                        Slider sliderChanging = sliderSender as Slider;
                        PropertyInfo propertyInfo = sliderChanging.Tag as PropertyInfo;

                        if (property.PropertyType == typeof(int))
                            property.SetValue(easingFunction, (int)sliderArgs.NewValue);
                        else
                            property.SetValue(easingFunction, (double)sliderArgs.NewValue);

                        DrawNewGraph();
                    };
                    propertiesStackPanel.Children.Add(slider);
                }
            }

            foreach (UIElement child in easingModeStackPanel.Children)
            {
                RadioButton easingModeRadioButton = child as RadioButton;
                easingModeRadioButton.IsEnabled = easingFunction != null;

                easingModeRadioButton.IsChecked =
                    easingFunction != null &&
                    easingFunction.EasingMode == (EasingMode)easingModeRadioButton.Tag;
            }

            DrawNewGraph();
        }

        void OnEasingModeRadioButtonChecked(object sender, RoutedEventArgs args)
        {
            RadioButton radioButton = sender as RadioButton;
            easingFunction.EasingMode = (EasingMode)radioButton.Tag;
            DrawNewGraph();
        }

        void OnDemoButtonClick(object sender, RoutedEventArgs args)
        {
            Storyboard storyboard = this.Resources["storyboard"] as Storyboard;
            (storyboard.Children[1] as DoubleAnimation).EasingFunction = easingFunction;
            storyboard.Begin();
        }

        void DrawNewGraph()
        {
            polyline.Points.Clear();

            if (easingFunction == null)
            {
                polyline.Points.Add(new Point(0, 0));
                polyline.Points.Add(new Point(1000, 500));
                return;
            }

            for (decimal t = 0; t <= 1; t += 0.01m)
            {
                double x = (double)(1000 * t);
                double y = 500 * easingFunction.Ease((double)t);
                polyline.Points.Add(new Point(x, y));
            }
        }
    }
}
