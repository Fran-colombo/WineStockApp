using Common.Models;
using Data.Entities;
using Data.Repositories;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
  public class UserService : IUserService
  {
    private readonly UserRepository _repository;
    public UserService(UserRepository repository)
    {
      _repository = repository;
    }

    public int AddUser(UserForCreationDto userDto)
    {
      if (!_repository.GetAllUsers().Any(u => u.Username == userDto.Username))
      {
        var newUser = _repository.AddUser(
         new User
         {
           Username = userDto.Username,
           Password = userDto.Password

         });
        return newUser; //No terminado, así para que n ode error.
      }
      else
      {
        throw new ArgumentException("The username already exists"); 
      }

    }
    public IEnumerable<User> GetUsers()
    {
      return _repository.GetAllUsers();
    }

    public User? GetUserByUsername(string username)
    {
      return _repository.GetUserByUsername(username);
    }

    public User? AuthenticateUser(string username, string password)
    {
      User? userToReturn = _repository.GetUserByUsername(username);
      if (userToReturn is not null && userToReturn.Password == password)
        return userToReturn;
      return null;
    }

  }
}
