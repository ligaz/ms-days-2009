using System.ComponentModel.Composition;

namespace Mefunc
{
    [Export(typeof(IMefunc))]
    [ExportMetadata("Name", "Min")]
    public class Min : IMefunc
    {
        public int Apply( int x, int y )
        {
            return x < y ? x : y;
        }
    }
}