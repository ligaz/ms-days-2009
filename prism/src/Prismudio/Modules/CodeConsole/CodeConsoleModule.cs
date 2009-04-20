using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Unity;

namespace Prismudio.Modules.CodeConsole
{
    public class CodeConsoleModule : IModule
    {
        private readonly IUnityContainer container;

        public CodeConsoleModule(IUnityContainer container)
        {
            this.container = container;
        }

        public void Initialize()
        {
            RegisterViewsAndServices();

            ICodeConsoleController controller = container.Resolve<ICodeConsoleController>();
            controller.Run();
        }

        protected void RegisterViewsAndServices()
        {
            container.RegisterType<ICodeConsolePresentationModel, CodeConsolePresentationModel>();
            container.RegisterType<ICodeConsoleView, CodeConsoleView>(new ContainerControlledLifetimeManager());
            container.RegisterType<ICodeConsoleController, CodeConsoleController>(new ContainerControlledLifetimeManager());
        }
    }
}