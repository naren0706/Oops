using OOPs.CommercialDataProcessing;
using OOPs.DataInventoryManagement;
using OOPs.InventoryManagement;
using OOPs.Stocks;
using System;

namespace OOPs
{
    class Program
    {
        static string filePath1 = @"E:\BridgeGateProblems\Oops\OOPs\DataInventoryManagement\InventoryData.json";
        static string filePath2 = @"E:\BridgeGateProblems\Oops\OOPs\InventoryManagement\InventoryManagementData.json";
        static string stockFilePath = @"E:\BridgeGateProblems\Oops\OOPs\Stocks\stock.json";
        public static void Main(String[] args)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1.show inventory files\n2.inventory management operation\n3.Stocks\n4.UserStock");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice) {
                    case 1:
                        InventoryDetailsOperation operation = new InventoryDetailsOperation();
                        operation.ReadInventoryJson(filePath1);
                        break;
                    case 2:
                        bool flag2 = true;
                        InventoryManagementOperation inventoryManagementOperation = new InventoryManagementOperation();
                        while (flag2)
                        {
                            Console.WriteLine("1.read files\n2.add values\n3.delete Value\n4.edit value \n5.update to json");
                            int choice2 = Convert.ToInt32(Console.ReadLine());

                            switch (choice2)
                            {
                                case 1:
                                    inventoryManagementOperation.ReadInventoryJson(filePath2);
                                    break;
                                case 2:
                                    Console.WriteLine("Enter the crop name ");
                                    string cropName = Console.ReadLine();
                                    inventoryManagementOperation.AddInventoryManagement(cropName);
                                    break;
                                case 3:
                                    Console.WriteLine("Enter the crop name ");
                                    cropName = Console.ReadLine();
                                    Console.WriteLine("Enter the crop name ");
                                    string inventoryName = Console.ReadLine();
                                    inventoryManagementOperation.DeleteValue(cropName,inventoryName);
                                    break;
                                case 4:
                                    Console.WriteLine("Enter the crop name ");
                                    cropName = Console.ReadLine();
                                    Console.WriteLine("Enter the crop name ");
                                    inventoryName = Console.ReadLine();
                                    inventoryManagementOperation.EditValue(cropName,inventoryName);
                                    break;
                                case 5:
                                    inventoryManagementOperation.AddToJsonFile(filePath2);
                                    break;
                                default:
                                    flag2 = false;
                                    break;

                            }
                        }
                        break;
                    case 3:
                        StockOperation stockOperation = new StockOperation();
                        stockOperation.ReadInventoryJson(stockFilePath);
                        break;
                    
                    case 4:
                        Console.WriteLine("Enter the  amount");
                        int amount = Convert.ToInt32(Console.ReadLine());
                        string companyStockFilePath = @"E:\\BridgeGateProblems\\Oops\\OOPs\\Stocks\\stock.json";
                        string customerStockFilePath = @"E:\BridgeGateProblems\Oops\OOPs\CommercialDataProcessing\CustomerStock.json";
                        CustomerStockOperation customerStockOperation = new CustomerStockOperation(amount);
                        customerStockOperation.ReadCompanyStock(companyStockFilePath);
                        customerStockOperation.ReadCustomerStock(customerStockFilePath);
                        bool flag4 = true;
                        while (flag4)
                        {
                            Console.WriteLine("1.buy\n2.sell\n2.write to json\n3.display");
                            switch (Convert.ToInt32(Console.ReadLine()))
                            {
                                case 1:
                                    customerStockOperation.CustomerBuyStockFromCompany();
                                    break;
                                case 2:
                                    customerStockOperation.CustomerSellStockToCompany();
                                    break;
                                case 3:
                                    customerStockOperation.WriteToCustomerFile(customerStockFilePath);
                                    customerStockOperation.WriteToCompanyFile(companyStockFilePath);
                                    break;
                                case 4:
                                    customerStockOperation.Display();
                                    break;
                                default:
                                    flag4 = false;              
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