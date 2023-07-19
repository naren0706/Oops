using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OOPs.DataInventoryManagement
{
    internal class InventoryDetailsOperation
    {
        public void ReadInventoryJson(string filePath)
        {
            var json = File.ReadAllText(filePath);
            List<InventoryDetails> list = JsonConvert.DeserializeObject<List<InventoryDetails>>(json);
            foreach (var data in list)
            {
                Console.WriteLine(data.Name+" "+data.Weight+" "+data.PricePerKg);
            }
        }
    }
}
