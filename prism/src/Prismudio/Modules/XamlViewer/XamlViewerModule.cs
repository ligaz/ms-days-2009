using Prismudio.Core;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;

namespace Prismudio.Modules.XamlViewer
{
    public class XamlViewerModule : IModule
    {
        private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;

        public XamlViewerModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            RegisterViewsAndServices();

            IXamlViewerView view = container.Resolve<IXamlViewerView>();
            var region = regionManager.Regions[ RegionNames.Instance.XamlViewerRegion ];
            region.Add( view );
            region.Activate( view );
        }

        protected void RegisterViewsAndServices()
        {
            container.RegisterType<IXamlViewerPresentationModel, XamlViewerPresentationModel>();
            container.RegisterType<IXamlViewerView, XamlViewerView>();
        }
    }
}