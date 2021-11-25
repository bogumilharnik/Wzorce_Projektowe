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