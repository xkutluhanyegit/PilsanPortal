using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Constant;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;

namespace Business.Concrete
{
    public class PersonelShiftsManager : IPersonelShiftService
    {
        IPersonelShiftsDAL _personelShiftsDal;
        public PersonelShiftsManager(IPersonelShiftsDAL personelShiftsDal)
        {
            _personelShiftsDal = personelShiftsDal;
        }
        public IResult Add(DepartmentsPersonelDto personelDto)
        {
            Personelshift p = new Personelshift();
            
            p.Shiftid = personelDto.ShiftId;
            p.Sicilno = personelDto.RegisterNo;
            p.Createday = DateTime.Now.ToShortDateString();
            p.WeekOfYear = personelDto.ShiftWeek;
            var ShiftEnd = DateTime.Now;
            var ShiftStart = DateTime.Now;
            while (true)
            {
                if (ShiftStart.DayOfWeek == DayOfWeek.Monday)
                {
                    p.Startday = ShiftStart.ToShortDateString();
                    //Vardiya
                    if (p.Shiftid == 1 | p.Shiftid == 5 | p.Shiftid == 6 | p.Shiftid == 7)
                    {
                        p.Endday = ShiftStart.AddDays(5).ToShortDateString();
                        break;
                    }
                    //Sabit
                    else if (p.Shiftid == 2)
                    {
                        p.Endday = ShiftStart.AddDays(4).ToShortDateString();
                        break;
                    }
                    
                }
                ShiftStart = ShiftStart.AddDays(1);
            }

            _personelShiftsDal.Add(p);
            return new SuccessResult("");
        }

        public IResult Delete(DepartmentsPersonelDto personelDto)
        {
            var personel = _personelShiftsDal.Get(p=>p.Sicilno == personelDto.RegisterNo && p.WeekOfYear == personelDto.ShiftWeek);
            _personelShiftsDal.Delete(personel);
            return new SuccessResult("");
        }

        public IDataResult<Personelshift> Get(string RegisterNo)
        {
            _personelShiftsDal.Get(p=>p.Sicilno == RegisterNo);
            return new SuccessDataResult<Personelshift>("");
        }

        public IResult Update(DepartmentsPersonelDto personelDto)
        {
            var personel = _personelShiftsDal.Get(p=>p.Sicilno == personelDto.RegisterNo && p.WeekOfYear == personelDto.ShiftWeek);
            personel.Shiftid = personelDto.ShiftId;
            _personelShiftsDal.Update(personel);
            return new SuccessResult("");
        }
    }
}