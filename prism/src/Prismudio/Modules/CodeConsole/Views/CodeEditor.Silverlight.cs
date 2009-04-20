using System;
using System.Windows;
using System.Windows.Controls;

namespace Prismudio.Modules.CodeConsole
{
    public partial class CodeEditor :  UserControl
    {
        public TextBox CodeTextBox { get; private set; }

        private void InitializeComponent()
        {
            var resourceLocater =
                new Uri("/Prismudio.Modules.CodeConsole;component/views/codeeditor.xaml", UriKind.Relative);
            Application.LoadComponent(this, resourceLocater);

            CodeTextBox = (TextBox) FindName( "CodeTextBox" );

        }
    }
}