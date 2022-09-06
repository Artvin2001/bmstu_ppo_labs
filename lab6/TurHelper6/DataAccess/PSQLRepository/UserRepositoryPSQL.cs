using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using TurHelper.DataAccesss.EntityStructures;
using TurHelper6.DataAccess.Exceptions;
using TurHelper6;

namespace TurHelper.DataAccesss.PSQLRepository
{
    public class UserRepositoryPSQL : UserRepositoryInterface
    {
        private PSQLContext db;
        private Log log;

        public UserRepositoryPSQL()
        {
            this.db = new PSQLContext();
            this.log = new Log();
        }

        public UserRepositoryPSQL(string ConString)
        {
            this.db = new PSQLContext(ConString);
            this.log = new Log();
        }

        public List<Users> GetAllUsers()
        {
            return this.db.Users.ToList();
        }

        public Users GetUserByLogin(string Login)
        {
            try
            {
                var res = this.db.Users.Where(u => u.Login == Login);
                return res.FirstOrDefault();
            }
            catch
            {
                throw new GetUserException();
            }
        }

        public void InsertUser(Users U)
        {
            try
            {
                this.db.Users.Add(U);
                this.db.SaveChanges();
            }
            catch
            {
                throw new InsertUserException();
            }
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
            catch 
            {
                throw new UseridException();
            }
        }

        public void DeleteUser(int Id)
        {
            try
            {
                var u = this.db.Users.Find(Id);
                this.db.Remove(u);
                this.db.SaveChanges();
            }
            catch
            {
                throw new DeleteUserException();
            }
        }

        public void DeleteUser(Users U)
        {
            try
            {
                this.db.Remove(U);
                this.db.SaveChanges();
            }
            catch
            {
                throw new DeleteUserException();
            }
        }

        public void UpdatePassword(int Id, string Password)
        {
            try
            {
                var User = this.db.Users.Where(u => u.Id == Id);
                User.First().Password = Password;
                this.db.SaveChanges();
            }
            catch
            {
                throw new UpdateUserException();
            }
        }

        public void UpdateUser(Users u)
        {
            try
            {
                var User = this.db.Users.Find(u.Id);
                User.Permission = u.Permission;
                this.db.SaveChanges();
            }
            catch
            {
                throw new UpdateUserException();
            }
        }
    }
}
