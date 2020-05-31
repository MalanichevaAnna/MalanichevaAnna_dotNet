using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Model;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TouristWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ServiceController : Controller
    {
        private readonly ServiceManagementService _seviceManagementService;
        private readonly ILogger<ServiceController> _logger;

        public ServiceController(ServiceManagementService serviceManagementService,
                                 ILogger<ServiceController> logger)
        {
            _seviceManagementService = serviceManagementService;
            _logger = logger;
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
            try
            {
                var service = await _seviceManagementService.GetItem(id);
                return Ok(service);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured during get service. Exception: {ex.Message}");
                return BadRequest();
            }
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<Service>> Post(Service service)
        {
            try
            {
                await _seviceManagementService.Create(service);
                return Ok(service);

            }
            catch(Exception ex)
            {
                _logger.LogError($"Error occured during creating service. Exception: {ex.Message}");
                return BadRequest();
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Service>> Put(Service service)
        {
            try
            {
                await _seviceManagementService.Update(service);
                return Ok(service);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error occured during editing service. Exception: {ex.Message}");
                return BadRequest();
            } 
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Service>> Delete(int id)
        {
            try
            {
                await _seviceManagementService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured during deleting service. Exception: {ex.Message}");
                return BadRequest();
            }
        }
    }
}
