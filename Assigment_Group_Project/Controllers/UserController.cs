using Assigment_Group_Project.ViewModel;
using AutoMapper;
using BusinessObject.Models;
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
                    return Unauthorized();
                }
                if(loginAccount.StatusId == 2)
                {
                    return Unauthorized();
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
                    return BadRequest();
                }

                if (!user.Password!.Equals(user.ConfirmPassword))
                {
                    return BadRequest();
                }

                var existUser = _userService.GetAll().FirstOrDefault(x => x.Email!.Equals(user.Email));
                if (existUser == null)
                {
                    return BadRequest();
                }

                User newUser = _mapper.Map<User>(existUser);
                newUser.Role = "Customer";
                newUser.StatusId = 1;
                _userService.Add(newUser);
                _userService.Save();

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAll", Name = "Get All Accounts")]
        public IActionResult GetAllAccounts(int? page = 1, int? quantity = 10)
        {
            try
            {
                var list = _userService.GetAll(page, quantity);
                if (!list.Any())
                {
                    return NotFound();
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
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("SearchByEmail", Name = "Search Account By Email")]
        public IActionResult SearchByEmail(string email)
        {
            try
            {
                var list = _userService.GetAll().Where(x => x.Email!.Contains(email));
                if (!list.Any())
                {
                    return NotFound();
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
                    return BadRequest();
                }

                var newUser = _mapper.Map<User>(user);
                newUser.StatusId = 1;
                _userService.Add(newUser);
                _userService.Save();

                return Ok();
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
                    return BadRequest();
                }

                var existUser = _userService.GetById(id);
                if (existUser == null)
                {
                    return NotFound();
                }

                existUser = _mapper.Map(user, existUser);
                _userService.Update(existUser);
                _userService.Save();

                return Ok();
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
                    return BadRequest();
                }

                var existUser = _userService.GetById(id);
                if (existUser == null)
                {
                    return NotFound();
                }

                existUser.Role = role;
                _userService.Update(existUser);
                _userService.Save();

                return Ok();
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
                    return NotFound();
                }

                switch (existUser.StatusId)
                {
                    case 1:
                        existUser.StatusId = 2;
                        break;
                    case 2:
                        existUser.StatusId = 1;
                        break;
                    default:
                        existUser.StatusId = 1;
                        break;
                }

                _userService.Update(existUser);
                _userService.Save();

                return Ok();
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
                    return NotFound();
                }

                _userService.Delete(existUser);
                _userService.Save();

                return Ok();
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
                    new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new(JwtRegisteredClaimNames.Sub, user.Email!.Trim()),
                    new(JwtRegisteredClaimNames.Email, user.Email!.Trim()),
                    new("UserId", user.UserId.ToString()),
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
