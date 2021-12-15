using Models;

namespace DL;

public static class StaticStorage
{
    
    //Will make only one list: static
    private static List<Store> _allStore = new List<Store>(); 
    
    /// <summary>
    /// Returns all stores from _allStore List
    /// </summary>
    /// <returns>_allStore</returns>
    public static List<Store> GetAllStores()
    {
        return StaticStorage._allStore;
    }

    /// <summary>
    /// Adds a new store to the list
    /// </summary>
    /// <param name="storeToAdd"></param>
    public static void AddStore(Store storeToAdd)
    {
        StaticStorage._allStore.Add(storeToAdd);
    }

    /// <summary>
    /// Adds clay object to the clay List that the user has selected
    /// </summary>
    /// <param name="clayIndex"></param>
    /// <param name="clayToAdd"></param>
    public static void AddClay(int clayIndex, Clay clayToAdd)
    {
        StaticStorage._allStore[clayIndex].locClay.Add(clayToAdd);
    }
}