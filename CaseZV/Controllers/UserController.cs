using CaseZV.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaseZV.Controllers
{
        [ApiController]
        [Route("user")]
        public class UserController : ControllerBase
        {
            [HttpGet]
            [Route("all")]

            public IActionResult GetAll()
            {
                var db = new CaseZvzvzvzvContext();
                return Ok(db.Users);
            }

            [HttpGet]
            [Route("{id}")]

            public IActionResult Get(int id)
            {
                var db = new CaseZvzvzvzvContext();
                var users = db.Users.FirstOrDefault(x => x.Id == id);
                if(users == null) {return NotFound();}
                return Ok(users);
            }

            [HttpPost]
            public IActionResult Add(User users)
            {
                var db = new CaseZvzvzvzvContext();
                db.Users.Add(users);
                db.SaveChanges();
                return Ok();
            }
            [HttpPut]
            public IActionResult Update(User users)
            {
                var db = new CaseZvzvzvzvContext();
                db.Users.Update(users);
                db.SaveChanges();
                return Ok(users);
                }
            [HttpDelete]
            public IActionResult Delete(int id)
            {
                var db = new CaseZvzvzvzvContext();
                var users = db.Users.FirstOrDefault(x => x.Id == id);
                if (users == null) { return NotFound(); }
                db.Users.Remove(users);
                db.SaveChanges();
                return Ok();
            }
        }
}
