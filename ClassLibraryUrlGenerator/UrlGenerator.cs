using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryUrlGenerator
{
    public static class UrlGenerator
    {
        public static string Generate(List<string> urlsColletion)
        {
            bool isUnique = false;
            string result = null;

            while (!isUnique)
            {
               result = GenerateUrl();

                if (!urlsColletion.Contains(result))
                {
                    isUnique = true;    
                }
            }
            return result;
        }

        private static string GenerateUrl()
        {
            char[] set = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
            var url = new StringBuilder(@"http://localhost:5000/Home/R?t=");
            var rnd = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < 6; ++i)
            {
                url.Append(set[rnd.Next(16)]);
            }

            return url.ToString();
        }
    }
}
