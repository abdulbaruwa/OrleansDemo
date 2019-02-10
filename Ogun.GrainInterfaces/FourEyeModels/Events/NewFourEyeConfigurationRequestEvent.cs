using System;
using Orleans.Concurrency;

namespace Ogun.GrainInterfaces.FourEyeModels.Events
{
    [Serializable, Immutable]
    public class NewFourEyeConfigurationRequestEvent
    {
        public NewFourEyeConfigurationRequestEvent(Guid id, string name)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; }
        public Guid Id { get; }
    }
}