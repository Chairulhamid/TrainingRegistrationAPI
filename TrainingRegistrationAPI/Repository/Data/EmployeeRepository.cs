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
                              acr.RoleId equals r.RoleId
                              select new RegisterEmpVM
                              {
                                  EmployeeId = e.EmployeeId,
                                  FirstName = e.FirstName,
                                  LastName = e.LastName,
                                  Email = e.Email,
                                  Phone = e.Phone,
                                  Gender = (ViewModel.Gender)e.Gender,
                                  BirthDate = e.BirthDate,
                                  Address = e.Address,
                                  Password = acc.Password,
                                  HireDate = e.HireDate,
                                  RoleId = r.RoleId,
                                  AccountId = acc.AccountId
                              }).ToList();

            return getProfile;
        }

        public IEnumerable<RegisterEmpVM> GetIdProfile(int EmployeeId)
        {
            var getProfile = (from e in myContext.Employees
                              join acc in myContext.Accounts on
                              e.AccountId equals acc.AccountId
                              join acr in myContext.AccountRoles on
                              acc.AccountId equals acr.AccountId
                              join r in myContext.Roles on
                              acr.RoleId equals r.RoleId
                              select new RegisterEmpVM
                              {
                                  AccountId = e.AccountId,
                                  EmployeeId = e.EmployeeId,
                                  FirstName = e.FirstName,
                                  LastName = e.LastName,
                                  Email = e.Email,
                                  Phone = e.Phone,
                                  Gender = (ViewModel.Gender)e.Gender,
                                  BirthDate = e.BirthDate,
                                  Address = e.Address,
                                  Password = acc.Password,
                                  HireDate = e.HireDate,
                                  RoleId = r.RoleId
                              }).Where(u => u.EmployeeId == EmployeeId).ToList();

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
            employee.Address = registerEmpVM.Address;
            employee.HireDate = registerEmpVM.HireDate;

            myContext.Employees.Add(employee);
            myContext.SaveChanges();

            AccountRole accountRole = new AccountRole();
            accountRole.AccountId = account.AccountId;
            accountRole.RoleId = registerEmpVM.RoleId;
            myContext.AccountRoles.Add(accountRole);
            var result = myContext.SaveChanges();
            return result;
        }

        public int LoginEmp(LoginEmpVM loginEmpVM)
        {
            Employee employee = new Employee();
            Account account = new Account();
            var checkEmail = myContext.Employees.Where(x => x.Email == loginEmpVM.Email).FirstOrDefault();
            if (checkEmail == null)
            {
                return 2;
            }
            var checkNik = checkEmail.AccountId;
            var checkPass = myContext.Accounts.Find(checkEmail.AccountId);
            bool validPass = BCrypt.Net.BCrypt.Verify(loginEmpVM.Password, checkPass.Password);
            if (validPass)
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }

        public int ResetPassword(LoginEmpVM loginEmpVM)
        {
            var checkEmail = myContext.Employees.Where(p => p.Email == loginEmpVM.Email).FirstOrDefault();
            if (checkEmail == null)
            {
                return 0;
            }
            else
            {
                var findEmpPassword = (from e in myContext.Employees
                                        join a in myContext.Accounts on e.AccountId equals a.AccountId
                                        where e.Email == loginEmpVM.Email
                                        select new
                                        {
                                            Employee = a
                                        });
                foreach (var x in findEmpPassword)
                {
                    x.Employee.Password = BCrypt.Net.BCrypt.HashPassword(loginEmpVM.Password);
                }
                var result = myContext.SaveChanges();
                return result;
            }
        }

        public string GetId(string email)
        {
            var checkEmail = myContext.Employees.Where(e => e.Email == email).FirstOrDefault();
            return checkEmail.EmployeeId.ToString();
        }
        public string GetName(string email)
        {
            var checkName = myContext.Employees.Where(e => e.Email == email).FirstOrDefault();
            return checkName.FirstName + " " + checkName.LastName;
        }

    }
}


