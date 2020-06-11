// ************************************************************************
// Practica 01
// Joseph Bravo, Esteban Machado
// Fecha de realizacion: 04/06/2020
// Fecha de entrega: 08/06/2020
// Resultados:
//* El codigo permita verificar como se puede bloquear 
// un hilo para que otro se ejecute completamenta
//Preguntas
//Explique claramente qué sucede en este caso
//La clase EjemploHilo nos permite instanciar un objeto de tipo EjemploHilo 
//que en su constructor unicamente recibe un entero que sera el numero de veces
//que cada hilo imprimira su nombre y el numero de iteracion correspondiente
//hiloUno.name establece un nombre a un hilo lo que nos permitira identificarlo
//finalmente con hiloDos.IsBackground = true se habilita al hilo para que 
//se ejecute en segundo plano, los dos hilos se ejecutaran al mismo tiempo
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
    class Practica01f
    {

        static void Main(string[] args)
        {


            var hiloForeground = new EjemploHilo(10);
            var hiloBackground = new EjemploHilo(20);

            var hiloUno = new Thread(hiloForeground.Contar); 
            hiloUno.Name = "hilo Foreground"; 
            var hiloDos = new Thread(hiloBackground.Contar); 
            hiloDos.Name = "hilo Background"; 
            hiloDos.IsBackground = true;

            hiloUno.Start();
            hiloDos.Start();

            Console.ReadLine();
        }


       
    }


    class EjemploHilo{
        private readonly int numIteraciones;

        public EjemploHilo(int iteraciones) { 
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