using System.Windows;
using System.Windows.Data;
using Microsoft.Practices.Composite.Presentation.Commands;
using Microsoft.Practices.Unity;

namespace Prismudio.Modules.CodeConsole
{
    /// <summary>
    /// Interaction logic for CodeConsoleView.xaml
    /// </summary>
    public partial class CodeConsoleView : ICodeConsoleView
    {
        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register(
                "Model", typeof( ICodeConsolePresentationModel ), typeof( CodeConsoleView ), new PropertyMetadata( null, OnModelChanged ) );

        private static void OnModelChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
        {
            ( (CodeConsoleView) d ).DataContext = e.NewValue;
        }

        [Dependency]
        public ICodeConsolePresentationModel Model
        {
            get { return (ICodeConsolePresentationModel) GetValue( ModelProperty ); }
            set { SetValue( ModelProperty, value ); }
        }

        ICodeEditor ICodeConsoleView.CodeEditor
        {
            get { return CodeEditor; }
        }

        ICodeViewer ICodeConsoleView.CodeViewer
        {
            get { return CodeViewer; }
        }

        public CodeConsoleView()
        {
            InitializeComponent();
        }
    }
}