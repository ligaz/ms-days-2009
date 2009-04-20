namespace Prismudio.Modules.CodeConsole
{
    public interface ICodeViewer
    {
        void WriteText( string text );
        void WriteCode( string code );
        void WriteNewLine();
    }
}