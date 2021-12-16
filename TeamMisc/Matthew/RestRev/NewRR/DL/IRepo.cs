namespace DL;

/*Interface is a contract in essence
It enforces that any type that implements
the interface must also also implement interface members
As public methods
We use interface to define/enforce a certain set of behavior
on a type such as class, example of abstraction (1 of 4 OOP pillars)
Other OOP pillars are Polymorphism, Inheritance and Encapsulation
Interfaces can only have methods*/
public interface IRepo //These don't do anything, themselves, just enforce that all methods must be implemented
{
    //No access modifiers, Implicitely public
    List<Rest> GetAllRest();

    void AddRest(Rest restToAdd);

    void AddReview(int restIndex, Review reviewToAdd);

    //Rest SearchRest(string searchString);
} 