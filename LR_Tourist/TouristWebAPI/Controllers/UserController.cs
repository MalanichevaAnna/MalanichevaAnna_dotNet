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
    public class UserController : Controller
    {
        private readonly UserManagementService _userManagementService;
        private readonly ILogger<UserController> _logger;

        public UserController(UserManagementService userManagementService,
                              ILogger<UserController> logger)
        {
            _userManagementService = userManagementService;
            _logger = logger;
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
            try
            {
                var user = await _userManagementService.GetItem(id);
                return Ok(user);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error occured during get user. Exception: {ex.Message}");
                return BadRequest();
            }
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            try
            {
                await _userManagementService.Create(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured during creating user. Exception: {ex.Message}");
                return BadRequest();
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(User user)
        {
            try
            {
                await _userManagementService.Update(user);
                return Ok(user);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error occured during editing user. Exception: {ex.Message}");
                return BadRequest();
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            try
            {
                await _userManagementService.Delete(id);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error occured during deleting user. Exception: {ex.Message}");
                return BadRequest();
            }
           
        }
    }
}