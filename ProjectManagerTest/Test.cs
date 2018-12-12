using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ProjectManagerBAL;
using ProjectManagerDAL;
using System.Web.Http;

namespace ProjectManagerTest
{
    public class Test    {
        
            [Test]
            public void Getall()
            {
                ProjectBAL obj = new ProjectBAL();
                int count = obj.GetTask().Count();
                Assert.Greater(count, 0);
            }
            [Test]
            public void Getbytask()
            {
                ProjectBAL obj = new ProjectBAL();
                List<tblTask> Ts = obj.GetTask();
                //Task count = obj.GetTaskbyId(1);
                tblTask count = obj.GetTaskbyId(Ts[0].TaskId);
                Assert.IsNotNull(count);
                //   Assert.Greater(count, 0);
            }
            [Test]
            public void AddTask()
            {
                ProjectBAL obje = new ProjectBAL();
                int count = obje.GetTask().Count();
                //dynamic testtask = new (Task) list<Task>;
                tblTask T = (new tblTask { TaskName = "Testtaskname", TStartDate = DateTime.Now, TEndDate = DateTime.Now, TPriority = 10, TStatus = false, ParentTaskName = "parenttask", UserId = 1 });
                obje.AddTask(T);
                int count1 = obje.GetTask().Count();
                Assert.AreEqual(count1, count + 1);
            }
            [Test]
            public void updateTask()
            {
                ProjectBAL obj = new ProjectBAL();
                List<tblTask> Ts = obj.GetTask();
                tblTask Taskgetbyid = obj.GetTaskbyId(Ts[0].TaskId);
                int count = obj.GetTask().Count();
                //dynamic testtask = new (Task) list<Task>;
                tblTask T = (new tblTask { TaskId = Ts[0].TaskId, TaskName = "taskname", TStartDate = DateTime.Now, TEndDate = DateTime.Now, TPriority = 10, TStatus = false, ParentTaskName = "parenttask", UserId = 1 });
                obj.UpdateTask(T);
                int count1 = obj.GetTask().Count();
                List<tblTask> TS1 = obj.GetTask();
                Assert.AreEqual(count1, count);
                // Assert.AreEqual(T.TaskName, TS1[0].TaskName);
            }
            [Test]
            public void DeleteTask()
            {
                ProjectBAL obj = new ProjectBAL();
                List<tblTask> Ts = obj.GetTask();
                tblTask Taskgetbyid = obj.GetTaskbyId(Ts[0].TaskId);
                int count1 = obj.GetTask().Count();
                //dynamic testtask = new (Task) list<Task>;
                //Task T = (new Task { TaskId = 1015, ParentName = "ParentTaskstest", TaskName = "Testtaskname", Priority = 15, SDate = DateTime.Now, EDate = DateTime.Now });           
                obj.DeleteTask(Taskgetbyid.TaskId);
                int count2 = obj.GetTask().Count();
                Assert.AreEqual(count2, count1 - 1);
            }
        }
}
