using System;
using System.Threading.Tasks;
using Orleans;
using Orleans.Concurrency;

namespace Ogun.GrainInterfaces
{
    public interface IFourEyeManager : IGrain
    {
        Task NewAsync(FourEyeRequest fourEyeRequest);
        Task<FourEyeRequest> GetAllRequestsAsync();
    }

    public interface IFourEyeActor : IGrainWithIntegerKey
    {
        Task NewAsync(FourEyeRequest fourEyeRequest);
    }
    
    public class FourEyeRequest
    {
    }

    [Serializable, Immutable]
    public class FourEyeRequestState
    {
        public string Name { get; private set; }
        public TimeSpan Timeout { get; private set; }
        public void Apply(NewRequestEvent @event)
        {
            Name = @event.Name;
            Timeout = @event.TimeOut;
        }
    }

    #region DomainEvents

    [Serializable, Immutable]
    public class NewRequestEvent
    {
        public NewRequestEvent(string name, TimeSpan timeOut, DateTime startDateTimeUtc, Object requestBody)
        {
            RequestBody = requestBody;
            StartDateTimeUtc = startDateTimeUtc;
            Name = name;
            TimeOut = timeOut;
        }

        public object RequestBody { get; }
        public string Name { get; }
        public TimeSpan TimeOut { get; }
        public DateTime StartDateTimeUtc { get; }
    }
#endregion
}