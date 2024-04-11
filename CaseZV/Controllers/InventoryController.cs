using CaseZV.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaseZV.Controllers
{
        [ApiController]
        [Route("inventory")]
        public class InventoryController : ControllerBase
        {
            [HttpGet]
            [Route("all")]

            public IActionResult GetAll()
            {
                var db = new CaseZvzvzvzvContext();
                return Ok(db.Inventorys);
            }

            [HttpGet]
            [Route("{id}")]

            public IActionResult Get(int id)
            {
                var db = new CaseZvzvzvzvContext();
                var inventory = db.Inventorys.FirstOrDefault(x => x.Id == id);
                if(inventory == null) {return NotFound();}
                return Ok(inventory);
            }

            [HttpPost]
            public IActionResult Add(Inventory inventory)
            {
                var db = new CaseZvzvzvzvContext();
                db.Inventorys.Add(inventory);
                db.SaveChanges();
                return Ok();
            }
            [HttpPut]
            public IActionResult Update(Inventory inventory)
            {
                var db = new CaseZvzvzvzvContext();
                db.Inventorys.Update(inventory);
                db.SaveChanges();
                return Ok(inventory);
                }
            [HttpDelete]
            public IActionResult Delete(int id)
            {
                var db = new CaseZvzvzvzvContext();
                var inventory = db.Inventorys.FirstOrDefault(x => x.Id == id);
                if (inventory == null) { return NotFound(); }
                db.Inventorys.Remove(inventory);
                db.SaveChanges();
                return Ok();
            }
        }
}
