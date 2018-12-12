using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagerDAL;

namespace ProjectManagerBAL
{
    public class ProjectBAL
    {        
            FinalSBADBEntities db = new FinalSBADBEntities();
            public void AddUser(tblUser item)
            {
                using (FinalSBADBEntities db1 = new FinalSBADBEntities())
                {
                    db1.tblUsers.Add(item);
                    db1.SaveChanges();
                }
            }
            public void AddTask(tblTask item)
            {
                using (FinalSBADBEntities db1 = new FinalSBADBEntities())
                {
                    var projectupdate = db1.tblProjects.Where(x => x.ProjectId == item.ProjectId).ToList();
                    projectupdate.ForEach(m => m.Nooftasks = m.Nooftasks + 1);
                    item.TStatus = false;
                    db1.tblTasks.Add(item);
                    db1.SaveChanges();
                }
            }
            public void AddParentTask(tblParent item)
            {
                using (FinalSBADBEntities db1 = new FinalSBADBEntities())
                {
                    db1.tblParents.Add(item);
                    db1.SaveChanges();
                }
            }
            public void AddProject(tblProject item)
            {
                using (FinalSBADBEntities db1 = new FinalSBADBEntities())
                {
                    item.Nooftasks = 0;
                    item.completed = 0;
                    item.Pstatus = false;
                    db1.tblProjects.Add(item);
                    db1.SaveChanges();
                }
            }
            public List<tblUser> GetUser()
            {
                {
                    return db.tblUsers.ToList();
                }
            }
            public List<tblTask> GetTask()
            {
                return db.tblTasks.ToList();

            }
            public List<tblParent> GetParentTask()
            {
                return db.tblParents.ToList();

            }
            public List<tblProject> GetProject()
            {
                if (db.tblProjects != null)
                {
                    // var Projects = from proj in db.tblProjects.Include("tblUsers").Include("tblTasks")
                    //  select proj;
                    return db.tblProjects.ToList();
                }
                return null;
            }
            //public List<string> Getallrecords(int id)
            //{
            //    using (FinalSBADBEntities db1 = new FinalSBADBEntities())
            //    {
            //        List<string> li = new List<string>();
            //        var taskupdate = db1.tblTasks.Where(x => x.ProjectId == id).ToList();
            //        var projupd=db1.t
            //    }
            //    return li;

