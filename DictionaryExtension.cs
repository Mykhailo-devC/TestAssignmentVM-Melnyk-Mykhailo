using System.Text;

namespace TestAssignmentVM_Melnyk_Mykhailo
{
    public static class DictionaryExtension
    {
        public static void PrintAllPairs(this IDictionary<string, string> source)
        {
            var builder = new StringBuilder();

            foreach(var pair in source)
            {
                builder.AppendFormat("{0}: {1}\n", pair.Key, pair.Value);
            }

            Console.WriteLine(builder.ToString());
        }
    }
}
