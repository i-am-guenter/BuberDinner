using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Threading.Tasks;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("The user does not exist. Please register first.");
        }

        if (password != user.Password)
        {
            throw new Exception("The provided password is not correct.");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult
        (
            user,
            token
        );
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // 1. Check if user already exists in the database...

        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("The user with given email already exists.");
        }


        // 2. If not, create the user with data from the request.

        var user = new User()
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        // 3. Persist user in database

        _userRepository.Add(user);

        // 4. Issue token for the user

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult
        (
            user,
            token
        );
    }
}
