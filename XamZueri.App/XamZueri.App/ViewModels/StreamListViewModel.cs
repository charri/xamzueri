using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class StreamListViewModel
        : AbstractListViewModel<StreamItem>
    {
        private readonly IODataStreamItemsService _streamItemsService;
        
        public StreamListViewModel(IODataStreamItemsService streamItemsService)
        {
            _streamItemsService = streamItemsService;
        }
        
        protected override Task<IEnumerable<StreamItem>> NextItems(int skip)
        {
            return _streamItemsService.Next(skip);
        }
    }
}
