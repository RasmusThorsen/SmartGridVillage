using System.Collections.Generic;
using System.Net;
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
        public IHttpActionResult Get(string id)
        {
            TransactionWindow transactionWindow = _repository.Get(id);
            return transactionWindow == null ? (IHttpActionResult)NotFound() : Ok(transactionWindow);
        }

        // POST: api/TransactionWindow
        [ResponseType(typeof(TransactionWindow))]
        public async Task<IHttpActionResult> Post(TransactionWindow newTransactionWindow)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _repository.Insert(newTransactionWindow);

            return CreatedAtRoute("DefaultApi", new { id = newTransactionWindow.TransactionWindowId }, newTransactionWindow);
        }

        // PUT: api/TransactionWindow/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(string id, TransactionWindow newTransactionWindow)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != newTransactionWindow.TransactionWindowId)
                return BadRequest();

            _repository.ChangeDocument(id, newTransactionWindow);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/TransactionWindow/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_repository.Get(id) == null)
                return NotFound();

            _repository.Delete(id);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
