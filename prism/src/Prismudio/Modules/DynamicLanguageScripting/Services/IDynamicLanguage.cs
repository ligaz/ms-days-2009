using Microsoft.Scripting.Hosting;
using Prismudio.Core;

namespace Prismudio.Modules.DynamicLanguageScripting
{
    public interface IDynamicLanguage : ILanguage
    {
        ScriptEngine ScriptEngine { get; }
    }
}