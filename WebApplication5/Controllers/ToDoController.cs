using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using WebApplication5.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoContext _context;

        public ToDoController(ToDoContext context)
        {
            _context = context;
        }

        // GET: api/<ToDoController>
        [HttpGet]
        public ActionResult<List<ToDo>> GetAllToDos()
        {
            ToDoRepo tdRepo = new ToDoRepo();
            List<ToDo> allToDos = tdRepo.GetAllToDos(_context);

            if (allToDos == null)
            {
                return BadRequest("No ToDos Found");
            }

            return Ok(allToDos);

        }


        // GET api/<ToDoController>/5
        [HttpGet("{id}")]
        public ActionResult<ToDo> GetToDo(int id)
        {
            ToDoRepo tdRepo = new ToDoRepo();
            ToDo toDo = tdRepo.GetToDo(_context, id);
            if (toDo == null)
            {
                return BadRequest("Id Not Found");
            }
            return toDo;
        }

        // POST api/<ToDoController>
        [HttpPost]
        public ActionResult<List<ToDo>> AddToDo(ToDo newToDo)
        {
            ToDoRepo tdRepo = new ToDoRepo();

            List<ToDo> toDos = tdRepo.AddToDo(_context, newToDo);

            if (toDos == null)
            {
                return BadRequest("Could not add To Do.");
            }

            return toDos;
        }


        // PUT api/<ToDoController>/5
        [HttpPut("{id}")]
        public ActionResult<List<ToDo>> UpdateToDo(int id, ToDo newToDo)
        {
            ToDoRepo tdRepo = new ToDoRepo();
            ToDo toDo = tdRepo.UpdateToDo(_context, id, newToDo);

            if (toDo == null)
            {
                return BadRequest("Id Not Found");
            }

            List<ToDo> ToDos = tdRepo.GetAllToDos(_context);
            return ToDos;
        }


        // DELETE api/<ToDoController>/5
        [HttpDelete("{id}")]
        public ActionResult<List<ToDo>> DeleteToDo(int id)
        {
            ToDoRepo tdRepo = new ToDoRepo();
            List<ToDo> toDos = tdRepo.DeleteToDo(_context, id);

            if (toDos == null)
            {
                return BadRequest("Id Not Found");
            }

            return toDos;

        }
    }
}
