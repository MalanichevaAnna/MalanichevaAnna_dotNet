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
    public class TravelVoucherController : Controller
    {
        private readonly TravelVoucherManagementService _travelVoucherManagementService;

        public TravelVoucherController(TravelVoucherManagementService travelVoucherManagementService)
        {
            _travelVoucherManagementService = travelVoucherManagementService;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TravelVoucher>>> Get()
        {
            return (await _travelVoucherManagementService.GetItems()).ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TravelVoucher>> Get(int id)

        {
            var staff = await _travelVoucherManagementService.GetItem(id);
            if (staff == null)
            {
                return NotFound();
            }
            return new ObjectResult(staff);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<TravelVoucher>> Post(TravelVoucher travelVoucher)
        {
            if (travelVoucher == null)
            {
                return BadRequest();
            }

            await _travelVoucherManagementService.Create(travelVoucher);
            return Ok(travelVoucher);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TravelVoucher>> Put(TravelVoucher travelVoucher)
        {
            if (travelVoucher == null)
            {
                return BadRequest();
            }
            if (!_travelVoucherManagementService.GetItems().Result.Any(x => x.Id == travelVoucher.Id))
            {
                return NotFound();
            }

            await _travelVoucherManagementService.Update(travelVoucher);
            return Ok(travelVoucher);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TravelVoucher>> Delete(int id)
        {
            var travelVoucher = await _travelVoucherManagementService.GetItem(id);
            if (travelVoucher == null)
            {
                return NotFound();
            }
            await _travelVoucherManagementService.Delete(id);

            return Ok(travelVoucher);
        }
    }
}