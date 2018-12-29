﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ogun.GrainInterfaces;
using Orleans.EventSourcing;
using Orleans.Providers;

namespace Ogun.GrainImplementations
{
    [StorageProvider(ProviderName = "GloballySharedAzureAccount")]
    public class CustomerActor : JournaledGrain<CustomerState>, ICustomerActor
    {
        public Task NewAsync(Customer customer)
        {
             RaiseConditionalEvent(new NewCustomerEvent(customer.Name));
            return Task.CompletedTask;
        }

        public Task<List<Guid>> GetAccountsAsync()
        {
            return Task.FromResult(this.State.Accounts.ToList());
        }

        public Task<Customer> GetDetailsAsync()
        {
            return Task.FromResult(new Customer(this.State.Name));
        }

        public Task AddAccountAsync(Guid account)
        {
            return Task.FromResult(RaiseConditionalEvent(new AddAccountEvent(account)));
        }
    }
}