using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamGps
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            btnIngresar.Clicked += BtnIngresar_Clicked;
            btnLogeoCliente.Clicked += BtnCliente_Clicked;
        }

        private async void BtnIngresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LogeoCadete(), true);

        }
        private async void BtnCliente_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LogeoCliente(), true);

        }
    }
}
