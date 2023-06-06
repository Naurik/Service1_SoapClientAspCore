using Microsoft.EntityFrameworkCore;
using Service.DATA.DataBase.PostgresSQL;
using Service.DATA.Model;
using Service.Helpers;
using Service.Helpers.Classes.MO_RequestResponse;
using System;

namespace Service.DATA.DataBase.PostgresSQL.OperationsDB
{
    public class OperationRepo
    {
        ApplicationContext _context;
        public OperationRepo(ApplicationContext context)
        {
            _context = context;
        }
        public int AddDB_Candidates(MO_DataResponse responseData) 
        {
            try
            {
                // добавление данных
                using (_context = new ApplicationContext())
                {
                    // создаем два объекта User
                    Candidates candidates = new Candidates
                    {
                        FullName = responseData.FullName,
                        BirthDate = responseData.BirthDate,
                        EducationInfo = responseData.EducationInfo,
                        Locations = responseData.Locations,
                        SpouseEducationInfo = responseData.SpouseEducationInfo,
                        WorkingActivity = responseData.WorkingActivity,
                        ResponseDate = responseData.ResponseDate,
                    };

                    // добавляем их в бд
                    _context.Candidates.AddRange(candidates);
                    _context.SaveChanges();
                    return 1;
                }
            }
            catch(Exception ex)
            {
                Logger.Log.Debug("Error in Insert: " + responseData, ex);
                return 0;
            }
        }

        public List<Candidates> GetAllCandidates()
        {
            List<Candidates> list = _context.Candidates.Select(x => new Candidates
            {
                Id = x.Id,
                FullName = x.FullName,
                BirthDate = x.BirthDate,
                Locations = x.Locations,
                EducationInfo = x.EducationInfo,
                SpouseEducationInfo = x.SpouseEducationInfo,
                WorkingActivity = x.WorkingActivity,
                ResponseDate = x.ResponseDate

            }).ToList();

            return list;
        }
    }
}
