using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Prueba_Xamarin.ViewModel
{
    public class VMpatron : BaseViewModel
    {
        #region VARIABLES
        double _Peso;
        double _Altura;

        int _latidosEn15Segundos;
        string _frecuenciaCardiacaResultado;

        private bool _imcSelected;
        #endregion

        #region CONSTRUCTOR
        public VMpatron()
        {
            
        }
        #endregion

        #region OBJETOS

        public int LatidosEn15Segundos
        {
            get { return _latidosEn15Segundos; }
            set { SetValue(ref _latidosEn15Segundos, value); }
        }

        public string FrecuenciaCardiacaResultado
        {
            get { return _frecuenciaCardiacaResultado; }
            set { SetValue(ref _frecuenciaCardiacaResultado, value); }
        }
        public double Peso
        {
            get { return _Peso; }
            set { SetValue(ref _Peso, value); }
        }
        public double Altura
        {
            get { return _Altura; }
            set { SetValue(ref _Altura, value); }
        }
        #endregion

        #region PROCESOS
        public void CalcularIMC()
        {
            double peso = Peso;
            double altura = Altura;
            double resultado = peso / (altura * altura);

            if (resultado < 18.5)
            {
                 MostrarMensaje("Bajo peso");
            }
            else if (resultado >= 18.5 && resultado < 24.9)
            {
                 MostrarMensaje("Peso normal");
            }
            else if (resultado >= 25 && resultado < 29.9)
            {
                 MostrarMensaje("Sobrepeso");
            }
            else if (resultado >= 30)
            {
                 MostrarMensaje("Obesidad");
            }

        }
        private void CalcularFrecuenciaCardiaca()
        {
            // Lógica para calcular la frecuencia cardíaca en base a la fórmula dada
            int frecuenciaCardiacaCalculada = LatidosEn15Segundos * 4;

            // Asignar el resultado a la propiedad que se vincula con el Label
            FrecuenciaCardiacaResultado = $"Frecuencia Cardíaca: {frecuenciaCardiacaCalculada} latidos por minuto";

            // Determinar si es baja, normal o alta y actualizar según tus criterios
            if (frecuenciaCardiacaCalculada < 60)
            {
                FrecuenciaCardiacaResultado += " (FC Baja)";
            }
            else if (frecuenciaCardiacaCalculada >= 60 && frecuenciaCardiacaCalculada <= 100)
            {
                FrecuenciaCardiacaResultado += " (FC Normal)";
            }
            else
            {
                FrecuenciaCardiacaResultado += " (FC Alta)";
            }
        }

        private async Task MostrarMensaje(string mensaje)
        {
            await Application.Current.MainPage.DisplayAlert("Resultado IMC", mensaje, "OK");
        }

        #endregion

        #region COMANDOS



        public ICommand ProcesoCalcularIMCcommand => new Command(CalcularIMC);
        public ICommand CalcularFrecuenciaCardiacaCommand => new Command(CalcularFrecuenciaCardiaca);




        #endregion

    }
}
