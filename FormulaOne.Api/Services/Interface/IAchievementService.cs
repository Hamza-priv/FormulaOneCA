using FormulaOne.Entity.Dtos.Request;
using FormulaOne.Entity.Dtos.Response;

namespace FormulaOne.Api.Services.Interface
{
    public interface IAchievementService
    {
        Task<AchievementResponeDto> GetDriverAchievement(Guid DriverId);
        Task<AchievementResponeDto> CreateDriverAchievement(AchievementRequestDto achievement);
        Task<bool> UpdateAchievement(UpdateAchievementRequestDto update);
    }
}
