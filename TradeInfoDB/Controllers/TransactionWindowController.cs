using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TradeInfoDB.Models;
using TradeInfoDB.Repositories;

namespace TradeInfoDB.Controllers
{
    public class TransactionWindowController : ApiController
    {
        private readonly TransactionWindowRepository _repository = new TransactionWindowRepository();

        // GET: api/TransactionWindow
        public IEnumerable<TransactionWindow> Get()
        {
            return _repository.GetAll();
        }

        // GET: api/TransactionWindow/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TransactionWindow
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TransactionWindow/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TransactionWindow/5
        public void Delete(int id)
        {
        }
    }
}
