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
            var checkModulTitle = myContext.Moduls.Where(x => x.ModulTittle == modulVM.ModulTitle).FirstOrDefault();
            modul.ModulTittle = modulVM.ModulTitle;

            if (checkModulTitle != null)
            {
                return 2;
            }
            modul.ModulTittle = modulVM.ModulTitle;
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
                                ModulTitle = m.ModulTittle,
                                ModulDesc = m.ModulDesc,
                                ModulContent = m.ModulContent,
                                CourseId = m.CourseId,
                            }).Where(u => u.ModulId == modulId).ToList();
            return getTopic;
        }
    }
}
