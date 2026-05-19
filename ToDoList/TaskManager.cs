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
            Console.WriteLine($"Task added successfully (ID: {NextId})");

        }


    }
}