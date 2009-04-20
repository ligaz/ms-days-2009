using System.ComponentModel;

namespace Prismudio.Modules.XamlViewer
{
    public interface IXamlViewerPresentationModel : INotifyPropertyChanged
    {
        object RootElement { get; }
    }
}