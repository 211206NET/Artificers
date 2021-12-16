namespace BL;

public class RRBL : IBL
{
    //private FileRepo _dl;
    //private DBRepo _dl;
    private IRepo _dl;

    public RRBL(IRepo repo)
    {
        //_dl = new FileRepo();
        _dl = repo;
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

