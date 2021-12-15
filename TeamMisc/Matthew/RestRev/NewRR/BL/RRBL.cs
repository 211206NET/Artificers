using Models;
using DL;

namespace BL;

public class RRBL
{
    private FileRepo _dl;

    public RRBL()
    {
        _dl = new FileRepo();
    }

    public List<Rest> GetAllRest()
    {
        return _dl.GetAllRest();
    }

    public void AddRest(Rest restToAdd)
    {
        _dl.AddRest(restToAdd);
    }

    public void AddReview(int restIndex, Review reviewToAdd)
    {
        _dl.AddReview(restIndex,reviewToAdd);
    }
}

