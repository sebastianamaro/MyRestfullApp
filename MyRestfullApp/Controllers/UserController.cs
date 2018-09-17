using MyRestfullApp.DTO;
using MyRestfullApp.Service;
using MyRestfullApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyRestfullApp.Controllers
{
    public class UserController : ApiController
    {
        IUserService service;
        public UserController(IUserService userService)
        {
            this.service = userService;
        }

        // GET: api/User
        public IHttpActionResult Get()
        {
            return Ok(service.GetUsers());
        }

        // GET: api/User/5
        public IHttpActionResult Get(int id)
        {
            var user= service.GetUser(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // POST: api/User
        public IHttpActionResult Post([FromBody]UserDTO value)
        {
            var newUser = service.AddUser(value);
            return Ok(newUser);
        }

        // PUT: api/User/5
        public IHttpActionResult Put(int id, [FromBody]UserDTO value)
        {
            var updatedUser= service.UpdateUser(id,value);
            if (updatedUser == null)
                return NotFound();

            return Ok(updatedUser);
        }

        // DELETE: api/User/5
        public IHttpActionResult Delete(int id)
        {
            var user = service.GetUser(id);
            if (user == null)
                return NotFound();

            service.DeleteUser(id);
            return Ok();
        }
    }
}
