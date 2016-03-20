using Android.Content;
using MvvmCross.Droid.Views;
using MvvmCross.Platform.Droid.Platform;
using Xamarin.Forms;
using XamZueri.App.Services;

namespace XamZueri.App.Droid.PlattformServices
{
    public class AndroidSocialShareService
        : ISocialShareService
    {
        private readonly IMvxAndroidCurrentTopActivity _currentTopActivity;

        public AndroidSocialShareService(IMvxAndroidCurrentTopActivity currentTopActivity)
        {
            _currentTopActivity = currentTopActivity;
        }

        #region Implementation of ISocialShareService

        public void ShareText(string text, string url)
        {
            var sendIntent = new Intent();
            sendIntent.SetAction(Intent.ActionSend);
            sendIntent.PutExtra(Intent.ExtraText, $"{text} {url}");
            sendIntent.SetType("text/plain");
            _currentTopActivity.Activity.StartActivity(Intent.CreateChooser(sendIntent, "Share"));
        }

        #endregion
    }
}