using Microsoft.AspNetCore.SignalR.Client;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace XamGps
{
   public class Signalr
    {

        HubConnection hubConnection;



        public Signalr()
        {
            
            hubConnection = new HubConnectionBuilder()
          .WithUrl($"http://www.signalrcarlos.somee.com/transport")
          .Build();
          hubConnection.StartAsync();
         

        }
       
        
    
        public async void Disconnect()
        {
            await hubConnection.StopAsync();
        }
        public async void EnviarCoordenadas(int orden)
        {
            
            //var position = await Task.Run(() => CrossGeolocator.Current.GetPositionAsync(TimeSpan.FromSeconds(2)));
            var request = new GeolocationRequest(GeolocationAccuracy.Medium);
            var location = await Geolocation.GetLocationAsync(request);
             await  hubConnection.SendAsync("EnviarMessage", orden, location.Latitude, location.Longitude);
            //var locator = CrossGeolocator.Current;
            //var position2 = await locator.GetPositionAsync(TimeSpan.FromSeconds(20), null, true);

            //var sendlocation = new Signalr(position2.Latitude, position2.Longitude);



        }
       
    }
}
