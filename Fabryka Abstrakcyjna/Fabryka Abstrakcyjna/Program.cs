using System;
using System.Text;


interface ILitery
{
    public string ShowAlfa();
}

interface ICyfry
{
    public string ShowNum();
}

class AlfabetFactory
{
    private SystemFactory systemFactory;
    public ILitery letters;
    public ICyfry numbers;

    public AlfabetFactory(SystemFactory systemFactory)
    {
        this.systemFactory = systemFactory;
    }

    public void Generate()
    {
        letters = systemFactory.CreateAlfa();
        numbers = systemFactory.CreateNum();
    }
}

abstract class SystemFactory
{
    public abstract ILitery CreateAlfa();

    public abstract ICyfry CreateNum();
}

class LacinkaFactory : SystemFactory
{
    public override ILitery CreateAlfa()
    {
        return new LacinkaLetters();
    }

    public override ICyfry CreateNum()
    {
        return new LacinkaNumbers();
    }
}

class CyrylicaFactory : SystemFactory
{
    public override ILitery CreateAlfa()
    {
        return new CyrylicaLetters();
    }

    public override ICyfry CreateNum()
    {
        return new CyrylicaNumbers();
    }
}

class GrekaFactory : SystemFactory
{
    public override ILitery CreateAlfa()
    {
        return new GrekaLetters();
    }

    public override ICyfry CreateNum()
    {
        return new GrekaNumbers();
    }
}

class LacinkaLetters : ILitery
{
    string letters;

    public LacinkaLetters()
    {
        letters = "abcde";
    }

    public string ShowAlfa()
    {
        return letters;
    }
}

class CyrylicaLetters : ILitery
{
    string letters;

    public CyrylicaLetters()
    {
        letters = "абвгд";
    }

    public string ShowAlfa()
    {
        return letters;
    }
}

class GrekaLetters : ILitery
{
    string letters;

    public GrekaLetters()
    {
        letters = "αβγδε";
    }

    public string ShowAlfa()
    {
        return letters;
    }
}

class LacinkaNumbers : ICyfry
{
    string numbers;

    public LacinkaNumbers()
    {
        numbers = "I II III";
    }  

    public string ShowNum()
    {
        return numbers;
    }
}

class CyrylicaNumbers : ICyfry
{
    string numbers;

    public CyrylicaNumbers()
    {
        numbers = "1 2 3";
    } 

    public string ShowNum()
    {
        return numbers;
    }
}

class GrekaNumbers : ICyfry
{
    string numbers;

    public GrekaNumbers()
    {
        numbers = "αʹ βʹ γʹ";
    }

    public string ShowNum()
    {
        return numbers;
    }
}

public class Application
{
    public static void Main(String[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        AlfabetFactory alfabet_lacinka = new AlfabetFactory(new LacinkaFactory());
        AlfabetFactory alfabet_cyrylica = new AlfabetFactory(new CyrylicaFactory());
        AlfabetFactory alfabet_greka = new AlfabetFactory(new GrekaFactory());

        AlfabetFactory cyfry_lacinka = new AlfabetFactory(new LacinkaFactory());
        AlfabetFactory cyfry_cyrylica = new AlfabetFactory(new CyrylicaFactory());
        AlfabetFactory cyfry_greka = new AlfabetFactory(new GrekaFactory());

        alfabet_lacinka.Generate();
        alfabet_cyrylica.Generate();
        alfabet_greka.Generate();

        cyfry_lacinka.Generate();
        cyfry_cyrylica.Generate();
        cyfry_greka.Generate();

        Console.WriteLine($"{alfabet_lacinka.letters.ShowAlfa()} {cyfry_lacinka.numbers.ShowNum()}");
        Console.WriteLine($"{alfabet_cyrylica.letters.ShowAlfa()} {cyfry_cyrylica.numbers.ShowNum()}");
        Console.WriteLine($"{alfabet_greka.letters.ShowAlfa()} {cyfry_greka.numbers.ShowNum()}");
    }
}