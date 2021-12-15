//namespace RestaurantReviews;
//using Models;
namespace Models;

public class Rest {

    //In a rest. I want to store Name, City, State...
    public Rest()
    {
        this.Reviews = new List<Review>();
    }

    public Rest(string name)
    {
        this.Reviews = new List<Review>();
        this.Name = name;
    }

    //This is a property, a type member
    //Access modifier controls visibility of type and type members
    //There are four Public, Private, Internal, Protected
    //Public most visible, Private least visible
    //By default class members have private
    //Class, by default, are internal unless you explicitely say otherwise
    public string Name { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public List<Review> Reviews { get; set; }
    //public List<Review> Reviews { get; }

    //private string _name; //Underscore to denote private var

    // public string GetName(){
    //     return this._name;
    // }

    // public void SetName(string name){
    //     this._name = name;
    // }
}