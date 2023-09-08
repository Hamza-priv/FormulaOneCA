using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IDriverRepository Drivers { get; }
        IAchievements Achievements { get; }
        Task CompleteAsync();

    }
}
