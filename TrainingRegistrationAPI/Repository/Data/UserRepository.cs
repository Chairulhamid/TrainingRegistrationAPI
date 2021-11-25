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
                              acr.RoleId equals r.RoleId
                              select new RegisterUserVM
                              {
                                  FirstName = u.FirstName,
                                  LastName = u.LastName,
                                  Email = u.Email,
                                  Phone = u.Phone,
                                  Gender = (ViewModel.Gender)u.Gender,
                                  BirthDate = u.BirthDate,
                                  Address = u.Address,
                                  Password = acc.Password,
                                  RegistDate = u.RegistDate,
                                  RoleId = r.RoleId,
                                  AccountId = acc.AccountId
                              }).ToList();

            return getProfile;
        }

        public IEnumerable<RegisterUserVM> GetIdProfile(int UserId)
        {
            var getProfile = (from u in myContext.Users
                              join acc in myContext.Accounts on
                              u.AccountId equals acc.AccountId
                              join acr in myContext.AccountRoles on
                              acc.AccountId equals acr.AccountId
                              join r in myContext.Roles on
                              acr.RoleId equals r.RoleId
                              select new RegisterUserVM
                              {
                                  AccountId = u.AccountId,
                                  UserId = u.UserId,
                                  FirstName = u.FirstName,
                                  LastName = u.LastName,
                                  Email = u.Email,
                                  Phone = u.Phone,
                                  Gender = (ViewModel.Gender)u.Gender,
                                  BirthDate = u.BirthDate,
                                  Address = u.Address,
                                  Password = acc.Password,
                                  RegistDate = u.RegistDate,
                                  RoleId = r.RoleId
                              }).Where(u => u.UserId == UserId).ToList();

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
            Account account = new Account();
            account.Email = registerUserVM.Email;
            account.Password = BCrypt.Net.BCrypt.HashPassword(registerUserVM.Password, GetRandomSalt());
            myContext.Accounts.Add(account);
            myContext.SaveChanges();

            user.AccountId = account.AccountId;
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

            AccountRole accountRole = new AccountRole();
            accountRole.AccountId = account.AccountId;
            accountRole.RoleId = 2;
            myContext.AccountRoles.Add(accountRole);
            var result = myContext.SaveChanges();
            return result;
        }
        public int LoginUser(LoginUserVM loginUserVM)
        {
            User user= new User();
            Account account = new Account();
            var checkEmail = myContext.Users.Where(x => x.Email == loginUserVM.Email).FirstOrDefault();
            if (checkEmail == null)
            {
                return 2;
            }
            var checkNik = checkEmail.AccountId;
            var checkPass = myContext.Accounts.Find(checkEmail.AccountId);
            bool validPass = BCrypt.Net.BCrypt.Verify(loginUserVM.Password, checkPass.Password);
            if (validPass)
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }

        public int ResetPassword(LoginUserVM loginUserVM)
        {
            var checkEmail = myContext.Users.Where(p => p.Email == loginUserVM.Email).FirstOrDefault();
            if (checkEmail ==  null)
            {
                return 0;
            }
            else
            {
                var findUserPassword = (from u in myContext.Users
                                        join a in myContext.Accounts on u.AccountId equals a.AccountId
                                        where u.Email == loginUserVM.Email
                                        select new
                                        {
                                            User = a
                                        });
                foreach (var x in findUserPassword)
                {
                    x.User.Password = BCrypt.Net.BCrypt.HashPassword(loginUserVM.Password);
                }
                var result = myContext.SaveChanges();
                return result;
            }
        }

    }
}
