
using tparf.Application.Services.Common.Errors;
using tparf.Application.Services.Common.Interfaces.Authentication;
using tparf.Application.Services.Common.Interfaces.Persistance;
using tparf.Domain.Entites;

namespace tparf.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, 
            IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }
        public AuthenticationResult Login(string email, string password)
        {
            // Проверка на существование пользователя
            if (_userRepository.GetUserByEmail(email) is not User user) 
            {
                throw new Exception("Неверный адрес электронной почты или пароль");            
            }
            // Проверка корректности пароля
            if (user.Password != password)
            {
                throw new Exception("Неверный адрес электронной почты или пароль");
            }
            // Создание Jwt Token
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(
                user,
                token);
        }

        public AuthenticationResult Register(string firstname, string lastname, string email, string password)
        {
            // Проверка на существование пользователя
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                throw new DuplicateEmailException();
            }
            // Создание пользователя (генерация уникального ID)
            var user = new User {
                FirstName = firstname, 
                LastName = lastname, 
                Email= email, 
                Password = password };
            _userRepository.Add(user);
            // Создание JWT Token
            
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
