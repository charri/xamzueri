using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamZueri.App.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class UiChildOfAttribute
        : Attribute
    {
        public PageType Page { get; set; }

        public UiChildOfAttribute(PageType page)
        {
            Page = page;
        }
    }

    public enum PageType
    {
        None = 0,
        MasterDetailPage,
        NavigationPage,
        TabbedPage,
        CarouselPage
    }
}
