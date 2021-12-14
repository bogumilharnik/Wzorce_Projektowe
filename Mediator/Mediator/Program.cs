using System;
using System.Collections.Generic;
using System.Text;

namespace Mediator
{
    public interface IMediator
    {
        void DodajUzytkownika(IUzytkownik uzytkownik);
        void WyslijWiadomosc(string wiadomosc, IUzytkownik nadawca);
    }

    public interface IUzytkownik
    {
        void WyslijWiadomosc(string wiadomosc);
        void OdbierzWiadomosc(string wiadomosc);
    }

    public class Mediator : IMediator
    {
        List<IUzytkownik> uzytkownicy;

        public Mediator()
        {
            uzytkownicy = new List<IUzytkownik>();
        }

        public void DodajUzytkownika(IUzytkownik uzytkownik)
        {
            uzytkownicy.Add(uzytkownik);
        }

        public void WyslijWiadomosc(string wiadomosc, IUzytkownik nadawca)
        {

            foreach (var item in this.uzytkownicy)
            {
                if (item == nadawca)
                {
                    continue;
                }
                item.OdbierzWiadomosc(wiadomosc);
            }
        }
    }

    public class Dev : IUzytkownik
    {
        string login;
        IMediator Mediator;

        public Dev(IMediator Mediator, string login)
        {
            this.login = login;
            this.Mediator = Mediator;
        }

        public void WyslijWiadomosc(string wiadomosc)
        {
            Mediator.WyslijWiadomosc(wiadomosc, this);
        }

        public void OdbierzWiadomosc(string wiadomosc)
        {
            Console.WriteLine("Programista " + login + " otrzymał wiadomość: " + wiadomosc);
        }
    }

    public class Klient : IUzytkownik
    {
        string login;
        IMediator Mediator;

        public Klient(IMediator Mediator, string login)
        {
            this.login = login;
            this.Mediator = Mediator;
        }

        public void WyslijWiadomosc(string wiadomosc)
        {
            Mediator.WyslijWiadomosc(wiadomosc, this);
        }

        public void OdbierzWiadomosc(string wiadomosc)
        {
            Console.WriteLine("Użytkownik " + login + " otrzymał wiadomość: " + wiadomosc);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            IMediator mediator = new Mediator();

            IUzytkownik ania = new Klient(mediator, "Ania");
            IUzytkownik nakamoto = new Dev(mediator, "Nakamoto");
            IUzytkownik geohot = new Dev(mediator, "Geohot");
 
            mediator.DodajUzytkownika(ania);
            mediator.DodajUzytkownika(nakamoto);
            mediator.DodajUzytkownika(geohot);

            ania.WyslijWiadomosc("Proszę natychmiast wprowadzić poprawki na produkcje.");
            geohot.WyslijWiadomosc("Czekam aż Nakamoto zaparzy kawe...");
        }
    }
}