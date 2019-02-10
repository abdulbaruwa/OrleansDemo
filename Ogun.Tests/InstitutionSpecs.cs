using System;
using Ogun.GrainInterfaces.FourEyeModels;
using Xunit;

namespace Ogun.Tests
{
    public class InstitutionSpecs
    {
        [Fact]
        public void Handle_NewInstitutionEvent()
        {
            var sut = new FourEyeInstitution();

            var eventId = Guid.NewGuid();
            var institutionId = Guid.NewGuid();
            var testInstitutionName = "TestInstitution";
            var @event = new NewInstitutionEvent<NewInstitution>(eventId, "TestEvent", DateTime.UtcNow, new NewInstitution(testInstitutionName, institutionId));

            sut.Causes(@event);

            Assert.Contains(@event, sut.Changes);
            Assert.Equal(sut.Name, testInstitutionName);
            Assert.Equal(sut.InstitutionId, institutionId);
        }
    }
}
