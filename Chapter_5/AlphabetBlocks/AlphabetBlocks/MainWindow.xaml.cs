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

namespace AlphabetBlocks
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {

        const double BUTTON_SIZE = 60;
        const double BUTTON_FONT = 18;
        string blockChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!?-+*/%=";
        Color[] colors = { Colors.Red, Colors.Green, Colors.Orange, Colors.Blue, Colors.Purple };
        Random rand = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        void OnGridSizeChanged(object sender, SizeChangedEventArgs args)
        {
            buttonCanvas.Children.Clear();

            double widthFraction = args.NewSize.Width / (args.NewSize.Width + args.NewSize.Height);
            int horzCount = (int)(widthFraction * blockChars.Length / 2);
            int vertCount = (int)(blockChars.Length / 2 - horzCount);
            int index = 0;

            double slotWidth = (args.NewSize.Width - BUTTON_SIZE) / horzCount;
            double slotHeight = (args.NewSize.Height - BUTTON_SIZE) / vertCount + 1;

            for (int i = 0; i < horzCount; i++)
            {
                Button button = MakeButton(index++);
                Canvas.SetLeft(button, i * slotWidth);
                Canvas.SetTop(button, 0);
                buttonCanvas.Children.Add(button);
            }

            for (int i = 0; i < vertCount; i++)
            {
                Button button = MakeButton(index++);
                Canvas.SetLeft(button, this.ActualWidth - BUTTON_SIZE);
                Canvas.SetTop(button, i * slotHeight);
                buttonCanvas.Children.Add(button);
            }

            for (int i = 0; i < horzCount; i++)
            {
                Button button = MakeButton(index++);
                Canvas.SetLeft(button, this.ActualWidth - i * slotWidth - BUTTON_SIZE);
                Canvas.SetTop(button, this.ActualHeight - BUTTON_SIZE);
                buttonCanvas.Children.Add(button);
            }

            for (int i = 0; i < vertCount; i++)
            {
                Button button = MakeButton(index++);
                Canvas.SetLeft(button, 0);
                Canvas.SetTop(button, this.ActualHeight - i * slotHeight - BUTTON_SIZE);
                buttonCanvas.Children.Add(button);
            }
        }
        Button MakeButton(int index)
        {
            Button button = new Button
            {
                Content = blockChars[index].ToString(),
                Width = BUTTON_SIZE,
                Height = BUTTON_SIZE,
                FontSize = BUTTON_FONT,
                Tag = new SolidColorBrush(colors[index % colors.Length]),
            };
            button.Click += OnButtonClick;
            return button;
        }

        void OnButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            Block block = new Block
            {
                Text = button.Content as string,
                Foreground = button.Tag as Brush
            };
            Canvas.SetLeft(block, this.ActualWidth / 2 - 144 * rand.NextDouble());
            Canvas.SetTop(block, this.ActualHeight / 2 - 144 * rand.NextDouble());
            Canvas.SetZIndex(block, Block.ZIndex);
            blockcanvas.Children.Add(block);
        }
    }
}
