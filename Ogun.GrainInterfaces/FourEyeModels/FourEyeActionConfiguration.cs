using System;
using System.Collections.Generic;
using Ogun.GrainInterfaces.FourEyeModels.Events;

namespace Ogun.GrainInterfaces.FourEyeModels
{
    public class FourEyeActionConfiguration
    {
        public List<DomainEvent<IDomainEventEntity>> Changes { get; set; }
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public HashSet<Guid> Approvers { get; private set; }
        public HashSet<Guid> Institutions { get; private set; }

        public FourEyeActionConfiguration()
        {
            Changes = new List<DomainEvent<IDomainEventEntity>>();
            Approvers = new HashSet<Guid>();
        }

        public void Causes(DomainEvent<IDomainEventEntity> @event)
        {
            AddDomainEvent(@event);
            Apply(@event);
        }

        private void Apply(DomainEvent<IDomainEventEntity> @event)
        {
            When((dynamic) @event);
        }

        private void AddDomainEvent(DomainEvent<IDomainEventEntity> @event)
        {
            Changes.Add(@event);
        }

        public void When(UserAddedToConfigurationEvent @event)
        {
            if (Approvers == null)
            {
                Approvers = new HashSet<Guid>();
            }

            Approvers.Add(@event.Id);
        }

        public void When(InstitutionAddedToConfigurationEvent @event)
        {
            if (Institutions == null)
            {
                Institutions = new HashSet<Guid>();
            }

            Institutions.Add(@event.Id);
        }

        public void When(NewFourEyeConfigurationEvent<NewFourEyeConfiguration> @event)
        {
            if (@event.Event is NewFourEyeConfiguration eventBody)
            {
                Name = eventBody.Name;
                Id = @eventBody.Id;
            }
        }
    }
}