using System.Collections.Generic;

namespace Prismudio.Core
{
    public interface ILanguageService
    {
        IEnumerable<ILanguage> GetLanguages();
    }
}