using System;
using System.Windows;
using System.Windows.Controls;

namespace Prismudio
{
    public partial class Shell : UserControl
    {
        public void ShowView()
        {
            Application.Current.RootVisual = this;
        }

        public void InitializeComponent()
        {
            var resourceLocater = new Uri( "/Prismudio;component/shell.xaml", UriKind.Relative );
            Application.LoadComponent( this, resourceLocater );
        }
    }
}