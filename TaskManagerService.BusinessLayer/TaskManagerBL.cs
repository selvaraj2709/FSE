using System.Collections.Generic;
using TaskManagerService.Entity;
using TaskManagerService.DataLayer;

namespace TaskManagerService.BusinessLayer
{
    public class TaskManagerBL : ITaskManagerBL
    {
        private ITasksRepository _taskRepo;
        public TaskManagerBL(ITasksRepository repo)
        {
            _taskRepo = repo;
        }

        public List<TaskEntity> GetAllTasks()
        {
            return _taskRepo.GetAllTasks();
        }

        public void UpdateTask(TaskEntity task)
        {
            _taskRepo.UpdateTask(task);
        }

        public void EndTask(int taskId, string userId)
        {
            _taskRepo.EndTask(taskId, userId);
        }

        public void AddTask(TaskEntity task)
        {
            _taskRepo.AddTask(task);
        }

        public TaskEntity GetTaskById(int taskId)
        {
            return _taskRepo.GetTaskById(taskId);
        }
    }
}
