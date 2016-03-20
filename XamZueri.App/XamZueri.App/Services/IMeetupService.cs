using System.Threading.Tasks;
using XamZueri.App.Models;

namespace XamZueri.App.Services
{
    public interface IMeetupService
    {
        Task<Meetup> GetDetailsAsync(string meetupId);
    }
}