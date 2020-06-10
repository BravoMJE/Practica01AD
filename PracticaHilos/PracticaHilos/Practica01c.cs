// ************************************************************************
// Practica 01
// Joseph Bravo, Esteban Machado
// Fecha de realizacion: 04/06/2020
// Fecha de entrega: 08/06/2020
// Resultados:
//* El codigo permita verificar como se puede bloquear 
// un hilo para que otro se ejecute completamenta
//Preguntas
//a.	¿Qué encontró al ejecutar dos veces el programa?
//Se puede observar que inicia el hilo principal al llamar al hilo trabajador el 
//    principal queda a la espera que hilo trabajador finalice y continua.
//b.  ¿Es el resultado el mismo al del código anterior Practica01b?
//No, ya que en el código anterior la primera pausa del método ImprimirNumerosConRetardo() 
//hacia que la ejecución del principal se ejecutara, mientras que en este caso se 
//bloquea el hilo principal permitiendo que el hilo trabajador se ejecute por completo.
//c.Qué sucede si comenta la línea hiloTrabajador.Join()? Explique claramente qué
//sucede en este caso?
//En este caso el hilo principal no espera a que se termine la ejecución del hilo 
//trabajador por lo que dependerán de su quantum para ejecutar sus acciones en este 
//ejemplo en concreto tenemos que el hilo principal termina sus acciones antes de que el 
//hilo trabajador inicie con los suyos

// Conclusiones:
//*
// Recomendaciones:
//*
// ************************************************************************
using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace PracticaHilos
{
    class Practica01c
    {


        static void Main(string[] args)
        {
            //Creacion de hilo este ejecutara el metodo ImprimirNumeros
            Console.WriteLine("Empezando");
            Thread hiloTrabajador = new Thread(delegate () { ImprimirNumerosConRetardo(); });
            hiloTrabajador.Start();
            //La funcion Join nos permite hacer que el hilo trabajador se ejecute por completo
            //para ello bloquea el hilo que lo llamo en este caso el hilo principal
            hiloTrabajador.Join();
            Console.WriteLine("Ejecucion del hilo principal finalizada");

            //Llamada al metodo ImprimirNumeros que nos permitira ver
            //la asignacion de tiempos del procesador
            //ImprimirNumeros();

            Console.ReadLine();
        }


        //Metodo que imprime numeros del 1 a 50
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
    }
}