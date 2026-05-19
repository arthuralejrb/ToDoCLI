using System.Text.Json;
using System.Text.Json.Serialization;

namespace ToDoList
{
    public class TaskRepository
    {
        public static bool WriteJson<T>(T data)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(data, Configs.JsonOptions);
                File.WriteAllText(Configs.Path, jsonString);

                return true;
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("No permission to write file");
                return false;
            }
            catch(PathTooLongException)
            {
                Console.WriteLine("File Path too long");
                return false;

            }
            catch(Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return false;
            }
        }

        public static T? ReadJson<T>()
        {
            try
            {
                if(!File.Exists(Configs.Path))
                {
                    Console.WriteLine($"File not found: {Configs.Path}");
                    return default;
                }

                string jsonString = File.ReadAllText(Configs.Path);

                if(string.IsNullOrEmpty(jsonString))
                {
                    Console.WriteLine("Empty File!");
                    return default;
                
                }

                return JsonSerializer.Deserialize<T>(jsonString, Configs.JsonOptions);
            }
            catch(JsonException ex)
            {
                Console.WriteLine($"Error on JSON format : {ex.Message}");
                return default;
            
            }catch (Exception ex)
            {
                Console.WriteLine($"Error trying to read: {ex.Message}");
                return default;

            }
        }
    }
}