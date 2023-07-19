using Newtonsoft.Json;
using OOPs.DataInventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace OOPs.InventoryManagement
{
    internal class InventoryManagementOperation
    {
        InventoryManagementDetails list;        
        public void ReadInventoryJson(string filePath)
        {
            var json = File.ReadAllText(filePath);
            list = JsonConvert.DeserializeObject<InventoryManagementDetails>(json);
            Console.WriteLine("riceList");
            DisplayList(list.RiceList);
            Console.WriteLine("WheatList");
            DisplayList(list.WheatList);
            Console.WriteLine("PulsesList");
            DisplayList(list.Pulseslist);
        }
        public void AddInventoryManagement(string objectName)
        {
            if (objectName.ToLower().Equals("rice"))
            {
                Console.WriteLine("Enter Name ,weight and price per Kg");
                InventoryDetails data = new InventoryDetails()
                {
                    Name = Console.ReadLine(),
                    Weight = Convert.ToInt32(Console.ReadLine()),
                    PricePerKg = Convert.ToInt32(Console.ReadLine()),
                };
                list.RiceList.Add(data);
            }
            if (objectName.ToLower().Equals("wheat"))
            {
                Console.WriteLine("Enter Name,weight and price per Kg");
                InventoryDetails inventoryDetails = new InventoryDetails()
                {
                    Name = Console.ReadLine(),
                    Weight = Convert.ToInt32(Console.ReadLine()),
                    PricePerKg = Convert.ToInt32(Console.ReadLine()),
                };
                list.WheatList.Add(inventoryDetails);

            }
            if (objectName.ToLower().Equals("pulse"))
            {
                Console.WriteLine("Enter Name,weight and price per Kg");
                InventoryDetails inventoryDetails = new InventoryDetails()
                {
                    Name = Console.ReadLine(),
                    Weight = Convert.ToInt32(Console.ReadLine()),
                    PricePerKg = Convert.ToInt32(Console.ReadLine()),
                };
                list.Pulseslist.Add(inventoryDetails);
            }
        }
        public void AddToJsonFile(string filePath)
        {
            var json = JsonConvert.SerializeObject(list);
            File.WriteAllText(filePath, json);
        }
        

        public void DisplayList(List<InventoryDetails> list)
        {
            foreach (var data in list)
            {
                Console.WriteLine(data.Name + " " + data.Weight + " " + data.PricePerKg);
            }
        }
    }
}
