namespace Models;

public class Inventory 
{
    public int InventoryId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public Product Item { get; set; }
    
}