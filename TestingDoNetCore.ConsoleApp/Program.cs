﻿
using Microsoft.Data.SqlClient;
using System.Data;
using TestingDoNetCore.ConsoleApp.AdoDotNetExamples;

Console.WriteLine("Hello, World!");
//SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
//{
//    DataSource = ".",
//    InitialCatalog = "Testing",
//    UserID = "sa",
//    Password = "sa@123",
//    TrustServerCertificate = true
//};
//SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
//Console.WriteLine("Connection opening...");
//connection.Open();
//Console.WriteLine("Connection opened.");

//string query = @"SELECT [Blog_Id]
//      ,[Blog_Title]
//      ,[Blog_Author]
//      ,[Blog_Content]
//  FROM [dbo].[Tbl_Blog] ";
//SqlCommand command = new SqlCommand(query, connection);
//SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
//DataTable dataTable = new DataTable();
//sqlDataAdapter.Fill(dataTable);
//Console.WriteLine("Connection closing...");
//connection.Close();
//Console.WriteLine("Connection closed.");


AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
adoDotNetExample.Run();
Console.ReadKey();
//Console.ReadLine();
