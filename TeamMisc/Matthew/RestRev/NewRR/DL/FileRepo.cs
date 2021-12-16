using System.Text.Json;

namespace DL;

//Repository Design Pattern

//Read/Write to file
public class FileRepo : IRepo
{
    public FileRepo(){}

    //private string filePath = "C:/Users/khyri/Revature/NETFS/team-Artificers/TeamMisc/Matthew/RestRev/NewRR/RR";
    private string filePath = "../DL/Rest.json";
    //GetAllRest from file
    public List<Rest> GetAllRest()
    {
        //returns all Rest
        string jsonString = File.ReadAllText(filePath);
        //Console.WriteLine($"jsonString: {jsonString}");

        // List<Rest> allRest = JsonSerializer.
        // Deserialize<List<Rest>>(jsonString);

        // foreach (Rest resto in allRest)
        // {
        //     if(resto.Reviews != null)
        //     {
        //         //Console.WriteLine(review.Rating);
        //     }
        // }

        return JsonSerializer.Deserialize<List<Rest>>(jsonString);
    }

    public Rest GetRestByIndex(int index)
    {

        //GetAllRest();//Dont need string, JsonSerializer etc, use this
        // string jsonString = File.ReadAllText(filePath);
        // List<Rest> allRest = JsonSerializer.
        // Deserialize<List<Rest>>(jsonString);

        List<Rest>allRest = GetAllRest();

        // for(int i = 0; i < allRest.Count; i++)
        // {
        //     if(i == index)
        //     {
        //         return allRest[i];
        //     }
        // }

        //or...
        return allRest[index];
 
    }

    //AddRest to a file
    public void AddRest(Rest restToAdd)
    {
        //StaticStorage._allRest.Add(restToAdd);
        List<Rest> allRest = GetAllRest();
        allRest.Add(restToAdd);

        string jsonStr = JsonSerializer.Serialize(allRest);
        File.WriteAllText(filePath, jsonStr);
    }

    //AddReview to file
    public void AddReview(int restIndex, Review reviewToAdd)
    {
        //StaticStorage._allRest[restIndex].Reviews.Add(reviewToAdd);
        List<Rest> allRest = GetAllRest();

        Rest selectRest = allRest[restIndex];

        if(selectRest.Reviews == null)
        {
            selectRest.Reviews = new List<Review>();
        }
        selectRest.Reviews.Add(reviewToAdd);

        string jsonString = JsonSerializer.Serialize(allRest);
        File.WriteAllText(filePath, jsonString);
    }

} 

