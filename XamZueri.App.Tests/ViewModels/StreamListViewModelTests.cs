using System.Threading.Tasks;
using NUnit.Framework;
using XamZueri.App.Infrastructure;
using XamZueri.App.Services;
using XamZueri.App.Tests.Mvx;
using XamZueri.App.ViewModels;

namespace XamZueri.App.Tests.ViewModels
{
    [TestFixture]
    public class StreamListViewModelTests
        : MvxTest
    {
        [Test]
        public async Task Start_TestAsync()
        {
            Ioc.RegisterType<IODataStreamItemsService>(Ioc.IoCConstruct<ODataStreamItemsService>);

            var vm = await ViewModelWithLifecycleAsync<StreamListViewModel>();

            Assert.That(vm.Items, Is.Not.Empty);
        }

        [Test]
        public async Task Refresh_Constraint_TestAsync()
        {
            Ioc.RegisterType<IODataStreamItemsService>(Ioc.IoCConstruct<ODataStreamItemsService>);

            var vm = await ViewModelWithLifecycleAsync<StreamListViewModel>();

            Assert.That(vm.RefreshCommand.CanExecute(null), Is.True);

            var refresh = vm.RefreshCommand.ExecuteAsync();

            Assert.That(vm.RefreshCommand.CanExecute(null), Is.False);

            await refresh;

            Assert.That(vm.RefreshCommand.CanExecute(null), Is.True);
        }
    }
}