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
//Este codigo nos presenta dos metodos principales contador y contador con bloqueo
//con lo dicen sus nombre uno bloquea los elementos dentro de el para que no puedan
//ser modificados mientras el hilo en curso no ha terminado su ejecucion
//para ello se crearan 3 hilos para ejecutar cada metodo los metodos contador y contador
//con bloqueo incremetaran y decrementaran una variable en el mismo metodo por lo que de 
// hacerlo un solo hilo el resultado seria 0 en los resultados se puede observar que contador
//nos arroja un numero muy alto lo que quiere decir que los 2 hilos restantes
//alteraron el resultado esperado
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


            //Instancia e inicializacion de los 3 hilos para contador
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


            //Muestro los resultados obtenidos por el contador 
            //lo que mostrara un resultado incorrecto al no estar bloqueado
            Console.WriteLine("Cuenta Total: {0}", c.Contar); 
            Console.WriteLine("------");

            Console.WriteLine("Contador correcto");




            //Instancia e inicializacion de los 3 hilos para contadorConBloque
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

            //Muestra los resultados esperados para este ejercicio el resiltado
            //correcto seria 0
            Console.WriteLine("Cuenta Total: {0}", c1.Contar); 
            Console.WriteLine("------");

            Console.ReadLine();
        }



        //Aumenta y decrementa la variable el resultado ideal sera 0
        static void Prueba(ContadorBase c)
        {

            for (int i = 0; i<100000; i++)
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




        //contrador sin bloqueo metodos Incrementar aumenta contar en una unidad
        //metodo decrementar contar en una unidad 
        //el aumentar o decrementar esta bloqueado lo que nos permite obtener los 
        //resultados esperados
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
