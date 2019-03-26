using BlLayer.Interface;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTOLayer;

namespace BlLayer
{
   public class Taskdatatprovider:ITask
    {
        public List<Productdetail> Product()
        {
            List<Productdetail> productlist = new List<Productdetail>();

            string consString = @"Data Source=AYUSH;Initial Catalog=StudentsDB;Trusted_Connection=True";
            SqlConnection con = new SqlConnection(consString);

            SqlCommand cmd = new SqlCommand("select * from Product", con);
            con.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                // Check is the reader has any rows at all before starting to read.
                while (reader.Read())
                {
                    Productdetail Productitem = new Productdetail();
                    Productitem.Price = Convert.ToInt32(reader["Price"]);
                    Productitem.ID = Convert.ToInt32(reader["id"]);
                    Productitem.Product = reader["name"].ToString();
                    productlist.Add(Productitem);
                }

            }
            return productlist;
        }

        public bool ProductOperation(string CommandName, int id = 0, string Product = "", int Price = 0)
        {

            SqlCommand cmd = new SqlCommand();
            List<Productdetail> productlist = new List<Productdetail>();
            string consString = @"Data Source=AYUSH;Initial Catalog=StudentsDB;Trusted_Connection=True";
            SqlConnection con = new SqlConnection(consString);
            if(CommandName=="Edit")
            {
                 cmd = new SqlCommand("Update Product set price = "+ Price+"  where id ="+id+"", con);
            }
            if(CommandName=="Delete")
            {
                 cmd = new SqlCommand("Delete from Product where id="+id+"", con);
            }
            if(CommandName=="ADD")
            {
                Product = String.Concat("'", Product, "'");
                String query = "INSERT INTO Product (name,Price) VALUES ("+ Product + ", "+ Price + ")";
              
                cmd = new SqlCommand(query, con);
                //cmd.Parameters.Add("@Name", Product);
                //cmd.Parameters.Add("@Price", Price);
            }
            
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            return true;
        }
    }
}
