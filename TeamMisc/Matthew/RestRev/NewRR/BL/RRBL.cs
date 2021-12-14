using Models;
using DL;

namespace BL;

public class RRBL
{
    
    public List<Rest> GetAllRest()
    {
        return StaticStorage.GetAllRest();
    }

    public void AddRest(Rest restToAdd)
    {
        StaticStorage.AddRest(restToAdd);
    }

    public void AddReview(int restIndex, Review reviewToAdd)
    {
        
    }
}

