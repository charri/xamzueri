using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using XamZueri.App.Models;
using XamZueri.App.Services;
using XamZueri.App.Utils;

namespace XamZueri.App.ViewModels
{
    public class EventListViewModel
        : AbstractListViewModel<EventItem>
    {
        
        private readonly IODataEventItemsService _eventItemsService;
        
        public EventListViewModel(IODataEventItemsService eventItemsService)
        {
            _eventItemsService = eventItemsService;
        }

        protected override Task<IEnumerable<EventItem>> NextItems(int skip)
        {
            return _eventItemsService.Next(skip);
        }
    }
}
