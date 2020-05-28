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
    public class StaffController : Controller
    {
        private readonly StaffManagementService _staffManagementService;

        public StaffController(StaffManagementService staffManagementService)
        {
            _staffManagementService = staffManagementService;
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
            var staff = await _staffManagementService.GetItem(id);
            if (staff == null)
            {
                return NotFound();
            }
            return new ObjectResult(staff);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<Staff>> Post(Staff staff)
        {
            if (staff == null)
            {
                return BadRequest();
            }

            await _staffManagementService.Create(staff);
            return Ok(staff);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Staff>> Put(Staff staff)
        {
            if (staff == null)
            {
                return BadRequest();
            }
            if (!_staffManagementService.GetItems().Result.Any(x => x.Id == staff.Id))
            {
                return NotFound();
            }

            await _staffManagementService.Update(staff);
            return Ok(staff);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Staff>> Delete(int id)
        {
            var staff = await _staffManagementService.GetItem(id);
            if (staff == null)
            {
                return NotFound();
            }
            await _staffManagementService.Delete(id);

            return Ok(staff);
        }
    }
}