using FormulaOne.Entity.Dtos.Request;
using FormulaOne.Entity.Dtos.Response;
using FormulaOne.Entity.Model;

namespace FormulaOne.Api.Services.Interface
{
    public interface IDriverServices
    {
        Task<IEnumerable<Driver>> GetAllDrivers();
        Task<DriverResponseDto> GetDriverById(Guid Id);
        Task<DriverResponseDto> CreateDriver(CreateDriverRequestDto newDriver);
        Task<Driver> UpdateDriver(UpdateDriverRequestDto updateDriver);
        Task <bool> DeleteDriver(Guid Id);
    }
}
