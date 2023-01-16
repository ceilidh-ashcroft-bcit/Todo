using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        public int Priority { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
    }
}
