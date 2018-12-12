using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectManagerBAL;
using ProjectManagerDAL;

namespace ProjectManagerAPI.Controllers
{
    public class UserController : ApiController
    {       
            [Route("Adduser")]
            [AcceptVerbs("POST")]
            public IHttpActionResult post(tblUser item)
            {
                ProjectBAL obj = new ProjectBAL();
                obj.AddUser(item);
                // obj.AddProject(item1);
                return Ok("Record added");
            }
            [Route("Getallusers")]
            public IHttpActionResult Get()

            {
                ProjectBAL obj = new ProjectBAL();
                return Ok(obj.GetUser());
            }
            [Route("getbyuserid/{id:int}")]
            [AcceptVerbs("GET")]
            [HttpGet]
            public IHttpActionResult Get(int id)
            {
                ProjectBAL obj = new ProjectBAL();
                return Ok(obj.GetUserbyId(id));
            }
            [Route("updatebyuserid/{id}")]
            [AcceptVerbs("PUT")]
            [HttpPut]
            public IHttpActionResult put(tblUser item)
            {
                ProjectBAL obj = new ProjectBAL();
                obj.UpdateUser(item);
                return Ok("Record Updated");
            }
            [Route("Deleteuser/{id:int}")]
            [AcceptVerbs("DELETE")]
            [HttpDelete]
            public IHttpActionResult Delete(int id)
            {
                ProjectBAL obj = new ProjectBAL();
                obj.DeleteUser(id);
                return Ok("Record is deleted");
            }
        }
}
