using CaseZV.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaseZV.Controllers
{
        [ApiController]
        [Route("balance")]
        public class BalanceController : ControllerBase
        {
            [HttpGet]
            [Route("all")]

            public IActionResult GetAll()
            {
                var db = new CaseZvzvzvzvContext();
                return Ok(db.Balances);
            }

            [HttpGet]
            [Route("{id}")]

            public IActionResult Get(int id)
            {
                var db = new CaseZvzvzvzvContext();
                var balances = db.Balances.FirstOrDefault(x => x.Id == id);
                if(balances == null) {return NotFound();}
                return Ok(balances);
            }

            [HttpPost]
            public IActionResult Add(Balance balances)
            {
                var db = new CaseZvzvzvzvContext();
                db.Balances.Add(balances);
                db.SaveChanges();
                return Ok();
            }
            [HttpPut]
            public IActionResult Update(Balance balances)
            {
                var db = new CaseZvzvzvzvContext();
                db.Balances.Update(balances);
                db.SaveChanges();
                return Ok(balances);
                }
            [HttpDelete]
            public IActionResult Delete(int id)
            {
                var db = new CaseZvzvzvzvContext();
                var balances = db.Balances.FirstOrDefault(x => x.Id == id);
                if (balances == null) { return NotFound(); }
                db.Balances.Remove(balances);
                db.SaveChanges();
                return Ok();
            }
        }
}
