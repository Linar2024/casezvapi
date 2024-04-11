using CaseZV.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaseZV.Controllers
{
        [ApiController]
        [Route("gun")]
        public class GunController : ControllerBase
        {
            [HttpGet]
            [Route("all")]

            public IActionResult GetAll()
            {
                var db = new CaseZvzvzvzvContext();
                return Ok(db.Guns);
            }

            [HttpGet]
            [Route("{id}")]

            public IActionResult Get(int id)
            {
                var db = new CaseZvzvzvzvContext();
                var gun = db.Guns.FirstOrDefault(x => x.Id == id);
                if(gun == null) {return NotFound();}
                return Ok(gun);
            }

            [HttpPost]
            public IActionResult Add(Gun gun)
            {
                var db = new CaseZvzvzvzvContext();
                db.Guns.Add(gun);
                db.SaveChanges();
                return Ok();
            }
            [HttpPut]
            public IActionResult Update(Gun gun)
            {
                var db = new CaseZvzvzvzvContext();
                db.Guns.Update(gun);
                db.SaveChanges();
                return Ok(gun);
                }
            [HttpDelete]
            public IActionResult Delete(int id)
            {
                var db = new CaseZvzvzvzvContext();
                var gun = db.Guns.FirstOrDefault(x => x.Id == id);
                if (gun == null) { return NotFound(); }
                db.Guns.Remove(gun);
                db.SaveChanges();
                return Ok();
            }
        }
}
