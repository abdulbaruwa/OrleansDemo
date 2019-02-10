using System;
using System.Collections.Generic;
using Ogun.GrainInterfaces.FourEyeModels.Events;

namespace Ogun.GrainInterfaces.FourEyeModels
{
    public class FourEyeActionConfiguration
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public HashSet<Guid> Approvers { get; private set; }
        public HashSet<Guid> Institutions { get; private set; }

        public void Apply(UserAddedToConfigurationEvent @event)
        {
            if (Approvers == null)
            {
                Approvers = new HashSet<Guid>();
            }

            Approvers.Add(@event.Id);
        }
        public void Apply(InstitutionAddedToConfigurationEvent @event)
        {
            if (Institutions == null)
            {
                Institutions = new HashSet<Guid>();
            }
            Institutions.Add(@event.Id);
        }

        public void Apply(NewFourEyeConfigurationRequestEvent @event)
        {
            Name = @event.Name;
            Id = @event.Id;
        }
    }
}