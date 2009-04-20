using System.ComponentModel;
using System.Windows;
using Microsoft.Practices.Unity;

namespace Prismudio.Modules.XamlViewer
{
    /// <summary>
    /// Interaction logic for XamlViewerView.xaml
    /// </summary>
    public partial class XamlViewerView : IXamlViewerView
    {
        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register( "Model", typeof( IXamlViewerPresentationModel ), typeof( XamlViewerView ),
                                         new PropertyMetadata( OnModelChanged ) );

        private static void OnModelChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
        {
            ( (XamlViewerView) d ).DataContext = e.NewValue;
        }

        [Dependency]
        public IXamlViewerPresentationModel Model
        {
            get { return (IXamlViewerPresentationModel) GetValue( ModelProperty ); }
            set { SetValue( ModelProperty, value ); }
        }

        public XamlViewerView()
        {
            InitializeComponent();
        }
    }
}