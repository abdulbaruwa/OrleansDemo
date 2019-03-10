using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ogun.GrainInterfaces;
using Ogun.GrainInterfaces.FourEyeModels.Events;
using Ogun.GrainInterfaces.FourEyeModels.Requests;
using Orleans;

namespace Ogun.Client.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FourEyeInstitutionController : ControllerBase
    {
        private readonly IClusterClient _clusterClient;

        public FourEyeInstitutionController(IClusterClient clusterClient)
        {
            _clusterClient = clusterClient;
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public Task<Customer> Get(int id)
        //{
        //    var customerActor = _clusterClient.GetGrain<ICustomerActor>(id);
        //    return customerActor.GetDetailsAsync();
        //}

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] FourEyeInstitutionRequest value)
        {
            var customerActor = _clusterClient.GetGrain<IFourEyeInstitutionActor>(value.Id);
            await customerActor.NewAsync(new NewInstitution(value.Name, value.Id));
        }
    }
}