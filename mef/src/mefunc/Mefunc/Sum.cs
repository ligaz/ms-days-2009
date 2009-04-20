using System.ComponentModel.Composition;

namespace Mefunc
{
    [Export( typeof( IMefunc ) )]
    [ExportMetadata( "Name", "Sum" )]
    public class Sum : IMefunc
    {
        public int Apply( int x, int y )
        {
            return x + y;
        }
    }
}