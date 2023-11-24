using Microsoft.AspNetCore.Mvc;
using Tasks.API.Interfaces;
using Tasks.API.Models;

namespace Tasks.API.Controllers
{
    [ApiController]
    [Route("Task")]
    public class TaskController : Controller
    {
        private ITaskServices _taskServices;
       public TaskController(ITaskServices taskServices) { 
            
            _taskServices = taskServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _taskServices.GetTasks();
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> InsertTasks([FromBody]InsertTaskDto dto)
        {
            var idTask = await _taskServices.InsertTask(dto);
            return Ok(idTask);
        }

        [HttpPost("{idTask:int}/SubTask")]
        public async Task<IActionResult> InsertSubTasks([FromBody] InsertSubTaskDTO dto, int idTask)
        {
            var idSubTask = await _taskServices.InsertSubTask(dto, idTask);
            return Ok(idSubTask);
        }

        [HttpPut]
        public async Task<IActionResult> AlterTasks([FromBody] AlterTaskDto dto)
        {
            var idTask = await _taskServices.AlterTask(dto);
            return Ok(idTask);
        }

        [HttpDelete("{idTask:int}")]
        public async Task<IActionResult> DeleteTasks(int idTask)
        {
            if (idTask == 0) 
                return BadRequest();

            var idDeletedTask = await _taskServices.DeleteTask(idTask);
            return Ok();
        }
        [HttpDelete("SubTask/{idSubTask:int}")]
        public async Task<IActionResult> DeleteSubTasks( int idSubTask)
        {
            if (idSubTask == 0)
                return BadRequest();

            var idDeletedTask = await _taskServices.DeleteSubTask( idSubTask);
            return Ok();
        }
        [HttpPut("ChangeStatus/{idTask:int}/{idStatus:int}")]
        public async Task<IActionResult> ChangeStatusTask(int idTask, int idStatus)
        {
            if (idTask == 0 || idStatus== 0)
                return BadRequest();

            var taskResult = await _taskServices.AlterTaskStatus(idTask, idStatus);
            return Ok();
        }
    }
}
