using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anti_scam_backend.Services.Helper
{
    public static class RandomString
    {
        public static string Random(int length, string stringArray = "qwertyuiopasdfghjklzxcvbnm123456789")
        {
            StringBuilder arr = new StringBuilder();
            Random ran = new Random();
            for (int i = 0; i < length; i++)
            {
                var index = ran.Next(0, stringArray.Length - 1);
                arr.Append(stringArray[index]);
            }
            return arr.ToString();
        }
    }
}
