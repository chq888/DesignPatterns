using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace DesignPatterns.Pattern.GangOfFour.Structural
{
    public class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
    }

    public interface ICustomerApi
    {
        Customer Get(string id);
    }

    public class ServiceApi : ICustomerApi
    {
        public Customer Get(string id)
        {
            return new Customer();
        }

    }

    public class ServiceProxy : ICustomerApi
    {
        public Customer Get(string id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("url").Result;
            string jsonData = response.Content.ReadAsStringAsync().Result;
            Customer data = JsonConvert.DeserializeObject<Customer>(jsonData);

            return data;
        }
    }
}