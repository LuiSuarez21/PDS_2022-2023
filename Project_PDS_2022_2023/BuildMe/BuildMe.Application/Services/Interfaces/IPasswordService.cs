namespace BuildMe.Application.Services.Interfaces
{
    public interface IPasswordService
    {
        public string HashPassword(string password);
        public bool VerifyHashedPassword(string hashedPassword, string password);
    }
}