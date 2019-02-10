using System;
using Orleans.Concurrency;

namespace Ogun.GrainInterfaces.FourEyeModels.Events
{
    [Serializable, Immutable]
    public class UserAddedEvent
    {
        public UserAddedEvent(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; private set; }
    }
}