using System.Runtime.InteropServices.ComTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;

namespace Business.Concrete
{
    public class PersonelManager : IPersonelService
    {
        IPersonelDAL _personelDal;
        public PersonelManager( IPersonelDAL personelDal)
        {
            _personelDal = personelDal;
        }
        public IDataResult<List<Personel1>> GetAll()
        {
            var result = _personelDal.GetAll();
            return new SuccessDataResult<List<Personel1>>(result,"");
        }

        public IDataResult<List<DepartmentsPersonelDto>> GetAllDepartmentsPersonelDto(string departmentId, int WeekNow, string dayNow)
        {
            var result = _personelDal.GetAllDepartmentsPersonelDto(departmentId,WeekNow,dayNow);
            return new SuccessDataResult<List<DepartmentsPersonelDto>>(result,"");
        }

        public IDataResult<List<HRPersonelDto>> GetAllHRPersonelDto(int WeekNow,string dayNow)
        {
            var result = _personelDal.GetAllHRPersonelDto(WeekNow,dayNow);
            return new SuccessDataResult<List<HRPersonelDto>>(result,"");
        }

    }
}