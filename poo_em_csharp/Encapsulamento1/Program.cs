using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Encapsulamento1
{
    public class Carro
    {
        private int _kmTotal = 0;

        public int GetKmTotal()
        {
            return _kmTotal;
        }
        //ou
        public int KmTotal
        {
            get { return _kmTotal; }
        }

        public void Andar(int km, int velocidade)
        {
            for (int i = 0; i <= km; i++)
            {
                Thread.Sleep(velocidade);
            }
            _kmTotal += km;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Carro c1 = new Carro();
            Console.WriteLine("Km Total: {0}", c1.GetKmTotal());
            c1.Andar(100, 10);
            Console.WriteLine("Km Total: {0}", c1.KmTotal);
            Console.ReadKey();
        }
    }
}
