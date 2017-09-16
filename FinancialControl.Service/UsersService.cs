using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DatabaseProxy;
using ServiceStack;

namespace FinancialControl.Service
{
    [Route("/users", "POST", Summary = @"Create user")]
    public class NewUserRequest
    {
        public string Password { get; set; }
        public string Login { get; set; }
    }
    [Route("/users", "GET", Summary = "Returns all usernames")]
    public class GetAllUsersRequest
    {

    }
    public class UsersService : IService
    {
        public async Task<int> Post(NewUserRequest request)
        {
            using (var db = new DatabaseContext())
            {
                return await db.CreateUser(request.Login, request.Password);
            }
        }

        public List<string> Get(GetAllUsersRequest request)
        {
            using (var db = new DatabaseContext())
            {
                return db.Users.Select(x => x.Login).ToList();
            }
        }
    }
}