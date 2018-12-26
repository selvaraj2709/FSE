using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TaskManagerService.Entity;

namespace TaskManagerService.DataLayer
{
    public class TaskManagerDataAccess : ITasksRepository
    {
        TaskManagerAPISqlConn _db;
        public TaskManagerDataAccess()
        {
            _db = new TaskManagerAPISqlConn();
        }

        public void AddTask(TaskEntity task)
        {
            var newTask = new T_TASK()
            {

                TASK = task.TaskName,
                PARENT_ID = task.ParentId,
                START_DT = task.StartDate,
                END_DT = task.EndDate,
                PRIORITY = task.Priority,
                CRT_BY = task.CreatedBy,
                CRT_DT = DateTime.Now,
                ACT_IND = "Y"
            };

            _db.T_TASK.Add(newTask);
            _db.SaveChanges();
        }

        public List<TaskEntity> GetAllTasks()
        {
            var tasksFromDb = (from t in _db.T_TASK
                               join p in _db.T_TASK on t.PARENT_ID equals p.TASK_ID into parents
                               from parent in parents.DefaultIfEmpty()
                               select new TaskEntity
                               {
                                   TaskId = t.TASK_ID,
                                   TaskName = t.TASK,
                                   ParentId = parent != null ? parent.TASK_ID : 0,
                                   ParentName = parent.TASK,
                                   StartDate = t.START_DT,
                                   EndDate = t.END_DT,
                                   Priority = t.PRIORITY,
                                   ActiveInd = t.ACT_IND
                               }).ToList();

            return tasksFromDb;
        }

        public TaskEntity GetTaskById(int taskId)
        {
            var taskFromDb = (from t in _db.T_TASK
                              join p in _db.T_TASK on t.PARENT_ID equals p.TASK_ID into parents
                              from parent in parents.DefaultIfEmpty()
                              where t.TASK_ID == taskId
                              select new TaskEntity
                              {
                                  TaskId = t.TASK_ID,
                                  TaskName = t.TASK,
                                  ParentId = parent != null ? parent.TASK_ID : 0,
                                  ParentName = parent.TASK,
                                  StartDate = t.START_DT,
                                  EndDate = t.END_DT,
                                  Priority = t.PRIORITY
                              }).SingleOrDefault();

            return taskFromDb;
        }

        public void EndTask(int taskId, string userId)
        {
            var taskFromDb = (from t in _db.T_TASK
                              where t.TASK_ID == taskId
                              select t).FirstOrDefault();

            taskFromDb.END_DT = DateTime.Now;
            taskFromDb.UPDT_BY = userId;
            taskFromDb.UPDT_DT = DateTime.Now;
            taskFromDb.ACT_IND = "N";

            _db.SaveChanges();
        }

        public void UpdateTask(TaskEntity task)
        {
            var taskFromDb = (from t in _db.T_TASK
                              where t.TASK_ID == task.TaskId
                              select t).FirstOrDefault();

            taskFromDb.TASK = task.TaskName;
            taskFromDb.PARENT_ID = task.ParentId;
            taskFromDb.START_DT = task.StartDate;
            taskFromDb.END_DT = task.EndDate;
            taskFromDb.PRIORITY = task.Priority;
            taskFromDb.UPDT_BY = task.UpdatedBy;
            taskFromDb.UPDT_DT = DateTime.Now;

            _db.SaveChanges();
        }
    }
}
