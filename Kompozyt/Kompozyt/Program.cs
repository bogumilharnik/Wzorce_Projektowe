using System;
using System.Collections.Generic;

public interface Kompozyt
{
    string Nazwa { get; set; }
    void DodajElement(Kompozyt element);
    void UsunElement(Kompozyt element);
    void Renderuj();
}

public class Lisc : Kompozyt
{
    public string Nazwa { get; set; }

    public void DodajElement(Kompozyt element)
    {
        // Liście nie mogą zawierać innych elementów, więc ta metoda jest pusta.
    }

    public void UsunElement(Kompozyt element)
    {
        // Liście nie mogą zawierać innych elementów, więc ta metoda jest pusta.
    }

    public void Renderuj()
    {
        Console.WriteLine($"Liść {Nazwa} renderowanie...");
    }
}

public class Wezel : Kompozyt
{
    private List<Kompozyt> Lista = new List<Kompozyt>();

    public string Nazwa { get; set; }

    public void DodajElement(Kompozyt element)
    {
        Lista.Add(element);
    }

    public void UsunElement(Kompozyt element)
    {
        Lista.Remove(element);
    }

    public void Renderuj()
    {
        Console.WriteLine($"{Nazwa} rozpoczęcie renderowania");

        foreach (var item in Lista)
        {
            item.Renderuj();
        }

        Console.WriteLine($"{Nazwa} zakończenie renderowania");
    }
}

class MainClass
{
    public static void Main(string[] args)
    {
        // Definicje struktury
        Wezel korzen = new Wezel { Nazwa = "Korzeń" };
        korzen.DodajElement(new Lisc { Nazwa = "1.1" });
            
        Wezel wezel2 = new Wezel { Nazwa = "Węzeł 2" };
        wezel2.DodajElement(new Lisc { Nazwa = "2.1" });
        wezel2.DodajElement(new Lisc { Nazwa = "2.2" });
        wezel2.DodajElement(new Lisc { Nazwa = "2.3" });

        Wezel wezel3 = new Wezel { Nazwa = "Węzeł 3" };
        wezel3.DodajElement(new Lisc { Nazwa = "3.1" });
        wezel3.DodajElement(new Lisc { Nazwa = "3.2" });

        Wezel wezel3_3 = new Wezel { Nazwa = "Węzeł 3.3" };
        wezel3_3.DodajElement(new Lisc { Nazwa = "3.3.1" });

        wezel3.DodajElement(wezel3_3);

        korzen.DodajElement(wezel2);
        korzen.DodajElement(wezel3);

        // Renderowanie
        korzen.Renderuj();
    }
}
