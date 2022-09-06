using System;
using Xunit;
using System.Linq;
using TurHelper;

using TurHelper.DataAccesss.PSQLRepository;
using TurHelper.DataAccesss.EntityStructures;
using TurHelper.DataAccesss;

namespace DAUnitTests
{
    public class UnitTestUsers
    {
        UserRepositoryPSQL user_rep = new UserRepositoryPSQL();
        private void CheckEqual(Users u1, Users u2)
        {
            Assert.Equal(u1.Login, u2.Login);
            Assert.Equal(u1.Password, u2.Password);
            Assert.Equal(u1.Permission, u2.Permission);
        }

        [Fact]
        public void TestInsertUser()
        {
            Users user = new Users();
            user.Id = user_rep.GetNewId();
            user.Login = "Test";
            user.Password = "test123";
            user.Permission = 1;

            user_rep.InsertUser(user);
            using (PSQLContext db = new PSQLContext())
            {
                var u = db.Users.Find(user.Id);
                CheckEqual(user, u);
            }
        }


        [Theory]
        [InlineData("moder")]

        public void TestGetUserInfo(string Login)
        {
            Users user = user_rep.GetUserByLogin(Login);

            using (PSQLContext db = new PSQLContext ())
            {
                var u = db.Users.Find(user.Id);
                CheckEqual(user, u);
            }
        }

        [Fact]
        public void TestDeleteUser()
        {
            using (PSQLContext db = new PSQLContext())
            {
                //как лучше?
                int Id = user_rep.GetNewId() - 1;
                user_rep.DeleteUser(Id);

                if (db.Users.Find(Id) != null)
                    throw new Exception("Delete_user problem");
            }
        }

        [Theory]
        [InlineData("2345")]
        public void TestUpdatePassword(string Password)
        {
            int Id = 1;
            user_rep.UpdatePassword(Id, Password);

            using (PSQLContext db = new PSQLContext())
            {
                var u = db.Users.Find(Id);
                Assert.Equal(u.Password, Password);
            }
        }

    }
}
