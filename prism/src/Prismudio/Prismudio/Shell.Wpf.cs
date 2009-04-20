using System.Windows;

namespace Prismudio
{
    public partial class Shell
    {
        public void ShowView()
        {
            Application.Current.MainWindow.Content = this;
        }
    }
}