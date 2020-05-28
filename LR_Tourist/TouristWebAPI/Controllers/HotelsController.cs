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
    public class HotelsController : Controller
    {
        private readonly HotelManagementService _hotelManagementService;

        public HotelsController(HotelManagementService hotelManagementService)
        {
            _hotelManagementService = hotelManagementService;
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
            var hotel = await _hotelManagementService.GetItem(id);
            if(hotel == null)
            {
                return NotFound();
            }
            return new ObjectResult(hotel);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<Hotel>> Post(Hotel hotel)
        {
            if (hotel == null)
            {
                return BadRequest();
            }

            await _hotelManagementService.Create(hotel);
            return Ok(hotel);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Hotel>> Put(Hotel hotel)
        {
            if (hotel == null)
            {
                return BadRequest();
            }
            if (!_hotelManagementService.GetItems().Result.Any(x=>x.Id == hotel.Id))
            {
                return NotFound();
            }

            await _hotelManagementService.Update(hotel);
            return Ok(hotel);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> Delete(int id)
        {
            var hotel = await _hotelManagementService.GetItem(id);
            if (hotel == null)
            {
                return NotFound();
            }
            await _hotelManagementService.Delete(id);
           
            return Ok(hotel);
        }
    }
}
