namespace Prismudio.Core
{
    public interface ILanguage
    {
        string Name { get; }
        string ShortName { get; }

        object ExecuteCode( string code );
    }
}