            //}
            public tblUser GetUserbyId(int id)
            {
                return db.tblUsers.SingleOrDefault(k => k.UserId == id);
            }
            public tblTask GetTaskbyId(int id)
            {

                return db.tblTasks.SingleOrDefault(k => k.TaskId == id);

            }
            public tblProject GetProjectbyId(int id)
            {

                return db.tblProjects.SingleOrDefault(k => k.ProjectId == id);

            }
            public tblParent GetparenttaskbyId(int id)
            {

                return db.tblParents.SingleOrDefault(k => k.ParentId == id);

            }
            public void DeleteUser(int Id)
            {
                using (FinalSBADBEntities db1 = new FinalSBADBEntities())
                {
                    tblUser us = db1.tblUsers.Where(d => d.UserId == Id).First();
                    var projectupdate = db1.tblProjects.Where(x => x.ManagerId == Id).ToList();
                    projectupdate.ForEach(m => m.ManagerId = 0);
                    var taskupdate = db1.tblTasks.Where(x => x.UserId == Id).ToList();
                    taskupdate.ForEach(m => m.UserId = 0);
                    db1.tblUsers.Remove(us);
                    db1.SaveChanges();
                }
            }
            public void DeleteTask(int TaskId)
            {
                using (FinalSBADBEntities db1 = new FinalSBADBEntities())
                {
                    tblTask ts = db1.tblTasks.Where(d => d.TaskId == TaskId).FirstOrDefault();
                    var projectupdate = db1.tblProjects.Where(x => x.ProjectId == ts.ProjectId).ToList();
                    projectupdate.ForEach(m => m.completed = m.completed - 1);
                    db1.tblTasks.Remove(ts);
                    db1.SaveChanges();
                }
            }
            public void DeleteProject(int Id)
            {
                using (FinalSBADBEntities db1 = new FinalSBADBEntities())
                {
                    tblProject ts = db1.tblProjects.Where(d => d.ProjectId == Id).FirstOrDefault();
                    db1.tblProjects.Remove(ts);
                    db1.SaveChanges();
                }
            }
            public void Deleteparenttask(int Id)
            {
                using (FinalSBADBEntities db1 = new FinalSBADBEntities())
                {
                    tblParent par = db1.tblParents.Where(d => d.ParentId == Id).First();
                    db1.tblParents.Remove(par);
                    db1.SaveChanges();
                }
            }
            public void UpdateUser(tblUser useritem)
            {
                using (FinalSBADBEntities db1 = new FinalSBADBEntities())
                {
                    tblUser userupdate = db1.tblUsers.SingleOrDefault(x => x.UserId == useritem.UserId);
                    userupdate.FirstName = useritem.FirstName;
                    userupdate.LastName = useritem.LastName;
                    userupdate.EmployeeId = useritem.EmployeeId;
                    db1.SaveChanges();
                }
            }
            public void UpdateTask(tblTask taskitem)
            {
                using (FinalSBADBEntities db1 = new FinalSBADBEntities())
                {
                    tblTask taskupdate = db1.tblTasks.SingleOrDefault(x => x.TaskId == taskitem.TaskId);
                    tblProject projectupdate = db1.tblProjects.SingleOrDefault(x => x.ProjectId == taskupdate.ProjectId);
                    projectupdate.Nooftasks = projectupdate.Nooftasks - 1;
                    taskupdate.TaskName = taskitem.TaskName;
                    taskupdate.TStartDate = taskitem.TStartDate;
                    taskupdate.TEndDate = taskitem.TEndDate;
                    taskupdate.TPriority = taskitem.TPriority;
                    taskupdate.TStatus = taskitem.TStatus;
                    //taskupdate.IsParentTask = taskitem.IsParentTask;
                    taskupdate.ParentId = taskitem.ParentId;
                    taskupdate.ProjectId = taskitem.ProjectId;
                    taskupdate.UserId = taskitem.UserId;
                    taskupdate.ParentTaskName = taskitem.ParentTaskName;
                    // taskupdate.ProjectName = taskitem.ProjectName;
                    // taskupdate.Manager = taskitem.Manager;
                    tblProject projectupdate1 = db1.tblProjects.SingleOrDefault(x => x.ProjectId == taskitem.ProjectId);
                    projectupdate1.Nooftasks = projectupdate1.Nooftasks + 1;
                    db1.SaveChanges();
                }
            }
            public void Updateproject(tblProject projectitem)
            {
                using (FinalSBADBEntities db1 = new FinalSBADBEntities())
                {

                    tblProject projectupdate = db1.tblProjects.SingleOrDefault(x => x.ProjectId == projectitem.ProjectId);

                    projectupdate.ProjectName = projectitem.ProjectName;
                    projectupdate.PStartDate = projectitem.PStartDate;
                    projectupdate.PEndDate = projectitem.PEndDate;
                    projectupdate.PPriority = projectitem.PPriority;
                    projectupdate.ManagerId = projectitem.ManagerId;
                    //updating in tasktable
                    //  var taskupdate = db1.tblTasks.Where(x => x.ProjectId == projectitem.ProjectId).ToList();
                    //  taskupdate.ForEach(m => m.ProjectName = projectitem.ProjectName);
                    db1.SaveChanges();
                }
                using (FinalSBADBEntities db2 = new FinalSBADBEntities())
                {
                    var projectupdate = db2.tblProjects.Where(x => x.ProjectId == projectitem.ProjectId).ToList();
                    // projectupdate.ForEach(m=>m.Nooftasks=()
                }
            }
            public void UpdateParentTask(tblParent taskitem)
            {
                using (FinalSBADBEntities db1 = new FinalSBADBEntities())
                {
                    tblParent taskupdate = db1.tblParents.SingleOrDefault(x => x.ParentId == taskitem.ParentId);
                    taskupdate.ParentName = taskitem.ParentName;
                    db1.SaveChanges();
                }
            }
            public void Endtask(int id)
            {
                using (FinalSBADBEntities db = new FinalSBADBEntities())
                {
                    tblTask ts = db.tblTasks.SingleOrDefault(x => x.TaskId == id);
                    var projectupdate = db.tblProjects.Where(x => x.ProjectId == ts.ProjectId).ToList();
                    projectupdate.ForEach(m => m.Nooftasks = m.Nooftasks - 1);
                    projectupdate.ForEach(m => m.completed = m.completed + 1);
                    ts.TStatus = true;
                    ts.TEndDate = DateTime.Now;
                    db.SaveChanges();
                }
            }
            public void Suspendtask(int id)
            {
                using (FinalSBADBEntities db = new FinalSBADBEntities())
                {
                    tblProject tp = db.tblProjects.SingleOrDefault(x => x.ProjectId == id);
                    if (tp.Pstatus == false)
                    {
                        tp.Pstatus = true;
                    }
                    else
                        tp.Pstatus = false;
                    //tp.PEndDate = DateTime.Now;
                    db.SaveChanges();
                }
            }
            //public void Continue
        }
    }
