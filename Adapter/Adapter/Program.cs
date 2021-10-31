using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Adapter
{
    public class UsersApi
    {
        public async Task<string> GetUsersXmlAsync()
        {
            var apiResponse = "<?xml version= \"1.0\" encoding= \"UTF-8\"?><users><user name=\"John\" surname=\"Doe\"/><user name=\"John\" surname=\"Wayne\"/><user name=\"John\" surname=\"Rambo\"/></users>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(apiResponse);

            return await Task.FromResult(doc.InnerXml);
        }
    }

    public class UsersAccounting
    {
        public string GetUsersCsv()
        {
            return File.ReadAllText("users.csv");
        }
    }

    public interface IUserRepository
    {
        List<string> GetUserNames();
    }

    public class UsersRepositoryAdapter : IUserRepository
    {
        private UsersApi _adaptee = null;

        public UsersRepositoryAdapter(UsersApi adaptee)
        {
            _adaptee = adaptee;
        }

        public List<string> GetUserNames()
        {
            string incompatibleApiResponse = this._adaptee
              .GetUsersXmlAsync()
              .GetAwaiter()
              .GetResult();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(incompatibleApiResponse);

            var rootEl = doc.LastChild;

            List<string> userNames = new List<string>();

            if (rootEl.HasChildNodes)
            {
                foreach (XmlNode user in rootEl.ChildNodes)
                {
                    userNames.Add(user.Attributes["name"].InnerText + " " + user.Attributes["surname"].InnerText);
                }
            }
            return userNames;
        }
    }

    public class UsersRepositoryAccountingAdapter : IUserRepository
    {
        private UsersAccounting _adaptee = null;

        public UsersRepositoryAccountingAdapter(UsersAccounting adaptee)
        {
            _adaptee = adaptee;
        }

        public List<string> GetUserNames()
        {
            List<string> userNames = new List<string>();
            string csvData = _adaptee.GetUsersCsv();
            string[] lines = csvData.Split("\n");
            foreach (string line in lines)
            {
                string[] names = line.Split(",");
                userNames.Add(names[0] + " " + names[1]);
            }
            return userNames;
        }
    }

    public class Program
    {
        static void PrintNames(IUserRepository adapter)
        {
            List<string> users = adapter.GetUserNames();
            int index = 0;

            foreach (var userName in users)
            {
                Console.WriteLine((++index).ToString() + ". " + userName);
            }
        }
        static void Main(string[] args)
        {
            IUserRepository adapter = new UsersRepositoryAccountingAdapter(new UsersAccounting());

            PrintNames(adapter);
        }
    }
}