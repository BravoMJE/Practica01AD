// ************************************************************************
// Deber 02
// Joseph Bravo, Esteban Machado
// Fecha de realizacion: 04/06/2020
// Fecha de entrega: 08/06/2020
// Resultados:
//* El codigo permita verificar el estado de un hilo en un 
// momento determinado 
//Preguntas
//Explique claramente qué sucede en este caso
//Al instanciar los dos hilos y no iniciarlos aun al ejecutar thread state
//nos indica unstarted lo que confirma que no ha sido iniciado en cada ejecucion del 
//lazo el se sensa el estado del primer hilo debido al quantum es periodos que el hilo 
//pasa a estado WaitSleepJoin es decir que el hilo principal esta ejecutandose
//cada vez que esta dentro de su quantum el estado del hilo pasa a running
//al ser abortado a la fuerza el estado cambia a Aborted
//y finalmente a Stopped cuando ejecuta todas sus tareas
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
    class Practica01e
    {

        static void Main(string[] args)
        {
            //Creacion de hilo este ejecutara el metodo ImprimirNumeros
            Console.WriteLine("Empezando el programa");
            Thread primerHilo = new Thread(ImprimirNumerosConRetardo);
            Thread segundoHilo = new Thread(NoHaceNada);
            Console.WriteLine(primerHilo.ThreadState.ToString());
            primerHilo.Start();
            segundoHilo.Start();
            for (int i = 1; i < 30; i++)
                Console.WriteLine(primerHilo.ThreadState.ToString());
            Thread.Sleep(TimeSpan.FromSeconds(6));
            primerHilo.Abort();
            Console.WriteLine("El primer hilo ha abortado!");
            Console.WriteLine(primerHilo.ThreadState.ToString());
            Console.WriteLine(segundoHilo.ThreadState.ToString()+"fuera del lazo");

            Console.ReadLine();
        }


        //Metodo que imprime numeros del 1 a 10
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


        //Metodo que ejecuta simplemente una pausa de 2 segundos
        static void NoHaceNada()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }
    }
}
