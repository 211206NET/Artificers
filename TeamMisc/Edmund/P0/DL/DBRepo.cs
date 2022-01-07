using Microsoft.Data.SqlClient;
using Models;
using System.Data;

namespace DL;

public class DBRepo : IRepo
{
    private string _connectionString;

    public DBRepo(string connectionString) {
        _connectionString = connectionString;
        Console.WriteLine(_connectionString);
    }


    public void AddStore(Store storeToAdd)
    {
        string selectCmd = "SELECT" FROM STORE";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {

        
            using(SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd,_connectionString))
            {
            DataSet stoSet = new DataSet();
            dataAdapter.Fill(stoSet, "Store");

            DataTable stoTable = stoSet.Tables["Store"];

            // foreach(DataRow row in stoTable.Rows)
            // {
            //     Console.WriteLine(row["Id"]);
            // }

            DataRow newRow = stoTable.NewRow();
            newRow["Name"] = storeToAdd.Name;
            newRow["City"] = storeToAdd.City ?? "";
            newRow["State"] = storeToAdd.State ?? "";

            stoTable.Rows.Add(newRow);

            string insertCmd = $"INSERT INTO Store (Name, City, State) VALUES (' {storeToAdd.Name}', '{storeToAdd.City}', '{storeToAdd.State}')";

            dataAdapter.InsertCommand = new SqlCommand(insertCmd, connection);


            dataAdapter.Update(stoTable);

            }
        }
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

    