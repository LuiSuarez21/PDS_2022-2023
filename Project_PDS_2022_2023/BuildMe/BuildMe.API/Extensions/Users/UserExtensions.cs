using BuildMe.API.Data.Contracts.Users;
using BuildMe.Domain.Model;

namespace BuildMe.API.Extensions.Users
{
    public static class UserExtensions
    {
        public static User ConvertFromBody(this CreateUserRequestContract newUser)
        {
            return new User()
            {
                UserName = newUser.UserName,
                Password = newUser.Password,
                Email = newUser.Email,
                Address = newUser.Address,
                CompanyId = newUser.CompanyId is null ? null: newUser.CompanyId,
                Phone = newUser.Phone,
                PostalCode = newUser.PostalCode,
                VAT = newUser.VAT
            };
        }

        public static User ConvertFromBody(this UpdateUserRequestContract updateUser)
        {
            return new User()
            {
                Id = updateUser.Id,
                UserName = updateUser.UserName,
                Password = updateUser.Password,
                Email = updateUser.Email,
                Address = updateUser.Address,
                CompanyId = updateUser.CompanyId,
                Phone = updateUser.Phone,
                PostalCode = updateUser.PostalCode,
                VAT = updateUser.VAT,
                Inactive = updateUser.Inactive,
                LastUpdate = updateUser.LastUpdate
            };
        }

        public static User ConvertFromBody(this UserLoginRequestContract userLogin)
        {
            return new User()
            {
                UserName = userLogin.UserName,
                Password = userLogin.Password
            };
        }
    }
}
