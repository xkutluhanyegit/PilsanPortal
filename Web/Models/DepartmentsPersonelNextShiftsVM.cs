using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dto;

namespace Web.Models
{
    public class DepartmentsPersonelNextShiftsVM:DepartmentsPersonelShiftsVM
    {
        public List<DepartmentsPersonelDto> DepartmentsPersonelDtoNextShiftVM { get; set; }
    }
}