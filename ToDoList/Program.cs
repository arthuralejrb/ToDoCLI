using System.ComponentModel;

namespace ToDoList
{
    
    class Program
    {
        static void Main(string[]args)
        {
            TaskManager t = new TaskManager();

            switch(args[0])
            {
                case "add":
                    t.AddTask(args);
                    
                break;
                // case "update":
                // break;
                // case "delete":
                // break;
                // case "mark":
                // break;

            }

            
        }
    }


    public enum Progress {ToDo, InProgress, Done};
}