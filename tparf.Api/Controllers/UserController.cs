using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using tparf.Dto;
using tparf.Interfaces;
using tparf.Domain.Entites;
using tparf.Repository;
using tparf.Application.Services.Common.Interfaces.Persistance;

namespace tparf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository1;
        private readonly IUserRepositories _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepositories userRepository, IMapper mapper, IUserRepository userRepository1)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers()
        {
            var users = _mapper.Map<List<UserDto>>(_userRepository.GetUsers());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(users);
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUser(string userEmail)
        {
            if (!_userRepository.UserExists(userEmail))
                return NotFound();
            var user = _mapper.Map<UserDto>(_userRepository.GetUser(userEmail));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(user);
        }

        [HttpGet("{userId}/product")]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(400)]
        public IActionResult GetProductByUser(string userEmail)
        {
            if (!_userRepository.UserExists( userEmail))
            {
                return NotFound();
            }
            var userProduct = _mapper.Map<List<ProductDto>>(_userRepository.GetProductByUser(userEmail));
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(userProduct);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        

        [HttpGet("{userId}/totalprice")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetTotalPrice(string userEmail)
        {
            if (!_userRepository.UserExists(userEmail))
                return NotFound();
            var userTotalPrice = _userRepository.GetTotalPrice(userEmail);
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(userTotalPrice);
        }
    }
}
