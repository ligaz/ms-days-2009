using System.Windows;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.UnityExtensions;
using Prismudio.Modules.CodeConsole;
using Prismudio.Modules.DynamicLanguageScripting;
using Prismudio.Modules.XamlEditor;
using Prismudio.Modules.XamlViewer;

namespace Prismudio
{
    public class PrismudioBootstrapper : UnityBootstrapper
    {
        protected override IModuleCatalog GetModuleCatalog()
        {
            return new ModuleCatalog()
                .AddModule( typeof( XamlEditorModule ) )
                .AddModule( typeof( XamlViewerModule ) )
                .AddModule( typeof( DynamicLanguageModule ) )
                .AddModule( typeof( CodeConsoleModule ), "DynamicLanguageModule" )
                .AddModule( typeof( DynamicLanguageXamlBinderModule ), "DynamicLanguageModule" );
//                .AddModule( typeof( LanguageSelectorModule ), "DynamicLanguageModule" )
        }

        protected override void ConfigureContainer()
        {
            Container.RegisterType<IShellView, Shell>();

            base.ConfigureContainer();
        }

        protected override DependencyObject CreateShell()
        {
            var view = Container.Resolve<IShellView>();

            view.ShowView();
            return view as DependencyObject;
        }
    }
}