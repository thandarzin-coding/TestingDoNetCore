using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingDoNetCore.ConsoleApp.AdoDotNetExamples
{
    public class AdoDotNetExample
    {
        public void Run()
        {
            //Read();
            //Edit(1);
            //Edit(12);
            Create("rrr", "uuu", "ggg");

        }

        public void Read()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "Testing",
                UserID = "sa",
                Password = "sa@123",
                TrustServerCertificate = true
            };
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            Console.WriteLine("Connection opening...");
            connection.Open();
            Console.WriteLine("Connection opened.");

            string query = @"SELECT [Blog_Id]
                  ,[Blog_Title]
                  ,[Blog_Author]
                  ,[Blog_Content]
                   FROM [dbo].[Tbl_Blog] ";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            Console.WriteLine("Connection closing...");
            connection.Close();
            Console.WriteLine("Connection closed.");


            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"Id => {row["Blog_Id"]}");
                Console.WriteLine($"Title => {row["Blog_Title"]}");
                Console.WriteLine($"Author => {row["Blog_Author"]}");
                Console.WriteLine($"Content => {row["Blog_Content"]}");
                Console.WriteLine("------------------------");

            }
        }


        public void Edit(int Id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "Testing",
                UserID = "sa",
                Password = "sa@123",
                TrustServerCertificate = true
            };
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            Console.WriteLine("Connection opening...");
            connection.Open();
            Console.WriteLine("Connection opened.");

            string query = @"SELECT [Blog_Id]
                  ,[Blog_Title]
                  ,[Blog_Author]
                  ,[Blog_Content]
                   FROM [dbo].[Tbl_Blog] where Blog_Id = @Blog_Id";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            command.Parameters.AddWithValue("@Blog_Id", Id);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            Console.WriteLine("Connection closing...");
            connection.Close();
            Console.WriteLine("Connection closed.");

            if(dt.Rows.Count == 0) {
                Console.WriteLine("No  Data Found");
                return;
            }

            DataRow row = dt.Rows[0];            
                Console.WriteLine($"Id => {row["Blog_Id"]}");
                Console.WriteLine($"Title => {row["Blog_Title"]}");
                Console.WriteLine($"Author => {row["Blog_Author"]}");
                Console.WriteLine($"Content => {row["Blog_Content"]}");
                Console.WriteLine("------------------------");

            
        }

        public void Create(string title, string author, string content)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "Testing",
                UserID = "sa",
                Password = "sa@123",
                TrustServerCertificate = true
            };
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            Console.WriteLine("Connection opening...");
            connection.Open();
            Console.WriteLine("Connection opened.");

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([Blog_Title]
           ,[Blog_Author]
           ,[Blog_Content])
           VALUES
           (@Blog_Title
           ,@Blog_Author
           ,@Blog_Content)";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            command.Parameters.AddWithValue("@Blog_Title", title);
            command.Parameters.AddWithValue("@Blog_Author", author);
            command.Parameters.AddWithValue("@Blog_Content", content);
            int result = command.ExecuteNonQuery();
            connection.Close();

            //string message = result > 0 ? "saving successfully" : "successful faild";
            string message;
            if(result > 0 )
            {
                message = "saving successfully";
            }
            else
            {
                message = "Error";
            }

            Console.WriteLine(message);

            

            }
        }


    }


