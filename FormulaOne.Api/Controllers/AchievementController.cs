using AutoMapper;
using FormulaOne.Api.Services.Interface;
using FormulaOne.DataService.Repository.Interfaces;
using FormulaOne.Entity.Dtos.Request;
using FormulaOne.Entity.Dtos.Response;
using FormulaOne.Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers
{
    public class AchievementController : BaseController
    {
        private readonly IAchievementService _achievementService;

        public AchievementController(IDriverServices driverServices, IAchievementService achievementService) : base(driverServices, achievementService)
        {
            _achievementService = achievementService;
        }

        [HttpGet]
        [Route("driverAchievement/{driverId:guid}")]
        public async Task<ActionResult<AchievementResponeDto>> GetDriverAchievement(Guid driverId)
        {
            return Ok(await _achievementService.GetDriverAchievement(driverId));
        }
        [HttpPost]
        [Route("createDriverAchievement")]
        public async Task<ActionResult<AchievementResponeDto>> CreateAchievement([FromBody] AchievementRequestDto achievement)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(await _achievementService.CreateDriverAchievement(achievement));
            
        }
        [HttpPost]
        [Route("updateAchievement")]
        public async Task<IActionResult> UpdateAchievement([FromBody] UpdateAchievementRequestDto update)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _achievementService.UpdateAchievement(update);
            if(response == true)
            {
                return Ok("Updated");
            }
            return BadRequest("Cant Update");
        }
    }
}
