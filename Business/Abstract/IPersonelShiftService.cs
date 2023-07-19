using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dto;

namespace Business.Abstract
{
    public interface IPersonelShiftService
    {
        IResult Add(DepartmentsPersonelDto personelDto);
        IResult Update(DepartmentsPersonelDto personelDto);
        IResult Delete(DepartmentsPersonelDto personelDto);
        IDataResult<Personelshift> Get(string RegisterNo);
    }
}