using Newtonsoft.Json;
using OOPs.DataInventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OOPs.Stocks
{
    internal class StockOperation
    {
        public static List<Stock> list { get; set; }
        public void ReadInventoryJson(string filePath)
        {
            var json = File.ReadAllText(filePath);
            list = JsonConvert.DeserializeObject<List<Stock>>(json);
            foreach (var data in list)
            {
                Console.WriteLine(data.StockName + " " + data.NoOfShares + " " + data.SharePrice);
            }
        }
        public static void UpdateToJsonFile(string filePath)
        {
            var json = JsonConvert.SerializeObject(list);
            File.WriteAllText(filePath, json);
        }
    }
}
