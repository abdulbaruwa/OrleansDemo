using System.Threading.Tasks;
using Ogun.GrainInterfaces.FourEyeModels;
using Orleans;

namespace Ogun.GrainInterfaces
{
    public interface IFourEyeActor : IGrainWithIntegerKey
    {
        Task NewAsync(FourEyeRequest fourEyeRequest);
    }
}