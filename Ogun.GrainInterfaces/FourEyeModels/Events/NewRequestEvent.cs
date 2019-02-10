using System;
using Orleans.Concurrency;

namespace Ogun.GrainInterfaces.FourEyeModels.Events
{
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
}