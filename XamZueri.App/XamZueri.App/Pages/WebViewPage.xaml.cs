using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamZueri.App.ViewModels;

namespace XamZueri.App.Pages
{
    public partial class WebViewPage : ContentPage
    {
        public WebViewPage()
        {
            InitializeComponent();
        }

        public WebViewViewModel ViewModel => (WebViewViewModel)BindingContext;
        
    }
}
