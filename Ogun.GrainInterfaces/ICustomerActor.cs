using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans;

namespace Ogun.GrainInterfaces
{

    public interface ICustomerActor : IGrainWithIntegerKey
    {
        Task NewAsync(Customer customer);
        Task<List<Guid>> GetAccounts();
        Task<Customer> GetDetails();
        Task AddAccount(Guid account);
    }

    public class NewCustomerRequest
    {
        public string Name { get; set; }
    }

    [Serializable]
    public class Customer
    {
        public Customer(string name)
        {
            Name = name;
            Accounts = new HashSet<Guid>();
        }

        public string Name { get; }
        public HashSet<Guid> Accounts{get;}
    }
}
