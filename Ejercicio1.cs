using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPAlgoritmos
{
    internal class Ejercicio1
    {
        static void Main(string[] args)
        {
            /* EJERCICIO_1
            Console.Write("Ingrese el importe a cobrar: ");
            int importe = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese el monto con el que paga el cliente: ");
            int pagoCliente = Convert.ToInt32(Console.ReadLine());

            if (pagoCliente < importe)
            {
                Console.WriteLine("El monto ingresado es menor al importe a cobrar. Por favor, ingrese un monto adecuado.");
                Console.ReadLine(); // Pausa antes de salir
                return;
            }

            int vuelto = pagoCliente - importe;

            Console.WriteLine("El vuelto es: " + vuelto);

            int[] valoresMonedas = { 100, 20, 10, 5, 1 };
            int[] cantidadMonedas = new int[5];

            for (int i = 0; i < valoresMonedas.Length; i++)
            {
                cantidadMonedas[i] = vuelto / valoresMonedas[i];
                vuelto = vuelto % valoresMonedas[i];
            }

            Console.WriteLine("Vuelto en monedas:");

            for (int i = 0; i < valoresMonedas.Length; i++)
            {
                Console.WriteLine("$" + valoresMonedas[i] + ": " + cantidadMonedas[i]);
            }

            Console.ReadLine();*/
            //Ejercicio_2
            Grafo g = new Grafo();

            g.AgregarArista("Arad", "Zerind", 75);
            g.AgregarArista("Arad", "Timisoara", 118);
            g.AgregarArista("Arad", "Sibiu", 140);
            g.AgregarArista("Zerind", "Oradea", 71);
            g.AgregarArista("Timisoara", "Lugoj", 111);
            g.AgregarArista("Oradea", "Sibiu", 151);
            g.AgregarArista("Lugoj", "Mehadia", 70);
            g.AgregarArista("Sibiu", "Rimnicu Vilcea", 80);
            g.AgregarArista("Sibiu", "Fagaras", 99);
            g.AgregarArista("Mehadia", "Drobeta", 75);
            g.AgregarArista("Rimnicu Vilcea", "Craiova", 146);
            g.AgregarArista("Craiova", "Pitesti", 138);
            g.AgregarArista("Pitesti", "Bucharest", 101);
            g.AgregarArista("Fagaras", "Bucharest", 211);
            g.AgregarArista("Rimnicu Vilcea", "Pitesti", 97);
            g.AgregarArista("Drobeta", "Craiova", 120);

            var distancias = g.Dijkstra("Arad");

            Console.WriteLine("Ingrese la ciudad para mostrar su recorrido:");
            string ciudad = Console.ReadLine();

            if (distancias.ContainsKey(ciudad))
            {
                var recorrido = g.Recorrido(ciudad, distancias);
                Console.WriteLine("Recorrido para la ciudad " + ciudad + ":");
                foreach (var c in recorrido)
                    Console.Write(c + " -> ");
                Console.WriteLine("Fin");
            }
            else
            {
                Console.WriteLine("Ciudad no encontrada.");
            }

            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
