// ************************************************************************
// Deber 02
// Joseph Bravo, Esteban Machado
// Fecha de realizacion: 04/06/2020
// Fecha de entrega: 08/06/2020
// Resultados:
//* El codigo permita visualizar como se puede pausar un hilo
//para que otro pueda ejecutarse 
//
//a.    ¿Qué encontró al ejecutar dos veces el programa?
//Se obtuvo resultados similares en cada ejecución con un resultado claro cuando el 
//hiloTrabajador entra a la pausa da tiempo a que el hilo principal ejecute el método ImprimirNumeros().
//
//b.  ¿Es el resultado el mismo? Explique el por qué?
//No, son similares sin embargo no iguales ya que la única cosa que varia es que hilo ejecuta primero el método 
//ImprimirNumeros(), independientemente de que hilo se ejecute primero, el hilo principal es quien ejecutara en 
//método ya que el hiloTrabajador entrara en pausa permitiendo imprimir todos los números durante esa pausa
//
//c.  ¿Qué diferencia hay con el caso anterior?
//La introducción de la pausa de 2 segundo hace posible que el método imprimirNumeros() que ejecuta el hilo 
//principal muestre todos los números seguidos sin interrupción.

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
    class Practica01b
    {


        static void Main(string[] args)
        {
            //Creacion de hilo este ejecutara el metodo ImprimirNumerosConRetardo
            Thread hiloTrabajador = new Thread(delegate () { ImprimirNumerosConRetardo(); });
            hiloTrabajador.Start();

            //Llamada al metodo ImprimirNumeros que nos permitira ver
            //la asignacion de tiempos del procesador
            ImprimirNumeros();

            Console.ReadLine();
        }


        //Metodo que imprime numeros del 1 a 10
        static void ImprimirNumeros()
        {
            Console.WriteLine("Empezando ….");
            for (int i = 1; i < 10; i++)
                Console.WriteLine(i);
        }

        //Metodo que imprime numeros del 1 a 10 y que ademas introduce
        //una pausa de 2 segundos con cada iteracion
        static void ImprimirNumerosConRetardo()
        {
            Console.WriteLine("Empezando …. Retardo");
            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine(i);
            }
        }
    }
}
