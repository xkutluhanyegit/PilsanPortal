using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class DepartmentsPersonelDto
    {
        public int id { get; set; }
        public bool check { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string RegisterNo { get; set; }
        public string ServiceName { get; set; }
        public string StationName { get; set; }
        public string ShiftName { get; set; }
        public int? ShiftId { get; set; }
        public int? OvertimeId { get; set; }
        public string OvertimeName { get; set; }
        public string OvertimeDay { get; set; }
        public string DepartmentName { get; set; }
        public int? ShiftWeek { get; set; }
    }
}