﻿using System;
using System.Text;

namespace Metoda_Szablonowa
{
    abstract class ZamowienieTemplatka
    {
        abstract public void doKoszyk();
        abstract public void doPlatnosc();
        abstract public void doDostawa();

        public void dodanieGratisu()
        {
            Console.WriteLine("Dodano gratis...");
        }

        public void przetwarzajZamowienie(bool czyGratis)
        {
            this.doKoszyk();
            this.doPlatnosc();

            if (czyGratis == true)
            {
                this.dodanieGratisu();
            }

            this.doDostawa();
        }
    }

    class ZamowienieOnline : ZamowienieTemplatka
    {

        override public void doKoszyk()
        {
            Console.WriteLine("Kompletowanie zamówienia...");
            Console.WriteLine("Ustawiono parametry wysyłki...");
        }

        override public void doPlatnosc()
        {
            Console.WriteLine("Płatność...");
        }

        override public void doDostawa()
        {
            Console.WriteLine("Wysyłka...");
        }
    }

    class ZamowienieStacjonarne : ZamowienieTemplatka
    {
        public override void doDostawa()
        {
            Console.WriteLine("Wydanie produktów (odbiór osobisty)...");
        }

        public override void doKoszyk()
        {
            Console.WriteLine("Wybranie produktów...");
        }

        public override void doPlatnosc()
        {
            Console.WriteLine("Płatność w kasie (karta/gotówka)...");
        }
    }

    class Program
    {
        public static void Main(String[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            ZamowienieTemplatka zamowienieOnline = new ZamowienieOnline();
            zamowienieOnline.przetwarzajZamowienie(true);
            Console.WriteLine();

            ZamowienieTemplatka zamowienieStacjonarne = new ZamowienieStacjonarne();
            zamowienieStacjonarne.przetwarzajZamowienie(false);
        }
    }
}