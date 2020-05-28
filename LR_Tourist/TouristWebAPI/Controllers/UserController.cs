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
    public class UserController : Controller
    {
        private readonly UserManagementService _userManagementService;

        public UserController(UserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return (await _userManagementService.GetItems()).ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)

        {
            var user = await _userManagementService.GetItem(id);
            if (user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            await _userManagementService.Create(user);
            return Ok(user);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!_userManagementService.GetItems().Result.Any(x => x.Id == user.Id))
            {
                return NotFound();
            }

            await _userManagementService.Update(user);
            return Ok(user);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var user = await _userManagementService.GetItem(id);
            if (user == null)
            {
                return NotFound();
            }
            await _userManagementService.Delete(id);

            return Ok(user);
        }
    }
}