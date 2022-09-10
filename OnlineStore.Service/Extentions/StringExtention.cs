using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Service.Extentions
{
    public static class StringExtention
    {
        public static string GetHash(this string input)
        {
            var hash = new System.Security.Cryptography.SHA256Managed();
            var bytes = Encoding.UTF8.GetBytes(input);
            var hashByte = hash.ComputeHash(bytes);
            return BitConverter.ToString(hashByte).Replace("-", "");
        }
    }
}
