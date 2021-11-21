using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Context;
using TrainingRegistrationAPI.Models;
using TrainingRegistrationAPI.ViewModel;

namespace TrainingRegistrationAPI.Repository.Data
{
    public class UserRepository : GeneralRepository<MyContext, User, int>
    {
        private static string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }

        private readonly MyContext myContext;
        public UserRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public IEnumerable<RegisterUserVM> GetProfile()
        {
            var getProfile = (from u in myContext.Users
                              join acc in myContext.Accounts on
                              u.AccountId equals acc.AccountId
                              join acr in myContext.AccountRoles on
                              acc.AccountId equals acr.AccountId
                              join r in myContext.Roles on
                              acr.RoleId equals r.Role_Id
                              select new RegisterUserVM
                              {
                                  FullName = u.FirstName + " " + u.LastName,
                                  Email = u.Email,
                                  Phone = u.Phone,
                                  Gender = (ViewModel.Gender)u.Gender,
                                  BirthDate = u.BirthDate,
                                  Address = u.Address,
                                  //Password = acc.Password,
                                  RegistDate = u.RegistDate,
                                  Role_Id = r.Role_Id
                              }).ToList();

            return getProfile;
        }

        public IEnumerable<RegisterUserVM> GetProfile(string Email)
        {
            var getProfile = (from u in myContext.Users
                              join acc in myContext.Accounts on
                              u.AccountId equals acc.AccountId
                              join acr in myContext.AccountRoles on
                              acc.AccountId equals acr.AccountId
                              join r in myContext.Roles on
                              acr.RoleId equals r.Role_Id
                              select new RegisterUserVM
                              {
                                  FullName = u.FirstName + " " + u.LastName,
                                  Email = u.Email,
                                  Phone = u.Phone,
                                  Gender = (ViewModel.Gender)u.Gender,
                                  BirthDate = u.BirthDate,
                                  Address = u.Address,
                                  //Password = acc.Password,
                                  RegistDate = u.RegistDate,
                                  Role_Id = r.Role_Id
                              }).Where(u => u.Email == Email).ToList();

            return getProfile;
        }

        public int RegisterUser(RegisterUserVM registerUserVM)
        {
            User user = new User();
            var checkEmail = myContext.Users.Where(x => x.Email == registerUserVM.Email).FirstOrDefault();
            var checkPhone = myContext.Users.Where(x => x.Phone == registerUserVM.Phone).FirstOrDefault();
            user.Email = registerUserVM.Email;
            
            if (checkEmail != null)
            {
                return 2;
            }
            if (checkPhone != null)
            {
                return 3;
            }
            
            user.FirstName = registerUserVM.FirstName;
            user.LastName = registerUserVM.LastName;
            user.Email = registerUserVM.Email;
            user.Phone = registerUserVM.Phone;
            user.Gender = (Models.Gender)registerUserVM.Gender;
            user.BirthDate = registerUserVM.BirthDate;
            user.Address = registerUserVM.Address;
            user.RegistDate = registerUserVM.RegistDate;
            myContext.Users.Add(user);
            myContext.SaveChanges();

            Account account = new Account();
            account.AccountId = registerUserVM.AccountId;
            account.Password = BCrypt.Net.BCrypt.HashPassword(registerUserVM.Password, GetRandomSalt());
            myContext.Accounts.Add(account);
            myContext.SaveChanges();

            AccountRole accountRole = new AccountRole();
            accountRole.AccountId = account.AccountId;
            accountRole.RoleId = 2;
            /*accountRole.RoleId = registerUserVM.Role_Id;*/
            myContext.AccountRoles.Add(accountRole);
            var result = myContext.SaveChanges();
            return result;
        }

    }
}
