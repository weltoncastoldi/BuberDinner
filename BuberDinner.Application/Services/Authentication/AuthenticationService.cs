using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResult Login(string email, string password);
        AuthenticationResult Register(string firstName, string lastName, string email, string password);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(
                            Guid.NewGuid(), "Nome", "Sobrenome", email, "token");
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            var id = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(id.ToString(), firstName, lastName);
            
            return new AuthenticationResult(
                Guid.NewGuid(), firstName, lastName, token, email);
        }
    }
}