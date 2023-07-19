using OOPs.DataInventoryManagement;
using System;

namespace OOPs
{
    class Program
    {
        static string filePath = @"E:\BridgeGateProblems\Oops\OOPs\DataInventoryManagement\InventoryData.json";
        public static void Main(String[] args)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1.show inventory files");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice) {
                    case 1:
                        InventoryDetailsOperation operation = new InventoryDetailsOperation();
                        operation.ReadInventoryJson(filePath);
                        break;
                    default:
                        flag = false;
                        break;
            }
            }
        }
    }
}