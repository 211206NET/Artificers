namespace Models;

// create class for store-> username, password, first and last name

public class Store {
    public string StoreID{ get; set; }

    public string StoreName{ get; set; }

    public string City{ get; set; }

    public string State{ get; set; } 

    public string Address { get; set; }

    public List<Inventory> Inventories { get; set; }

    public List<Order> Orders { get; set; }

}

// return sports clothing apparel, sports equipment, shoes