using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoAhorcado
{
    class AhorcadoV1
    {
        static void Main()
        {
            //1. El programa escoge una palabra al azar de una lista..
            string[] palabras = { "gato", "perro", "restaurante", "ordenador", "ventana" };
            Random generadorAleatorio = new Random();
            int numAzar = generadorAleatorio.Next(0, palabras.Length);
            string palabraAdivinar = palabras[numAzar];

            //2.Se muestra una serie de guiones.
            string palabraMostrar = "";
            for (int i = 0; i < palabraAdivinar.Length; i++)
            {
                //if (palabraAdivinar[i] == ' ')
                //    palabraMostrar += " ";

                palabraMostrar += "_ ";
            }

            int fallosRestantes = 10;
            char letraActual;
            bool terminado = false;

            do
            {
                //3.Se muestra la palabra oculta y el jugador elige una letra.
                Console.WriteLine("Palabra oculta: {0}", palabraMostrar);
                Console.WriteLine("Fallos restantes: {0}", fallosRestantes);

                //4.El usuario elige una letra.
                Console.Write("Introduzca una letra: ");
                letraActual = Convert.ToChar(Console.ReadLine());

                //5.Si letra no pertenece a la plabra pierde un intento.
                if (palabraAdivinar.IndexOf(letraActual) == -1)
                    fallosRestantes--;

                //6.Si la letra es parte de la palabra, la letra se muestra como parte de ella.
                string palabraOculta ="";
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

                Console.WriteLine();
            }
            while (!terminado);

            Console.ReadKey();
        }
    }
}
