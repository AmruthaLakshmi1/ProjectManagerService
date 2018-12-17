using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBench;
using ProjectManagerBAL;
using ProjectManagerDAL;

namespace ProjectManagerNbench
{
    public class Nbench
    {
        private Counter _opcounter;
        private ProjectManagerBAL.ProjectBAL TaskBAL;
        [PerfSetup]
        public void SetUp(BenchmarkContext context)
        {
            TaskBAL = new ProjectManagerBAL.ProjectBAL();
            _opcounter = context.GetCounter("MyCounter");
        }
        [PerfBenchmark(NumberOfIterations = 13, RunMode = RunMode.Throughput, RunTimeMilliseconds = 1000, TestMode = TestMode.Measurement)]
        [CounterMeasurement("MyCounter")]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void benchmarkmethod(BenchmarkContext context)
        {
            var bytes = new byte[1024];
            _opcounter.Increment();
            tblTask T = (new tblTask { TaskId = 1, TaskName = "taskname", TStartDate = DateTime.Now, TEndDate = DateTime.Now, TPriority = 10, TStatus = false, ParentTaskName = "parenttask", UserId = 0 });
            tblProject P = (new tblProject { ProjectId = 1, ProjectName = "ProjectName", PStartDate = DateTime.Now, PEndDate = DateTime.Now, PPriority = 10, Pstatus = false, ManagerId =0, completed=0,Nooftasks=0});
            tblUser U = (new tblUser { UserId = 1, FirstName = "FirstName", LastName = "LastName", EmployeeId = "Emp01" });
            tblParent Pa = (new tblParent { ParentId = 1, ParentName = "ParentTask"});

            TaskBAL.GetProject();
            TaskBAL.GetTask();
            TaskBAL.GetUser();
            TaskBAL.GetParentTask();

            TaskBAL.AddTask(T);
            TaskBAL.UpdateTask(T);
            TaskBAL.DeleteTask(T.TaskId);
            TaskBAL.GetTaskbyId(T.TaskId);
            TaskBAL.Suspendtask(T.TaskId);
            TaskBAL.Endtask(T.TaskId);

            TaskBAL.AddProject(P);
            TaskBAL.DeleteProject(P.ProjectId);
            TaskBAL.GetProjectbyId(P.ProjectId);
            TaskBAL.Updateproject(P);

            TaskBAL.AddUser(U);
            TaskBAL.DeleteUser(U.UserId);
            TaskBAL.UpdateUser(U);
            TaskBAL.GetUserbyId(U.UserId);

            TaskBAL.AddParentTask(Pa);
            TaskBAL.Deleteparenttask(Pa.ParentId);
            TaskBAL.UpdateParentTask(Pa);
            TaskBAL.GetparenttaskbyId(Pa.ParentId);
        }
    }
}
