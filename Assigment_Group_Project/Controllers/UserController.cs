using Assigment_Group_Project.ViewModel;
using AutoMapper;
using BusinessObject.CustomMessage;
using BusinessObject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.IService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Assigment_Group_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        //3 Role = ["Admin", "Staff", "Customer"]
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("Login", Name = "Login By Email")]
        public IActionResult Login(string email, string password)
        {
            try
            {
                var loginAccount = _userService.GetAll().FirstOrDefault(x => x.Email!.Equals(email, StringComparison.OrdinalIgnoreCase)
                                                                     && x.Password!.Equals(password));
                if(loginAccount == null)
                {
                    return Unauthorized(ReturnMessage.WRONG_LOGIN_INFO);
                }
                if(loginAccount.StatusUserId == 2)
                {
                    return Unauthorized(ReturnMessage.BANNED);
                }

                string jwt = GenerateToken(loginAccount);
                return Ok(jwt);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("SignUp", Name = "Sign Up New Account")]
        public IActionResult SignUp(SignUpUserVM user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ReturnMessage.BAD_REQUEST);
                }

                if (!user.Password!.Equals(user.ConfirmPassword))
                {
                    return BadRequest(ReturnMessage.FAILED_MATCH_PASSWORD);
                }

                var existUser = _userService.GetAll().FirstOrDefault(x => x.Email!.Equals(user.Email));
                if (existUser != null)
                {
                    return BadRequest(ReturnMessage.DUPLICATE_EMAIL);
                }

                User newUser = _mapper.Map<User>(user);
                newUser.Role = "Customer";
                newUser.StatusUserId = 1;
                _userService.Add(newUser);
                _userService.Save();

                return Ok(ReturnMessage.SIGNUP_SUCCESS);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAll", Name = "Get All Accounts")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllAccounts(int? page = 1, int? quantity = 10)
        {
            try
            {
                var list = _userService.GetAll(page, quantity);
                if (!list.Any())
                {
                    return NotFound(ReturnMessage.EMPTY_LIST);
                }
                return Ok(list);
            }
            catch(Exception ex )
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Get/{id}", Name = "Get Account By ID")]
        public IActionResult GetById([FromRoute] long id)
        {
            try
            {
                var user = _userService.GetById(id);
                if (user == null)
                {
                    return NotFound(ReturnMessage.USER_NOT_FOUND);
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("SearchByEmail", Name = "Search Account By Email")]
        public IActionResult SearchByEmail(string email, int? page = 1, int? quantity = 10) 
        { 
            try
            {
                var list = _userService.SearchByEmail(email, page, quantity);
                if (!list.Any())
                {
                    return NotFound(ReturnMessage.EMPTY_LIST);
                }
                return Ok(list);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Create", Name = "Create New User By Admin")]
        public IActionResult CreateUser(UserCreateByAdminVM user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ReturnMessage.BAD_REQUEST);
                }

                var newUser = _mapper.Map<User>(user);
                newUser.StatusUserId = 1;
                _userService.Add(newUser);
                _userService.Save();

                return Ok(ReturnMessage.ADD_SUCCESS);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("UpdateByUser/{id}", Name = "Update Profile By User")]
        public IActionResult UpdateByUser([FromRoute] long id ,UserUpdateByCustomerVM user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ReturnMessage.BAD_REQUEST);
                }

                var existUser = _userService.GetById(id);
                if (existUser == null)
                {
                    return NotFound(ReturnMessage.USER_NOT_FOUND);
                }

                if (!existUser.Email!.Equals(user.Email))
                {
                    var existUserByEmail = _userService.GetAll().Where(x => x.Email!.Equals(user.Email, StringComparison.OrdinalIgnoreCase));
                    if (!existUserByEmail.Any())
                    {
                        return BadRequest(ReturnMessage.DUPLICATE_EMAIL);
                    }
                }

                existUser = _mapper.Map(user, existUser);
                _userService.Update(existUser);
                _userService.Save();

                return Ok(ReturnMessage.UPDATE_SUCCESS);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("UpdateRoleByAdmin/{id}", Name = "Update Profile By Admin")]
        public IActionResult UpdatRoleByAdmin([FromRoute] long id, string role)
        {
            try
            {
                if(role == null)
                {
                    return BadRequest(ReturnMessage.NULL_DATA);
                }

                var existUser = _userService.GetById(id);
                if (existUser == null)
                {
                    return NotFound(ReturnMessage.USER_NOT_FOUND);
                }

                existUser.Role = role;
                _userService.Update(existUser);
                _userService.Save();

                return Ok(ReturnMessage.UPDATE_SUCCESS);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("ChangeStatus/{id}", Name = "Ban/Unban A User")]
        public IActionResult ChangeUserStatus([FromRoute] long id)
        {
            try
            {
                var existUser = _userService.GetById(id);
                if (existUser == null)
                {
                    return NotFound(ReturnMessage.USER_NOT_FOUND);
                }

                switch (existUser.StatusUserId)
                {
                    case 1:
                        existUser.StatusUserId = 2;
                        break;
                    case 2:
                        existUser.StatusUserId = 1;
                        break;
                    default:
                        existUser.StatusUserId = 1;
                        break;
                }

                _userService.Update(existUser);
                _userService.Save();

                return Ok(ReturnMessage.UPDATE_STATUS_SUCCESS);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete/{id}", Name = "Delete A User")]
        public IActionResult DeleteUser([FromRoute] long id)
        {
            try
            {
                var existUser = _userService.GetById(id);
                if (existUser == null)
                {
                    return NotFound(ReturnMessage.USER_NOT_FOUND);
                }

                _userService.Delete(existUser);
                _userService.Save();

                return Ok(ReturnMessage.DELETE_SUCCESS);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        private string GenerateToken(User user)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            var tokenSecret = config["Jwt:Key"];

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(tokenSecret);

            var claims = new List<Claim>
                {
                    new("userId", user.UserId.ToString()),
                    new(ClaimTypes.Name, user.Fullname ?? ""),
                    new(ClaimTypes.Role, user.Role!.Trim()),
                };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(TimeSpan.FromMinutes(30)),
                Issuer = config["Jwt:Issuer"],
                Audience = config["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);
            return jwt;
        }
    }
}
