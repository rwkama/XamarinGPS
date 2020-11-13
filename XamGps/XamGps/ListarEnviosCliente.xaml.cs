using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamGps.Entidades;

namespace XamGps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListarEnviosCliente : ContentPage
    {
        private const string url = "http://www.carlosbackend.somee.com/api/";
        private HttpClient _Client = new HttpClient();

        public ListarEnviosCliente()
        {
            InitializeComponent();
            LLenarOrdenesEnvio();


        }
        private async void LLenarOrdenesEnvio()
        {
            var cadse = Application.Current.Properties["Cliente"];
           var cliente = (Cliente)cadse;
            string content = await _Client.GetStringAsync(url + "ListarOrdenesEnvioCliente?cliente=" + cliente.CedulaCli);
            var listaordenes = JsonConvert.DeserializeObject<List<OrdenEnvio>>(content);
            if (listaordenes == null)
            {
                await DisplayAlert("Error", "Ese cliente no tiene ninguna orden asignada", "Aceptar");

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
            
            await Navigation.PushModalAsync(new VerOrdenEnvioCliente(), true);
        }
    }
}
