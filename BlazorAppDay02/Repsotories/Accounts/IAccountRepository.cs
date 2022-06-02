using Website.Shared.DTOs;
using Website.Shared.Models;

namespace BlazorAppDay02.Repsotories.Accounts
{
    public interface IAccountRepository
    {
        User User { get; }
        Task Login(LoginUserDto loginUserDto);
        Task Register(RegisterUserDto registerUserDto);
        Task Logout();
    }
}
