using System;
using System.Windows;
using System.Windows.Controls;

namespace Prismudio.Modules.XamlViewer
{
    public partial class XamlViewerView : UserControl
    {
        public void InitializeComponent()
        {
            var resourceLocater =
                new Uri( "/Prismudio.Modules.XamlViewer;component/views/xamlviewerview.xaml", UriKind.Relative );
            Application.LoadComponent( this, resourceLocater );
        }
    }
}