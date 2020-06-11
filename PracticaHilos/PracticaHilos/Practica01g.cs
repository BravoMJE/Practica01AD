// ************************************************************************
// Deber 02
// Joseph Bravo, Esteban Machado
// Fecha de realizacion: 04/06/2020
// Fecha de entrega: 08/06/2020
// Resultados:
//* El codigo permite visualizar las diferentes formas de pasar parametros a un Hilo
//Preguntas
//Explique claramente qué sucede en este caso
//En este ejercicio se puede visualizar como se puede hacer el paso de parametros
//a un hilo de maneras diferentes desde el paso a un objeto como tal que va a 
//ejecutar un metodo dentro de nuestro hilo y uso de expresiones lambda todas 
// las maneras citas tienen la misma funcionalidad
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

            //Paso de parametros por medio del atributo del objeto
            var ejemplo = new HiloEjemplo(10);
            var hiloUno = new Thread(ejemplo.Contar);
            hiloUno.Name = "hilo Primero";
            hiloUno.Start();
            hiloUno.Join();
            Console.WriteLine("------");

            //Paso de parametros por medio del metodo .Start()
            var hiloDos = new Thread(Contar);
            hiloDos.Name = "hilo Dos"; 
            hiloDos.Start(8); 
            hiloDos.Join(); 
            Console.WriteLine("------");


            //Paso de parametros por expresiones lambda
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


        //Nos mostrara el nombre del hilo y el numero de la iteracion
        static void ContarNumeros(int iteraciones)
        {

            for (int i = 1; i <= iteraciones; i++) {
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                Console.WriteLine("{0} imprime {1}", Thread.CurrentThread.Name, i);
            }

        }

        //imprime por consola el valor ingresado
        static void ImprimirNumeros(int numero) { 
            Console.WriteLine(numero); 
        }




    }


    //clase HiloEjemplo
    class HiloEjemplo
    {
        private readonly int numIteraciones;

        public HiloEjemplo(int iteraciones)
        {
            numIteraciones = iteraciones;
        }


        //Nos mostrara el nombre del hilo y el numero de la iteracion
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
