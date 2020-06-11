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
//El bloqueo con interlock de igual forma nos permite bloquear 
//un recurso para que no sea utilizado por otro hilo en caso de no 
//finalizar una accion determinada, utilizamos  el metodo interlocked 
//y obtenemos resultados distintos en el caso del bloqueo o sin bloqueo
// Conclusiones:
//* Se determino que el correcto uso de los hilos, permiten distribuir las tareas
//  aumentar el rendimiento y permite trabajar de manera simultanea en varias tareas 
//  al mismo tiempo.
//* Se comprobo que el desconocer el funcionamiento de los hilos y como interactuan
//  entre si puede generar errores e inconsistencias en las operaciones que el programa
//  realiza, esto debido quantum de cada hilo y la forma en la que realizan las tareas.
//* Se corroboro que los hilos que se pueden ejecutar dependen de cuantos pueda ejecutar
//  el procesador, ya que al usar VMWare con 2 procesadores obtuvimos resultados muy erroneos
// Recomendaciones:
//* Al usar una maquina virtual, asignar un numero de procesadores logicos, segun los hilos 
//  empleados en el programa
//* Para trabajar de manera mas eficaz en grupo se puede utilizar la herramienta de GitHub
//  ya que permite un trabajo colaborativo y a su vez nos proporciona un control de versiones.
// ************************************************************************
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaHilos
{
    class Practica01j
    {
        static void Main(string[] args)
        {
            //Instancia e inicializacion de los 3 hilos para contar sin bloqueo

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

            //Instancia e inicializacion de los 3 hilos para contador con bloqueo 

            var c1 = new ContadorConBloqueo();
            t1 = new Thread(() => Prueba(c1));
            t2 = new Thread(() => Prueba(c1));
            t3 = new Thread(() => Prueba(c1));
            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();
            Console.WriteLine("Cuenta Total: {0}", c1.Contar);
            Console.WriteLine("------");

            Console.ReadLine();
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

    }
    //contrador sin bloqueo metodos Incrementar aumenta contar en una unidad
    //metodo decrementar contar en una unidad 
    //el aumentar o decrementar esta desbloqueado
    class Contador : ContadorBase
    {
        private int contar;
        public int Contar { get { return contar; } }
        public override void Incrementar()
        {
            contar++;
        }
        public override void Decrementar()
        {
            contar--;
        }
    }

    //contrador con bloqueo metodos Incrementar aumenta contar en una unidad
    //metodo decrementar contar en una unidad 
    //el aumentar o decrementar esta bloqueado lo que nos permite obtener los 
    //resultados esperados
    class ContadorConBloqueo : ContadorBase
    {
        private int contar;
        public int Contar { get { return contar; } }
        public override void Incrementar()
        {
            Interlocked.Increment(ref contar);
        }
        public override void Decrementar()
        {
            Interlocked.Decrement(ref contar);
        }
    }
    abstract class ContadorBase
    {
        public abstract void Incrementar();
        public abstract void Decrementar();
    }

}
