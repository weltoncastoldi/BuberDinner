namespace BuberDinner.Contracts.Authentication
{
    public record LoginRequest(
        string Password,
        string Email
    );
}