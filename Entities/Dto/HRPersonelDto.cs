using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class HRPersonelDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string RegisterNo { get; set; }
        public string TCKN { get; set; }
        public string departmanName { get; set; }
        public string? shiftName { get; set; }
        public int? shiftId { get; set; }
        public string stationName { get; set; }
        public string serviceName { get; set; }
        public int? OvertimeId { get; set; }
        public string overtimeName { get; set; }
        public int? ShiftWeek { get; set; }
        public string OvertimeDay { get; set; }
    }
}