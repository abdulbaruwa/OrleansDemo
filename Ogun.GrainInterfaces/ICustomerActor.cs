using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans;
using Orleans.Concurrency;

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

    [Serializable, Immutable]
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
    [Serializable, Immutable]
    public class CustomerState
    {
        public CustomerState()
        {
            Accounts = new HashSet<Guid>();
        }

        public string Name { get; private set; }
        public HashSet<Guid> Accounts{get;}

        public void Apply(NewCustomerEvent @event)
        {
            this.Name = @event.Name;
        }

        public void Apply(AddAccountEvent @event)
        {
            this.Accounts.Add(@event.Account);
        }
    }

    [Serializable, Immutable]
    public class AddAccountEvent
    {
        public AddAccountEvent(Guid account)
        {
            Account = account;
        }

        public Guid Account { get; private set; }

    }
    [Serializable, Immutable]
    public class NewCustomerEvent{
        public NewCustomerEvent(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
