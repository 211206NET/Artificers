using System.Text.Json;
using Models;

namespace DL;

//This class reads and writes to the file
public class FileRepo : IRepo
{
    public FileRepo()
    { }

    private string filePath = "../DL/Store.json";

 
    public List<Store> GetAllStores()
    {
        string jsonString = "";
        try
        {
            jsonString = File.ReadAllText(filePath);
        }
        catch(FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return JsonSerializer.Deserialize<List<Store>>(jsonString) ?? new List<Store>();
    }
}