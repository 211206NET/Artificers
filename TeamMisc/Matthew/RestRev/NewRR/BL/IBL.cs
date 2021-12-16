namespace BL;

//??
public interface IBL
{
    List<Rest> GetAllRest();

    void AddRest(Rest rest);

    void AddReview(int intRest, Review review);//..
}