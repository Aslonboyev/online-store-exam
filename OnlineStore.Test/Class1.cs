using System.Text.RegularExpressions;
using Xunit;

namespace OnlineStore.Test
{
    public class Class1
    {
        [Theory]
        [InlineData("wdskvn@gmail.com")]
        [InlineData("jdvkvnd@mail.ru")]
        public static void Test(string email)
        {
            bool result = CheckEmail(email);
            Assert.True(result);
        }

        public static bool CheckEmail(string email)
        {
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
         RegexOptions.CultureInvariant | RegexOptions.Singleline);
            return regex.IsMatch(email);
        }
    }
}