using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TradeInfoDB.Models
{
    public class TransactionWindow
    {
        [JsonProperty(PropertyName = "id")] 
        public int TransactionWindowId { get; set; }

        public DateTime TransactionStartTime { get; set; }
        public DateTime TransactionEndTime { get; set; }
        public double CurrentTokenValue { get; set; }
        public TransactionDetails ExpectedTransactions { get; set; }
        public TransactionDetails ActualTransactions { get; set; }
    }
}