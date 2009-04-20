using System;
using System.Windows;
using System.Windows.Controls;

namespace Prismudio.Modules.CodeConsole
{
    public partial class CodeViewer : UserControl
    {
        public Panel RootPanel { get; private set; }


        private void InitializeComponent()
        {
            var resourceLocater =
                new Uri( "/Prismudio.Modules.CodeConsole;component/views/codeviewer.xaml", UriKind.Relative );
            Application.LoadComponent( this, resourceLocater );

            RootPanel = (Panel)FindName("RootPanel");

        }
    }
}