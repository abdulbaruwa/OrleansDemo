using System;
using System.Collections.Generic;
using Ogun.GrainInterfaces.FourEyeModels.Events;

namespace Ogun.GrainInterfaces.FourEyeModels
{
    /// <summary>
    /// Model for an Institution
    /// Ability
    /// 1. Init for a new onboarded institution 
    /// 2. Add Users as Approvers
    /// 3. Remove Users from list of Approvers
    /// 4. Disable, when an user
    /// </summary>
    public class FourEyeInstitution
    {
        public List<DomainEvent<IDomainEventEntity>> Changes { get; set; }
        public string Name { get; private set; }
        public Guid InstitutionId { get; private set; }
        public HashSet<Guid> Approvers { get; private set; }

        public FourEyeInstitution()
        {
            Approvers = new HashSet<Guid>();
            Changes = new List<DomainEvent<IDomainEventEntity>>();
        }

        public void Causes(DomainEvent<IDomainEventEntity> @event)
        {
            AddDomainEvent(@event);
            Apply(@event);
        }

        private void When(NewInstitutionEvent<NewInstitution> @event)
        {
            if (@event.Event is NewInstitution eventBody)
            {
                InstitutionId = eventBody.InstitutionId;
                Name = eventBody.Name;
            }
        }

        private void When(UserAddedToInstitutionEvent<UserAddedToInstitution> @event)
        {
            Approvers.Add(((UserAddedToInstitution)@event.Event).UserId);
        }

        private void When(UserRemovedFromInstitutionEvent<UserRemovedFromInstitution> @event)
        {
            Approvers.Remove(((UserAddedToInstitution)@event.Event).UserId);
        }

        private void AddDomainEvent(DomainEvent<IDomainEventEntity> domainEvent)
        {
            Changes.Add(domainEvent);
        }

        private void Apply(DomainEvent<IDomainEventEntity> @event)
        {
            When((dynamic) @event);
        }
    }
}