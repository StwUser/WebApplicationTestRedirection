using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationTestRedirection.Models;

namespace WebApplicationTestRedirection.Interfaces
{
    public interface IAddressesRepository
    {
        IEnumerable<Address> GetAddresses();

        Address GetAddress(int id);

        void AddAddress(Address address);

        void UpdateAddress(int id, Address address);

        void DeleteAddress(int id);
    }
}
