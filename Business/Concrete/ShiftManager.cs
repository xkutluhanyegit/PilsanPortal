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
    public class ShiftManager : IShiftService
    {
        IShiftDAL _shiftDAL;
        
        public ShiftManager(IShiftDAL shiftDAL)
        {
            _shiftDAL = shiftDAL;
        }
        public IDataResult<List<Shift>> GetAll()
        {
            var result = _shiftDAL.GetAll();
            return new SuccessDataResult<List<Shift>>(result,"");
        }
    }
}