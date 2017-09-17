using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using FinancialControl.Database;
using FinancialControl.Repositories;
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
        private readonly IDataAccessProxy _proxy;

        public UsersService(IDataAccessProxy proxy)
        {
            _proxy = proxy;
        }
        public void Post(NewUserRequest request)
        {
            _proxy.CreateUser(request.Login, request.Password);
        }

        public List<string> Get(GetAllUsersRequest request)
        {
            return _proxy.GetUsers();
        }
    }
}