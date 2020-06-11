// ************************************************************************
// Deber 02
// Joseph Bravo, Esteban Machado
// Fecha de realizacion: 04/06/2020
// Fecha de entrega: 08/06/2020
// Resultados:
//* El codigo permita verificar como se pueden alterar los resultados
// si no se bloquean los elementos de los que se hace uso y asi no obtener
//resultados incorrectos o inesperados
//Preguntas
//Explique claramente qué sucede en este caso
//Mediante el uso del Bloqueo con Monitor nos permite realizar
//casi las mismas acciones, con la diferencia que el monitor es una clase
//en este caso generemas dos bloqueos de dos objetos para poder 
//generar una muerte por DEADLOCK, en este caso logramos congelar 
//la maquina y no logra avanzar
// Conclusiones:
//*
// Recomendaciones:
//*
// ************************************************************************
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaHilos
{
    class Practica01i
    {
        static void Main(string[] args)
        {
            object bloqueo1 = new object();
            object bloqueo2 = new object();
            new Thread(() => DemasiadosBloqueos(bloqueo1, bloqueo2)).Start();
            lock (bloqueo2)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Monitor.TryEnter permite no quedarse atascado,retornado falso depuesta de que el timeout ha expirado");
                //Verificamos que no exita ningun bloqueo 
                if (Monitor.TryEnter(bloqueo1, TimeSpan.FromSeconds(5)))
                {
                    Console.WriteLine("Desbloqueo del recurso exitoso");
                }
                else
                {
                    Console.WriteLine("Temporizador no se cumple!");
                }
            }


            Console.WriteLine("----");

            //Generamos los dos bloqueos para ver como trabaja el modo monitor 

            new Thread(() => DemasiadosBloqueos(bloqueo1, bloqueo2)).Start();



            lock (bloqueo2)
            {
                Console.WriteLine("Aquí viene una muerte por bloqueo DEADLOCK");
                Thread.Sleep(1000);
                lock (bloqueo1)
                {
                    Console.WriteLine("Desbloqueo del recurso exitoso");
                }
            }
            var c = new Contador();
            var t1 = new Thread(() => Prueba(c));
            var t2 = new Thread(() => Prueba(c));

        }

        //Metodo que me  crear mas de un bloqueo 
        static void DemasiadosBloqueos(object bloqueo1, object bloqueo2)
        {

            lock (bloqueo1)
            {
                Thread.Sleep(1000);
                lock (bloqueo2)
                {
                    ;
                }
            }

        }
        //Aumenta y decrementa la variable el resultado ideal sera 0
        static void Prueba(ContadorBase c)
        {

            for (int i = 0; i < 100000; i++)
            {
                c.Incrementar();
                c.Decrementar();
            }

        }
        //contrador sin bloqueo metodos Incrementar aumenta contar en una unidad
        //metodo decrementar contar en una unidad 
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

        abstract class ContadorBase
        {
            public abstract void Incrementar();
            public abstract void Decrementar();
        }
    }
}
