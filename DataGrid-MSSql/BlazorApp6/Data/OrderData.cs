using System.Data;
using System.Data.SqlClient;

namespace BlazorApp6.Data
{
    
    public class OrderData
    {        
        public async Task<List<Order>> GetOrdersAsync()
        {
            string ConnectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\VigneshNatarajan\\Downloads\\BlazorApp6\\BlazorApp6\\BlazorApp6\\App_Data\\NORTHWND.MDF;Integrated Security=True;Connect Timeout=30";            
            string Query = "SELECT * FROM dbo.Orders ORDER BY OrderID;";
            List<Order> Orders = null;
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter Ddapter = new SqlDataAdapter(Query, Connection);
                DataSet Data = new DataSet();
                Connection.Open();
                // Using SqlDataAdapter, we process the query string and fill the data into the dataset
                Ddapter.Fill(Data);
                Orders = Data.Tables[0].AsEnumerable().Select(r => new Order
                {
                    OrderID = r.Field<int>("OrderID"),
                    CustomerID = r.Field<string>("CustomerID"),
                    EmployeeID = r.Field<int>("EmployeeID"),
                    ShipCity = r.Field<string>("ShipCity"),
                    Freight = r.Field<decimal>("Freight")
                }).ToList();
                Connection.Close();
            }
            return Orders;
        }
        public async Task AddOrderAsync(Order Value)
        {
            string ConnectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\VigneshNatarajan\\Downloads\\BlazorApp6\\BlazorApp6\\BlazorApp6\\App_Data\\NORTHWND.MDF;Integrated Security=True;Connect Timeout=30";
            string Query = $"Insert into Orders(CustomerID,Freight,ShipCity,EmployeeID) values('{(Value as Order).CustomerID}','{(Value as Order).Freight}','{(Value as Order).ShipCity}','{(Value as Order).EmployeeID}')";
            SqlConnection Connection = new SqlConnection(ConnectionString);
            Connection.Open();
            SqlCommand SqlCommand = new SqlCommand(Query, Connection);
            SqlCommand.ExecuteNonQuery();
            Connection.Close();
        }

        public async Task UpdateOrderAsync(Order Value)
        {
            string ConnectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\VigneshNatarajan\\Downloads\\BlazorApp6\\BlazorApp6\\BlazorApp6\\App_Data\\NORTHWND.MDF;Integrated Security=True;Connect Timeout=30";
            string Query = $"Update Orders set CustomerID='{(Value as Order).CustomerID}', Freight='{(Value as Order).Freight}',EmployeeID='{(Value as Order).EmployeeID}',ShipCity='{(Value as Order).ShipCity}' where OrderID='{(Value as Order).OrderID}'";
            SqlConnection Connection = new SqlConnection(ConnectionString);
            Connection.Open();
            SqlCommand SqlCommand = new SqlCommand(Query, Connection);
            SqlCommand.ExecuteNonQuery();
            Connection.Close();
        }

        public async Task RemoveOrderAsync(int? Key)
        {
            string ConnectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\VigneshNatarajan\\Downloads\\BlazorApp6\\BlazorApp6\\BlazorApp6\\App_Data\\NORTHWND.MDF;Integrated Security=True;Connect Timeout=30";
            string Query = $"Delete from Orders where OrderID={Key}";
            SqlConnection Connection = new SqlConnection(ConnectionString);
            Connection.Open();
            SqlCommand SqlCommand = new SqlCommand(Query, Connection);
            SqlCommand.ExecuteNonQuery();
            Connection.Close();
        }        
    }
    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public decimal Freight { get; set; }
        public string ShipCity { get; set; }
    }
}
