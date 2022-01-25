using System;
using System.Text;

public interface Lancuch
{
    public void ustawNastepne(Lancuch c);
    public void przetwarzaj(Powiadomienia powiadomienia);
}

public class Powiadomienia
{

    private int number;

    public Powiadomienia(int number)
    {
        this.number = number;
    }

    public int pobierzLiczbe()
    {
        return number;
    }

}

public class BrakLancuch : Lancuch
{

    private Lancuch nastepneWLancuchu;

    public void ustawNastepne(Lancuch c)
    {
        nastepneWLancuchu = c;
    }

    public void przetwarzaj(Powiadomienia powiadomienia)
    {
        if (powiadomienia.pobierzLiczbe() <= 0)
        {
            Console.WriteLine("Brak powiadomień");
        }
        else
        {
            nastepneWLancuchu.przetwarzaj(powiadomienia);
        }
    }
}
public class DuzoLancuch : Lancuch
{

    private Lancuch nastepneWLancuchu;

    public void ustawNastepne(Lancuch c)
    {
        nastepneWLancuchu = c;
    }

    public void przetwarzaj(Powiadomienia powiadomienia)
    {
        if (powiadomienia.pobierzLiczbe() > 5)
        {
            Console.WriteLine($"Dużo powiadomień: {powiadomienia.pobierzLiczbe()}");
        }
        else
        {
            nastepneWLancuchu.przetwarzaj(powiadomienia);
        }
    }
}
public class MaloLancuch : Lancuch
{

    private Lancuch nastepneWLancuchu;

    public void ustawNastepne(Lancuch c)
    {
        nastepneWLancuchu = c;
    }

    public void przetwarzaj(Powiadomienia powiadomienia)
    {
        if (powiadomienia.pobierzLiczbe() <= 5)
        {
            Console.WriteLine($"Mało powiadomień: {powiadomienia.pobierzLiczbe()}");
        }
        else
        {
            nastepneWLancuchu.przetwarzaj(powiadomienia);
        }
    }
}


class Program
{
    static void Main(String[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Lancuch l1 = new BrakLancuch();
        Lancuch l2 = new MaloLancuch();
        Lancuch l3 = new DuzoLancuch();

        l1.ustawNastepne(l2);
        l2.ustawNastepne(l3);

        int i = 0;
        l1.przetwarzaj(new Powiadomienia(i));
        i++;
        l1.przetwarzaj(new Powiadomienia(i));
        i = 12;
        l1.przetwarzaj(new Powiadomienia(i));
        i = 3;
        l1.przetwarzaj(new Powiadomienia(i));
        i = 0;
        l1.przetwarzaj(new Powiadomienia(i));
    }
}