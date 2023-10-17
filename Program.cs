using TestAssignmentVM_Melnyk_Mykhailo;

IConfigurationReader reader = new ConfigurationReader();

Console.WriteLine("Connection string: {0}", reader.GetConnectionString());
Console.WriteLine("Parameters: ");
reader.GetParameters().PrintAllPairs();

