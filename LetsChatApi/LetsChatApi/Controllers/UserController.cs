using LetsChat.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace LetsChatApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        UserDAO _userDAO = new UserDAO();

        public List<string> Get(Int64 id)
        {
            return _userDAO.GetOnlineUsers(id);
        }


        [ResponseType(typeof(Int64))]
        public IHttpActionResult Post(string username)
        {
            if (_userDAO.LoggedInUserCount() >= 20)
            {
                return BadRequest("Most 20 users can login at a time, which are already logged in.");
            }

            Int64 userId = _userDAO.Login(username);
            return Ok(userId);
        }

        public void Put(Int64 id)
        {
            _userDAO.LogOut(id);
        }


    }
}
