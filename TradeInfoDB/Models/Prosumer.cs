using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace TradeInfoDB.Models
{
    public class Prosumer
    {
        public Address ProsumerAdress { get; set; }
        public int Produce { get; set; }
        public int Consume { get; set; }
        public int CanSell { get; set; }
        public int WillBuy { get; set; }
    }
}