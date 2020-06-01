using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Model;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TouristWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TravelVoucherController : Controller
    {
        private readonly TravelVoucherManagementService _travelVoucherManagementService;
        private readonly ILogger<TravelVoucherController> _logger;

        public TravelVoucherController(TravelVoucherManagementService travelVoucherManagementService,
                                       ILogger<TravelVoucherController> logger)
        {
            _travelVoucherManagementService = travelVoucherManagementService;
            _logger = logger;
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
            try
            {
                var travelVoucher = await _travelVoucherManagementService.GetItem(id);
                return Ok(travelVoucher);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured during get travelVoucher. Exception: {ex.Message}");
                return BadRequest();
            }
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<TravelVoucher>> Post(TravelVoucher travelVoucher)
        {
            try
            {
                await _travelVoucherManagementService.Create(travelVoucher);
                return Ok(travelVoucher);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error occured during creating characteristic. Exception: {ex.Message}");
                return BadRequest();
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TravelVoucher>> Put(TravelVoucher travelVoucher)
        {
            try
            {
                await _travelVoucherManagementService.Update(travelVoucher);
                return Ok(travelVoucher);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured during editing travelVoucher. Exception: {ex.Message}");
                return BadRequest();
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TravelVoucher>> Delete(int id)
        {
            try
            {
                await _travelVoucherManagementService.Delete(id);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error occured during deleting travelVoucher. Exception: {ex.Message}");
                return BadRequest();
            }
        }
    }
}