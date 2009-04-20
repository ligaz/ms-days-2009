using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;

namespace Mefunc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IPartImportsSatisfiedNotification
    {
        private ObservableCollection<Export<IMefunc>> functions;

        public MainWindow()
        {
            InitializeComponent();
        }

        public int X
        {
            get { return int.Parse( XTextBox.Text ); }
        }

        public int Y
        {
            get { return int.Parse( YTextBox.Text ); }
        }

        public ObservableCollection<Export<IMefunc>> Functions
        {
            get
            {
                if ( functions == null )
                {
                    functions = new ObservableCollection<Export<IMefunc>>();
                }
                return functions;
            }
        }

        [Import( AllowRecomposition = true )]
        private IEnumerable<Export<IMefunc>> ImportedFunctions { get; set; }

        public void OnImportsSatisfied()
        {
            Functions.Clear();

            ImportedFunctions.ToList().ForEach( Functions.Add );
        }

        private void OnApplyClicked( object sender, RoutedEventArgs e )
        {
            var function = (Export<IMefunc>) OperationComboBox.SelectedItem;
            ResultTextBox.Text = function.GetExportedObject().Apply( X, Y ).ToString();
        }
    }
}