using System.Windows.Controls;
using System.Windows.Media;

namespace Prismudio.Modules.CodeConsole
{
    /// <summary>
    /// Interaction logic for CodeViewer.xaml
    /// </summary>
    public partial class CodeViewer : ICodeViewer
    {
        private static readonly SolidColorBrush RedBrush = new SolidColorBrush(Colors.Red);
        private static readonly SolidColorBrush BlueBrush = new SolidColorBrush(Colors.Blue);

        public CodeViewer()
        {
            InitializeComponent();
        }

        public void WriteText( string text )
        {
            RootPanel.Children.Add(new TextBlock { Text = text, Foreground = RedBrush });
        }

        public void WriteCode( string code )
        {
            RootPanel.Children.Add( new TextBlock { Text = code + " =>", Foreground = BlueBrush } );
        }

        public void WriteNewLine()
        {
        }
    }
}