using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Entity.Model
{
    public class Driver : Generic
    {
        public Driver()
        {
            Achievements = new HashSet<Achievement>();
        }
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public DateTime dateofbirth { get; set; }
        public int driverNumber { get; set; }
        public virtual ICollection<Achievement> Achievements { get; set; }
    }
}
