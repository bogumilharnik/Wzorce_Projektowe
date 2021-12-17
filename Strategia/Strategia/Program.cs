using System;

namespace Strategia
{
    abstract class Zawodnik
    {
        KopniecieTyp kopniecieTyp;
        SkokTyp skokTyp;

        public Zawodnik(KopniecieTyp _kopniecieTyp, SkokTyp _skokTyp)
        {
            kopniecieTyp = _kopniecieTyp;
            skokTyp = _skokTyp;
        }

        public void uderzenie()
        {
            Console.WriteLine("Uderzenie");
        }

        public void kopniecie()
        {
            kopniecieTyp.kopniecie();
        }

        public void skok()
        {
            skokTyp.skok();
        }

        public void ustawKopniecieTyp(KopniecieTyp kopniecieTyp)
        {
            this.kopniecieTyp = kopniecieTyp;
        }

        public void ustawSkokTyp(SkokTyp skokTyp)
        {
            this.skokTyp = skokTyp;
        }

        public virtual void przedstaw()
        {
        }
    }

    interface KopniecieTyp
    {
        void kopniecie();
    }

    class KopniecieLod : KopniecieTyp
    {
        public void kopniecie()
        {
            Console.WriteLine("Kopnięcie lodowe");
        }
    }

    class KopniecieOgien : KopniecieTyp
    {
        public void kopniecie()
        {
            Console.WriteLine("Kopnięcie z ogniem");
        }
    }

    interface SkokTyp
    {
        void skok();
    }

    class KrotkiSkok : SkokTyp
    {
        public void skok()
        {
            Console.WriteLine("Krótki skok");
        }
    }

    class DlugiSkok : SkokTyp
    {
        public void skok()
        {
            Console.WriteLine("Długi skok");
        }
    }

    class SubZero : Zawodnik
    {
        KopniecieTyp kopniecieTyp;
        SkokTyp skokTyp;

        public SubZero(KopniecieTyp _kopniecieTyp, SkokTyp _skokTyp) : base(_kopniecieTyp, _skokTyp)
        {
            kopniecieTyp = _kopniecieTyp;
            skokTyp = _skokTyp;
        }

        override public void przedstaw()
        {
            Console.WriteLine("Jestem Sub-Zero!");
        }
    }

    class Scorpion : Zawodnik
    {
        KopniecieTyp kopniecieTyp;
        SkokTyp skokTyp;

        public Scorpion(KopniecieTyp _kopniecieTyp, SkokTyp _skokTyp) : base(_kopniecieTyp, _skokTyp)
        {
            kopniecieTyp = _kopniecieTyp;
            skokTyp = _skokTyp;
        }

        override public void przedstaw()
        {
            Console.WriteLine("Jestem Scorpion!");
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("-- Mortal Kombat --");
            Console.WriteLine();

            KopniecieTyp kopniecieLod = new KopniecieLod();
            KopniecieTyp kopniecieOgien = new KopniecieOgien();
            SkokTyp krotkiSkok = new KrotkiSkok();
            SkokTyp dlugiSkok = new DlugiSkok();
            Zawodnik subZero = new SubZero(kopniecieLod, krotkiSkok);
            subZero.przedstaw();
            subZero.uderzenie();
            subZero.kopniecie();
            subZero.skok();
            subZero.ustawSkokTyp(dlugiSkok);
            subZero.skok();
            Console.WriteLine();
            Zawodnik scorpion = new Scorpion(kopniecieLod, krotkiSkok);
            scorpion.przedstaw();
            scorpion.uderzenie();
            scorpion.ustawKopniecieTyp(kopniecieOgien);
            scorpion.kopniecie();
            scorpion.ustawKopniecieTyp(kopniecieLod);
            scorpion.kopniecie();
            scorpion.ustawSkokTyp(dlugiSkok);
            scorpion.skok();
        }
    }
}