using System;
using System.Collections.Generic;
using Ogun.GrainInterfaces.FourEyeModels.Events;

namespace Ogun.GrainInterfaces.FourEyeModels
{
    public class FourEyeInstitutionManager
    {
        public HashSet<Guid> Institutions { get; private set; }

        public void Apply(InstitutionAddedEvent @event)
        {
            if (Institutions == null)
            {
                Institutions = new HashSet<Guid>();
            }

            Institutions.Add(@event.InstitutionId);
        }

    }
}