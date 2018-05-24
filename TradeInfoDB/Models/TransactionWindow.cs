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
        public string TransactionWindowId { get; set; }

        public string TransactionStartTime { get; set; }
        public int TransactionEndTime { get; set; }
        public double CurrentTokenValue { get; set; }
        public TransactionDetails ExpectedTransactions { get; set; }
        public TransactionDetails ActualTransactions { get; set; }  

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}