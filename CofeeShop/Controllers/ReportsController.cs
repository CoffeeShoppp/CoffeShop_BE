using CofeeShop.Business.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CofeeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _service;

        public ReportsController(IReportService service)
        {
            _service = service;
        }

        [HttpGet("revenue")]
        public async Task<IActionResult> GetRevenue(DateTime from, DateTime to)
        {
            if (from > to)
                return BadRequest("From date must be before To date");

            var result = await _service.GetRevenueAsync(from, to);
            return Ok(result);
        }


        [HttpGet("customer-count")]
        public async Task<IActionResult> GetCustomerCount(DateTime from, DateTime to)
        {
            if (from > to)
                return BadRequest("From date must be before To date");

            var result = await _service.GetCustomerCountAsync(from, to);
            return Ok(result);
        }
    }
}
