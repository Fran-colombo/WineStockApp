using Common.Models;
using Data.Entities;

namespace Service.Interface
{
  public interface IUserService
  {
    int AddUser(UserForCreationDto userDto);
    User? AuthenticateUser(string username, string password);
  }
}