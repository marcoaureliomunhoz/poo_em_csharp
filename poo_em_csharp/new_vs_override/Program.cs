using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_vs_override
{
    public class PapagaioCurintiano1
    {
        public void QualSeuNome()
        {
            Console.WriteLine("É cú!");
        }
    }

    public class PapagaioCurintianoEducadoPorNew : PapagaioCurintiano1
    {
        public new void QualSeuNome()
        {
            Console.WriteLine("É curi!");
        }

        public void FalaSerio()
        {
            base.QualSeuNome();
        }
    }

    public class PapagaioCurintiano2
    {
        public virtual void QualSeuNome()
        {
            Console.WriteLine("É cú!");
        }
    }

    public class PapagaioCurintianoEducadoPorOverride : PapagaioCurintiano2
    {
        public override void QualSeuNome()
        {
            Console.WriteLine("É curi!");
        }

        public void FalaSerio()
        {
            base.QualSeuNome();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PapagaioCurintiano1 p1 = new PapagaioCurintiano1();
            p1.QualSeuNome();

            PapagaioCurintianoEducadoPorNew p2 = new PapagaioCurintianoEducadoPorNew();
            p2.QualSeuNome();
            p2.FalaSerio();

            PapagaioCurintianoEducadoPorOverride p3 = new PapagaioCurintianoEducadoPorOverride();
            p3.QualSeuNome();
            p3.FalaSerio();

            Console.ReadKey();
        }
    }
}
