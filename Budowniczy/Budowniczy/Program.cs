using System;
using System.Text;

public class Computer
{
    private string _type;
    public string MotherBoard { get; set; }
    public string Processor { get; set; }
    public string Disc { get; set; }
    public string Screen { get; set; }
    public double Price { get; set; }

    public Computer(string computerType)
    {
        _type = computerType;
        Price = 0;
    }

    public void DisplayConfiguration()
    {
        Console.WriteLine("Typ: " + _type);

        Console.WriteLine("Płyta główna: " + MotherBoard);

        Console.WriteLine("Procesor: " + Processor);

        Console.WriteLine("Dysk: " + Disc);

        Console.WriteLine("Monitor: " + Screen);

        Console.WriteLine("Cena: " + Price.ToString("F2") + " zł");

        Console.WriteLine();
    }
}

public class ComputerShop
{

    public void ConstructComputer(ComputerBuilder computerBuilder)
    {
        computerBuilder.BuildMotherBoard();
        computerBuilder.BuildProcessor();
        computerBuilder.BuildDisc();
        computerBuilder.BuildScreen();
    }

}

public abstract class ComputerBuilder
{
    public Computer Computer { get; set; }
    public abstract void BuildMotherBoard();
    public abstract void BuildProcessor();
    public abstract void BuildDisc();
    public abstract void BuildScreen();
}

public class OfficeComputerBuilder : ComputerBuilder
{
    public OfficeComputerBuilder()
    {
        Computer = new Computer("biurowy");
    }

    public override void BuildMotherBoard()
    {
        Computer.MotherBoard = "Asus Prime A320M-E";
        Computer.Price += 259.90;
    }
    public override void BuildProcessor()
    {
        Computer.Processor = "AMD Ryzen 5 2600";
        Computer.Price += 589.00;
    }
    public override void BuildDisc()
    {
        Computer.Disc = "Goodram CX400 250 GB SATA3";
        Computer.Price += 144.99;
    }
    public override void BuildScreen()
    {
        Computer.Screen = "BenQ GW2270H (1920x1080)";
        Computer.Price += 1367.89;
    }
}

public class GamerComputerBuilder : ComputerBuilder
{
    public GamerComputerBuilder()
    {
        Computer = new Computer("gamingowy");
    }

    public override void BuildMotherBoard()
    {
        Computer.MotherBoard = "Gigabyte X570 Aorus Elite";
        Computer.Price += 895.60;
    }

    public override void BuildProcessor()
    {
        Computer.Processor = "Intel i7 9700K";
        Computer.Price += 1829.00;
    }

    public override void BuildDisc()
    {
        Computer.Disc = "Samsung 970 EVO Plus 2TB M.2";
        Computer.Price += 2028.45;
    }

    public override void BuildScreen()
    {
        Computer.Screen = "HP Z4W65A4";
        Computer.Price += 9680.80;
    }
}

public class ProComputerBuilder : ComputerBuilder
{
    public ProComputerBuilder()
    {
        Computer = new Computer("profesjonalisci");
    }

    public override void BuildMotherBoard()
    {
        Computer.MotherBoard = "Supermicro MBD X11DPH";
        Computer.Price += 2755.30;
    }

    public override void BuildProcessor()
    {
        Computer.Processor = "Intel Xeon Gold 5120";
        Computer.Price += 7999.00;
    }

    public override void BuildDisc()
    {
        Computer.Disc = "Seagate Skyhawk 14TB 3.5";
        Computer.Price += 2101.75;
    }

    public override void BuildScreen()
    {
        Computer.Screen = "Eizo CG319X";
        Computer.Price += 33605.05;
    }
}
public class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        ComputerShop computerShop = new ComputerShop();

        ComputerBuilder computerBuilder = new OfficeComputerBuilder();

        computerShop.ConstructComputer(computerBuilder);

        computerBuilder.Computer.DisplayConfiguration();

        computerBuilder = new GamerComputerBuilder();

        computerShop.ConstructComputer(computerBuilder);

        computerBuilder.Computer.DisplayConfiguration();

        computerBuilder = new ProComputerBuilder();

        computerShop.ConstructComputer(computerBuilder);

        computerBuilder.Computer.DisplayConfiguration();
    }
}