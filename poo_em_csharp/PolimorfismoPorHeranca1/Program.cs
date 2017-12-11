using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolimorfismoPorHeranca1
{

    public class Narrador
    {
        public string Lance { get; set; }

        public virtual void Narrar()
        {
            Console.WriteLine(Lance);
        }
    }

    public class Narrador1 : Narrador
    {
        public override void Narrar()
        {
            if (Lance == "caneta")
                Console.WriteLine("Sensacional a caneta que o Pelé deu no Maradona!");
        }
    }

    public class Narrador2 : Narrador
    {
        public override void Narrar()
        {
            if (Lance == "caneta")
                Console.WriteLine("Incrível o rolinho que o Pelé deu no Maradona!");
        }
    }

    public class Jogo
    {
        private Narrador _narrador;

        public void SetNarrador(Narrador narrador)
        {
            _narrador = narrador;
        }

        public void NovoLance(string lance)
        {
            _narrador.Lance = lance;
            _narrador.Narrar();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //O narrador escalado para o jogo é o Neto Berolo
            Narrador1 netoBerolo = new Narrador1();
            //Começa o jogo
            Jogo jogo = new Jogo();
            jogo.SetNarrador(netoBerolo);
            //Ocorre o primeiro lance
            jogo.NovoLance("caneta");
            //Felizmente o Neto Berolo teve uma dor de barriga daquelas e teve que ser substituído pelo Galvão Pateta
            Narrador2 galvaoPatela = new Narrador2();
            jogo.SetNarrador(galvaoPatela);
            //Ocorre o segundo lance
            jogo.NovoLance("caneta");
            Console.ReadKey();
        }
    }
}
