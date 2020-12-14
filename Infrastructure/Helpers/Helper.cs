using System;
using System.Linq;

namespace Infrastructure.Helpers
{
    public class Helper
    {
   
        public static string RandomNumber(int length)
        {
            Random random = new Random();
            const string chars = "0123456789ABCDEGHKMNPQRSTVWXY";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
