using System.Linq;
using System.Windows.Input;
using Microsoft.Practices.Composite.Presentation.Commands;
using Microsoft.Practices.Unity;
using Prismudio.Core;
using Microsoft.Practices.Composite.Regions;

namespace Prismudio.Modules.CodeConsole
{
    public class CodeConsoleController : ICodeConsoleController
    {
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;
        private readonly ILanguageService languageService;

        public ICommand ExecuteCodeCommand { get; private set; }

        public CodeConsoleController(IRegionManager regionManager, IUnityContainer container, ILanguageService languageService)
        {
            this.regionManager = regionManager;
            this.container = container;
            this.languageService = languageService;

            ExecuteCodeCommand = new DelegateCommand<object>( OnExecuteCode );
        }

        private void OnExecuteCode(object obj)
        {
            ICodeConsoleView consoleView = container.Resolve<ICodeConsoleView>();

            string code = consoleView.CodeEditor.Text;

            if (!string.IsNullOrEmpty(code))
            {
                object result = languageService.GetLanguages().First().ExecuteCode(code);
                consoleView.CodeViewer.WriteLineCode(code);
                consoleView.CodeViewer.WriteLineText(result != null ? result.ToString() : "null");

                consoleView.CodeEditor.Text = string.Empty;
            }
        }

        public void Run()
        {
            ICodeConsoleView consoleView = container.Resolve<ICodeConsoleView>();
            //regionManager.RegisterViewWithRegion( RegionNames.Instance.CodeConsoleRegion, null );

            var region = regionManager.Regions[RegionNames.Instance.CodeConsoleRegion];
            region.Add( consoleView );
            region.Activate( consoleView );
        }
    }
}