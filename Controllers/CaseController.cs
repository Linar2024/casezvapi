using CaseZV.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaseZV.Controllers
{
        [ApiController]
        [Route("case")]
        public class CaseController : ControllerBase
        {
            [HttpGet]
            [Route("all")]

            public IActionResult GetAll()
            {
                var db = new CaseZvzvzvzvContext();
                return Ok(db.Cases);
            }

            [HttpGet]
            [Route("{id}")]

            public IActionResult Get(int id)
            {
                var db = new CaseZvzvzvzvContext();
                var cases = db.Cases.FirstOrDefault(x => x.Id == id);
                if(cases == null) {return NotFound();}
                return Ok(cases);
            }

            [HttpPost]
            public IActionResult Add(Case cases)
            {
                var db = new CaseZvzvzvzvContext();
                db.Cases.Add(cases);
                db.SaveChanges();
                return Ok();
            }
            [HttpPut]
            public IActionResult Update(Case cases)
            {
                var db = new CaseZvzvzvzvContext();
                db.Cases.Update(cases);
                db.SaveChanges();
                return Ok(cases);
                }
            [HttpDelete]
            public IActionResult Delete(int id)
            {
                var db = new CaseZvzvzvzvContext();
                var cases = db.Cases.FirstOrDefault(x => x.Id == id);
                if (cases == null) { return NotFound(); }
                db.Cases.Remove(cases);
                db.SaveChanges();
                return Ok();
            }
        }
}
