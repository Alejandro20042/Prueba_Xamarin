using Prueba_Xamarin.Vistas;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prueba_Xamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PaginaPrincipal();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
