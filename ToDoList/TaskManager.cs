using System.Net;
using System.Runtime.CompilerServices;

namespace ToDoList
{
    public class TaskManager
    {
        private List<Task>? Tasks;
        private int NextId;

        public void AddTask(string[] FullDescription)
        {
            //get all the json data into Tasks list
            Tasks = TaskRepository.ReadJson<List<Task>>() ?? new List<Task>();

            //gets the right NextID
            if (Tasks.Count() != 0){
                NextId = Tasks.Last().Id + 1;        
           
            }else{
                NextId = 1;

            }
            
            //creates and concatenate the new task description
            string newDescription = "";

            for(int i = 1; i < FullDescription.Length; i++){
                newDescription += FullDescription[i];
                if(i < FullDescription.Length - 1)
                {
                    newDescription += " ";   
                    
                } 
            }

            //creates a new Task and adds it to the Tasks list
            Task task = new Task(newDescription, NextId);
            Tasks.Add(task);

            //write the tasks list into the json file
            TaskRepository.WriteJson<List<Task>>(Tasks);
            Console.WriteLine($"Task added successfully (ID: {NextId})!!");

        }

        public void UpdateTask(int idTask, string[] FullDescription)
        {
            //get all the json data into Tasks list
            Tasks = TaskRepository.ReadJson<List<Task>>() ?? new List<Task>();

            //creates and concatenate the task new description
            string newDescription = "";
            for(int i = 2; i < FullDescription.Length; i++)
            {
                newDescription += FullDescription[i];
                if(i < FullDescription.Length - 1)
                {
                    newDescription += " ";
                }
            }

            //loops through every task until it finds a matching ID. then changes its description
            if(Tasks.Any(f=> f.Id == idTask)) {
                
                foreach(Task task in Tasks)
                {
                    if(task.Id == idTask)
                    {
                        task.Description = newDescription;
                        task.UpdatedAt = DateTime.Now;

                        TaskRepository.WriteJson<List<Task>>(Tasks);
                        Console.WriteLine($"Task ID: {idTask} description updated!!");

                    }
                }
            }else
            {
                Console.WriteLine($"There is no task with ID: {idTask}");
            }

        }

        public void DeleteTask(int idTask)
        {
            //get all the json data into Tasks list
            Tasks = TaskRepository.ReadJson<List<Task>>() ?? new List<Task>();
            
            //loops through every task until it finds a matching ID, then delete the task
            if(Tasks.Any( f => f.Id == idTask)) {
                
                for(int i = Tasks.Count() - 1; i >= 0; i--)
                {
                    if(Tasks[i].Id == idTask)
                    {
                        Tasks.RemoveAt(i);
                        TaskRepository.WriteJson<List<Task>>(Tasks);
                        Console.WriteLine($"Task ID: {idTask} removed!!");
                        
                    }
                }
            }else {
                Console.WriteLine($"There is no task with ID: {idTask}");
            
            }
        }
    
        public void MarkTask(int idTask, string status)
        {
            //get all the json data into Tasks list
            Tasks = TaskRepository.ReadJson<List<Task>> () ?? new List<Task>();

            //defines the new status based on the user input
            Progress NewStatus = status switch
            {
                "in-progress" => Progress.InProgress,
                "done" => Progress.Done,
                "to-do" => Progress.ToDo,
                _ => Progress.ToDo,

            };

            //loops through each task until it finds a matching ID, then changes it's status
            if(Tasks.Any(f=> f.Id == idTask)) {
                
                foreach(Task task in Tasks)
                {
                    if(task.Id == idTask)
                    {          
                        task.UpdatedAt = DateTime.Now;
                        task.Status = NewStatus;
                        TaskRepository.WriteJson<List<Task>>(Tasks);
                        Console.WriteLine($"Task ID: {idTask} status marked as {status}!!");

                    }
                }
            }else{
                Console.WriteLine($"There is no task with ID: {idTask}");
            
            }
        }
    
        public void ListTasks(params string[] filter)
        {
            //get all the json data into Tasks list
            Tasks = TaskRepository.ReadJson<List<Task>>() ?? new List<Task>();
            Progress statusFilter = Progress.ToDo;
            
            //defines the filter for the search
            if (filter.Length > 0) 
            {
                statusFilter = filter[1] switch
                {
                    "in-progress" => Progress.InProgress,
                    "done" => Progress.Done,
                    "to-do" => Progress.ToDo,
                    _ => Progress.ToDo,

                };
                
            }

            //loops througth each task and exhibits any task with matching filters
            foreach (Task task in Tasks)
            {
                if(filter.Length > 0)
                {   if(task.Status == statusFilter){
                        Console.WriteLine($"Task: {task.Description} | Status: {task.Status}");
                    
                    }

                }else{
                    Console.WriteLine($"Task: {task.Description} | Status: {task.Status}");
                    
                }
            }
        }
    }
}