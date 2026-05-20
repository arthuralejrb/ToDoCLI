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

            Tasks = TaskRepository.ReadJson<List<Task>>() ?? new List<Task>();

            if (Tasks.Count() != 0)
            {
                NextId = Tasks.Last().Id + 1;        
           
            }else
            {
                NextId = 1;
            }
            
            string newDescription = "";

            for(int i = 1; i < FullDescription.Length; i++)
            {
                newDescription += FullDescription[i];
                if(i < FullDescription.Length - 1)
                {
                    newDescription += " ";   
                    
                } 
            }

            Task task = new Task(newDescription, NextId);
            Tasks.Add(task);

            TaskRepository.WriteJson<List<Task>>(Tasks);
            Console.WriteLine($"Task added successfully (ID: {NextId})!!");

        }

        public void UpdateTask(int idTask, string[] FullDescription)
        {

            Tasks = TaskRepository.ReadJson<List<Task>>() ?? new List<Task>();

            string newDescription = "";
            for(int i = 2; i < FullDescription.Length; i++)
            {
                newDescription += FullDescription[i];
                if(i < FullDescription.Length - 1)
                {
                    newDescription += " ";
                }
            }

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

            Tasks = TaskRepository.ReadJson<List<Task>>() ?? new List<Task>();
            
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
            Tasks = TaskRepository.ReadJson<List<Task>> () ?? new List<Task>();
            Progress NewStatus = status switch
            {
                "in-progress" => Progress.InProgress,
                "done" => Progress.Done,
                "to-do" => Progress.ToDo,
                _ => Progress.ToDo,

            };

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
            Tasks = TaskRepository.ReadJson<List<Task>>() ?? new List<Task>();

            Progress statusFilter = filter[1] switch
            {
                "in-progress" => Progress.InProgress,
                "done" => Progress.Done,
                "to-do" => Progress.ToDo,
                _ => Progress.ToDo,

            };

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