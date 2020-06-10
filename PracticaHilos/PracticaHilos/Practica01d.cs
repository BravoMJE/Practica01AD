// ************************************************************************
// Practica 01
// Joseph Bravo, Esteban Machado
// Fecha de realizacion: 04/06/2020
// Fecha de entrega: 08/06/2020
// Resultados:
//* El codigo permita verificar como se puede bloquear 
// un hilo para que otro se ejecute completamenta
// Conclusiones:
//*
// Recomendaciones:
//*
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace PracticaHilos
{
    class Practica01d
    {


        static void Main(string[] args)
        {
            //Creacion de hilo este ejecutara el metodo ImprimirNumeros
            Console.WriteLine("Empezando el programa");
            Thread hiloTrabajador = new Thread(ImprimirNumerosConRetardo);
            hiloTrabajador.Start();

            Thread.Sleep(TimeSpan.FromSeconds(6));
            hiloTrabajador.Abort();
            Console.WriteLine("El hilo trabajador ha abortado");

            Thread hiloTrabajador2 = new Thread(ImprimirNumeros);
            hiloTrabajador2.Start();

            //Llamada al metodo ImprimirNumeros
            ImprimirNumeros();
            Console.ReadLine();
        }


        //Metodo que imprime numeros del 1 a 50
        //e incluye una pausa de 2 segundos con cada iteracion
        static void ImprimirNumerosConRetardo()
        {
            Console.WriteLine("Empezando …. Retardo");
            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine(i);
            }
            Console.WriteLine("Hilo trabajador por concluir");
        }


        //Metodo que imprime numeros del 1 a 10
        static void ImprimirNumeros()
        {
            Console.WriteLine("Empezando ….");
            for (int i = 1; i < 10; i++)
                Console.WriteLine(i);
        }
    }
}
