using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Model;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TouristWebApp.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TouristWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class HotelsController : Controller
    {
        private readonly HotelManagementService _hotelManagementService;
        private readonly ILogger<HotelsController> _logger;
        public HotelsController(HotelManagementService hotelManagementService,
                                ILogger<HotelsController> logger)
        {
            _hotelManagementService = hotelManagementService;
            _logger = logger;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> Get()
        {
            return (await _hotelManagementService.GetItems()).ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> Get(int id)
        {
            try
            {
                var hotel = await _hotelManagementService.GetItem(id);
                return new ObjectResult(hotel);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error occured during get hotel. Exception: {ex.Message}");
                return BadRequest();
            }
           
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<Hotel>> Post(Hotel hotel)
        {
            try
            { 
                await _hotelManagementService.Create(hotel);
                return Ok(hotel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured during creating hotel. Exception: {ex.Message}");
                return BadRequest();
            }
          
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Hotel>> Put(Hotel hotel)
        {
            try
            {
                await _hotelManagementService.Update(hotel);
                return Ok(hotel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured during editing hotel. Exception: {ex.Message}");
                return BadRequest();
            }
          
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> Delete(int id)
        {
            try
            {
                await _hotelManagementService.Delete(id);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error occured during deleting hotel. Exception: {ex.Message}");
                return BadRequest();
            }
            
           
        }
    }
}
