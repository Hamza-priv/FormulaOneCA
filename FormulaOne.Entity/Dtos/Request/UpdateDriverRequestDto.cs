using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Entity.Dtos.Request
{
    public class UpdateDriverRequestDto
    {
        Guid DriverId { get; set; }
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public DateTime dateofbirth { get; set; }
        public int driverNumber { get; set; }
    }
}
