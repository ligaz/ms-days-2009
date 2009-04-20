using System;
using System.Windows;
using System.Windows.Controls;

namespace Prismudio.Modules.CodeConsole
{
    public partial class CodeConsoleView : UserControl
    {
        public CodeEditor CodeEditor { get; private set; }
        public CodeViewer CodeViewer { get; private set; }

        private void InitializeComponent()
        {
            var resourceLocater =
                new Uri( "/Prismudio.Modules.CodeConsole;component/views/codeconsoleview.xaml", UriKind.Relative );
            Application.LoadComponent( this, resourceLocater );

            CodeEditor = (CodeEditor) FindName( "CodeEditor" );
            CodeViewer = (CodeViewer) FindName( "CodeViewer" );
        }
    }
}