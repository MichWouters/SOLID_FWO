using System.IO;

namespace ArdalisRating.Persistence
{
    public class FilePolicySource
    {
        public string GetPolicyFromSource(string path)
        {
            return File.ReadAllText(path);
        }
    }
}