using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradeInfoDB.Models
{
    public class TransactionDetails
    {
        public int TransactionWindowBalance { get; set; }
        public string ProfitOrDeficitSendTo { get; set; }
        public Prosumer[] ProsumerTradeDetails { get; set; }
    }
}