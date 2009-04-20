using System;
using System.Windows;
using System.Windows.Media;

namespace Prismudio.Modules.DynamicLanguageScripting
{
    public static class DependencyObjectExtensions
    {
        public static void ForEachVisualChild( this DependencyObject obj, Action<DependencyObject> action )
        {
            action( obj );

            for ( int i = 0; i < VisualTreeHelper.GetChildrenCount( obj ); i++ )
            {
                DependencyObject child = VisualTreeHelper.GetChild( obj, i );
                ForEachVisualChild( child, action );
            }
        }
    }
}