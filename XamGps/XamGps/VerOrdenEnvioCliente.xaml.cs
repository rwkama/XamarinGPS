using Microsoft.AspNetCore.SignalR.Client;
using Plugin.Geolocator.Abstractions;
using System;
using Xamarin.Forms;

using Xamarin.Forms.Xaml;

namespace XamGps
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VerOrdenEnvioCliente : ContentPage
	{
        Position addressPosition;
        HubConnection hubConnection;
       
        public VerOrdenEnvioCliente ()
		{
            InitializeComponent();
            RecibirLocation();
            btnRecibir.Clicked += BtnVerC_Clicked;

        }
        private  void BtnVerC_Clicked(object sender, EventArgs e)
        {
             RecibirLocation();

        }
        private  void RecibirLocation()
        {
            hubConnection = new HubConnectionBuilder()
               .WithUrl($"http://www.signalrcarlos.somee.com/transport")
               .Build();
             hubConnection.StartAsync();
            hubConnection.On<int,double, double>("locationMessage", (orden,latitude, longitude) =>
            {
                addressPosition = new Position(latitude, longitude);

                 Xamarin.Essentials.Map.OpenAsync(addressPosition.Latitude, addressPosition.Longitude);
            });
         
        }
       

    }
}