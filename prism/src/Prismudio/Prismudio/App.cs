using System;
using System.Windows;

namespace Prismudio
{
    public class App : Application
    {
        public App()
        {
            Startup += OnAppStartup;
        }

        private void OnAppStartup( object sender, StartupEventArgs e )
        {
            var bootstrapper = new PrismudioBootstrapper();
            bootstrapper.Run();
        }

#if !SILVERLIGHT
        [STAThread]
        public static void Main()
        {
            App app = new App();
            app.Run( new MainWindow() );
        }
#endif
    }
}