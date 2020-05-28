using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Model;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TouristWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ServiceController : Controller
    {
        private readonly ServiceManagementService _seviceManagementService;

        public ServiceController(ServiceManagementService serviceManagementService)
        {
            _seviceManagementService = serviceManagementService;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> Get()
        {
            return (await _seviceManagementService.GetItems()).ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> Get(int id)
        {
            var service = await _seviceManagementService.GetItem(id);
            if (service == null)
            {
                return NotFound();
            }
            return new ObjectResult(service);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<Service>> Post(Service service)
        {
            if (service == null)
            {
                return BadRequest();
            }

            await _seviceManagementService.Create(service);
            return Ok(service);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Service>> Put(Service service)
        {
            if (service == null)
            {
                return BadRequest();
            }
            if (!_seviceManagementService.GetItems().Result.Any(x => x.Id == service.Id))
            {
                return NotFound();
            }

            await _seviceManagementService.Update(service);
            return Ok(service);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Service>> Delete(int id)
        {
            var service = await _seviceManagementService.GetItem(id);
            if (service == null)
            {
                return NotFound();
            }
            await _seviceManagementService.Delete(id);

            return Ok(service);
        }
    }
}
