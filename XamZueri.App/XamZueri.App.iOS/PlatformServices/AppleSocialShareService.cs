using Foundation;
using MvvmCross.iOS.Views.Presenters;
using UIKit;
using XamZueri.App.Services;

namespace XamZueri.App.iOS.PlatformServices
{
    public class AppleSocialShareService
        : ISocialShareService
    {
        private readonly IMvxIosViewPresenter _presenter;

        public AppleSocialShareService(IMvxIosViewPresenter presenter)
        {
            _presenter = presenter;
        }

        #region Implementation of ISocialShare

        public void ShareText(string text, string url)
        {
            var parameters = new[] { NSObject.FromObject(text), NSObject.FromObject(url) };

            var vc = new UIActivityViewController(parameters, null);

            _presenter.PresentModalViewController(vc, true);
        }

        #endregion
    }
}