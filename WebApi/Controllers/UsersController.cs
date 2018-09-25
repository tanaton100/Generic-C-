using Model.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        private IUserService _userService;

        public UsersController()
        {
            _userService = new UserService();
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userService.GetAll();
        }

        [HttpGet]
        [Route("{id:int}")]
        public User GetById(int id)
        {
            return _userService.GetById(id);
        }

        [HttpPost]
        public bool Add(User user)
        {
            return _userService.Add(user);
        }

        [HttpPut]
        public bool Update(User user)
        {
            return _userService.Update(user);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public bool Delete(int id)
        {
            var user = new User { Id = id };
            return _userService.Delete(user);
        }

    }
}
