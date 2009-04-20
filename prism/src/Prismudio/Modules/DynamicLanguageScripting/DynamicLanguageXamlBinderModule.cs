using System.Collections.Generic;
using System.Windows;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Scripting.Hosting;
using Prismudio.Core;

namespace Prismudio.Modules.DynamicLanguageScripting
{
    public class DynamicLanguageXamlBinderModule : IModule
    {
        private readonly List<string> xamlVariables = new List<string>();
        private readonly EventAggregator eventAggregator;
        private readonly ScriptRuntime scriptRuntime;

        public DynamicLanguageXamlBinderModule( EventAggregator eventAggregator, ScriptRuntime scriptRuntime)
        {
            this.eventAggregator = eventAggregator;
            this.scriptRuntime = scriptRuntime;
        }

        public void Initialize()
        {
            eventAggregator.GetEvent<XamlParsedEvent>().Subscribe( OnXamlParsed, true );
        }

        public void OnXamlParsed( object obj )
        {
            ClearXamlVariables();
            AddXamlVariablesRecursive( obj );
        }

        private void ClearXamlVariables()
        {
            while ( xamlVariables.Count > 0 )
            {
                scriptRuntime.Globals.RemoveVariable( xamlVariables[ 0 ] );
                xamlVariables.RemoveAt( 0 );
            }
        }

        private void AddXamlVariablesRecursive( object root )
        {
            var obj = root as DependencyObject;
            if ( obj != null )
            {
                obj.ForEachVisualChild(
                    o =>
                        {
                            var element = o as FrameworkElement;
                            if ( element != null && !string.IsNullOrEmpty( element.Name ) )
                            {
                                scriptRuntime.Globals.SetVariable( element.Name, element );
                                xamlVariables.Add( element.Name );
                            }
                        } );
            }
        }
    }
}