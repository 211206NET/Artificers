namespace Models;

// create class for users-> username, password, first and last name

public class User {

    public User() {}
    public string UserID{ get; set; }
    public string Username{ get; set; }
    public string Password{ get; set; }
    public string Name{ get; set; } 
    public List<Order> Orders { get; set; }
}
