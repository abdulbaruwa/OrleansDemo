using System;
using System.Collections.Generic;
using Ogun.GrainInterfaces.FourEyeModels.Events;

namespace Ogun.GrainInterfaces.FourEyeModels
{
    public class FourEyeUserManager
    {
        public HashSet<Guid> Approvers { get; private set; }

        public void Apply(UserAddedEvent @event)
        {
            if (Approvers == null)
            {
                Approvers = new HashSet<Guid>();
            }

            Approvers.Add(@event.UserId);
        }

    }
}