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

        string _Imagen;

        int _latidosEn15Segundos;
        string _frecuenciaCardiacaResultado;

        private bool _imcSelected;
        private bool _fcnSelected;
        #endregion

        #region CONSTRUCTOR
        public VMpatron()
        {

        }
        #endregion

        #region OBJETOS

        public bool IMCselected
        {
            get { return _imcSelected; }
            set
            {
                SetValue(ref _imcSelected, value);
                OnPropertyChanged(nameof(FCNStackLayoutVisible)); // Notifica a la interfaz de usuario sobre cambios en la visibilidad de FCN
            }
        }

        public bool FCNSelected
        {
            get { return _fcnSelected; }
            set
            {
                SetValue(ref _fcnSelected, value);
                OnPropertyChanged(nameof(FCNStackLayoutVisible)); // Notifica a la interfaz de usuario sobre cambios en la visibilidad de FCN
            }
        }

        public bool FCNStackLayoutVisible => FCNSelected;
        public string Imagen
        {
            get { return _Imagen; }
            set { SetValue(ref _Imagen, value); }
        }

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
            if (IMCselected == true)
            {
                double peso = Peso;
                double altura = Altura;
                double resultado = peso / (altura * altura);

                if (resultado < 18.5)
                {
                    Imagen = "https://i.ibb.co/zZfj1cT/check.png";
                }
                else if (resultado >= 18.5 && resultado < 24.9)
                {
                    Imagen = "https://i.ibb.co/zZfj1cT/check.png";
                }
                else if (resultado >= 25 && resultado < 29.9)
                {
                    Imagen = "https://i.ibb.co/zZfj1cT/check.png";
                }
                else if (resultado >= 30)
                {
                    Imagen = "https://i.ibb.co/zZfj1cT/check.png";
                }
                // Restaura el estado de Frecuencia Cardíaca si es necesario
                FrecuenciaCardiacaResultado = string.Empty;
                FCNSelected = false; // Asegura que el StackLayout de FCN no esté visible
            }
            else
            {
                // La lógica para calcular la frecuencia cardíaca sigue aquí
                int frecuenciaCardiacaCalculada = LatidosEn15Segundos * 4;

                FrecuenciaCardiacaResultado = $"Frecuencia Cardíaca: {frecuenciaCardiacaCalculada} latidos por minuto";

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
                // Restaura el estado de IMC si es necesario
                Imagen = string.Empty;
                FCNSelected = true; // Asegura que el StackLayout de FCN esté visible
            }
        }
        #endregion

        #region COMANDOS
        public ICommand ProcesoCalcularIMCcommand => new Command(CalcularIMC);
        #endregion
    }
}

