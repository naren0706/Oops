namespace OOPs.UserStocks
{
    internal class UserStocksMain
    {
        const string filePath = @"E:\BridgeGateProblems\Oops\OOPs\UserStocks\UserStock.json";
        internal static void Go()
        {
            bool flag3 = true;
            UserStockOperation userStockOperation = new UserStockOperation();
            while (flag3)
            {
                Console.WriteLine("1.Display Transaction\n2.Buy stocks\n3.Sell Stocks");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        userStockOperation.DisplayJsonFile(filePath);
                        break;
                    case 2:
                        Console.WriteLine("Enter StockName you wanted to buy");
                        string stockName = Console.ReadLine();
                        Console.WriteLine("Enter the quantity you wanted to buy");
                        int quantity = Convert.ToInt32(Console.ReadLine());
                        userStockOperation.BuyStocks(filePath, stockName, quantity);
                        break;
                    case 3:
                        Console.WriteLine("Enter StockName you wanted to sell");
                         stockName = Console.ReadLine();
                        Console.WriteLine("Enter the quantity you wanted to sell");
                        quantity = Convert.ToInt32(Console.ReadLine());
                        userStockOperation.SellStocks(filePath, stockName, quantity);
                        break;

                    default:
                        Console.WriteLine("----------breaked-----------");
                        flag3 = false;
                        break;
                    
                }
            }
        }
    }
}