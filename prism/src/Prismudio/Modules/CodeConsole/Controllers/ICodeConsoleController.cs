using System.Windows.Input;

namespace Prismudio.Modules.CodeConsole
{
    public interface ICodeConsoleController
    {
        void Run();
        ICommand ExecuteCodeCommand { get; }
    }
}