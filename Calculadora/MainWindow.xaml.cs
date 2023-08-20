using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculadora
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Limpiar(object sender, RoutedEventArgs e)
        {
            _numeroOperador1 = 0;
            _numeroOperador2 = 0;
            _numeroTexto1 = "";
            _numeroTexto2 = "";
            _operador = "";
            _resultado = "";
            Pantalla.Text = "";
        }
        private void ButtonNumeros(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (_operador == "" && _numeroTexto2 == "")
            {
                _numeroTexto1 = _numeroTexto1 + (string)btn.Content;
                _numeroOperador1 = double.Parse(_numeroTexto1);
                MostrarPantalla(_numeroTexto1);
            }
            else
            {
                _numeroTexto2 = _numeroTexto2 + (string)btn.Content;
                _numeroOperador2 = double.Parse(_numeroTexto2);
                MostrarPantalla(_numeroTexto1, _numeroTexto2);
            }

        }
        private void ButtonOperadores(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if(_operador == "" && _numeroTexto2 == "")
            {
                _operador = (string)btn.Content;
                MostrarPantalla(_numeroTexto1);
            }  
        }
        private void ButtonIgual(object sender, RoutedEventArgs e)
        {
            if(_operador != "")
            {
                switch(_operador)
                {
                    case "+":
                        _resultado = Convert.ToString(_numeroOperador1 + _numeroOperador2);
                        break;
                    case "-":
                        _resultado = Convert.ToString(_numeroOperador1 - _numeroOperador2);
                        break;
                    case "*":
                        _resultado = Convert.ToString(_numeroOperador1 * _numeroOperador2);
                        break;
                    case "/":
                        _resultado = Convert.ToString(_numeroOperador1 / _numeroOperador2);
                        break;
                }
            }
            _numeroTexto1 = _resultado;
            _numeroOperador1 = double.Parse(_numeroTexto1);
            _numeroTexto2 = "";
            _numeroOperador2 = 0;
            _operador = "";
            _resultado = "";
            MostrarPantalla(_numeroTexto1, _numeroTexto2);
        }
        private void ButtonPunto(object sender, RoutedEventArgs e)
        {
            if (_operador=="" && _numeroTexto1 != "" && _numeroOperador1%1 == 0)
            {
                _numeroTexto1 = _numeroTexto1 + ".";
                MostrarPantalla(_numeroTexto1);
            }
            if (_operador != "" && _numeroTexto2 != "" && _numeroOperador2 % 1 == 0)
            {
                _numeroTexto2 = _numeroTexto2 + ".";
                MostrarPantalla(_numeroTexto1, _numeroTexto2);
            }
        }

        private void MostrarPantalla (Object numero, Object numero2 = null){
            if(_resultado == "")
            {
                if(_operador=="")
                {
                    Pantalla.Text = Convert.ToString(numero);
                }
                else
                {
                    Pantalla.Text = Convert.ToString(numero) + _operador + Convert.ToString(numero2);
                }
            }
            else
            {
                Pantalla.Text = "Resultado= " + _resultado;
            }
        }

        private double _numeroOperador1 = 0;
        private double _numeroOperador2 = 0;
        private string _numeroTexto1 = "";
        private string _numeroTexto2 = "";
        private string _resultado = "";
        private string _operador = "";




    }
}
