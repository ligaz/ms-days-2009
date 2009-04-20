using System;
using System.IO;
using System.Windows.Markup;
using System.Xml;
using Prismudio.Core;

namespace Prismudio.Modules.XamlEditor
{
    public class XamlParserService : IXamlParserService
    {
        public object ParseXaml( string xaml )
        {
#if SILVERLIGHT
            return XamlReader.Load( xaml );
#else
            XmlReader reader = null;
            try
            {
                reader = XmlReader.Create( new StringReader( xaml ) );
                return XamlReader.Load( reader );
            }
            finally
            {
                if (reader != null)
                {
                    ( (IDisposable) reader ).Dispose();
                }
            }
#endif
        }
    }
}