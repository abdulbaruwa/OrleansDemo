using System;
using System.Collections.Generic;

namespace Ogun.GrainInterfaces.FourEyeModels
{
    public class FourEyeInstitution
    {
        public Guid Id { get; }
        public string Name { get; }
        public Guid InstitutionId { get; }
        public HashSet<Guid> Approvers { get; }
    }
}