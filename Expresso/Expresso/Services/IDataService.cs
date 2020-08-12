using ExpressoApi.Models;
using System.Threading.Tasks;

namespace Expresso.Services
{
    public interface IDataService
    {
        Task<Menu[]> GetMenus();
        Task<bool> ReserveTable(Reservation reservation);
    }
}