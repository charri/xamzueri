using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using XamZueri.App.Infrastructure;
using XamZueri.App.Services;
using XamZueri.App.Tests.Mvx;
using XamZueri.App.ViewModels;

namespace XamZueri.App.Tests.ViewModels
{
    [TestFixture]
    public class EventListViewModelTetsts
        : MvxTest
    {

        [Test]
        public async Task Start_TestAsync()
        {
            Ioc.RegisterType<IODataEventItemsService>(Ioc.IoCConstruct<ODataEventItemsService>);

            var vm = await ViewModelWithLifecycleAsync<EventListViewModel>();

            Assert.That(vm.Items, Is.Not.Empty);
        }
    }
}
