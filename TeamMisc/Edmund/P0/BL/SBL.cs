using DL;
using Models;

namespace BL;
public class SBL : IBL
{
    private IRepo _dl; //DL

    public SBL(IRepo repo)
    {
        _dl = repo;
    }

    public List<Store> GetAllStores()
    {
        return _dl.GetAllStores();
    }
}