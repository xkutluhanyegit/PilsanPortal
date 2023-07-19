using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PersonelOvertimeManager : IPersonelOvertimeService
    {
        IPersonelOvertimeDAL _personelOvertimeDal;
        public PersonelOvertimeManager(IPersonelOvertimeDAL personelOvertimeDal)
        {
            _personelOvertimeDal = personelOvertimeDal;
        }
        public IResult Add(Personelovertime personelovertime)
        {
            _personelOvertimeDal.Add(personelovertime);
            return new SuccessResult("");
        }

        public IResult Delete(Personelovertime personelovertime)
        {
            var personel = _personelOvertimeDal.Get(p=>p.Sicilno == personelovertime.Sicilno && p.Overtimeday == personelovertime.Overtimeday);
            _personelOvertimeDal.Delete(personel);
            return new SuccessResult("");
        }

        public IDataResult<Personelovertime> Get(string RegisterNo)
        {
            _personelOvertimeDal.Get(p=>p.Sicilno == RegisterNo);
            return new SuccessDataResult<Personelovertime>("");
        }

        public IResult Update(Personelovertime personelovertime)
        {
            var personel = _personelOvertimeDal.Get(p=>p.Sicilno == personelovertime.Sicilno & p.Overtimeday == personelovertime.Overtimeday);
            personel.Overtimeid = personelovertime.Overtimeid;
            _personelOvertimeDal.Update(personel);
            return new SuccessResult("");
        }
    }
}