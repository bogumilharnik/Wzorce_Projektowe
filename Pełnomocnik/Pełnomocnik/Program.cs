using System;
using System.Collections.Generic;

namespace Pelnomocnik{
  
    public class User{
      
        private bool HasAdminPrivilages;

        // konstruktor? jak jest tworzony obiekt?
        public User(bool hasAdminPrivilages){
          HasAdminPrivilages = hasAdminPrivilages;
        }
      
        public void MakeAdmin(){
          HasAdminPrivilages = true;
        }
      
        public bool IsAdmin(){
          return HasAdminPrivilages;
        }
      
    }
  
    public interface Information{
        public abstract void DisplayData();
        public abstract void DisplayRestrictedData();
    }

    public class Database : Information{
      
        private Dictionary<string, double> Map;

        public Database(){
          Map = new Dictionary<string, double>();
          
          Map.Add("Zyzio MacKwacz", 2500);
          Map.Add("Scooby Doo", 11.4);
          Map.Add("Adam Mackiewicz", 15607.95);
          Map.Add("Rick Morty", 429.18);
        }

      // wyświetlenie listy użytkowników
      public void DisplayData()
      {
        Console.WriteLine("Użytkownicy:");
        foreach (string key in Map.Keys)
        {
            Console.WriteLine(key);
        }
      }

      // wyświetlenie ujawniające zarobki
      public void DisplayRestrictedData()
      {
        foreach(var kvp in Map)
          Console.WriteLine($"{kvp.Key} zarabia {kvp.Value} zł miesięcznie");

      }

    }

    public class DatabaseGuard : Information{

        private Database DB;
        private User user;

        public DatabaseGuard(User u){
            DB = new Database();
            user = u;
        }

        public void DisplayData(){
            DB.DisplayData();
        }

        public void DisplayRestrictedData(){
            if (user.IsAdmin())
              DB.DisplayRestrictedData();
          else
            Console.WriteLine("Nie masz wystarczających uprawnień");
        }

    }

    class Program{
        static void Main(string[] args){
          
            var Zbyszek = new User(false);
            var db = new DatabaseGuard(Zbyszek);
          
            db.DisplayData();
          
            Console.WriteLine("---------------------------------------------------------");

            db.DisplayRestrictedData();
          
            Console.WriteLine("---------------------------------------------------------");

            Zbyszek.MakeAdmin();
            db.DisplayRestrictedData();
          
        }
    }
  
}



using System;
using System.Text;

namespace Pełnomocnik
{
    public interface IClient
    {
        string GetData();
    }

    public class RealClient : IClient
    {
        string Data { get; set; }

        public RealClient()
        {
            Console.WriteLine("RealClient: Initialized");
            Data = "WSEI data";
        }

        public string GetData()
        {
            return Data;
        }
    }

    public class ProxyClient : IClient
    {
        RealClient client = null;
        private string _pass = "dobrehaslo";
        private bool _authenticated;

        public ProxyClient(string password)
        {
            if (password == _pass)
            {
                Console.WriteLine("ProxyClient: Initialized");
                client = new RealClient();
                _authenticated = true;
            }
            else
            {
                _authenticated = false;
                Console.WriteLine("ProxyClient: Access denied\n");
            }
        }

        public string GetData()
        {
            if (_authenticated)
            {
                string data = client.GetData();
                return data;
            }
            throw new UnauthorizedAccessException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            ProxyClient proxy1 = new ProxyClient("zlehaslo");

            ProxyClient proxy2 = new ProxyClient("dobrehaslo");
            Console.WriteLine($"Data from Proxy Client = {proxy2.GetData()}");
        }
    }
}
