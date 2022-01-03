// using Microsoft.Data.SqlClient;
// using Models;

// namespace DL;

// public class DBRepo : IRepo
// {
//     private string _connectionString;

//     public DBRepo(string connectionString) {
//         _connectionString = connectionString;
//     }

//     public List<Store> GetAllStores()
//     {
//         using(SqlConnection connection = new SqlConnection(_connectionString))
//         {
//             connection.Open();

//             string queryTxt = "SELECT* FROM Store";
//             using(SqlCommand cmd = new SqlCommand(queryTxt, connection))
//             {   
//                 using(SqlDataReader reader = cmd.ExecuteReader())
//                 {
//                     while(reader.Read())
//                     {
//                         Console.WriteLine(reader.GetInt32(0));
//                         Console.WriteLine(reader.GetString(1));
//                     }
//                 }
//             }

//             connection.Close();
//         }
//         return new List<Store>();
//     }
// }

    