using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace WebApiUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            private UserModel Authenticater(UserModel userLogin)
            {

                var CurrentUser = CurrentUsers.UserCollection.FirstOrDefault(o => o.Email.ToLower() ==
                 userLogin.Email.ToLower() && o.Password == userLogin.Password);
                // cant use != so i had to settle with this
                // hopefully it works
                //knowing me it wont

                if (CurrentUser != null)
                {
                    return CurrentUser;
                }
                return null;

            }
        }
    }
}
