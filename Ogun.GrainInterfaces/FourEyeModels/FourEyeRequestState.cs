using System;
using Ogun.GrainInterfaces.FourEyeModels.Events;
using Orleans.Concurrency;

namespace Ogun.GrainInterfaces.FourEyeModels
{
    [Serializable, Immutable]
    public class FourEyeRequestState
    {
        public string Name { get; private set; }
        public TimeSpan Timeout { get; private set; }
        public void Apply(NewRequestEvent @event)
        {
            Name = @event.Name;
            Timeout = @event.TimeOut;
        }
    }
}