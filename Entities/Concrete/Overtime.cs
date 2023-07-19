using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public partial class Overtime
    {
        public int Id { get; set; }
        public int? Overtimeid { get; set; }
        public string? Overtimename { get; set; }
        public string? Endhour { get; set; }
        public string? Starthour { get; set; }
    }
}
