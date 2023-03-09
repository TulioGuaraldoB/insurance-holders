using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using InsuranceHolders.Domain.Interfaces;
using InsuranceHolders.Web.Dtos;

namespace InsuranceHolders.Web.Controllers
{
    [ApiController]
    [Route("api/v1/holder")]
    public class InsuranceHolderController : ControllerBase
    {
        private readonly IHolderQueries _holderQueries;
        private readonly IHolderCommands _holderCommands;
        private readonly HolderDto _holderDto = new HolderDto();

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

                var holdersResponse = _holderDto.ParseHoldersToResponse(holders);

                return Ok(holdersResponse);
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

        [HttpPost("")]
        public IActionResult CreateHolder(HolderRequest holderRequest)
        {
            try
            {
                var holder = _holderDto.ParseRequestToHolder(holderRequest);
                _holderCommands.CreateHolder(holder);

                return Ok(new { message = "Holder created successfully!", holder = holderRequest });
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to create holder. ${(ex ?? ex.InnerException).Message}");
            }
        }
    }
}