using System;
using System.Windows;
using System.Windows.Controls;

namespace Prismudio.Modules.XamlEditor
{
    public partial class XamlEditorView : UserControl
    {
        public void InitializeComponent()
        {
            var resourceLocater =
                new Uri( "/Prismudio.Modules.XamlEditor;component/views/xamleditorview.xaml", UriKind.Relative );
            Application.LoadComponent( this, resourceLocater );
        }
    }
}