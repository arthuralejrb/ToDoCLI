using System.Runtime.CompilerServices;

namespace ToDoList
{

    //the record that represents a task
    public record Task
    {
        public int Id {get; set;}
        public string? Description {get; set;}
        public Progress Status {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime? UpdatedAt {get; set;} //will be null when first adding the task


        public Task(string descripton, int id)
        {
            Id = id;
            Description = descripton;
            Status = Progress.ToDo;
            CreatedAt = DateTime.Now;
            
        }        

        // empty constructor for the json serializer
        public Task()
        {   
        }
    }


}