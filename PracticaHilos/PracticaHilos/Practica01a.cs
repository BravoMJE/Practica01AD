// ************************************************************************
// Practica 01
// Joseph Bravo, Esteban Machado
// Fecha de realizacion: 04/06/2020
// Fecha de entrega: 08/06/2020
// Resultados:
//* El codigo permita visualizar como se asigna el quantum
// a cada hilo
//Preguntas:
//a.	¿Qué encontró al ejecutar dos veces el programa?
//En cada ejecución se generan resultados aleatorios y tanto el resultado del hilo
//como el método ImprimirNumeros() por si solo se cruzan en el tiempo
//
//b.  ¿Es el resultado el mismo? Explique el por qué
//Debido a que los hilos tienen un tiempo en el procesador el momento en que el tiempo 
//se termina entra el método ImprimirNumeros() y se ejecutan alternadamente el método y el hilo.
//
//c.Qué sucede si cambia la línea ImprimirNúmeros(); antes de la creación del hilo?
//Se ejecutará primero el método sin interrupción y de igual manera el hilo al no tener nada que 
//lo interrumpa se ejecutará a la vista del usuario continuamente sin embargo respetará cada quantum

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