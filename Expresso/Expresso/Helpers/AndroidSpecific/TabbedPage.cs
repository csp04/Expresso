using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace Expresso.Helpers.AndroidSpecific
{
    public static class TabbedPageEx
    {
        public static readonly BindableProperty ToolbarPlacementProperty = BindableProperty.Create("ToolbarPlacement", typeof(ToolbarPlacement), typeof(TabbedPageEx), default(ToolbarPlacement), propertyChanged: OnToolbarPlacementChanged);

        private static void OnToolbarPlacementChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if(bindable is Xamarin.Forms.TabbedPage page)
            {
                page.On<Android>().SetToolbarPlacement((ToolbarPlacement)newValue);
            }
        }

        public static void SetToolbarPlacement(this BindableObject obj, ToolbarPlacement value)
        {
            obj.SetValue(ToolbarPlacementProperty, value);
        }
       
        public static ToolbarPlacement GetToolbarPlacement(this BindableObject obj)
        {
            return (ToolbarPlacement)obj.GetValue(ToolbarPlacementProperty);
        }

       
    }
}
