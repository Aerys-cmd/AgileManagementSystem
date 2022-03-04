using AgileManagement.Core.Helpers;
using AgileManagementSystem.Core.Application;
using AgileManagementSystem.Core.Domain;
using AgileManagementSystem.Domain.Events;
using AgileManagementSystem.Domain.Models;
using AgileManagementSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Application.Services.Auth
{
    public class UserRegisterRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
    public class UserRegisterResponseDto
    {
        public bool IsSucceeded { get; set; }
        public string Message { get; set; }

    }
    public class UserRegisterService : IApplicationService<UserRegisterRequestDto, UserRegisterResponseDto>
    {
        private readonly IUserRepository _userRepository;
        public UserRegisterService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public UserRegisterResponseDto OnProcess(UserRegisterRequestDto request = null)
        {
            try
            {
                var existingUser = _userRepository.GetQuery().Where(x => x.Email == request.Email).FirstOrDefault();
                if (existingUser != null) return new UserRegisterResponseDto { IsSucceeded = false, Message = "Bu mail adresi sistemde mevcut." };

                var user = new User(request.Email);
                user.SetProfileInfo(request.FirstName, request.LastName, "");
                user.SetPasswordHash(CustomPasswordHashService.HashPassword(request.Password));
                _userRepository.Add(user);
                _userRepository.Save();
                DomainEvent.Raise(new UserCreatedEvent(user.Id, user.Email));
                return new UserRegisterResponseDto { IsSucceeded = true, Message = "Onay maili gönderilmiştir." };
            }
            catch (Exception ex)
            {
                return new UserRegisterResponseDto { IsSucceeded = false, Message = ex.Message };
            }

        }
    }
}
