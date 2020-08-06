using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryAddressValidator
{
    public class Address
    {
        public int Id { get; set; }
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }

        public string CreationData { get; set; }

        public int Transitions { get; set; }
    }
}
