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
    public class ProjectController : ApiController
    {
        [Route("Addproject")]
        public IHttpActionResult post(tblProject item)
        {
            ProjectBAL obj = new ProjectBAL();
            obj.AddProject(item);
            return Ok("Record added");
        }
        [Route("Getallprojects")]
        public IHttpActionResult Get()
        {
            ProjectBAL obj = new ProjectBAL();
            List<tblProject> projects = obj.GetProject();
            return Ok(projects);
        }
        [Route("getbyprojectid/{id:int}")]
        [AcceptVerbs("GET")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ProjectBAL obj = new ProjectBAL();
            return Ok(obj.GetProjectbyId(id));
        }
        [Route("updatebyprojectid/{id}")]
        [AcceptVerbs("PUT")]
        [HttpPut]
        public IHttpActionResult put(tblProject item)
        {
            ProjectBAL obj = new ProjectBAL();
            obj.Updateproject(item);
            return Ok("Record Updated");

        }
        [Route("Deleteproject/{id:int}")]
        [AcceptVerbs("DELETE")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            ProjectBAL obj = new ProjectBAL();
            obj.DeleteProject(id);
            return Ok("Record is deleted");
        }
        [Route("suspendprojectbyid/{id}")]
        [AcceptVerbs("PUT")]
        [HttpPut]
        public IHttpActionResult put(int id)
        {
            ProjectBAL obj = new ProjectBAL();
            obj.Suspendtask(id);
            return Ok("Record Updated");
        }
    }
}
