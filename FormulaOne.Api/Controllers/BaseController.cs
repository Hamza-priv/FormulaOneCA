using AutoMapper;
using FormulaOne.Api.Services.Interface;
using FormulaOne.DataService;
using FormulaOne.DataService.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : Controller
    {
        protected readonly IDriverServices _driverServices;
        protected readonly IAchievementService _achievementService;

        public BaseController(IDriverServices driverServices, IAchievementService achievementService)
        {
            _driverServices = driverServices;
            _achievementService = achievementService;
        }
    }
}
