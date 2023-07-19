using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dto;

namespace Business.Abstract
{
    public interface IPersonelService
    {
        IDataResult<List<Personel1>> GetAll();
        IDataResult<List<HRPersonelDto>> GetAllHRPersonelDto(int WeekNow,string dayNow);
        IDataResult<List<DepartmentsPersonelDto>> GetAllDepartmentsPersonelDto(string departmentId,int WeekNow,string dayNow);
    }
}