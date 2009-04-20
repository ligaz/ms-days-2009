using System;
using System.ComponentModel;
using Prismudio.Core;
using Microsoft.Practices.Composite.Events;

namespace Prismudio.Modules.XamlEditor
{
    public class XamlEditorPresentationModel : IXamlEditorPresentationModel, INotifyPropertyChanged
    {
        private string xaml;
        private readonly IXamlParserService xamlParserService;
        private readonly IEventAggregator eventAggregator;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Xaml
        {
            get { return xaml; }
            set
            {
                if ( xaml != value )
                {
                    xaml = value;
                    OnPropertyChanged( "Xaml" );
                    OnXamlChanged();
                }
            }
        }

        public XamlEditorPresentationModel( IXamlParserService xamlParserService, IEventAggregator eventAggregator )
        {
            this.xamlParserService = xamlParserService;
            this.eventAggregator = eventAggregator;
        }

        protected virtual void OnPropertyChanged( string propertyName )
        {
            if ( PropertyChanged != null )
            {
                PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
            }
        }

        protected virtual void OnXamlChanged()
        {
            try
            {
                object parsedObject = xamlParserService.ParseXaml( xaml );
                eventAggregator.GetEvent<XamlParsedEvent>().Publish( parsedObject );
            }
            catch ( Exception ex)
            {
                eventAggregator.GetEvent<XamlParseErrorEvent>().Publish( ex );
            }
        }
    }
}