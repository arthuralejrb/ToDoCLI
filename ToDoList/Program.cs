using System.ComponentModel;
using System.Data.Common;

namespace ToDoList
{
    
    class Program
    {
        static void Main(string[]args)
        {
            TaskManager ToDoListManager = new TaskManager();
            int idTask;
            if (args.Length > 0)
            {
                
                switch(args[0])
                {
                    case "add":
                        ToDoListManager.AddTask(args);
                        
                    break;
                    case "update":
                        idTask = Convert.ToInt32(args[1]);
                        ToDoListManager.UpdateTask(idTask, args);

                    break;

                    case "delete":
                        idTask = Convert.ToInt32(args[1]);
                        ToDoListManager.DeleteTask(idTask);

                    break;
                    case "mark":
                        idTask = Convert.ToInt32(args[1]);
                        ToDoListManager.MarkTask(idTask, args[2]);

                    break;
                    case "list":
                        if (args.Length > 1){
                            ToDoListManager.ListTasks(args);
                            
                        }else{
                            ToDoListManager.ListTasks();
                        }
                        
                    break;

                    default:
                        Console.WriteLine("Not a valid operation!");
                        
                    break;

                }

            }else{
                Console.WriteLine("You did not inform a operation!");

            }
        }
    }


    public enum Progress {ToDo, InProgress, Done};
}