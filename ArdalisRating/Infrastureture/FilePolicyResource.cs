using System.IO;

namespace ArdalisRating.Infrastureture
{
    public class FilePolicyResource:IPolicyFileLoader
    {
        public string LoadPolicyFile()
        {
            return File.ReadAllText("policy.json");
        }

    }
}
