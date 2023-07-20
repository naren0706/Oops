using Newtonsoft.Json;
using OOPs.DataInventoryManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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
        public void EditValue(string objectName, string inventoryName)
        {
            InventoryDetails details = new InventoryDetails();
            if (objectName.ToLower().Equals("rice"))
            {
                foreach (var data in list.RiceList)
                {
                    if (data.Name.Equals(inventoryName))
                        details = data;
                }
                if (details != null)
                {
                    Console.WriteLine("what do you want to edit 1.Name 2.Weight 3.Price Per Kg");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter Name");
                            details.Name = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter Weight");
                            details.Weight = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 3:
                            Console.WriteLine("Enter Price per kg");
                            details.PricePerKg = Convert.ToInt32(Console.ReadLine());
                            break;
                    }

                }
            }
            if (objectName.ToLower().Equals("wheat"))
            {
                foreach (var data in list.WheatList)
                {
                    if (data.Name.Equals(inventoryName))
                        details = data;
                }
                if (details != null)
                {
                    Console.WriteLine("what do you want to edit 1.Name 2.Weight 3.Price Per Kg");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter Name");
                            details.Name = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter Weight");
                            details.Weight = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 3:
                            Console.WriteLine("Enter Price per kg");
                            details.PricePerKg = Convert.ToInt32(Console.ReadLine());
                            break;
                    }

                }
            }
            if (objectName.ToLower().Equals("pulses"))
            {
                foreach (var data in list.Pulseslist)
                {
                    if (data.Name.Equals(inventoryName))
                        details = data;
                }
                if (details != null)
                {
                    Console.WriteLine("what do you want to edit 1.Name 2.Weight 3.Price Per Kg");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter Name");
                            details.Name = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter Weight");
                            details.Weight = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 3:
                            Console.WriteLine("Enter Price per kg");
                            details.PricePerKg = Convert.ToInt32(Console.ReadLine());
                            break;
                    }

                }
            }
        }

            public void DeleteValue(string objectName ,string inventoryName)
        {
            InventoryDetails details = new InventoryDetails();
            if (objectName.ToLower().Equals("rice"))
            {
                foreach (var data in list.RiceList)
                {
                    if (data.Name.Equals(inventoryName))
                        details = data;
                }
                if (details != null)
                {
                    list.RiceList.Remove(details);
                }
            }
            if (objectName.ToLower().Equals("wheat"))
            {
                foreach (var data in list.WheatList)
                {
                    if (data.Name.Equals(inventoryName))
                        details = data;
                }
                if (details != null)
                {
                    list.WheatList.Remove(details);
                }
            }
            if (objectName.ToLower().Equals("pulsus"))
            {
                foreach (var data in list.Pulseslist)
                {
                    if (data.Name.Equals(inventoryName))
                        details = data;
                }
                if (details != null)
                {
                    list.Pulseslist.Remove(details);
                }
            }
        }
        public void AddInventoryManagement(string objectName)
        {
            Console.WriteLine("Enter Name ,weight and price per Kg");
            InventoryDetails data = new InventoryDetails()
            {
                Name = Console.ReadLine(),
                Weight = Convert.ToInt32(Console.ReadLine()),
                PricePerKg = Convert.ToInt32(Console.ReadLine()),
            };
            if (objectName.ToLower().Equals("rice"))
            {
                list.RiceList.Add(data);
            }
            if (objectName.ToLower().Equals("wheat"))
            {
                list.WheatList.Add(data);
            }
            if (objectName.ToLower().Equals("pulsus"))
            {
                list.Pulseslist.Add(data);
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
