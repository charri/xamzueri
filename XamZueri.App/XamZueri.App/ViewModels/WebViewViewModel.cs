namespace XamZueri.App.ViewModels
{
    public class WebViewViewModel
        : AbstractViewModel
    {
        private string _title;
        private string _url;

        public void Init(string url, string title)
        {
            Url = url;
            Title = title;
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string Url
        {
            get { return _url; }
            set { SetProperty(ref _url, value); }
        }
    }
}