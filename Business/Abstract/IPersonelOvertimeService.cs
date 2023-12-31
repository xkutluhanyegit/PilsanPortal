using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPersonelOvertimeService
    {
        IResult Add(Personelovertime personelovertime);
        IResult Update(Personelovertime personelovertime);
        IResult Delete(Personelovertime personelovertime);
        IDataResult<Personelovertime> Get(string RegisterNo);
    }
}