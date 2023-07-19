using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPersonelDAL:EfEntityRepositoryBase<PersonelCIContext,Personel1>,IPersonelDAL
    {
        public List<DepartmentsPersonelDto> GetAllDepartmentsPersonelDto(string departmentId, int shiftWeek, string overtimeDay)
        {
            using (var context = new PersonelCIContext())
            {
                var personelList = context.Personel1s.Where(p=>p.Iscikt == null && (p.Masraf == "501" || p.Masraf == "1002") && p.Depart == departmentId);
                var shiftList = context.Personelshifts.Where(p=>p.WeekOfYear == shiftWeek);

                var overtimeList = context.Personelovertimes.Where(p=>p.Overtimeday == overtimeDay);

                var res = from personel in personelList
                            join Shift in shiftList
                            on personel.Sicilno equals Shift.Sicilno into t1
                            from personelShift in t1.DefaultIfEmpty()

                            join kimlik in context.Kimlik1s
                            on personel.Sicilno equals kimlik.Prsicil into t2
                            from personelKimlik in t2.DefaultIfEmpty()

                            join servis in context.Servis
                            on personel.Servis equals servis.Kodu into t3
                            from personelServis in t3.DefaultIfEmpty()

                            join station in context.Duraks
                            on personel.Durak equals station.DurakKodu into t4
                            from personelStation in t4.DefaultIfEmpty()

                            join shiftT in context.Shifts
                            on personelShift.Shiftid equals shiftT.Shiftid into t5
                            from personelShiftTable in t5.DefaultIfEmpty()

                            join pOvertime in overtimeList
                            on personel.Sicilno equals pOvertime.Sicilno into t6
                            from personelOvertime in t6.DefaultIfEmpty()

                            join overtime in context.Overtimes
                            on personelOvertime.Overtimeid equals overtime.Overtimeid into t7
                            from personelOvertimeTable in t7.DefaultIfEmpty()

                            join departman in context.Departmen
                            on personel.Depart equals departman.Kodu into t8
                            from personelDepartman in t8.DefaultIfEmpty()
                            
                            select new DepartmentsPersonelDto{
                                Name = personel.Adi,
                                Surname = personel.Soyadi,
                                ServiceName = personelServis.Turu,
                                StationName = personelStation.DurakAdi,
                                ShiftName = personelShiftTable.Shiftname,
                                OvertimeName = personelOvertimeTable.Overtimename,
                                DepartmentName = personelDepartman.Adi,
                                ShiftWeek = personelShift.WeekOfYear,
                                ShiftId = personelShiftTable.Shiftid,
                                RegisterNo = personel.Sicilno,
                                OvertimeDay = personelOvertime.Overtimeday,
                                OvertimeId = personelOvertime.Overtimeid
                            };
                var count = res.Count();
                var per = personelList.Count();
                return res.ToList();
            }
        }

        public List<HRPersonelDto> GetAllHRPersonelDto(int shiftWeek,string overtimeDay){
            
            using (var context = new PersonelCIContext())
            {
                var personelList = context.Personel1s.Where(p=>p.Iscikt == null && (p.Masraf == "501" || p.Masraf == "1002"));
                var shiftList = context.Personelshifts.Where(p=>p.WeekOfYear == shiftWeek);
                var overtimeList = context.Personelovertimes.Where(p=>p.Overtimeday == overtimeDay);
                

                var res = from personel in personelList
                            join Shift in shiftList
                            on personel.Sicilno equals Shift.Sicilno into t1
                            from personelShift in t1.DefaultIfEmpty()

                            join kimlik in context.Kimlik1s
                            on personel.Sicilno equals kimlik.Prsicil into t2
                            from personelKimlik in t2.DefaultIfEmpty()

                            join servis in context.Servis
                            on personel.Servis equals servis.Kodu into t3
                            from personelServis in t3.DefaultIfEmpty()

                            join station in context.Duraks
                            on personel.Durak equals station.DurakKodu into t4
                            from personelStation in t4.DefaultIfEmpty()

                            join shiftT in context.Shifts
                            on personelShift.Shiftid equals shiftT.Shiftid into t5
                            from personelShiftTable in t5.DefaultIfEmpty()

                            join pOvertime in overtimeList
                            on personel.Sicilno equals pOvertime.Sicilno into t6
                            from personelOvertime in t6.DefaultIfEmpty()

                            join overtime in context.Overtimes
                            on personelOvertime.Overtimeid equals overtime.Overtimeid into t7
                            from personelOvertimeTable in t7.DefaultIfEmpty()

                            join departman in context.Departmen
                            on personel.Depart equals departman.Kodu into t8
                            from personelDepartman in t8.DefaultIfEmpty()
                            
                            select new HRPersonelDto{
                                Name = personel.Adi,
                                Surname = personel.Soyadi,
                                TCKN = personelKimlik.Tckmno,
                                serviceName = personelServis.Turu,
                                stationName = personelStation.DurakAdi,
                                shiftName = personelShiftTable.Shiftname,
                                overtimeName = personelOvertimeTable.Overtimename,
                                departmanName = personelDepartman.Adi,
                                ShiftWeek = personelShift.WeekOfYear,
                                shiftId = personelShiftTable.Shiftid,
                                RegisterNo = personel.Sicilno,
                                OvertimeDay = personelOvertime.Overtimeday,
                                OvertimeId = personelOvertime.Overtimeid


                            };
                var count = res.Count();
                var per = personelList.Count();
                return res.ToList();


            }
        }
    }
}