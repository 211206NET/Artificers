using Models;

namespace DL;

public class StaticStorage : IRepo
{
    private static List<Rest> _allRest = new List<Rest>(); //Will make only one list: static
    
    /// <summary>
    /// Returns all restaurants from _allRestaurants List
    /// </summary>
    /// <returns>all rest in the list</returns>
    public List<Rest> GetAllRest()
    {
        return StaticStorage._allRest;
    }

    /// <summary>
    /// Adds a rest to the list
    /// </summary>
    /// <param name="restToAdd"></param>
    public void AddRest(Rest restToAdd)
    {
        StaticStorage._allRest.Add(restToAdd);
    }

    public void AddReview(int restIndex, Review reviewToAdd)
    {
        StaticStorage._allRest[restIndex].Reviews.Add(reviewToAdd);
    }

}


//StaticStorage ss = new StaticStorage(); not needed
//StaticStorage.   use

//dotnet add reference ../Models
