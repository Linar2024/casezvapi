using CaseZV.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaseZV.Controllers
{
        [ApiController]
        [Route("gunofcase")]
        public class GunOfCaseController : ControllerBase
        {
            [HttpGet]
            [Route("all")]

            public IActionResult GetAll()
            {
                var db = new CaseZvzvzvzvContext();
                return Ok(db.GunsOfCases);
            }

            [HttpGet]
            [Route("{id}")]

            public IActionResult Get(int id)
            {
                var db = new CaseZvzvzvzvContext();
                var gunsOfCase = db.GunsOfCases.FirstOrDefault(x => x.Id == id);
                if(gunsOfCase == null) {return NotFound();}
                return Ok(gunsOfCase);
            }

            [HttpPost]
            public IActionResult Add(GunsOfCase gunsOfCase)
            {
                var db = new CaseZvzvzvzvContext();
                db.GunsOfCases.Add(gunsOfCase);
                db.SaveChanges();
                return Ok();
            }
            [HttpPut]
            public IActionResult Update(GunsOfCase gunsOfCase)
            {
                var db = new CaseZvzvzvzvContext();
                db.GunsOfCases.Update(gunsOfCase);
                db.SaveChanges();
                return Ok(gunsOfCase);
                }
            [HttpDelete]
            public IActionResult Delete(int id)
            {
                var db = new CaseZvzvzvzvContext();
                var gunsOfCase = db.GunsOfCases.FirstOrDefault(x => x.Id == id);
                if (gunsOfCase == null) { return NotFound(); }
                db.GunsOfCases.Remove(gunsOfCase);
                db.SaveChanges();
                return Ok();
            }
        }
}
