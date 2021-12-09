using System;
using System.Collections.Generic;

namespace Pamiątka
{
    class Zycie
    {
        private string czas { get; set; }

        public void Czas(string czas)
        {
            Console.WriteLine("Skok do roku: " + czas);
            this.czas = czas;
        }

        public Pamiatka zapiszPamiatke()
        {
            Console.WriteLine("stan zapisany");
            return new Pamiatka(czas);
        }

        public void przywrocPamiatke(Pamiatka pamiatka)
        {
            czas = pamiatka.pobierzCzas();
            Console.WriteLine("Przywrócono rok: " + czas);
        }
    }

    public class Pamiatka
    {
        private string czas;

        public Pamiatka(string czas)
        {
            this.czas = czas;
        }

        public string pobierzCzas()
        {
            return this.czas;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Powrót do przyszłości (Back to the Future)");
            Console.WriteLine();

            List<Pamiatka> zapisaneStany = new List<Pamiatka>();
            Zycie zycie = new Zycie();

            zycie.Czas("1985");
            zapisaneStany.Add(zycie.zapiszPamiatke());
            zycie.Czas("1955");
            zapisaneStany.Add(zycie.zapiszPamiatke());
            zycie.Czas("2015");
            zapisaneStany.Add(zycie.zapiszPamiatke());
            zycie.Czas("1885");

            zycie.przywrocPamiatke(zapisaneStany[0]);
        }
    }
}