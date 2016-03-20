using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace XamZueri.App.Tests.Mvx
{
    public static class TestExtensions
    {
        public static async Task ExecuteAsync(this ICommand anyCommand, object parameter = null)
        {
            var cmd = (anyCommand as MvxAsyncCommandBase);
            if (cmd != null)
            {
                await cmd.ExecuteAsync(parameter);
            }
            else
            {
                anyCommand.Execute(parameter);
            }
        }
    }
}
