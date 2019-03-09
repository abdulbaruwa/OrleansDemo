using System.Threading.Tasks;
using Ogun.GrainInterfaces.FourEyeModels;
using Orleans;

namespace Ogun.GrainInterfaces
{
    public interface IFourEyeManager : IGrain
    {
        Task NewAsync(FourEyeRequest fourEyeRequest);
        Task<FourEyeRequest> GetAllRequestsAsync();
    }

    public class FourEyeRequest
    {
    }
}