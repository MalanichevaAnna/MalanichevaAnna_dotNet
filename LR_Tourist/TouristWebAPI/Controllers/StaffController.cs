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
    public class StaffController : Controller
    {
        private readonly StaffManagementService _staffManagementService;
        private readonly ILogger<Staff> _logger;

        public StaffController(StaffManagementService staffManagementService,
                               ILogger<Staff> logger)
        {
            _staffManagementService = staffManagementService;
            _logger = logger;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> Get()
        {
            return (await _staffManagementService.GetItems()).ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> Get(int id)
        {
            try
            {
                var staff = await _staffManagementService.GetItem(id);
                return Ok(staff);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured during get staff. Exception: {ex.Message}");
                return BadRequest();
            }
            
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<Staff>> Post(Staff staff)
        {
            try
            {
            await _staffManagementService.Create(staff);
                return Ok(staff);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error occured during creating staff. Exception: {ex.Message}");
                return BadRequest();
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Staff>> Put(Staff staff)
        {
            try
            {
                await _staffManagementService.Update(staff);
                return Ok(staff);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error occured during editing staff. Exception: {ex.Message}");
                return BadRequest();
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Staff>> Delete(int id)
        {
            try
            {
                await _staffManagementService.Delete(id);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error occured during deleting satff. Exception: {ex.Message}");
                return BadRequest();
            }
            
        }
    }
}