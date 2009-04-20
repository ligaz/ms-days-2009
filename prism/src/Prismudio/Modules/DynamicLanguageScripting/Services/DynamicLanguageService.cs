using System.Collections.Generic;
using Microsoft.Scripting.Hosting;
using Prismudio.Core;

namespace Prismudio.Modules.DynamicLanguageScripting
{
    public class DynamicLanguageService : ILanguageService
    {
        private readonly ScriptRuntime runtime;
        private readonly IList<ILanguage> languages;

        public DynamicLanguageService( ScriptRuntime runtime )
        {
            this.runtime = runtime;
            languages = new List<ILanguage>();

            CreateDynamicLanguages();
        }

        private void CreateDynamicLanguages()
        {
            foreach ( var languageSetup in runtime.Setup.LanguageSetups )
            {
                ScriptEngine engine = runtime.GetEngineByTypeName( languageSetup.TypeName );
                languages.Add( new DynamicLanguage( engine ) );
            }
        }

        public IEnumerable<ILanguage> GetLanguages()
        {
            return languages;
        }
    }
}
