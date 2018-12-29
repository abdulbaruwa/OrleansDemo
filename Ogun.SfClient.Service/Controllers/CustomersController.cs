using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ogun.GrainInterfaces;
using Orleans;

namespace Ogun.SfClient.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IClusterClient _clusterClient;

        public CustomersController(IClusterClient clusterClient)
        {
            _clusterClient = clusterClient;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Task<Customer> Get(int id)
        {
            var customerActor = _clusterClient.GetGrain<ICustomerActor>(id);
            return customerActor.GetDetailsAsync();
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] NewCustomerRequest value)
        {
            var customerActor = _clusterClient.GetGrain<ICustomerActor>(value.Id);
            await customerActor.NewAsync(new Customer(value.Id, value.Name));
        }
    }
}