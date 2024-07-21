using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Media3D;

// 빈 페이지 항목 템플릿에 대한 설명은 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x412에 나와 있습니다.

namespace NonAffineStretch
{
    /// <summary>
    /// 자체적으로 사용하거나 프레임 내에서 탐색할 수 있는 빈 페이지입니다.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Rect imageRect = new Rect(0, 0, 320, 400);

        public MainPage()
        {
            this.InitializeComponent();

            Loaded += (sender, args) =>
            {
                CalculateNewTransform();
            };
        }

        void OnThumbDragDelta(object sender, DragDeltaEventArgs args)
        {
            Thumb thumb = sender as Thumb;
            TransformGroup xformGroup = thumb.RenderTransform as TransformGroup;
            TranslateTransform translate = xformGroup.Children[1] as TranslateTransform;
            translate.X += args.HorizontalChange;
            translate.Y += args.VerticalChange;
            CalculateNewTransform();
        }

        void CalculateNewTransform()
        {
            Matrix3D matrix = CalculateNewTransform(imageRect,
                new Point(ulTranslate.X, ulTranslate.Y),
                new Point(urTranslate.X, urTranslate.Y),
                new Point(llTranslate.X, llTranslate.Y),
                new Point(lrTranslate.X, lrTranslate.Y));
            matrixProjection.ProjectionMatrix = matrix;
        }

        static Matrix3D CalculateNewTransform(Rect rect, Point ptUL, Point ptUR, Point ptLL, Point ptLR)
        {
            Matrix3D S = new Matrix3D()
            {
                M11 = 1 / rect.Width,
                M22 = 1 / rect.Height,
                OffsetX = -rect.Left / rect.Width,
                OffsetY = -rect.Top / rect.Height,
                M44 = 1
            };

            Matrix3D A = new Matrix3D()
            {
                OffsetX = ptUL.X,
                OffsetY = ptUL.Y,
                M11 = (ptUR.X - ptUL.X),
                M12 = (ptUR.Y - ptUL.Y),
                M21 = (ptLL.X - ptUL.X),
                M22 = (ptLL.Y - ptUL.Y),
                M44 = 1
            };

            Matrix3D B = new Matrix3D();
            double den = A.M11 * A.M22 - A.M12 * A.M21;
            double a =  (A.M22 * ptLR.X - A.M21 * ptLR.Y +
                         A.M21 * A.OffsetY - A.M22 * A.OffsetX) / den;
            double b =  (A.M11 * ptLR.Y - A.M12 * ptLR.X +
                         A.M12 * A.OffsetX - A.M11 * A.OffsetY) / den;

            B.M11 = a / (a + b - 1);
            B.M22 = b / (a + b - 1);
            B.M14 = B.M11 - 1;
            B.M24 = B.M22 - 1;
            B.M44 = 1;

            return S * B * A;
        }
    }
}