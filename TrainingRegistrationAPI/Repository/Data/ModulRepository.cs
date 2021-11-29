using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Context;
using TrainingRegistrationAPI.Models;
using TrainingRegistrationAPI.ViewModel;

namespace TrainingRegistrationAPI.Repository.Data
{
    public class ModulRepository : GeneralRepository<MyContext, Modul, int>
    {
        private readonly MyContext myContext;
        public ModulRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
        public int RegisterModul(ModulVM modulVM)
        {
            Modul modul = new Modul();
            var checkModulTitle = myContext.Moduls.Where(x => x.ModulTittle == modulVM.ModulTittle).FirstOrDefault();
            modul.ModulTittle = modulVM.ModulTittle;

            if (checkModulTitle != null)
            {
                return 2;
            }
            modul.ModulTittle = modulVM.ModulTittle;
            modul.ModulDesc = modulVM.ModulDesc;
            modul.ModulContent = modulVM.ModulContent;
            modul.CourseId = modulVM.CourseId;
            myContext.Moduls.Add(modul);
            var result = myContext.SaveChanges();
            return result;
        }
        public IEnumerable<ModulVM> GetIdModul(int modulId)
        {
            var getTopic = (from m in myContext.Moduls
                            select new ModulVM()
                            {
                                ModulId = m.ModulId,
                                ModulTittle = m.ModulTittle,
                                ModulDesc = m.ModulDesc,
                                ModulContent = m.ModulContent,
                                CourseId = m.CourseId,
                            }).Where(u => u.ModulId == modulId).ToList();
            return getTopic;
        }

        public IEnumerable<ModulVM> GetModul()
        {
            var result = from m in myContext.Moduls
                         join c in myContext.Courses on m.CourseId equals c.CourseId
                         select new ModulVM()
                         {
                             ModulId = m.ModulId,
                             ModulTittle = m.ModulTittle,
                             ModulDesc = m.ModulDesc,
                             ModulContent = m.ModulContent,
                             CourseId = m.CourseId,
                             CourseName = c.CourseName
                         };
            return result;
        }

        public IEnumerable<ModulVM> GetModul(int key)
        {
            var result = from m in myContext.Moduls
                         join c in myContext.Courses on m.CourseId equals c.CourseId
                         where m.ModulId == key
                         select new ModulVM()
                         {
                             ModulId = m.ModulId,
                             ModulTittle = m.ModulTittle,
                             ModulDesc = m.ModulDesc,
                             ModulContent = m.ModulContent,
                             CourseId = m.CourseId,
                             CourseName = c.CourseName
                         };
            return result;
        }

        public int GetId(int id)
        {
            var data = myContext.Moduls.Find(id);
            if (data != null)
            {
                return 1;
            }
            return 0;
        }

        public IEnumerable<ModulCourseVM> GetModulCourse(int EmployeeId)
        {
            var getModulCourse = (from us in myContext.Employees
                                   join c in myContext.Courses on
                                   us.EmployeeId equals c.EmployeeId
                                   join ml in myContext.Moduls on
                                    c.CourseId equals ml.CourseId
                                   select new ModulCourseVM
                                   {
                                       StatusCourse = c.StatusCourse,
                                       CourseName = c.CourseName,
                                       CourseDesc = c.CourseDesc,
                                       CourseImg = c.CourseImg,
                                       ModulTittle = ml.ModulTittle,
                                       ModulDesc = ml.ModulDesc,
                                       ModulContent = ml.ModulContent,
                                       EmployeeId = us.EmployeeId,
                                       CourseId = c.CourseId,
                                       ModulId = ml.ModulId,
                                   }).Where(u => u.StatusCourse == StatusCourse.Approved).Where(c => c.EmployeeId == EmployeeId).ToList();
            return getModulCourse;
        }

        public IEnumerable<ModulCourseVM> GetCourseModul(int courseId)
        {
            var getModulCourse = (from m in myContext.Moduls
                                  join c in myContext.Courses on m.CourseId equals c.CourseId
                                  where m.CourseId == courseId && c.StatusCourse == StatusCourse.Approved
                                  select new ModulCourseVM
                                  {
                                      CourseName = c.CourseName,
                                      CourseDesc = c.CourseDesc,
                                      CourseImg = c.CourseImg,
                                      ModulTittle = m.ModulTittle,
                                      ModulDesc = m.ModulDesc,
                                      ModulContent = m.ModulContent,
                                      CourseId = c.CourseId,
                                      ModulId = m.ModulId,
                                  }).ToList();
            return getModulCourse;
        }



    }
}
