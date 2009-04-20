using System.ComponentModel;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Events;
using Prismudio.Core;

namespace Prismudio.Modules.XamlViewer
{
    public class XamlViewerPresentationModel : IXamlViewerPresentationModel
    {
        private object rootElement;

        public event PropertyChangedEventHandler PropertyChanged;

        public object RootElement
        {
            get { return rootElement; }
            set
            {
                if ( rootElement != value )
                {
                    rootElement = value;
                    OnPropertyChanged( "RootElement" );
                }
            }
        }

        public XamlViewerPresentationModel( IEventAggregator eventAggregator )
        {
            eventAggregator.GetEvent<XamlParsedEvent>().Subscribe( OnXamlParsed, ThreadOption.UIThread );
        }

        public void OnXamlParsed( object obj )
        {
            RootElement = obj;
        }

        protected virtual void OnPropertyChanged( string propertyName )
        {
            if ( PropertyChanged != null )
            {
                PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
            }
        }
    }
}