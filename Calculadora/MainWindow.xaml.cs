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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            esVacio = true;

            arrayVacio = true;

            hayComa = false;

            datos = new double[] { 0 , 0 };

            botones = new Button[] { boton0, boton1, boton2, boton3, boton4, boton5, boton6, boton7, boton8, boton9 };
        }

        private void numeros(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < botones.Length; i++)
            {
                if (e.Source.Equals(botones[i]))
                {
                    if (esVacio)
                    {
                        display.Content = botones[i].Content;

                        esVacio = false;

                        break;
                    }
                    else
                    {

                        display.Content = display.Content.ToString() + botones[i].Content.ToString();

                        break;
                    }

                }
            }
        }

        private void coma(object sender,RoutedEventArgs e)
        {
            if (!hayComa)
            {
                display.Content= display.Content.ToString() + ".";

                hayComa=true;

                if (esVacio) esVacio = false;
            }
        }

        private void operacion(object sender, RoutedEventArgs e)
        {
            if (arrayVacio)
            {
                datos[0] = double.Parse(display.Content.ToString());

                arrayVacio = false;
            }
            else
            {
                switch (datos[1])
                {
                    case 0:
                        datos[0] += double.Parse(display.Content.ToString());

                        break;

                    case 1:
                        datos[0] -= double.Parse(display.Content.ToString());

                        break;

                    case 2:
                        datos[0] *= double.Parse(display.Content.ToString());

                        break;

                    case 3:
                        datos[0] /= double.Parse(display.Content.ToString());

                        break;
                }

                display.Content = datos[0];

                    
            }

            if (e.Source.Equals(mas)) datos[1] = 0;

            else if (e.Source.Equals(menos)) datos[1] = 1;

            else if (e.Source.Equals(por)) datos[1] = 2;

            else datos[1] = 3;

            esVacio = true;

            hayComa = false;

        }

        private void igual(object sender, RoutedEventArgs e)
        {
            switch (datos[1])
            {
                case 0:
                    datos[0] += double.Parse(display.Content.ToString());

                    break;

                case 1:
                    datos[0] -= double.Parse(display.Content.ToString());

                    break;

                case 2:
                    datos[0] *= double.Parse(display.Content.ToString());

                    break;

                case 3:
                    datos[0] /= double.Parse(display.Content.ToString());

                    break;
            }

            display.Content = datos[0];

            esVacio = true;

            hayComa = false;

            arrayVacio = true;

            datos[0] = 0;

            datos[1]=0;
        }

        private void borrarTodo(object sender, RoutedEventArgs e)
        {
            datos[0] = 0;

            datos[1] = 0;

            esVacio=true;

            display.Content = "0";

            hayComa = false;

        }

        private static bool esVacio,hayComa,arrayVacio;

        private double[] datos; 

        private static Button[] botones;
    }
}
