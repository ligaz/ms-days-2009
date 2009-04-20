using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Windows;

namespace Mefunc
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup( StartupEventArgs e )
        {
            MainWindow = new MainWindow();

            Compose();

            MainWindow.Show();

            base.OnStartup( e );
        }

        private void Compose()
        {
            var aggregateCatalog = new AggregateCatalog();
            aggregateCatalog.Catalogs.Add( new AssemblyCatalog( Assembly.GetExecutingAssembly() ) );
            aggregateCatalog.Catalogs.Add( new DirectoryCatalog( @"..\..\Addins", "*.exe" ) );

            var container = new CompositionContainer( aggregateCatalog );

            var batch = new CompositionBatch();
            batch.AddPart( MainWindow );

            container.Compose( batch );
        }
    }
}