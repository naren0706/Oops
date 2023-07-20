using Newtonsoft.Json;
using OOPs.DataInventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPs.Stocks
{
    internal class StockOperation
    {
        public void ReadInventoryJson(string filePath)
        {
            var json = File.ReadAllText(filePath);
            List<Stock> list = JsonConvert.DeserializeObject<List<Stock>>(json);
            foreach (var data in list)
            {
                Console.WriteLine(data.StockName + " " + data.NoOfStock + " " + data.SharePrice);
            }
        }
    }
}
