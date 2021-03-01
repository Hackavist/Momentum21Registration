using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MomentumRegistrationApi.Dtos;
using MomentumRegistrationApi.Extensions;
using Microsoft.AspNetCore.Http;
using MomentumRegistrationApi.Repository.Implementations;
using MomentumRegistrationApi.Services.SecurityService;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;

namespace MomentumRegistrationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository userRepository;
        private readonly ISecurityService securityService;

        public UserController(IUserRepository userRepository, ILogger<UserController> logger, ISecurityService securityService)
        {
            _logger = logger;
            this.userRepository = userRepository;
            this.securityService = securityService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetAllUsers()
        {
            var allItems = await userRepository.GetAllAsync();
            if (allItems == null)
                return StatusCode(StatusCodes.Status404NotFound, "No Users Found");
            return StatusCode(StatusCodes.Status200OK, allItems);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<UserResponseDto>> GetUserById(Guid Id)
        {
            var item = await userRepository.GetAsync(Id);
            if (item == null)
                return StatusCode(StatusCodes.Status404NotFound, "Item Not Found");
            return StatusCode(StatusCodes.Status200OK, item.AsResponseDto());
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<long>> InsertUsers(UserRequestDto item)
        {
            item.Username = item.Username.ToLower();
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            item.Password = securityService.HashPassword(item.Password, salt);
            var user = item.AsUser();
            user.Salt = salt;
            var insertedSequence = await userRepository.InsertAsync(user);
            if (insertedSequence < 1)
                return StatusCode(StatusCodes.Status406NotAcceptable);
            return StatusCode(StatusCodes.Status201Created, insertedSequence);
        }
        [AllowAnonymous]
        [HttpPost("Token")]
        public async Task<ActionResult<long>> GenerateToken(LoginRequest login)
        {
            var salt = await userRepository.GetUserSalt(login.username);
            login.Password = securityService.HashPassword(login.Password, salt);
            var user = await userRepository.Login(login.username, login.Password);
            if (user == null)
                return StatusCode(StatusCodes.Status406NotAcceptable);
            return StatusCode(StatusCodes.Status201Created, new LoginResponse
            {
                username = user.Username,
                Token = securityService.Createtoken(user),
                Expiry = 5.0
            });
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteuser(Guid id)
        {
            var deleteResult = await userRepository.DeleteAsync(id);
            if (deleteResult.IsAcknowledged)
                return StatusCode(StatusCodes.Status204NoContent);
            return StatusCode(StatusCodes.Status406NotAcceptable);
        }
    }
}