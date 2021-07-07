using System;

using SqlServerLibrary;

namespace SqlServerConsole {
    class Program {
        static void Main(string[] args) {

            SqlServerLib ssl = new SqlServerLib();
            ssl.Connect("localhost\\sqlexpress", "PrsDb31");

            //var users = ssl.UserGetAll();
            var user = ssl.UserGetByPK(9);
            //var newUser = new User() {
            //    Id = 0, Username = "XXX", Password = "XX",
            //    FirstName = "XX", LastName = "XX",
            //    Phone = "XX", Email = "XX",
            //    Reviewer = false, Admin = false
            //};
            //ssl.UserCreate(newUser);
            user.Phone = "999";
            user.Email = "help@outoforder.com";
            var rc = ssl.UserChange(user);
            Console.WriteLine($"The change {(rc ? "worked!" : "failed")}");


            ssl.Disconnect();
        }
    }
}
