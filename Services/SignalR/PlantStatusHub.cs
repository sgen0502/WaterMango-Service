using System;
using System.Composition;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using WaterMango_Service.Models;
using WaterMango_Service.Utils;

namespace WaterMango_Service.Services.SignalR
{
    public class PlantStatusHub : Hub
    {
        /// <summary>
        /// Only used for debugging not many feature.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        
        public async Task SendStatusUpdate(int id, int status, DateTime date)
        {
            await Clients.All.SendAsync("StatusUpdate", id, status, date);
        }

        /// <summary>
        /// Triggers SignalR Plant Status Management service to run.
        /// </summary>
        /// <returns></returns>
        public async Task ConnectStateManager()
        {
            var service = DependencyContainer.GetExportedValue<RuleService>();
            var service2 = DependencyContainer.GetExportedValue<PlantService>();
            var managementService =  PlantStatusManagementService.GetInstance(service2, service);
            managementService.StartManagement(Clients);
            
            await Clients.All.SendAsync("ConnectStateManagerLog", "Notify", "Content Connection called.");
        }
    }
}