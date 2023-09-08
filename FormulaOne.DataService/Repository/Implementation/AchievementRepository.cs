using FormulaOne.DataService.Repository.Interfaces;
using FormulaOne.Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FormulaOne.DataService.Repository.Implementation
{
    public class AchievementRepository : GenericRepository<Achievement>, IAchievements
    {
        public AchievementRepository(AppDbContext context) : base(context) {}

        public async Task<Achievement?> GetDriverAchievement(Guid driverID)
        {
            try
            {
                return await _dbSet.FirstOrDefaultAsync(x => x.DriverId == driverID);
            }
            catch (Exception)
            {
                throw new NotImplementedException("Error in get achievement fr DriverID");
            }
        }
        public override async Task<IEnumerable<Achievement>> All()
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
                throw new Exception("Error in get achievement");
            }
        }
        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var achievement = await _dbSet.FirstOrDefaultAsync(achievement => achievement.Id == id);
                if (achievement == null) { return false; }
                achievement.status = 0;
                achievement.updatedDate = DateTime.UtcNow;
                return true;
            }
            catch (Exception)
            {

                throw new Exception("Error in delete in achievement");
            }
        }
        public override async Task<bool> Update(Achievement newAchievement)
        {
            try
            {
                var achievement = await _dbSet.FirstOrDefaultAsync(achievement => achievement.DriverId == newAchievement.DriverId);
                if (achievement == null) { return false; }
                //automapper
                achievement.fastestLap = newAchievement.fastestLap;
                achievement.champions = newAchievement.champions;
                achievement.poleposition = newAchievement.poleposition;
                achievement.racewins = newAchievement.racewins;
                achievement.updatedDate = newAchievement.updatedDate;
                return true;
            }
            catch (Exception)
            {

                throw new Exception("Error in Update achievement");
            }
        }
    }
}
