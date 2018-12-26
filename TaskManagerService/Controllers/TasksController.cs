using System.Web.Http;
using TaskManagerService.Entity;
using TaskManagerService.BusinessLayer;

namespace TaskManagerService.Controllers
{
    public class TasksController : ApiController
    {
        private ITaskManagerBL _taskManagerService;
        public TasksController(ITaskManagerBL service)
        {
            _taskManagerService = service;
        }

        [HttpGet]
        public IHttpActionResult GetTaskById(int taskId)
        {
            var result = _taskManagerService.GetTaskById(taskId);
            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetAllTasks()
        {
            var result = _taskManagerService.GetAllTasks();
            return Ok(result);
        }

        [HttpPut]
        public IHttpActionResult EndTask(int taskId, string userId)
        {
            _taskManagerService.EndTask(taskId, userId);
            return Ok();
        }

       

        [HttpPut]
        public IHttpActionResult Update([FromBody]TaskEntity taskModel)
        {
            _taskManagerService.UpdateTask(taskModel);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody]TaskEntity taskModel)
        {
            _taskManagerService.AddTask(taskModel);
            return Ok();
        }
    }
}
