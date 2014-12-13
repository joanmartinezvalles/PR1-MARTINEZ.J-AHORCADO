using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoAhorcado
{
    class Logica
    {

        public string ListaPalabras()
        {
            //1. El programa escoge una palabra al azar de una lista..
            string[] palabras = { "gato", "perro", "restaurante", "ordenador", "ventana", "libro", "persona", "metodo", "variable",
                                "palabra", "letra", "oficina", "boligrafo", "auriculares", "altavoz"};
            Random generadorPalabras = new Random();
            int numAzar = generadorPalabras.Next(0, palabras.Length);
            string palabraAdivinar = palabras[numAzar];
            return palabraAdivinar;
        }

        public string PalabraOculta(string palabraAdivinar)
        {
            //2.Se muestra una serie de guiones.
            string palabraMostrar = "";
            for (int i = 0; i < palabraAdivinar.Length; i++)
            {
                //if (palabraAdivinar[i] == ' ')
                //    palabraMostrar += " ";

                palabraMostrar += "_ ";
            }
            return palabraMostrar;
        }

        public void ObtenerPalabra(string palabraAdivinar, ref string palabraMostrar, ref int fallosRestantes, char letraActual)
        {
            //5.Si letra no pertenece a la plabra pierde un intento.
            if (palabraAdivinar.IndexOf(letraActual) == -1)
                fallosRestantes--;

            //6.Si la letra es parte de la palabra, la letra se muestra como parte de ella.
            string palabraOculta = "";
            palabraMostrar = palabraMostrar.Replace(" ", "");

            for (int i = 0; i < palabraAdivinar.Length; i++)
            {
                if (letraActual == palabraAdivinar[i]) // equivalente letraActual==palabraAdivinar[i]
                    palabraOculta += letraActual + " ";
                else if (palabraMostrar[i] != '_')
                    palabraOculta += palabraMostrar[i] + " ";
                else
                    palabraOculta += "_ ";
            }
            palabraMostrar = palabraOculta;
        }

        public bool JuegoTerminado(string palabraAdivinar, string palabraMostrar, int fallosRestantes, bool terminado)
        {
            //7.Comprobar si el juego ha terminado.
            if (palabraMostrar.IndexOf("_ ") < 0)
            {
                Console.WriteLine("Felicidades has acertado ({0})", palabraAdivinar);
                terminado = true;
            }
            if (fallosRestantes == 0)
            {
                Console.WriteLine("Lo siento. La palabra era {0}", palabraAdivinar);
                terminado = true;
            }
            return terminado;
        }
    }
}

