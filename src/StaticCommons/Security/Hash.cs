using System.Security.Cryptography;

namespace StaticCommons.Security
{
    public static class Hash
    {

        public static SHA256 GetSha256Hash()
        {
            var sha256 = SHA256.Create();
            return sha256;
        }


        public static string GetMd5Hash(string input)
        {
            var md5 = MD5.Create();
            var inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            var hash = md5.ComputeHash(inputBytes);
            var sb = new System.Text.StringBuilder();
            foreach (var t in hash)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
