using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Dto;

namespace DataAccess.Abstract
{
    public interface IPersonelDAL:IEntityRepository<Personel1>
    {
        List<HRPersonelDto> GetAllHRPersonelDto(int shiftWeek,string overtimeDay);
        List<DepartmentsPersonelDto> GetAllDepartmentsPersonelDto(string departmentId,int shiftWeek,string overtimeDay);
    }
}