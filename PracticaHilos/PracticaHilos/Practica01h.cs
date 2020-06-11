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
    class Practica01h
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Contador Incorrecto"); 
            var c = new Contador(); 
            var t1 = new Thread(() => Prueba(c)); 
            var t2 = new Thread(() => Prueba(c)); 
            var t3 = new Thread(() => Prueba(c)); 
            t1.Start(); 
            t2.Start(); 
            t3.Start(); 
            t1.Join(); 
            t2.Join(); 
            t3.Join();

            Console.WriteLine("Cuenta Total: {0}", c.Contar); 
            Console.WriteLine("------");

            Console.WriteLine("Contador correcto");

            var c1 = new ContadorConBloqueo();

            var t4 = new Thread(() => Prueba(c1)); 
            var t5 = new Thread(() => Prueba(c1)); 
            var t6 = new Thread(() => Prueba(c1)); 
            t4.Start(); 
            t5.Start(); 
            t6.Start(); 
            t4.Join(); 
            t5.Join(); 
            t6.Join(); 
            Console.WriteLine("Cuenta Total: {0}", c1.Contar); 
            Console.WriteLine("------");

            Console.ReadLine();
        }


        static void Prueba(ContadorBase c)
        {

            for (int i = 0; i<100000; i++)
            {
                c.Incrementar();
                c.Decrementar();
            }

        }


        class Contador : ContadorBase
        {
            public int Contar { get; private set; }
            public override void Incrementar()
            {
                Contar++;
            }
            public override void Decrementar()
            {
                Contar--;
            }

        }





        class ContadorConBloqueo : ContadorBase
        {
            private readonly object objetoSincronizador = new Object();
            public int Contar { get; private set; }
            public override void Incrementar()
            {
                lock (objetoSincronizador)
                {
                    Contar++;
                }
            }
            public override void Decrementar()
            {

                lock (objetoSincronizador)
                {
                    Contar--;
                }
            }

        }


        abstract class ContadorBase
        {
            public abstract void Incrementar();
            public abstract void Decrementar();
        }



    }

    

}
