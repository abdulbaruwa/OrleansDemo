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
        Task<List<Guid>> GetAccountsAsync();
        Task<Customer> GetDetailsAsync();
        Task AddAccountAsync(Guid account);
    }

    public class NewCustomerRequest
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }

    [Serializable, Immutable]
    public class Customer
    {
        public Customer(int id, string name)
        {
            Name = name;
            Id = id;
            Accounts = new HashSet<Guid>();
        }

        public int Id { get; set; }
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
        public int Id { get; set; }

        public void Apply(NewCustomerEvent @event)
        {
            this.Name = @event.Name;
            this.Id = @event.Id;
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
        public NewCustomerEvent(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }
}
