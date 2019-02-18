using System;
using Ogun.GrainInterfaces.FourEyeModels;
using Ogun.GrainInterfaces.FourEyeModels.Events;
using Xunit;

namespace Ogun.Tests
{
    public class ConfigurationSpecs
    {
        public class NewFourEyeConfigurationRequestEvent
        {
            [Fact]
            public void Should_SetState_accordingly()
            {
                var sut = new FourEyeActionConfiguration();
                var eventId = Guid.NewGuid();
                var actionConfigName = "ActionConfig_Test";
                var actionConfigId = Guid.NewGuid();
                var @event = new NewFourEyeConfigurationEvent<NewFourEyeConfiguration>(eventId, actionConfigName,
                    DateTime.UtcNow, new NewFourEyeConfiguration(actionConfigId, actionConfigName));
                sut.Causes(@event);

                Assert.Contains(@event, sut.Changes);
                Assert.Equal(actionConfigName, sut.Name);
                Assert.Equal(actionConfigId, sut.Id);
            }

            [Fact]
            public void Should_Ignore_If_State_already_set()
            {
                var sut = new FourEyeActionConfiguration();
                var eventId = Guid.NewGuid();
                var actionConfigName = "ActionConfig_Test";
                var actionConfigId = Guid.NewGuid();
                var @event = new NewFourEyeConfigurationEvent<NewFourEyeConfiguration>(eventId, actionConfigName,
                    DateTime.UtcNow, new NewFourEyeConfiguration(actionConfigId, actionConfigName));
                sut.Causes(@event);


                var actionConfigName2 = "ActionConfig_Test2";
                var @event2 = new NewFourEyeConfigurationEvent<NewFourEyeConfiguration>(eventId, actionConfigName2,
                    DateTime.UtcNow, new NewFourEyeConfiguration(actionConfigId, actionConfigName2));
                sut.Causes(@event2);

                Assert.Single(sut.Changes);
                Assert.Equal(actionConfigName, sut.Name);
                Assert.Equal(actionConfigId, sut.Id);
            }
        }
    }
}