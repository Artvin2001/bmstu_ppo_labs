using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using TurHelper.DataAccesss.EntityStructures;

namespace TurHelper.DataAccesss.PSQLRepository
{
    public class UserRepositoryPSQL : UserRepositoryInterface
    {
        private PSQLContext db;

        public UserRepositoryPSQL()
        {
            this.db = new PSQLContext();
        }

        public UserRepositoryPSQL(string ConString)
        {
            this.db = new PSQLContext(ConString);
        }

        public List<Users> GetAllUsers()
        {
            return this.db.Users.ToList();
        }

        public Users GetUserByLogin(string Login)
        {
            var res = this.db.Users.Where(u => u.Login == Login);
            return res.FirstOrDefault();
            //return (Users)res.FirstOrDefault;
        }

        public void InsertUser(Users U)
        {
            this.db.Users.Add(U);
            this.db.SaveChanges();
        }

        public bool CheckUserLogin(string Login)
        {
            return this.db.Users.Any(u => u.Login == Login);
        }

        public int GetNewId()
        {
            try
            {
                return this.db.Users.Max(a => a.Id) + 1;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        public void DeleteUser(int Id)
        {
            var u = this.db.Users.Find(Id);
            this.db.Remove(u);
            this.db.SaveChanges();
        }

        public void DeleteUser(Users U)
        {
            this.db.Remove(U);
            this.db.SaveChanges();
        }

        public void UpdatePassword(int Id, string Password)
        {
            var User = this.db.Users.Where(u => u.Id == Id);
            User.First().Password = Password;
            this.db.SaveChanges();
        }

        public void UpdateUser(Users u)
        {
            var User = this.db.Users.Find(u.Id);
            User.Permission = u.Permission;
            this.db.SaveChanges();
        }
    }
}
