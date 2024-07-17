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
using System.Reflection;

namespace DependencyObjectHierarchy
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {

        Type rootType = typeof(DependencyObject);
        TypeInfo rootTypeInfo = typeof(DependencyObject).GetTypeInfo();
        List<Type> classes = new List<Type>();
        Brush highlightBrush;

        public MainWindow()
        {
            InitializeComponent();
            highlightBrush = new SolidColorBrush(new UISettings().UIElementColor(UIElementType.Highlight)); //이거 대체 어디 위치로 바뀐건질 못찾겠다.. 우선 패스
            AddToClassList(typeof(DependencyObject));

            classes.Sort((t1, t2) =>
            {
                return String.Compare(t1.GetTypeInfo().Name, t2.GetTypeInfo().Name);
            });

            ClassAndSubclasses rootClass = new ClassAndSubclasses(rootType);
            AddToTree(rootClass, classes);

            Display(rootClass, 0);
        }

        void AddToClassList(Type sampleType)
        {
            Assembly assembly = sampleType.GetTypeInfo().Assembly;

            foreach (Type type in assembly.ExportedTypes)
            {
                TypeInfo typeInfo = type.GetTypeInfo();

                if (typeInfo.IsPublic && rootTypeInfo.IsAssignableFrom(typeInfo))
                    classes.Add(type);
            }
        }

        void AddToTree(ClassAndSubclasses parentClass, List<Type> classes)
        {
            foreach (Type type in classes)
            {
                Type baseType = type.GetTypeInfo().BaseType;

                if (baseType == parentClass.Type)
                {
                    ClassAndSubclasses subClass = new ClassAndSubclasses(type);
                    parentClass.Subclasses.Add(subClass);
                    AddToTree(subClass, classes);
                }
            }
        }

        void Display(ClassAndSubclasses parentClass, int indent)
        {
            TypeInfo typeInfo = parentClass.Type.GetTypeInfo();

            TextBlock txtblk = new TextBlock();
            txtblk.Inlines.Add(new Run { Text = new string(' ', 8 * indent) });
            txtblk.Inlines.Add(new Run { Text = typeInfo.Name });

            if (typeInfo.IsSealed)
                txtblk.Inlines.Add(new Run 
                { 
                    Text = " (Seald)", Foreground = highlightBrush
                });

            IEnumerable<ConstructorInfo> constructorInfos = typeInfo.DeclaredConstructors;
            int publicConstructorCount = 0;

            foreach (ConstructorInfo constructorInfo in constructorInfos)
                if (constructorInfo.IsPublic)
                    publicConstructorCount += 1;

            if (publicConstructorCount == 0)
                txtblk.Inlines.Add(new Run
                {
                    Text = " (non-instantiable",
                    Foreground = highlightBrush
                });
            
            stackPanel.Children.Add(txtblk);

            foreach (ClassAndSubclasses subclasses in parentClass.Subclasses)
                Display(subclasses, indent + 1);
        }
        
    }
}
