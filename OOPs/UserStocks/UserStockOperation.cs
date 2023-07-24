using Newtonsoft.Json;
using OOPs.DataInventoryManagement;
using OOPs.Stocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Transactions;

namespace OOPs.UserStocks
{
    internal class UserStockOperation
    {
        List<UserStock> transactions = new List<UserStock>();
        
        public void ReadJsonFile(string filePath)
        {
            var json = File.ReadAllText(filePath);
            transactions = JsonConvert.DeserializeObject<List<UserStock>>(json);
        }
        public void DisplayJsonFile(string filePath)
        {
            foreach (var item in transactions)
            {
                Console.WriteLine(item.StockName+" | "+item.DateAndTime+" | "+item.Balance+" | "+item.NumberOfStockOwned+" | "+item.OrderType);
            }
        }
        public void AddToJsonFile(string filePath)
        {
            var json = JsonConvert.SerializeObject(transactions);
            File.WriteAllText(filePath, json);
        }
        public void AddStocks(string objectName)
        {
            Console.WriteLine("Enter StockName ,Date and time , balance , number of stock owned ordertype ");
            UserStock data = new UserStock()
            {
                StockName = Console.ReadLine(),
                DateAndTime = Console.ReadLine(),
                Balance = Convert.ToInt32(Console.ReadLine()),
                NumberOfStockOwned = Convert.ToInt32(Console.ReadLine()),
                OrderType = Console.ReadLine(),
            };
            transactions.Add(data);            
        }

        public void BuyStocks(string filePath, string stockName, int quantity)
        {
            string filePath2 = @"E:\BridgeGateProblems\Oops\OOPs\Stocks\stock.json";
            ReadJsonFile(filePath);
            UserStock newTransaction = new UserStock();
            UserStock lastTranaction = transactions.Last();
            Stock currentStock = new Stock();
            List<Stock> stockList = StockOperation.list;
            foreach (var stock in stockList)
            {
                if (stock.StockName.ToLower().Equals(stockName.ToLower()))
                {
                    currentStock = stock;
                    if (currentStock.NoOfShares > quantity)
                    {
                        DateTime currentDateTime = DateTime.Now;
                        newTransaction.DateAndTime = currentDateTime + "";
                        newTransaction.NumberOfStockOwned = quantity+lastTranaction.NumberOfStockOwned;
                        newTransaction.StockName = stockName;
                        newTransaction.OrderType = "Buy";
                        newTransaction.Balance = lastTranaction.Balance - (currentStock.SharePrice * quantity);
                        currentStock.NoOfShares -= quantity;
                        transactions.Add(newTransaction);
                        AddToJsonFile(filePath);
                        StockOperation.UpdateToJsonFile(filePath2);
                        Console.WriteLine("Transaction has been added successfully");
                    }
                }
            }
        }
        public void SellStocks(string filePath, string stockName, int quantity)
        {
            string filePath2 = @"E:\BridgeGateProblems\Oops\OOPs\Stocks\stock.json";
            ReadJsonFile(filePath);
            UserStock newTransaction = new UserStock();
            UserStock lastTranaction = transactions.Last();
            Stock currentStock = new Stock();
            List<Stock> stockList = StockOperation.list;
            foreach (var stock in stockList)
            {
                if (stock.StockName.ToLower().Equals(stockName.ToLower()))
                {
                    currentStock = stock;
                    if (lastTranaction.NumberOfStockOwned>0 && lastTranaction.Balance>currentStock.SharePrice*quantity)
                    {
                        DateTime currentDateTime = DateTime.Now;
                        newTransaction.DateAndTime = currentDateTime + "";
                        newTransaction.NumberOfStockOwned = lastTranaction.NumberOfStockOwned-quantity;
                        newTransaction.StockName = stockName;
                        newTransaction.OrderType = "Sell";
                        newTransaction.Balance = lastTranaction.Balance + (currentStock.SharePrice * quantity);
                        currentStock.NoOfShares += quantity;
                        transactions.Add(newTransaction);
                        AddToJsonFile(filePath);
                        StockOperation.UpdateToJsonFile(filePath2);
                        Console.WriteLine("Transaction has been added successfully");

                    }
                }
            }
        }
    }
}
