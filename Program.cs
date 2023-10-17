using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using TestAssignmentVM_Melnyk_Mykhailo;

IConfigurationReader reader = new ConfigurationReader();

Console.WriteLine("Connection string: {0}", reader.GetConnectionString());

var options = new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer(reader.GetConnectionString())
                .Options;

using (var context = new DataContext(options))
{
    context.Database.EnsureDeleted();
}

Console.WriteLine();
Console.WriteLine("Parameters: ");
reader.GetParameters().PrintAllPairs();

