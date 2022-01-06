using Microsoft.Data.SqlClient;
using Models;

namespace DL;

public class DBRepo : IRepo
{
    private string _connectionString;

    public DBRepo(string connectionString) {
        _connectionString = connectionString;
        Console.WriteLine(_connectionString);
    }

    public List<Store> GetAllStores()
    {
        List<Store> allStore = new List<Store>();

        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            string queryTxt = "SELECT* FROM Store";
            using(SqlCommand cmd = new SqlCommand(queryTxt, connection))
            {   
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Store sto = new Store();
                        sto.StoreID = reader.GetInt32(0);
                        sto.StoreName = reader.GetString(1);
                        sto.City = reader.GetString(2);
                        sto.State = reader.GetString(3);

                        allStore.Add(sto);
                    }
                }
            }

            connection.Close();
        }
        return allStore;
    }
}

    