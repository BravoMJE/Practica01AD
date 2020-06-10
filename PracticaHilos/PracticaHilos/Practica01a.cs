// ************************************************************************
// Practica 01
// Joseph Bravo, Esteban Machado
// Fecha de realizacion: 04/06/2020
// Fecha de entrega: 08/06/2020
// Resultados:
//* El codigo permita visualizar como se asigna el quantum
// a cada hilo
// Conclusiones:
//*
// Recomendaciones:
//*
// ************************************************************************

using System;
using System.Threading;

namespace PracticaHilos
{
    class Practica01a
    {
        static void Main(string[] args)
        {
            //Creacion de hilo este ejecutara el metodo ImprimirNumeros
            Thread hiloTrabajador = new Thread(delegate () { ImprimirNumeros(); });
            hiloTrabajador.Start();

            //Llamada al metodo ImprimirNumeros que nos permitira ver
            //la asignacion de tiempos del procesador
            ImprimirNumeros();

            Console.ReadLine();
        }


        //Metodo que imprime numeros del 1 a 50
        static void ImprimirNumeros()
        {
            Console.WriteLine("Empezando ….");
            for (int i = 1; i < 50; i++)
                Console.WriteLine(i);
        }

        
    }
}