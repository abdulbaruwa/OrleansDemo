using System;
using System.Collections.Generic;
using Ogun.GrainInterfaces.FourEyeModels.Events;

namespace Ogun.GrainInterfaces.FourEyeModels
{
    public class FourEyeAction
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public HashSet<DomainEvent<IDomainEventEntity>> Changes { get; set; }
        public bool Status { get; private set; } = false;

        public FourEyeAction()
        {
            Changes = new HashSet<DomainEvent<IDomainEventEntity>>();
        }

        public void Causes(DomainEvent<IDomainEventEntity> @event)
        {
            if (Apply(@event))
            {
                AddDomainEvent(@event);
            }
        }

        private bool When(NewFourEyeActionEvent<NewFourEyeAction> @event)
        {
            if (!string.IsNullOrEmpty(Name)) return false;
            if (@event.Event is NewFourEyeAction eventBody)
            {
                Name = eventBody.Name;
                Id = @eventBody.Id;
                return true;
            }

            return false;
        }


        private bool When(ApproveActionEvent<ApproveAction> @event)
        {
            var eventBody = @event.Event as ApproveAction;
            if (eventBody == null || eventBody.Status == Status) return false;
            if (eventBody is ApproveAction action)
            {
                Status = action.Status;
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