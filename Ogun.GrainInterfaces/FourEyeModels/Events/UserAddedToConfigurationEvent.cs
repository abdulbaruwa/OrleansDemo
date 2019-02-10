using System;

namespace Ogun.GrainInterfaces.FourEyeModels.Events
{
    public class UserAddedToConfigurationEvent
    {
        public UserAddedToConfigurationEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}