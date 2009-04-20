using System;
using System.Linq;
using Microsoft.Scripting.Hosting;

namespace Prismudio.Modules.DynamicLanguageScripting
{
    public class DynamicLanguage : IDynamicLanguage
    {
        private readonly ScriptEngine scriptEngine;

        public ScriptEngine ScriptEngine
        {
            get { return scriptEngine; }
        }

        public string Name
        {
            get { return scriptEngine.Setup.DisplayName; }
        }

        public string ShortName
        {
            get { return scriptEngine.Setup.Names.Last(); }
        }

        public object ExecuteCode( string code )
        {
            try
            {
                return scriptEngine.Execute(code, scriptEngine.Runtime.Globals);    
            }
            catch ( Exception ex )
            {
                return ex;
            }
            
        }

        public DynamicLanguage( ScriptEngine scriptEngine )
        {
            this.scriptEngine = scriptEngine;
        }
    }
}