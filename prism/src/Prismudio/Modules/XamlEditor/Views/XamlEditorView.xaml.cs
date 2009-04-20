using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Practices.Unity;

namespace Prismudio.Modules.XamlEditor
{
    /// <summary>
    /// Interaction logic for XamlEditorView.xaml
    /// </summary>
    public partial class XamlEditorView : IXamlEditorView
    {
        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register(
                "Model", typeof( IXamlEditorPresentationModel ), typeof( XamlEditorView ),
                new PropertyMetadata( null ) );

        [Dependency]
        public IXamlEditorPresentationModel Model
        {
            get { return (IXamlEditorPresentationModel)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        public XamlEditorView()
        {
            InitializeComponent();
        }

        private void OnXamlTextChanged( object sender, TextChangedEventArgs e )
        {
            var textBox = (TextBox) sender;
            Model.Xaml = textBox.Text;
        }
    }
}