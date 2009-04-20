using System.Windows.Input;

namespace Prismudio.Modules.CodeConsole
{
    public class CodeConsolePresentationModel : ICodeConsolePresentationModel
    {
        private readonly ICodeConsoleController controller;

        public CodeConsolePresentationModel( ICodeConsoleController controller )
        {
            this.controller = controller;
            ExecuteCodeCommand = this.controller.ExecuteCodeCommand;
        }

        public ICommand ExecuteCodeCommand { get; private set; }
    }
}