using System.Threading.Tasks;
using Ogun.GrainInterfaces.FourEyeModels;
using Orleans;

namespace Ogun.GrainInterfaces
{
    public interface IFourEyeInstitutionActor : IGrainWithIntegerKey
    {
        Task NewAsync(NewInstitution fourEyeRequest);
    }
}