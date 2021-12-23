using Models;
namespace DL;
public static class StaticStorage
{

//below is the method for User List
private static List<User> _UserList = new List<User>();

public static List <User> GetAllUsers()
{
    return StaticStorage._UserList;
}
public static void AddUser(User userToAdd)
{
    StaticStorage._UserList.Add(userToAdd);

}
//below is the method for Store List
private static List<Store> _StoreList = new List<Store>();

public static List <Store> GetAllStores()
{

    return StaticStorage._StoreList;
}

public static void AddStore(Store storeToAdd)
{
    StaticStorage._StoreList.Add(storeToAdd);

}

// end of class bracket
}

