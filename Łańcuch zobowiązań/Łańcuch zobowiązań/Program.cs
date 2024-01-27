

using System;
using System.Collections.Generic;

namespace LancuchZobowiazan
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        void Handle(string request);
    }

    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return _nextHandler;
        }

        public virtual void Handle(string request)
        {
            if (_nextHandler != null)
            {
                _nextHandler.Handle(request);
            }
            else
            {
                Console.WriteLine($"Nikt nie chce tego zjeść: {request}");
            }
        }
    }

    public class MonkeyHandler : AbstractHandler
    {
        public override void Handle(string request)
        {
            if (request == "banan")
            {
                Console.WriteLine("Małpa zjada banan.");
            }
            else
            {
                base.Handle(request);
            }
        }
    }

    public class DogHandler : AbstractHandler
    {
        public override void Handle(string request)
        {
            if (request == "szynka" || request == "plasterek szynki")
            {
                Console.WriteLine($"Pies zjada {request}.");
            }
            else if (request == "mięso")
            {
                Console.WriteLine("Pies zjada mięso.");
            }
            else
            {
                base.Handle(request);
            }
        }
    }

    public class SquirrelHandler : AbstractHandler
    {
        public override void Handle(string request)
        {
            if (request == "orzech")
            {
                Console.WriteLine("Wiewiórka zjada orzech.");
            }
            else
            {
                base.Handle(request);
            }
        }
    }

    public class CatHandler : AbstractHandler
    {
        public override void Handle(string request)
        {
            if (request == "mięso")
            {
                Console.WriteLine("Kot zjada mięso.");
            }
            else
            {
                base.Handle(request);
            }
        }
    }

    public class Client
    {
        public static void ClientCode(AbstractHandler handler)
        {
            foreach (var food in new List<string> { "orzech", "banan", "mięso", "plasterek szynki", "lody" })
            {
                Console.WriteLine($"Kto chce {food}?");
                handler.Handle(food);
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var monkey = new MonkeyHandler();
            var dog = new DogHandler();
            var squirrel = new SquirrelHandler();
            var cat = new CatHandler();

            monkey.SetNext(dog).SetNext(squirrel).SetNext(cat);

            Console.WriteLine("Łańcuch: Małpa > Pies > Wiewiórka > Kot");
            Client.ClientCode(monkey);
            Console.WriteLine();

            Console.WriteLine("Podzbiór łańcucha: Wiewiórka > Kot");
            squirrel.SetNext(cat);
            Client.ClientCode(squirrel);
        }
    }
}
