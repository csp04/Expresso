using ExpressoApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Expresso.Services
{
    public class AzureService : IDataService
    {
        private HttpClient client = new HttpClient() { BaseAddress = new Uri(App.AzureBackendUrl) };

        public Task<Menu[]> GetMenus() => client.GetFromJsonAsync<Menu[]>("api/menus");

        public async Task<bool> ReserveTable(Reservation reservation)
        {
            var response = await client.PostAsJsonAsync("api/reservations", reservation);

            return response.IsSuccessStatusCode;
        }
    }
}
