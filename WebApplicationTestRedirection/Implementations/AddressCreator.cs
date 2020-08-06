using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationTestRedirection.Models;
using ClassLibraryUrlGenerator;
using ClassLibraryUrlValidator;

namespace WebApplicationTestRedirection.Implementations
{
    public static class AddressCreator
    {
        public static bool Create(Address address, List<string> urlsCollection)
        {
            bool urlExists = UrlValidator.Validate(address.LongUrl);

            if(urlExists)
            {
                address.ShortUrl = UrlGenerator.Generate(urlsCollection);
                address.CreationData = DateTime.Now.ToString("yyyy-MM-dd h:mm tt");
            }
            return urlExists;
        }
    }
}
