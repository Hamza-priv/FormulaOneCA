using FormulaOne.DataService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repository.Implementation
{
    public class UnitofWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;

        public IDriverRepository Drivers { get; }

        public IAchievements Achievements { get; }

        public UnitofWork(AppDbContext context)
        {
            _context = context;
            Drivers = new DriverRepository(_context);
            Achievements = new AchievementRepository(_context);
            
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async void Dispose()
        {
            await _context.DisposeAsync();
        }
    }
}
