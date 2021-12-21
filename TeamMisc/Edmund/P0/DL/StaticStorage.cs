using Model;
namespace DL;
public static class StaticStorage
{
private static List<User> _UserList = new List<User>();

}

public static void AddUser(User userToAdd){
    StaticStorage._UserList.Add(userToAdd);
}