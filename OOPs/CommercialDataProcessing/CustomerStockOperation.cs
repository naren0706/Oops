using Newtonsoft.Json;
using OOPs.CommercialDataProcessing;
using OOPs.Stocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace OOPs.CommercialDataProcessing
{
    public class CustomerStockOperation
    {
        List<Stock> companyStock = new List<Stock>();
        List<CustomerStock> customerStock = new List<CustomerStock>();
        int amount;
        public CustomerStockOperation(int amount)
        {
            this.amount = amount;
        }
        public void ReadCompanyStock(string filePath)
        {
            var json = File.ReadAllText(filePath);
            companyStock = JsonConvert.DeserializeObject<List<Stock>>(json);
            Display(companyStock);
        }
        internal void Display()
        {
            Console.WriteLine("Company Stock: ");
            foreach (var data in companyStock)
            {
                Console.WriteLine("Stock Name:" + data.StockName + " " + "No.of Shares:" + data.NoOfShares + " " + "Share Price:" + data.SharePrice);
            }
            Console.WriteLine("Customer Stock: ");
            foreach (var data in customerStock)
            {
                Console.WriteLine("Stock Name:" + data.StockSymbol + " " + "No.of Shares:" + data.NoOfShares + " " + "Share Price:" + data.SharePrice);
            }
        }
        private void Display(List<Stock>? companyStock)
        {
            Console.WriteLine("Company Stock: ");
            foreach (var data in companyStock)
            {
                Console.WriteLine("Stock Name:" + data.StockName + " " + "No.of Shares:" + data.NoOfShares + " " + "Share Price:" + data.SharePrice);
            }
        }

        public void ReadCustomerStock(string filePath)
        {
            var json = File.ReadAllText(filePath);
            customerStock = JsonConvert.DeserializeObject<List<CustomerStock>>(json);
            Display(customerStock);
        }
        
        private void Display(List<CustomerStock>? customerStock)
        {
            Console.WriteLine("Customer Stock: ");
            foreach (var data in customerStock)
            {
                Console.WriteLine("Stock Name:" + data.StockSymbol + " " + "No.of Shares:" + data.NoOfShares + " " + "Share Price:" + data.SharePrice);
            }
        }

        public void CustomerBuyStockFromCompany()
        {
            Console.WriteLine("Enter the stock name to buy");
            string stockName = Console.ReadLine();
            Console.WriteLine("Enter the No.of Shares");
            int shares = Convert.ToInt32(Console.ReadLine());
            Stock buyStock = new Stock();
            foreach (var data in companyStock)
            {
                if (data.StockName.Equals(stockName))
                {
                    buyStock = data;
                    if (data.NoOfShares >= shares && data.NoOfShares * shares >= amount)
                    {
                        data.NoOfShares -= shares;
                        amount -= data.NoOfShares * shares;
                    }
                    else
                    {
                        Console.WriteLine("Stock limit exceeded");
                    }
                }
            }
            if (buyStock == null)
                Console.WriteLine("Stock Name doesnt exists");
            else
            {
                CustomerStock buyCustomerStock = new CustomerStock();
                foreach (var stock in customerStock)
                {
                    if (stock.StockSymbol.Equals(stockName))
                    {
                        buyCustomerStock = stock;
                        stock.NoOfShares += shares;
                    }
                    else
                    {
                        buyCustomerStock.StockSymbol = stockName;
                        buyCustomerStock.NoOfShares = shares;
                        buyCustomerStock.SharePrice = buyStock.SharePrice;
                    }
                }
                customerStock.Add(buyCustomerStock);
            }
        }
        public void CustomerSellStockToCompany()
        {
            Console.WriteLine("Enter the stock name to sell");
            string stockName = Console.ReadLine();
            Console.WriteLine("Enter the No.of Shares");
            int shares = Convert.ToInt32(Console.ReadLine());
            CustomerStock sellStock = new CustomerStock();
            foreach (var data in customerStock)
            {
                if(data.StockSymbol.Equals(stockName) && data.NoOfShares<=shares)
                {
                    amount += shares * data.SharePrice;
                    data.NoOfShares -= shares;
                    sellStock = data;
                }
            }
            if (sellStock == null)
            {
                Console.WriteLine("Stock dosen't exist");
            }
            {
                foreach (var data in companyStock)
                {
                    if (data.StockName.Equals(stockName))
                    {
                        data.NoOfShares += shares;
                    }
                }
            }
        }
        public void WriteToCompanyFile(string filePath)
        {
            var json = JsonConvert.SerializeObject(companyStock);
            File.WriteAllText(filePath, json);
        }
        public void WriteToCustomerFile(string filePath)
        {
            var json = JsonConvert.SerializeObject(customerStock);
            File.WriteAllText(filePath, json);
        }

        
    }
}