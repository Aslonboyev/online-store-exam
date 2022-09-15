using System.Text;
using System.Text.RegularExpressions;

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

        public static bool IsEmial(this string text)
        {
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            RegexOptions.CultureInvariant | RegexOptions.Singleline);
            
            return regex.IsMatch(text);
        }

        public static bool IsPhoneNumber(this string number)
        {
            return number.StartsWith("+998") && Regex.Match(number, @"^(\+[0-9]{12})$").Success;
        }
    }
}
