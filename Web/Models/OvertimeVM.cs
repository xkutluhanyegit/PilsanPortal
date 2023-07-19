using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dto;

namespace Web.Models
{
    public class OvertimeVM
    {
        public List<DepartmentsPersonelDto> DepartmentsPersonelDto { get; set; }
        public string Date { get; set; }
    }
}