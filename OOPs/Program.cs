using OOPs.DataInventoryManagement;
using OOPs.InventoryManagement;
using System;

namespace OOPs
{
    class Program
    {
        static string filePath1 = @"E:\BridgeGateProblems\Oops\OOPs\DataInventoryManagement\InventoryData.json";
        static string filePath2 = @"E:\BridgeGateProblems\Oops\OOPs\InventoryManagement\InventoryManagementData.json";
        public static void Main(String[] args)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1.show inventory files\n2.inventory management operation");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice) {
                    case 1:
                        InventoryDetailsOperation operation = new InventoryDetailsOperation();
                        operation.ReadInventoryJson(filePath1);
                        break;
                    case 2:
                        bool flag2 = true;
                        while (flag2)
                        {
                            Console.WriteLine("1.Display files\n2.add values");
                            int choice2 = Convert.ToInt32(Console.ReadLine());
                            InventoryManagementOperation inventoryManagementOperation = new InventoryManagementOperation();

                            switch (choice2)
                            {
                                case 1:
                                    inventoryManagementOperation.ReadInventoryJson(filePath2);
                                    break;
                                case 2:
                                    inventoryManagementOperation.ReadInventoryJson(filePath2);
                                    Console.WriteLine("Enter the crop name ");
                                    string cropName = Console.ReadLine();
                                    inventoryManagementOperation.AddInventoryManagement(cropName);
                                    inventoryManagementOperation.AddToJsonFile(filePath2);
                                    break;
                                default:
                                    flag2 = false;
                                    break;

                            }
                        }
                        break;
                    default:
                        flag = false;
                        break;
            }
            }
        }
    }
}