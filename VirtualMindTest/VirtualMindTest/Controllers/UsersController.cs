using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using VirtualMindTest.Repository;
using VirtualMindTest.Repository.Interface;

namespace VirtualMindTest.Controllers
{
    
    public class UsersController : ApiController
    {
        private IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        // GET api/users
        
       
        public List<User> Get()
        {
            return _userRepository.GetUsers();
        }

        // GET api/user/5
        [ResponseType(typeof(User))]
        public IHttpActionResult Get(int id)
        {
            return Ok(_userRepository.GetUserById(id));
        }

        // POST api/users
        
        public IHttpActionResult Post([FromBody] Models.User user)
        {
            _userRepository.InsertUser(user);
            return Ok();
        }

        // PUT api/users/5

        public IHttpActionResult Put(int id, [FromBody]Models.User user)
        {
            _userRepository.UpdateUser(id, user);
            return Ok();
        }

        // DELETE api/users/5
        
        public IHttpActionResult Delete(int id)
        {
            _userRepository.DeleteUserById(id);
            return Ok();
        }
    }
}
