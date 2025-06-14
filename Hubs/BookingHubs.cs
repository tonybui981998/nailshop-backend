using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace backend.Hubs
{
    public class BookingHubs : Hub
    {
        public async Task SendNewBooking(object booking)
        {
            Console.WriteLine("🔥 Booking received at SignalR Hub: " + JsonConvert.SerializeObject(booking));
            await Clients.Others.SendAsync("ReceiveBooking", booking);
        }

        public async Task NewStaffInfo(object staff)
        {
            Console.WriteLine("🔥 staff received at SignalR Hub: " + JsonConvert.SerializeObject(staff));
               await Clients.Others.SendAsync("Receivenewstaffinfor", staff);
        }
    }
}