using System;
using System.Collections.Generic;
using Ogun.GrainInterfaces.FourEyeModels.Events;

namespace Ogun.GrainInterfaces.FourEyeModels
{
    public class FourEyeActionConfiguration
    {
        public HashSet<DomainEvent<IDomainEventEntity>> Changes { get; set; }
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public HashSet<Guid> Approvers { get; private set; }
        public HashSet<Guid> Institutions { get; private set; }

        public FourEyeActionConfiguration()
        {
            Changes = new HashSet<DomainEvent<IDomainEventEntity>>();
            Approvers = new HashSet<Guid>();
        }

        public void Causes(DomainEvent<IDomainEventEntity> @event)
        {
            if (Apply(@event))
            {
                AddDomainEvent(@event);
            }
        }

        public bool When(UserAddedToConfigurationEvent @event)
        {
            if (Approvers == null)
            {
                Approvers = new HashSet<Guid>();
            }

            Approvers.Add(@event.Id);
            return true;
        }

        public bool When(InstitutionAddedToConfigurationEvent @event)
        {
            if (Institutions == null)
            {
                Institutions = new HashSet<Guid>();
            }

            Institutions.Add(@event.Id);
            return true;
        }

        public bool When(NewFourEyeConfigurationEvent<NewFourEyeConfiguration> @event)
        {
            if (!string.IsNullOrEmpty(Name)) return false;
            if (@event.Event is NewFourEyeConfiguration eventBody)
            {
                Name = eventBody.Name;
                Id = @eventBody.Id;
                return true;
            }

            return false;
        }

        private bool Apply(DomainEvent<IDomainEventEntity> @event)
        {
            return When((dynamic) @event);
        }

        private void AddDomainEvent(DomainEvent<IDomainEventEntity> @event)
        {
            Changes.Add(@event);
        }
    }
}