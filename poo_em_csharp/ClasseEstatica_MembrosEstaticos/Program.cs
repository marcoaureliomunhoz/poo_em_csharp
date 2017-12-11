using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasseEstatica_MembrosEstaticos
{
    public static class Calculadora
    {
        public static int Somar(int v1, int v2)
        {
            return v1 + v2;
        }

        public static int Multiplicar(int v1, int v2)
        {
            return v1 * v2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Resultado: 2 + 3 = {0}", Calculadora.Somar(2, 3));
            Console.WriteLine("Resultado: 3 * 3 = {0}", Calculadora.Multiplicar(3, 3));
            Console.ReadKey();
        }
    }
}
