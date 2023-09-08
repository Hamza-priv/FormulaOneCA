using AutoMapper;
using FormulaOne.Api.Services.Interface;
using FormulaOne.DataService.Repository.Interfaces;
using FormulaOne.Entity.Dtos.Request;
using FormulaOne.Entity.Dtos.Response;
using FormulaOne.Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers
{
    public class DriverController : BaseController
    {
        private readonly IDriverServices _driverServices;

        public DriverController(IDriverServices driverServices, IAchievementService achievementService)
        : base(driverServices, achievementService)
        {
            _driverServices = driverServices;
        }

        [HttpGet]
        [Route("getDrivers")]
        public async Task<ActionResult<DriverResponseDto>> GetDrivers()
        {
            return Ok(await _driverServices.GetAllDrivers());
        }

        [HttpGet]
        [Route("getDriver/{driverId:Guid}")]
        public async Task<ActionResult<DriverResponseDto>> GetDriver(Guid driverId)
        {
            return Ok(await _driverServices.GetDriverById(driverId));
        }

        [HttpPost]
        [Route("addDriver")]
        public async Task<ActionResult> AddDriver([FromBody] CreateDriverRequestDto newDriver)
        {
            return Ok(await _driverServices.CreateDriver(newDriver));
        }

        [HttpPut]
        [Route("updateDriver")]
        public async Task<ActionResult> UpdateDriver([FromBody] UpdateDriverRequestDto updateDriver)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Error in Data");
            }
            return Ok(await _driverServices.UpdateDriver(updateDriver));
        }

        [HttpDelete]
        [Route("deleteDriver/{driverId:Guid}")]
        public async Task<ActionResult> DeleteDriver(Guid driverId)
        {
            var driver = await _driverServices.DeleteDriver(driverId);
            if (driver == false)
            {
                return NotFound("No Driver to be found");
            }
            return Ok("Updated");
        }
    }
}
