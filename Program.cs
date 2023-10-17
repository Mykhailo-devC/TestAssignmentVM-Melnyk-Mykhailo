using System.Data.SqlClient;
using TestAssignmentVM_Melnyk_Mykhailo;

IConfigurationReader reader = new ConfigurationReader();

Console.WriteLine("Connection string: {0}", reader.GetConnectionString());

using(SqlConnection connection = new SqlConnection(reader.GetConnectionString()))
{
    connection.Open();
    Console.WriteLine(connection.State);
    connection.Close();
}

Console.WriteLine();
Console.WriteLine("Parameters: ");
reader.GetParameters().PrintAllPairs();

