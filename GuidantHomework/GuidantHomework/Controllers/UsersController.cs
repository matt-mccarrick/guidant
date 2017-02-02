using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;
using GuidantHomework.Core.Model;
using GuidantHomework.Core.Services;
using Newtonsoft.Json.Linq;

namespace GuidantHomework.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        // GET api/users
        public IEnumerable<User> Get()
        {
            return _userService.GetAllUsers();
        }

        // GET api/users/5
        public User Get(int id)
        {
            return _userService.GetUser(id);   
        }

        // POST api/users
        public int Post([FromBody]User user)
        {
            return _userService.AddUser(user);
        }

        //If we're being restful, this should maybe be a PUT.  That would also allow us to pass both parameters without a DTO
        // POST api/users/setpoints
        [System.Web.Mvc.HttpPost]
        //This is fine for this case, but if we were to keep expanding, we might want to come up with a more flexible routing to add to our WebApiConfig
        [Route("api/users/setpoints")]
        public string SetPoints([FromBody]JObject obj )
        {
            var id = (int)obj["id"];
            var points = (int)obj["points"];
            _userService.SetPoints(id, points);
            return "Points successfully set";
        }
    }
}
