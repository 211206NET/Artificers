using Models;
using DL;

namespace BL;
public class CSBL
{

    public List<Store> GetAllStores()
    {
        return StaticStorage.GetAllStores();
    }


    public void AddStore(Store storeToAdd)
    {
        StaticStorage.AddStore(storeToAdd);
    }


    public void AddClay(int storeIndex, Clay clayToAdd)
    {
        StaticStorage.AddClay(storeIndex, clayToAdd);
    }
}
