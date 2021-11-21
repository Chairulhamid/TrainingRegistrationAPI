using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Context;
using TrainingRegistrationAPI.Models;
using TrainingRegistrationAPI.ViewModel;

namespace TrainingRegistrationAPI.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<MyContext, Employee, int>
    {
        private static string GetRandomSalt()
        {
          return BCrypt.Net.BCrypt.GenerateSalt(12);
        }

        private readonly MyContext myContext;
        public EmployeeRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public IEnumerable<RegisterEmpVM> GetProfile()
        {
            var getProfile = (from e in myContext.Employees
                              join acc in myContext.Accounts on
                              e.AccountId equals acc.AccountId
                              join acr in myContext.AccountRoles on
                              acc.AccountId equals acr.AccountId
                              join r in myContext.Roles on
                              acr.RoleId equals r.Role_Id
                              select new RegisterEmpVM
                              {
                                  FirstName = e.FirstName,
                                  LastName = e.LastName,
                                  Email = e.Email,
                                  Phone = e.Phone,
                                  Gender = (ViewModel.Gender)e.Gender,
                                  BirthDate = e.BirthDate,
                                  /*Address = e.Address,*/
                                  Password = acc.Password,
                                  HireDate = e.HireDate,
                                  Role_Id = r.Role_Id,
                                  AccountId = acc.AccountId
                              }).ToList();

            return getProfile;
        }

        public IEnumerable<RegisterEmpVM> GetProfile(string Email)
        {
            var getProfile = (from e in myContext.Employees
                              join acc in myContext.Accounts on
                              e.AccountId equals acc.AccountId
                              join acr in myContext.AccountRoles on
                              acc.AccountId equals acr.AccountId
                              join r in myContext.Roles on
                              acr.RoleId equals r.Role_Id
                              select new RegisterEmpVM
                              {
                                  FirstName = e.FirstName,
                                  LastName = e.LastName,
                                  Email = e.Email,
                                  Phone = e.Phone,
                                  Gender = (ViewModel.Gender)e.Gender,
                                  BirthDate = e.BirthDate,
                                 /* Address = e.Address,*/
                                  //Password = acc.Password,
                                  HireDate = e.HireDate,
                                  Role_Id = r.Role_Id
                              }).Where(u => u.Email == Email).ToList();

            return getProfile;
        }
        public int RegisterEmp(RegisterEmpVM registerEmpVM)
        {
            Employee employee = new Employee();
            var checkEmail = myContext.Employees.Where(x => x.Email == registerEmpVM.Email).FirstOrDefault();
            var checkPhone = myContext.Employees.Where(x => x.Phone == registerEmpVM.Phone).FirstOrDefault();
            employee.Email = registerEmpVM.Email;

            if (checkEmail != null)
            {
                return 2;
            }
            if (checkPhone != null)
            {
                return 3;
            }
            Account account = new Account();
            account.Email = registerEmpVM.Email;
            account.Password = BCrypt.Net.BCrypt.HashPassword(registerEmpVM.Password, GetRandomSalt());
            myContext.Accounts.Add(account);
            myContext.SaveChanges();

            employee.AccountId = account.AccountId;
            employee.FirstName = registerEmpVM.FirstName;
            employee.LastName = registerEmpVM.LastName;
            employee.Email = registerEmpVM.Email;
            employee.Phone = registerEmpVM.Phone;
            employee.Gender = (Models.Gender)registerEmpVM.Gender;
            employee.BirthDate = registerEmpVM.BirthDate;
/*            employee.Address = registeremployeeVM.Address;*/
            employee.HireDate = registerEmpVM.HireDate;

            myContext.Employees.Add(employee);
            myContext.SaveChanges();

            AccountRole accountRole = new AccountRole();
            accountRole.AccountId = account.AccountId;
            accountRole.RoleId = registerEmpVM.Role_Id;
            myContext.AccountRoles.Add(accountRole);
            var result = myContext.SaveChanges();
            return result;
        }

        
    }
}


