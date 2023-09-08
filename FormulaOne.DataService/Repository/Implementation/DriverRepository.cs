using FormulaOne.DataService.Repository.Interfaces;
using FormulaOne.Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repository.Implementation
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(AppDbContext context) : base(context) {}

        public override async Task<IEnumerable<Driver>> All()
        {
            try
            {
                return await _dbSet.Where(x => x.status == 1)
                    .AsNoTracking()
                    .AsSplitQuery() // to split data if its too large
                    .OrderBy(x => x.createdDate)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("Error in get Driver");
            }
        }
        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var driver = await _dbSet.FirstOrDefaultAsync(driver => driver.Id == id);
                if (driver == null) { return false; }
                driver.status = 0;
                driver.updatedDate = DateTime.UtcNow;
                return true;
            }
            catch (Exception)
            {

                throw new Exception("Error in delete in Driver");
            }
        }
        public override async Task<bool> Update(Driver newDriver)
        {
            try
            {
                var driver = await _dbSet.FirstOrDefaultAsync(driver => driver.Id == newDriver.Id);
                if (driver == null) { return false; }
                //automapper
                return true;
            }
            catch (Exception)
            {

                throw new Exception("Error in Update driver");
            }
        }
    }
}
