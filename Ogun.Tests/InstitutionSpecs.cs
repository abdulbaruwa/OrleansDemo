using System;
using Ogun.GrainInterfaces.FourEyeModels;
using Ogun.GrainInterfaces.FourEyeModels.Events;
using Xunit;

namespace Ogun.Tests
{
    public class InstitutionSpecs
    {
        [Fact]
        public void Handle_NewInstitutionEvent()
        {
            var institutionId = InitTestInstitution(out var sut, out var testInstitutionName, out var @event);
            sut.Causes(@event);

            Assert.Contains(@event, sut.Changes);
            Assert.Equal(sut.Name, testInstitutionName);
            Assert.Equal(sut.InstitutionId, institutionId);
        }

        [Fact]
        public void Handle_UserAddedToInstitution()
        {
            var institutionId = InitTestInstitution(out var sut, out var testInstitutionName, out var @event);
            sut.Causes(@event);

            var userId = Guid.NewGuid();
            var userAdded = new UserAddedToInstitution(userId);
            var userAddedEvent = new UserAddedToInstitutionEvent<UserAddedToInstitution>(Guid.NewGuid(),
                nameof(UserAddedToInstitution), DateTime.UtcNow, userAdded);

            sut.Causes(userAddedEvent);

            Assert.Contains(userAddedEvent, sut.Changes);
            Assert.Contains(userId, sut.Approvers);
        }

        private static Guid InitTestInstitution(out FourEyeInstitution sut, out string testInstitutionName, out NewInstitutionEvent<NewInstitution> @event)
        {
            sut = new FourEyeInstitution();
            var eventId = Guid.NewGuid();
            var institutionId = Guid.NewGuid();
            testInstitutionName = "TestInstitution";
            @event = new NewInstitutionEvent<NewInstitution>(eventId, "TestEvent", DateTime.UtcNow,
                new NewInstitution(testInstitutionName, institutionId));
            return institutionId;
        }
    }
}
