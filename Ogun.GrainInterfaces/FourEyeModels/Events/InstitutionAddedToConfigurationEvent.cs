using System;
using Orleans.Concurrency;

namespace Ogun.GrainInterfaces.FourEyeModels.Events
{
    [Serializable, Immutable]
    public class InstitutionAddedToConfigurationEvent
    {
        public InstitutionAddedToConfigurationEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}