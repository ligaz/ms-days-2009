namespace Prismudio.Modules.CodeConsole
{
    /// <summary>
    /// Interaction logic for CodeEditor.xaml
    /// </summary>
    public partial class CodeEditor : ICodeEditor
    {
        public CodeEditor()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return CodeTextBox.Text; }
            set { CodeTextBox.Text = value; }
        }
    }
}