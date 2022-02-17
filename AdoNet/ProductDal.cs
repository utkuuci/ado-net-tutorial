using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet
{
    public class ProductDal
    {
        SqlConnection _connection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=ETrade;integrated security=true");
        internal List<Product> GetAll()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            SqlCommand command = new SqlCommand("Select * From Products", _connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = Convert.ToString(reader["Name"]),
                    StockAmount = Convert.ToInt32(reader["StockAmount"]),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                };
                products.Add(product);

            }
            reader.Close();
            _connection.Close();
            return products;
        }
        internal void Add(Product product)
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            SqlCommand command = new SqlCommand("Insert Into Products values(@name,@unitPrice,@stockAmount)", _connection);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.ExecuteNonQuery();
            _connection.Close();
        }
        //public DataTable GetAll()
        //{
        //    SqlConnection connection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=ETrade;integrated security=true");
        //    if(connection.State == ConnectionState.Closed)
        //    {
        //        connection.Open();
        //    }
        //    SqlCommand command = new SqlCommand("Select * From Products", connection);
        //    SqlDataReader reader = command.ExecuteReader();
        //    DataTable dataTable = new DataTable();
        //    dataTable.Load(reader);
        //    reader.Close();
        //    connection.Close();
        //    return dataTable;
        //}
    }
}
