﻿using Microsoft.AspNetCore.Mvc;
using Tasks.API.Interfaces;

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
        public async Task<IActionResult> InsertTasks()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> AlterTasks()
        {
            return Ok();
        }

        [HttpDelete("{idTask:int}")]
        public async Task<IActionResult> DeleteTasks(int idTask)
        {
            if (idTask == 0) 
                return BadRequest();

            var idDeletedTask = await _taskServices.DeleteTask(idTask);
            return Ok();
        }
    }
}
