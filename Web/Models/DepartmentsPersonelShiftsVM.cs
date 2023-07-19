using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.Dto;

namespace Web.Models
{
    public class DepartmentsPersonelShiftsVM
    {
        public List<DepartmentsPersonelDto> DepartmentsPersonelDtoVM { get; set; }
        public List<Shift> Shifts { get; set; }

    }
}