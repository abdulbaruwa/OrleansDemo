using System;
using Ogun.GrainInterfaces.FourEyeModels;
using Ogun.GrainInterfaces.FourEyeModels.Events;
using Xunit;

namespace Ogun.Tests
{
    public class ActionSpecs
    {
        public class NewActionRequestEvent
        {
            [Fact]
            public void Should_Set_Action_State_accordingly()
            {
                var sut = new FourEyeAction();
                var eventId = Guid.NewGuid();
                var actionConfigName = "ActionConfig_Test";
                var actionConfigId = Guid.NewGuid();
                var @event = new NewFourEyeActionEvent<NewFourEyeAction>(eventId, actionConfigName, DateTime.UtcNow, new NewFourEyeAction(actionConfigId, actionConfigName));
                sut.Causes(@event);

                Assert.Contains(@event, sut.Changes);
                Assert.Equal(actionConfigName, sut.Name);
                Assert.Equal(actionConfigId, sut.Id);
            }
        }
    }
}