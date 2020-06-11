// ************************************************************************
// Deber 02
// Joseph Bravo, Esteban Machado
// Fecha de realizacion: 04/06/2020
// Fecha de entrega: 08/06/2020
// Resultados:
//* El codigo permite abortar cualquier hilo en un instante determinado
//lo que termina su ejecucion en el momento en que se ejecuta
//Preguntas
//a. Explique claramente qué sucede en este caso.
// Al empezar el programa se instancia hilo trabajador, y se ejecuta una
//pausa de 6 segundos en los cuales el hilo trabajador esta vivo al finalizar la 
//espera el hilo finaliza su ejecucion sin terminar la tarea programa esto da paso
//a la creacion del segundo hilo, este por su parte ejecuta la accion completa
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

            //Nos permite abortar la ejecucion de un hilo
            hiloTrabajador.Abort();
            Console.WriteLine("El hilo trabajador ha abortado");

            //Instancia de un segunfo hilo este seguira funcionando a pesar de la 
            //operacion de aborto de el hiloTrabajador
            Thread hiloTrabajador2 = new Thread(ImprimirNumeros);
            hiloTrabajador2.Start();

            //Llamada al metodo ImprimirNumeros
            ImprimirNumeros();
            Console.ReadLine();
        }


        //Metodo que imprime numeros del 1 a 10
        //e incluye una pausa de 2 segundos con cada iteracion
        static void ImprimirNumerosConRetardo()
        {
            Console.WriteLine("Empezando ….");
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
