using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using XamZueri.App.Models;
using XamZueri.App.Services;
using XamZueri.App.Utils;

namespace XamZueri.App.ViewModels
{
    public class EventDetailViewModel
        : AbstractViewModel
    {
        private static readonly ILogger Log = LogManager.GetCurrentClassLogger();

        private readonly IODataEventItemsService _eventItemsService;
        private readonly IMeetupService _meetupService;
        private readonly ISocialShareService _socialShareService;
        private Guid _id;
        private EventItem _event;
        private Meetup _meetup;
        private ICommand _signUpCommand;
        private ICommand _shareCommand;

        public EventDetailViewModel(IODataEventItemsService eventItemsService, IMeetupService meetupService, ISocialShareService socialShareService)
        {
            _eventItemsService = eventItemsService;
            _meetupService = meetupService;
            _socialShareService = socialShareService;
        }


        public void Init(Guid id)
        {
            _id = id;
        }

        public ICommand SignUpCommand
        {
            get
            {
                return _signUpCommand ??
                       (_signUpCommand = new MvxCommand(() => ShowViewModel<WebViewViewModel>(new { url = Event.Url, title = Event.Title }), () => Event != null));
            }
        }

        public ICommand ShareCommand
        {
            get
            {
                return _shareCommand ??
                       (_shareCommand = new MvxCommand(() => _socialShareService.ShareText($"{Event.Title} #xamzueri", Event.Url), () => Event != null));
            }
        }

        public EventItem Event
        {
            get { return _event; }
            set { SetProperty(ref _event, value); }
        }

        public Meetup Meetup
        {
            get { return _meetup; }
            set { SetProperty(ref _meetup, value); }
        }

        public override void Start()
        {
            SetupCanExecuteDependency(nameof(Event), () => SignUpCommand, () => ShareCommand);
            base.Start();
        }

        protected override async Task StartAsync()
        {
            await base.StartAsync();

            try
            {
                using (BeginBusyScope())
                {
                    Event = await _eventItemsService.Single(_id);
                    Meetup = await _meetupService.GetDetailsAsync(Event.MeetupId);
                }
            }
            catch (Exception ex)
            {
                // TODO: Inform User
                Log.Error(ex);
            }
            
        }
    }
}