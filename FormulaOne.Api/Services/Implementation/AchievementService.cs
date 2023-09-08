using AutoMapper;
using FormulaOne.Api.Services.Interface;
using FormulaOne.DataService.Repository.Interfaces;
using FormulaOne.Entity.Dtos.Request;
using FormulaOne.Entity.Dtos.Response;
using FormulaOne.Entity.Model;

namespace FormulaOne.Api.Services.Implementation
{
    public class AchievementService : IAchievementService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AchievementService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<AchievementResponeDto> GetDriverAchievement(Guid DriverId)
        {
            var driverAchievement = await _unitOfWork.Achievements.GetDriverAchievement(DriverId);
            var result = _mapper.Map<AchievementResponeDto>(driverAchievement);
            return result;
        }

        public async Task<AchievementResponeDto> CreateDriverAchievement(AchievementRequestDto achievement)
        {
            var result = _mapper.Map<Achievement>(achievement);
            await _unitOfWork.Achievements.Add(result);
            await _unitOfWork.CompleteAsync();
            var response = _mapper.Map<AchievementResponeDto>(result);
            return response;
        }

        public async Task<bool> UpdateAchievement(UpdateAchievementRequestDto update)
        {
            var result = _mapper.Map<Achievement>(update);
            await _unitOfWork.Achievements.Update(result);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
