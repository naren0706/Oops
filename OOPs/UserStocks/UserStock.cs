using OOPs.DataInventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPs.UserStocks
{
    internal class UserStock
    {
        public string StockName { get; set; }
        public string DateAndTime { get; set; }
        public int Balance { get; set; }
        public int NumberOfStockOwned { get; set; }
        public string OrderType { get; set; }

        
    }
}
