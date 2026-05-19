using System.Runtime.CompilerServices;

namespace ToDoList
{
    public record Task
    {
        public int Id {get; set;}
        public string? Description {get; set;}
        public Progress Status {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime? UpdatedAt {get; set;}


        public Task(string descripton, int id)
        {
            Id = id;
            Description = descripton;
            Status = Progress.ToDo;
            CreatedAt = DateTime.Now;
            
        }        

        public Task()
        {   
        }
    }


}