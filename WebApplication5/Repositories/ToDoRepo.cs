using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Repositories
{
    public class ToDoRepo
    {
        public List<ToDo> GetAllToDos(ToDoContext context)
        {
            var query = from t in context.ToDos
                        select new ToDo() { Id = t.Id, Priority = t.Priority, Description = t.Description, IsComplete = t.IsComplete };

            if (query == null)
            {
                return null;
            }

            return query.ToList();
        }

        public ToDo GetToDo(ToDoContext context, int id)
        {
            var query = from t in context.ToDos
                        where id == t.Id
                        select new ToDo() { Id = t.Id, Priority = t.Priority, Description = t.Description, IsComplete = t.IsComplete };

            if (query == null)
            {
                return null;
            }

            return query.FirstOrDefault();
        }

        public List<ToDo> AddToDo(ToDoContext context, ToDo toDo)
        {
            try
            {
                context.Add(toDo);
                context.SaveChanges();

                var query = from t in context.ToDos
                            select new ToDo() { Priority = t.Priority, Description = t.Description, IsComplete = t.IsComplete };

                return query.ToList();
            }
            catch
            {
                return null;
            }
        }

        public ToDo UpdateToDo(ToDoContext context, int id, ToDo req)
        {
            var query = context.ToDos.Where(t => t.Id == id).FirstOrDefault();

            if (query == null)
            {
                return null;
            }

   
            query.Priority = req.Priority;
            query.Description = req.Description;
            query.IsComplete = req.IsComplete;
            context.SaveChanges();
            
            return query;
        }

        public List<ToDo> DeleteToDo(ToDoContext context, int id)
        {
            var query = context.ToDos.Where(t => t.Id == id).FirstOrDefault();

            if (query == null)
            {
                return null;
            }

            context.Remove(query);
            context.SaveChanges();

            return GetAllToDos(context);
        }
    }
}
