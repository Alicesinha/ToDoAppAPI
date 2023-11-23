using Microsoft.AspNetCore.Mvc;

namespace Tasks.API.Controllers
{
    [ApiController]
    [Route("Task")]
    public class TaskController : Controller
    {
       public TaskController() { 
            
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> InsertTasks()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTasks()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> AlterTasks()
        {
            return Ok();
        }
    }
}
