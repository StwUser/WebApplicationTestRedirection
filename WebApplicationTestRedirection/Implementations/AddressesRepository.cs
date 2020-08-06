using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationTestRedirection.Interfaces;
using WebApplicationTestRedirection.Models;

namespace WebApplicationTestRedirection.Implementations
{
    public class AddressesRepository : IAddressesRepository
    {
        private readonly AddressContext _db;
        public AddressesRepository(AddressContext context)
        {
            _db = context;
        }

        public IEnumerable<Address> GetAddresses()
        {
            return _db.Addresses;
        }

        public Address GetAddress(int id)
        {
            var address = _db.Addresses
            .Where(s => s.Id == id)
            .FirstOrDefault<Address>();
            return address;
        }

        public void AddAddress(Address address)
        {
            _db.Add(address);
            _db.SaveChanges();
        }

        public void UpdateAddress(int id, Address address)
        {
            var oldAddress = GetAddress(id);
            oldAddress.LongUrl = address.LongUrl;
            oldAddress.ShortUrl = address.ShortUrl;
            oldAddress.CreationData = address.CreationData;
            oldAddress.Transitions = address.Transitions;
            _db.SaveChanges();
        }

        public void DeleteAddress(int id)
        {
            var delAddress = GetAddress(id);
            _db.Remove(delAddress);
            _db.SaveChanges();
        }
    }
}
