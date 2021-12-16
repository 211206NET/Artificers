using UI;
using BL;
using DL;
//using RestaurantReviews;
//In .NET 6 I don't need using generic collections here

//List<Rest> allRests = new List<Rest>();

//IRepo>IBL>RRBL

IRepo repo = new FileRepo();
RRBL bl = new RRBL(repo);
MainMenu menu = new MainMenu(bl);
menu.Start();
