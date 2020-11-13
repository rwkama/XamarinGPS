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
	public partial class LogeoCliente : ContentPage
	{
        private const string url = "http://www.carlosbackend.somee.com/api/";
        private HttpClient _Client = new HttpClient();

        public LogeoCliente()
        {
            InitializeComponent();
            btnIngresar.Clicked += BtnIngresar_Clicked;
        }

        private async void BtnIngresar_Clicked(object sender, EventArgs e)
        {
            var cedula = Cedula.Text;
            var contraseñaingresar = Contrasena.Text;
            if (string.IsNullOrEmpty(cedula))
            {
                await DisplayAlert("Validación", "Ingrese el nombre", "Aceptar");
                Cedula.Focus();
                return;
            }
            if (string.IsNullOrEmpty(contraseñaingresar))
            {
                await DisplayAlert("Validación", "Ingrese la contraseña", "Aceptar");
                Contrasena.Focus();
                return;
            }
            var content = await _Client.GetStringAsync(url + "Cliente?cedula=" + cedula + "&pass=" + contraseñaingresar);
            var cliente = JsonConvert.DeserializeObject<Cliente>(content);
            if (cliente == null)
            {
                await DisplayAlert("Error", "El cliente ingresado no existe", "Aceptar");

                return;
            }
            if (cliente != null)
            {
                Application.Current.Properties["Cliente"] = cliente;


                await Navigation.PushModalAsync(new ListarEnviosCliente(), true);
            }

        }
    }
}