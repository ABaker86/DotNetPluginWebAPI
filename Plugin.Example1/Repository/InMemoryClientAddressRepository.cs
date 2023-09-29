namespace Plugin.Example1;
using Plugin.Example1.Models;
using System.Data.Common;
using System.Linq;

public class InMemoryClientAddressRepository : IStandardRepository
{

    public List<ClientAddress> Addresses = new List<ClientAddress>()
    {
        new ClientAddress(){Id = 1, City="Chicago", PostalCode="12345", State="IL", StreetAddress1="Main St."},
        new ClientAddress(){Id = 2, City="Chicago", PostalCode="12345", State="IL", StreetAddress1="Dunham Dr."}
    };

    public IEnumerable<ClientAddress> GetAll() => Addresses;

    public ClientAddress GetById(int id)
    {
        if(!Addresses.Any(x => x.Id.Equals(id)))
            throw new KeyNotFoundException($"No key with {id} exists");
        return Addresses.FirstOrDefault(x => x.Id.Equals(id));
    }

    public ClientAddress Update(ClientAddress data)
    {
        if (!Addresses.Any(x => x.Id.Equals(data.Id)))
            throw new KeyNotFoundException($"Unable to update data. No key with {data.Id} exists");

        Addresses = Addresses.Where(x => !x.Id.Equals(data.Id)).ToList();
        Addresses.Add(data);
        return data;
    }

    public bool Delete(ClientAddress data)
    {
        if (Addresses.Any(x => x.Id.Equals(data.Id)))
        {
            Addresses = Addresses.Where(x => !x.Id.Equals(data.Id)).ToList();
            return true;
        }
        else
        {
            return false;
        }
    }

    public IEnumerable<ClientAddress> Insert(IEnumerable<ClientAddress> data)
    {
        if(null == data || data == Enumerable.Empty<ClientAddress>())
            throw new ArgumentNullException(nameof(data));

        data.ToList()
            .ForEach(address => Addresses.Add(address));
        return data;
    }
}