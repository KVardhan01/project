using AuhntctionCRUD.Appmodels;
using AuhntctionCRUD.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AuhntctionCRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UsersLists _usersLists;
        public UserController(UsersLists usersLists)
        {
            _usersLists = usersLists;
        }
        [HttpPost]
        [Route("UserLogin")]
        
        public IActionResult UserLogin([FromBody]UserModel userModel)
        {
            var record=UsersLists.UserLogin(userModel);
            if(record != null)
            {
                var token=_usersLists.GenerateToken(record);
                return Ok(token);
            }
            else
            {
                return BadRequest("Invalid User Credentials");
            }
        }
    }
}
