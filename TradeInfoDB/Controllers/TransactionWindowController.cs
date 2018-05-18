using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
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
        [ResponseType(typeof(TransactionWindow))]
        public IHttpActionResult Get(int id)
        {
            TransactionWindow transactionWindow = _repository.Get(id);
            return transactionWindow == null ? (IHttpActionResult) NotFound() : Ok(transactionWindow);
        }

        // POST: api/TransactionWindow
        [ResponseType(typeof(TransactionWindow))]
        public IHttpActionResult Post(TransactionWindow newTransactionWindow)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _repository.Insert(newTransactionWindow);
            return CreatedAtRoute("DefaultApi", new {id = newTransactionWindow.TransactionWindowId},
                newTransactionWindow);
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
