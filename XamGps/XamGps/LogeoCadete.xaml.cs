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
	public partial class LogeoCadete : ContentPage
	{
        private const string url = "http://www.carlosbackend.somee.com/api/";
        private HttpClient _Client = new HttpClient();

        public LogeoCadete()
        {
            InitializeComponent();
            btnIngresar.Clicked += BtnIngresar_Clicked;
        }

        private async void BtnIngresar_Clicked(object sender, EventArgs e)
        {
            var cedulaingresar = Cedula.Text;
            var contraseñaingresar = Contrasena.Text;
            if (string.IsNullOrEmpty(cedulaingresar))
            {
                await DisplayAlert("Validación", "Ingrese la cedula", "Aceptar");
                Cedula.Focus();
                return;
            }
            if (string.IsNullOrEmpty(contraseñaingresar))
            {
                await DisplayAlert("Validación", "Ingrese la contraseña", "Aceptar");
                Contrasena.Focus();
                return;
            }
            var content = await _Client.GetStringAsync(url + "Cadete?cedula=" + cedulaingresar + "&contrasena=" + contraseñaingresar);
            var cadete = JsonConvert.DeserializeObject<Cadete>(content);
            if (cadete == null)
            {
                await DisplayAlert("Error", "El cadete ingresado no existe", "Aceptar");

                return;
            }
            if (cadete != null)
            {

                Application.Current.Properties["Cadetee"] = cadete;
                Application.Current.Properties["Cadete"] = cadete.CedulaUsu;


                await Navigation.PushModalAsync(new ListarEnvios(), true);
            }

        }
    }
}