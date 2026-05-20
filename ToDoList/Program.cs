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
                    // idTask = Convert.ToInt32(args[1]);
                    // ToDoListManager.MarkTask(idTask);

                break;
                case "list":
                
                break;

                default:
                break;

            }
        }
    }


    public enum Progress {ToDo, InProgress, Done};
}