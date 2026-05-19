using System.Text.Json;

namespace ToDoList
{
    public class Configs {
        public static JsonSerializerOptions JsonOptions {get;  private set;} = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };
        
        public static string Path = "./ToDoListData.json";
    
    }

}