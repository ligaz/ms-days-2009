namespace Prismudio.Core
{
    public class RegionNames
    {
        public static readonly RegionNames Instance = new RegionNames();

        public string XamlEditorRegion
        {
            get { return "XamlEditorRegion"; }
        }

        public string XamlViewerRegion
        {
            get { return "XamlViewerRegion"; }
        }

        public string CodeConsoleRegion
        {
            get { return "CodeConsoleRegion"; }
        }
    }
}