using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ProjectManagerBAL;
using ProjectManagerDAL;
using System.Web.Http;
using System.Web.Http.Results;
using ProjectManagerAPI;

namespace ProjectManagerTest
{
    class Testservice
    {      
            [Test]
            public void GetALL_service()
            {
                var obj = new ProjectManagerAPI.Controllers.TaskController();
                IHttpActionResult result = obj.Get();
                var contentresult = result as OkNegotiatedContentResult<List<tblTask>>;
                Assert.IsNotNull(contentresult);
                Assert.IsNotNull(contentresult.Content);
                Assert.Greater(contentresult.Content.Count, 0);
            }
            [Test]
            public void GetbytaskID_Service()
            {
                var obj = new ProjectManagerAPI.Controllers.TaskController();
                IHttpActionResult result = obj.Get();
                var contentresult = result as OkNegotiatedContentResult<List<tblTask>>;
                IHttpActionResult result2 = obj.Get(contentresult.Content[0].TaskId);
                var contentresult1 = result2 as OkNegotiatedContentResult<tblTask>;
                Assert.IsNotNull(contentresult1);
                Assert.IsNotNull(contentresult1.Content);
                Assert.AreEqual(contentresult.Content[0].TaskId, contentresult1.Content.TaskId);
            }
            [Test]
            public void AddTask_Service()
            {
                var obj = new ProjectManagerAPI.Controllers.TaskController();
                //Task ts = new tblTask { TaskName = "Task added", ParentName = "Parent added", Priority = 10, SDate = DateTime.Now, EDate = DateTime.Now, flag = true };
                tblTask Ts = (new tblTask { TaskName = "Testtaskname", TStartDate = DateTime.Now, TEndDate = DateTime.Now, TPriority = 10, TStatus = false, ParentTaskName = "parenttask", UserId = 0 });
                IHttpActionResult result = obj.post(Ts);
                var contentresult = result as OkNegotiatedContentResult<string>;
                IHttpActionResult result1 = obj.Get();
                var contentresult1 = result1 as OkNegotiatedContentResult<List<tblTask>>;
                Assert.IsNotNull(contentresult);
                Assert.Greater(contentresult1.Content.Count, 0);
            }
            [Test]
            public void UpdateTAsk()
            {
                var obj = new ProjectManagerAPI.Controllers.TaskController();
                IHttpActionResult result = obj.Get();
                var contentresult = result as OkNegotiatedContentResult<List<tblTask>>;
                // tblTask ts = new tblTask { TaskId = contentresult.Content[0].TaskId, TaskName = "Updated Task", ParentName = "Updated Parent", Priority = 10, SDate = DateTime.Now, EDate = DateTime.Now, flag = true };
                tblTask Ts = (new tblTask { TaskId = contentresult.Content[0].TaskId, TaskName = "taskname", TStartDate = DateTime.Now, TEndDate = DateTime.Now, TPriority = 10, TStatus = false, ParentTaskName = "parenttask", UserId = 1 });
                IHttpActionResult result1 = obj.put(Ts);
                IHttpActionResult result2 = obj.Get();
                var contentresult1 = result2 as OkNegotiatedContentResult<List<tblTask>>;
                Assert.AreEqual(contentresult1.Content[0].TaskName, Ts.TaskName);
            }
            [Test]
            public void DeleteTask()
            {
                var obj = new ProjectManagerAPI.Controllers.TaskController();
                IHttpActionResult result = obj.Get();
                var contentresult = result as OkNegotiatedContentResult<List<tblTask>>;
                IHttpActionResult result1 = obj.Delete(contentresult.Content[0].TaskId);
                IHttpActionResult result2 = obj.Get();
                var contentresult1 = result2 as OkNegotiatedContentResult<List<tblTask>>;
                Assert.AreNotEqual(contentresult.Content[0].TaskId, contentresult1.Content[0].TaskId);
            }
        }
}
