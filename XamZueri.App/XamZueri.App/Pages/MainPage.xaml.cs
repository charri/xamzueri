using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Forms.Presenter.Core;
using MvvmCross.Platform;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamZueri.App.Pages
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnChildAdded(Element child)
        {
            var page = child as Page;

            if (page != null && child.BindingContext == null)
            {
                var viewModelName = page.GetType().FullName.Replace("Page", "ViewModel");

                var viewModelType = Type.GetType(viewModelName);

                var request = MvxViewModelRequest.GetDefaultRequest(viewModelType);

                var loader = Mvx.Resolve<IMvxViewModelLoader>();

                page.BindingContext = loader.LoadViewModel(request, null);
            }
            
            base.OnChildAdded(child);
        }
    }


}
