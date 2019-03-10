﻿using System;
using Ogun.GrainInterfaces.FourEyeModels;
using Ogun.GrainInterfaces.FourEyeModels.Events;
using Xunit;

namespace Ogun.Tests
{
    public class NewActionSpecs
    {
        [Fact]
        public void Should_Set_Action_State_accordingly()
        {
            var sut = new FourEyeAction();
            var eventId = Guid.NewGuid();
            var actionConfigName = "Action_Test";
            var actionConfigId = Guid.NewGuid();
            var @event = new NewFourEyeActionEvent<NewFourEyeAction>(eventId, actionConfigName, DateTime.UtcNow,
                new NewFourEyeAction(actionConfigId, actionConfigName));
            sut.Causes(@event);

            Assert.Contains(@event, sut.Changes);
            Assert.Equal(actionConfigName, sut.Name);
            Assert.Equal(actionConfigId, sut.Id);
        }

        [Fact]
        public void Should_Ignore_If_State_already_set()
        {
            var sut = new FourEyeAction();
            var eventId = Guid.NewGuid();
            var actionConfigName = "Action_Test";
            var actionConfigId = Guid.NewGuid();
            var @event = new NewFourEyeActionEvent<NewFourEyeAction>(eventId, actionConfigName,
                DateTime.UtcNow, new NewFourEyeAction(actionConfigId, actionConfigName));
            sut.Causes(@event);

            var actionConfigName2 = "Action_Test2";
            var @event2 = new NewFourEyeActionEvent<NewFourEyeAction>(eventId, actionConfigName2,
                DateTime.UtcNow, new NewFourEyeAction(actionConfigId, actionConfigName2));
            sut.Causes(@event2);

            Assert.Single(sut.Changes);
            Assert.Equal(actionConfigName, sut.Name);
            Assert.Equal(actionConfigId, sut.Id);
        }
    }
}