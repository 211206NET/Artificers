namespace RestaurantReviews;

public class Review {

    //Empty
    public Review(){}

    //Constructor overloading
    public Review(int rating)
    {
        this.Rating = rating;
    }

    public Review(int rating, string note)
    {
        //Console.WriteLine("Constructor has been called");
        this.Rating = rating;
        this.Note = note;
    }

    public int Rating { get; set; }
    public string Note { get; set; } 

}