using System.Windows.Input;

namespace Prismudio.Modules.CodeConsole
{
    public interface ICodeConsolePresentationModel
    {
        ICommand ExecuteCodeCommand { get;}
    }
}