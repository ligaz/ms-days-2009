using Prismudio.Core;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;

namespace Prismudio.Modules.XamlEditor
{
    public class XamlEditorModule : IModule
    {
        private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;

        public XamlEditorModule( IUnityContainer container, IRegionManager regionManager )
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            RegisterViewsAndServices();

            IXamlEditorView view = container.Resolve<IXamlEditorView>();
            var region = regionManager.Regions[RegionNames.Instance.XamlEditorRegion];
            region.Add( view );
            region.Activate( view );
        }

        protected void RegisterViewsAndServices()
        {
            container.RegisterType<IXamlParserService, XamlParserService>( new ContainerControlledLifetimeManager() );
            container.RegisterType<IXamlEditorPresentationModel, XamlEditorPresentationModel>();
            container.RegisterType<IXamlEditorView, XamlEditorView>();
        }
    }
}