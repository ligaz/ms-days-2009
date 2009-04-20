namespace Prismudio.Modules.CodeConsole
{
    public static class CodeViewerExtensions
    {
        public static void WriteLineCode( this ICodeViewer codeViewer, string code )
        {
            codeViewer.WriteCode( code );
            codeViewer.WriteNewLine();
        }

        public static void WriteLineText( this ICodeViewer codeViewer, string text )
        {
            codeViewer.WriteText( text );
            codeViewer.WriteNewLine();
        }
    }
}