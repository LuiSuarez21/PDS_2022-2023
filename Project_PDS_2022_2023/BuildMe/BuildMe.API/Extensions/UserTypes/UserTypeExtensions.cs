using BuildMe.API.Data.Contracts.UserTypes;
using BuildMe.Domain.Model;

namespace BuildMe.API.Extensions.UserTypes
{
    public static class UserTypeExtensions
    {
        public static UserType ConvertFromBody(this CreateUserTypeRequestContract newUserType)
        {
            return new UserType()
            {
                Description = newUserType.Description
            };
        }

        public static UserType ConvertFromBody(this UpdateUserTypeRequestContract updateUserType)
        {
            return new UserType()
            {
                Id = updateUserType.Id,
                Description = updateUserType.Description,
                Inactive = updateUserType.Inactive,
                LastUpdate = updateUserType.LastUpdate
            };
        }
    }
}
