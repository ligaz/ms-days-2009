namespace Prismudio.Modules.CodeConsole
{
    public interface ICodeConsoleView
    {
        ICodeConsolePresentationModel Model { get; set; }
        ICodeEditor CodeEditor { get; }
        ICodeViewer CodeViewer { get; }
    }
}