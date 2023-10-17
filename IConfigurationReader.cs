namespace TestAssignmentVM_Melnyk_Mykhailo
{
    public interface IConfigurationReader
    {
        string GetConnectionString();
        IDictionary<string, string> GetParameters();
    }
}
