// ************************************************************************
// Practica 01
// Joseph Bravo, Esteban Machado
// Fecha de realizacion: 04/06/2020
// Fecha de entrega: 08/06/2020
// Resultados:
//* El codigo permite visualizar las diferentes formas de pasar parametros a un Hilo
//Preguntas
//Explique claramente qué sucede en este caso
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
    class Practica01g
    {

        static void Main(string[] args)
        {

            var ejemplo = new HiloEjemplo(10);
            var hiloUno = new Thread(ejemplo.Contar);
            hiloUno.Name = "hilo Primero";
            hiloUno.Start();
            hiloUno.Join();
            Console.WriteLine("------");
            var hiloDos = new Thread(Contar);
            hiloDos.Name = "hilo Dos"; 
            hiloDos.Start(8); 
            hiloDos.Join(); 
            Console.WriteLine("------");

            var hiloTres = new Thread(() => ContarNumeros(12)); 
            hiloTres.Name = "hilo Tres"; 
            hiloTres.Start(); 
            hiloTres.Join(); 
            Console.WriteLine("------");

            int i = 10;
            var hiloCuatro = new Thread(() => ImprimirNumeros(i));

            i = 20;
            var hiloCinco = new Thread(() => ImprimirNumeros(i));
            hiloCuatro.Start(); 
            hiloCinco.Start();

            Console.ReadLine();
        }

        static void Contar(object iteraciones)
        {

            ContarNumeros((int)iteraciones);

        }

        static void ContarNumeros(int iteraciones)
        {

            for (int i = 1; i <= iteraciones; i++) {
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                Console.WriteLine("{0} imprime {1}", Thread.CurrentThread.Name, i);
            }

        }

        static void ImprimirNumeros(int numero) { 
            Console.WriteLine(numero); 
        }




    }

    class HiloEjemplo
    {
        private readonly int numIteraciones;

        public HiloEjemplo(int iteraciones)
        {
            numIteraciones = iteraciones;
        }

        public void Contar()
        {
            for (int i = 0; i < numIteraciones; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                Console.WriteLine("{0} imprime {1}", Thread.CurrentThread.Name, i);
            }
        }

    }

}
