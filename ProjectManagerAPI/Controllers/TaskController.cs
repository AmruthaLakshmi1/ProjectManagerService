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
    public class TaskController : ApiController
    {
        [Route("Addtask")]
        public IHttpActionResult post(tblTask item)
        {
            ProjectBAL obj = new ProjectBAL();
            obj.AddTask(item);
            return Ok("Record added");
        }

        [Route("Getalltasks")]
        public IHttpActionResult Get()
        {
            ProjectBAL obj = new ProjectBAL();
            return Ok(obj.GetTask());
        }

        [Route("getbytaskid/{id:int}")]
        [AcceptVerbs("GET")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            if (id == 0)
            {
                return null;
            }
            ProjectBAL obj = new ProjectBAL();
            return Ok(obj.GetTaskbyId(id));
        }
        [Route("updatebytaskid/{id}")]
        [AcceptVerbs("PUT")]
        [HttpPut]
        public IHttpActionResult put(tblTask item)
        {
            ProjectBAL obj = new ProjectBAL();
            obj.UpdateTask(item);
            return Ok("Record Updated");
        }
        [Route("Deletetask/{id:int}")]
        [AcceptVerbs("DELETE")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            ProjectBAL obj = new ProjectBAL();
            obj.DeleteTask(id);
            return Ok("Record is deleted");
        }
        [Route("Endtask/{id:int}")]
        [AcceptVerbs("PUT")]
        [HttpDelete]
        public IHttpActionResult put(int id)
        {
            ProjectBAL obj = new ProjectBAL();
            obj.Endtask(id);
            return Ok("Record is deleted");
        }
    }
}
