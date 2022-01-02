namespace Models;

public class LineItem
{
    public LineItem ID { get; set; }   
    
    public ProductID { get; set; }
    public int OrderId { get; set; }
    public int Quantity { get; set; }
}