using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamGps
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListarEnvios : ContentPage
	{
        private const string url = "http://www.carlosbackend.somee.com/api/";
        private HttpClient _Client = new HttpClient();

        public ListarEnvios ()
		{
			InitializeComponent ();
            var cad = Application.Current.Properties["Cadetee"];
            Cadete cadete = (Cadete)cad;

            LLenarOrdenesEnvio();
            //var signalr = new Signalr();
            //signalr.EnviarCoordenadas(cadete.CedulaUsu);

        }
        private async void LLenarOrdenesEnvio()
        {
            var cadse = Application.Current.Properties["Cadete"].ToString();
            string content = await _Client.GetStringAsync(url + "ListarOrdenesEnvioCadete?cadete="+cadse);
            var listaordenes = JsonConvert.DeserializeObject <List<OrdenEnvio>>(content);
            if (listaordenes == null)
            {
                await DisplayAlert("Error", "Ese cadete no tiene ninguna orden asignada", "Aceptar");

                return;
            }
           else 
            {
                listarOrdenes.ItemsSource = listaordenes;
            }

        }

        private async void ListarOrdenes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var ordenenvios = (OrdenEnvio)e.SelectedItem;
            Application.Current.Properties["OrdenEnvio"] = ordenenvios;
            await Navigation.PushModalAsync(new VerOrdenEnvio(ordenenvios), true);
        }
    }
}