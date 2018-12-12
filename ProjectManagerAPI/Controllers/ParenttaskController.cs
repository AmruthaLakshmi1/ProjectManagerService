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
    public class ParenttaskController : ApiController
    {
        [Route("GetallParenttask")]
        public IHttpActionResult Get()
        {
            ProjectBAL obj = new ProjectBAL();
            return Ok(obj.GetParentTask());
        }
        [Route("Addparenttask")]
        public IHttpActionResult post(tblParent item)
        {
            ProjectBAL obj = new ProjectBAL();
            obj.AddParentTask(item);
            return Ok("Record added");
        }

        [Route("getbyparenttaskid/{id:int}")]
        [AcceptVerbs("GET")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            if (id == 0)
            {
                return null;
            }
            ProjectBAL obj = new ProjectBAL();
            return Ok(obj.GetparenttaskbyId(id));
        }
        [Route("updatebyparenttaskid/{id}")]
        [AcceptVerbs("PUT")]
        [HttpPut]
        public IHttpActionResult put(tblParent item)
        {
            ProjectBAL obj = new ProjectBAL();
            obj.UpdateParentTask(item);
            return Ok("Record Updated");
        }
        [Route("Deleteparenttask/{id:int}")]
        [AcceptVerbs("DELETE")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            ProjectBAL obj = new ProjectBAL();
            obj.Deleteparenttask(id);
            return Ok("Record is deleted");
        }
    }
}
