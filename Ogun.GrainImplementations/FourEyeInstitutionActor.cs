using System;
using System.Threading.Tasks;
using Ogun.GrainInterfaces;
using Ogun.GrainInterfaces.FourEyeModels;
using Ogun.GrainInterfaces.FourEyeModels.Events;
using Orleans;
using Orleans.EventSourcing;
using Orleans.Providers;

namespace Ogun.GrainImplementations
{
    [StorageProvider(ProviderName = "GloballySharedAzureAccount")]
    public class FourEyeInstitutionActor : Grain<FourEyeInstitution>, IFourEyeInstitutionActor
    {
        private FourEyeInstitution GrainState { get; set; }

        public Task NewAsync(NewInstitution fourEyeRequest)
        {
            if (GrainState == null)
            {
                GrainState = new FourEyeInstitution();
                var @event = new NewInstitutionEvent<NewInstitution>(this.GetPrimaryKey(),
                    nameof(NewInstitution), DateTime.UtcNow, fourEyeRequest);
                GrainState.Causes(@event);
                base.WriteStateAsync();
            }

            return Task.CompletedTask;
        }


    }
}