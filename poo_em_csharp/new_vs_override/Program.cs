using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_vs_override
{
    public class Papagaio1
    {
        public void QualSeuNome(string nome)
        {
            Console.WriteLine("Não importa!");
        }
    }

    public class PapagaioEducadoPorNew : Papagaio1
    {
        public new void QualSeuNome(string nome)
        {
            Console.WriteLine("É {0}!", nome);
        }

        public void FalaSerio(string nome)
        {
            base.QualSeuNome(nome);
        }
    }

    public class Papagaio2
    {
        public virtual void QualSeuNome(string nome)
        {
            Console.WriteLine("Não importa!");
        }
    }

    public class PapagaioEducadoPorOverride : Papagaio2
    {
        public override void QualSeuNome(string nome)
        {
            Console.WriteLine("É {0}!", nome);
        }

        public void FalaSerio(string nome)
        {
            base.QualSeuNome(nome);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Papagaio1 p1 = new Papagaio1();
            p1.QualSeuNome("Marco");

            PapagaioEducadoPorNew p2 = new PapagaioEducadoPorNew();
            p2.QualSeuNome("Marco");
            p2.FalaSerio("Marco");

            PapagaioEducadoPorOverride p3 = new PapagaioEducadoPorOverride();
            p3.QualSeuNome("Marco");
            p3.FalaSerio("Marco");

            Console.ReadKey();
        }
    }
}
