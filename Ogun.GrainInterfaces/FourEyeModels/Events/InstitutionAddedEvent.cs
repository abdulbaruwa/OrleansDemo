using System;
using Orleans.Concurrency;

namespace Ogun.GrainInterfaces.FourEyeModels.Events
{
    [Serializable, Immutable]
    public class InstitutionAddedEvent
    {
        public InstitutionAddedEvent(Guid institutionId)
        {
            InstitutionId = institutionId;
        }

        public Guid InstitutionId { get; private set; }
    }
}