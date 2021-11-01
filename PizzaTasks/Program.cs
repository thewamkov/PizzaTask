using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PizzaTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var ordersInfo = GetOrdersData();

            var top20Toppings = GetTop20Toppings(ordersInfo);

            foreach (KeyValuePair<string, int> item in top20Toppings)
            {
                Console.WriteLine("{0} Occurrences = {1}", item.Key, item.Value);
            }

            
        }



        public static Dictionary<string, int> GetTop20Toppings(List<Pizza> orders)
        {
            Dictionary<string, int> result = orders.SelectMany(obj => obj.Toppings)
                                .GroupBy(x => x)
                                .OrderByDescending(g => g.Count())
                                .Take(20)
                                .ToDictionary(d => d.Key, d => d.Count());

            return result;

        }


        public static List<Pizza> GetOrdersData()
        {
            try
            {
                var jsonOrders = File.ReadAllText("Test task #1 - Pizzas.json");
                return JsonConvert.DeserializeObject<List<Pizza>>(jsonOrders);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred {0}", ex.Message);
                throw;
            }

            return new List<Pizza>();

        }
    }
}
