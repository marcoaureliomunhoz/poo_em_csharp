using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasseNaoEstatica_MembrosEstaticos
{
    public class Calculadora
    {
        public static int contador = 0;

        public Calculadora()
        {
            contador++;
        }

        ~Calculadora()
        {
            contador--;
        }

        public int Somar(int v1, int v2)
        {
            return v1 + v2;
        }

        public int Multiplicar(int v1, int v2)
        {
            return v1 * v2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Contador: {0}", Calculadora.contador);
            Calculadora c1 = new Calculadora();
            Console.WriteLine("Resultado: 2+2 = {0}", c1.Somar(2, 2));
            Console.WriteLine("Contador: {0}", Calculadora.contador);
            Calculadora c2 = new Calculadora();
            Console.WriteLine("Resultado: 2*6 = {0}", c2.Multiplicar(2, 6));
            Console.WriteLine("Contador: {0}", Calculadora.contador);
            c1 = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine("Contador: {0}", Calculadora.contador);
            c2 = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine("Contador: {0}", Calculadora.contador);
            Console.ReadKey();
        }
    }
}
