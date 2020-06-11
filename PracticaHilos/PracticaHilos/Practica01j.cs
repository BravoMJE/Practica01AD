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
            var c1 = new ContadorSinBloqueo();
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

        static void Prueba(ContadorBase c)
        {
            for (int i = 0; i < 100000; i++)
            {
                c.Incrementar();
                c.Decrementar();
            }
        }

    }

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

    class ContadorSinBloqueo : ContadorBase
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
