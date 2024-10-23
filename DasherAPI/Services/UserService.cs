using DasherAPI.Controllers;
using DasherAPI.Data;
using DasherAPI.Interfaces;

namespace DasherAPI.Services
{
    public class UserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly UserController _userController;
        private readonly IJwtProvider _jwtProvider;
        public UserService(IJwtProvider jwtProvider,IPasswordHasher passwordHasher, UserController userController) 
        {
            _passwordHasher = passwordHasher;
            _userController = userController;
            _jwtProvider = jwtProvider;
        }
        public async Task Register(string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);
            var user = new User { 
                UserID = _userController.Get().Count + 1, 
                Firstname = "Test",
                Lastname = "Test",
                PasswordHash = hashedPassword,
                Email = email,
                PhoneNumber = "+000000000",
                Role = "Employee",
                IsActive = true,
                DateCreated = DateTime.Now,
                LastLogin = DateTime.Now,
            };
            await _userController.Post(user);
        }
        public async Task<string> Login(string email, string password)
        {
            var user = await _userController.GetByEmail(email);

            var result = _passwordHasher.Verify(password, user.PasswordHash);
            if (result == false)
            {
                throw new Exception("False Login");
            }
            var token = _jwtProvider.GenerateToken(user);


            return token;
        }
    }
}
