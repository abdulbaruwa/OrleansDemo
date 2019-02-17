using System;
using Ogun.GrainInterfaces.FourEyeModels;
using Ogun.GrainInterfaces.FourEyeModels.Events;
using Xunit;

namespace Ogun.Tests
{
    public class ConfigurationSpecs
    {
        [Fact]
        public void Handle_NewFourEyeConfigurationRequestEvent_Should_SetState_accordingly()
        {
            var sut = new FourEyeActionConfiguration();
            var eventId = Guid.NewGuid();
            var actionConfigName = "ActionConfig_Test";
            var actionConfigId = Guid.NewGuid();
            var @event = new NewFourEyeConfigurationEvent<NewFourEyeConfiguration>(eventId,actionConfigName, DateTime.UtcNow, new NewFourEyeConfiguration(actionConfigId, actionConfigName));
            sut.Causes(@event);

            Assert.Contains(@event, sut.Changes);
            Assert.Equal(actionConfigName, sut.Name);
            Assert.Equal(actionConfigId, sut.Id);
        }
    }
}