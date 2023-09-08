using AutoMapper;
using FormulaOne.Api.Services.Interface;
using FormulaOne.DataService.Repository.Interfaces;
using FormulaOne.Entity.Dtos.Request;
using FormulaOne.Entity.Dtos.Response;
using FormulaOne.Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Services.Implementation
{
    public class DriverService : IDriverServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DriverService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<DriverResponseDto> CreateDriver(CreateDriverRequestDto newDriver)
        {
            var result = _mapper.Map<Driver>(newDriver);
            await _unitOfWork.Drivers.Add(result);
            await _unitOfWork.CompleteAsync();
            var response = _mapper.Map<DriverResponseDto>(result);
            return response;
        }

        public async Task<bool> DeleteDriver(Guid Id)
        {
            var driver = await _unitOfWork.Drivers.GetbyId(Id);
            if (driver is not null)
            {
                await _unitOfWork.Drivers.Delete(Id);
                await _unitOfWork.CompleteAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Driver>> GetAllDrivers()
        {
            var drivers = await _unitOfWork.Drivers.All();
            return drivers;
        }

        public async Task<DriverResponseDto> GetDriverById(Guid Id)
        {
            var driver = await _unitOfWork.Drivers.GetbyId(Id);
            var result = _mapper.Map<DriverResponseDto>(driver);
            return result;
     
        }

        public async Task<Driver> UpdateDriver(UpdateDriverRequestDto updateDriver)
        { 
            var result = _mapper.Map<Driver>(updateDriver);
            await _unitOfWork.Drivers.Update(result);
            await _unitOfWork.CompleteAsync();
            
            return result;
        }
    }
}
