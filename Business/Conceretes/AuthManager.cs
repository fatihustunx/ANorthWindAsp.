using Business.Abstracts;
using Business.Constants;
using Core.Entities.Conceretes;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Conceretes
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> RunToRegister(UserForRegisterDto userForRegisterDto)
        {
            var user = Register(userForRegisterDto);
            if (!user.Success)
            {
                return new ErrorDataResult<AccessToken>(user.Message);
            }

            var res = CreateAccessToken(user.Data);

            return res;
        }

        public IDataResult<AccessToken> RunToLogin(UserForLoginDto userForLoginDto)
        {
            var user = Login(userForLoginDto);
            if (!user.Success)
            {
                return new ErrorDataResult<AccessToken>(user.Message);
            }
            var res = CreateAccessToken(user.Data);

            return res;
        }

        private IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            var error = IsUserExists(userForRegisterDto.Email);

            if(!error.Success)
            {
                return new ErrorDataResult<User>(error.Message);
            }

            byte[] passwordSalt, passwordHash;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordSalt, out passwordHash);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userService.Add(user);

            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        private IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var user = _userService.GetByMail(userForLoginDto.Email);

            if (user == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordSalt, user.PasswordHash))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(user, Messages.SuccessfulLogin);
        }

        private IResult IsUserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        private IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }
}