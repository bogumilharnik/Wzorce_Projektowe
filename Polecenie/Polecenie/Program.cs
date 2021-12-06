using System;
using System.Text;

namespace Polecenie
{
    public interface IPolecenie
    {
        void wykonaj();
    }

    public class KomendaWlacz : IPolecenie
    {
        Lampa lampa;

        public KomendaWlacz(Lampa lampa)
        {
            this.lampa = lampa;
        }

        public void wykonaj()
        {
            lampa.wlacz();
        }
    }

    public class KomendaWylacz : IPolecenie
    {
        Lampa lampa;

        public KomendaWylacz(Lampa lampa)
        {
            this.lampa = lampa;
        }

        public void wykonaj()
        {
            lampa.wylacz();
        }
    }

    public class Lampa
    {
        bool stan;

        public Lampa()
        {
            stan = false;
        }

        public void wlacz()
        {
            stan = true;
        }

        public void wylacz()
        {
            stan = false;
        }

        public bool sprawdz()
        {
            return stan;
        }
    }

    public class Pilot
    {
        private IPolecenie polecenie;

        public void ustawPolecenie(IPolecenie polecenie)
        {
            this.polecenie = polecenie;
        }

        public void wcisnijGuzik()
        {
            polecenie.wykonaj();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Lampa lampa = new Lampa();
            Pilot pilot = new Pilot();
            IPolecenie wlacz = new KomendaWlacz(lampa);

            Console.WriteLine(lampa.sprawdz() ? "Lampa włączona" : "Lampa wyłączona");

            pilot.ustawPolecenie(wlacz);
            pilot.wcisnijGuzik();

            Console.WriteLine(lampa.sprawdz() ? "Lampa włączona" : "Lampa wyłączona");
            IPolecenie wylacz = new KomendaWylacz(lampa);

            pilot.ustawPolecenie(wylacz);
            pilot.wcisnijGuzik();
            Console.WriteLine(lampa.sprawdz() ? "Lampa włączona" : "Lampa wyłączona");
        }
    }
}
