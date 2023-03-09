using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using InsuranceHolders.Domain.Interfaces;

namespace InsuranceHolders.Web.Controllers
{
    [ApiController]
    [Route("api/v1/holder")]
    public class InsuranceHolderController : ControllerBase
    {
        private readonly IHolderQueries _holderQueries;
        private readonly IHolderCommands _holderCommands;

        public InsuranceHolderController(IHolderQueries holderQueries, IHolderCommands holderCommands)
        {
            _holderQueries = holderQueries;
            _holderCommands = holderCommands;
        }

        [HttpGet("")]
        public IActionResult GetAllHolders()
        {
            try
            {
                var holders = _holderQueries.GetAllHolders();
                if (holders.Count() <= 0)
                    return NotFound("data not found");

                return Ok(holders);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get holders. {(ex ?? ex.InnerException).Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetHolderById(int id)
        {
            try
            {
                var holder = _holderQueries.GetHolderById(id);
                if (holder == null)
                    return NotFound("data not found");

                return Ok(holder);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get holder. {(ex ?? ex.InnerException).Message}");
            }
        }
    }
}