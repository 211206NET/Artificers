namespace Models;

public class LineItem
{
    public LineItem ID { get; set; }   
    public Product ID { get; set; }
    public int OrderId { get; set; }
    public int Quantity { get; set; }
}