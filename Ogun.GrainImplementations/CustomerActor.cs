using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ogun.GrainInterfaces;
using Orleans;

namespace Ogun.GrainImplementations
{
    public class CustomerActor : Grain, ICustomerActor
    {
        public Task NewAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<List<Guid>> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetDetails()
        {
            throw new NotImplementedException();
        }

        public Task AddAccount(Guid account)
        {
            throw new NotImplementedException();
        }
    }
}