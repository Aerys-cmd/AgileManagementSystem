using AgileManagementSystem.Core.Application;
using AgileManagementSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Application.Services.Verify
{
    public class UserVerifyEmailRequestDto
    {
        public string UserId { get; set; }
    }
    public class UserVerifyEmailResponseDto
    {
        public bool IsSucceeded { get; set; }
        public string Message { get; set; }
    }

    public class UserVerifyMailService : IApplicationService<UserVerifyEmailRequestDto, UserVerifyEmailResponseDto>
    {
        private readonly IUserRepository _userRepository;
        public UserVerifyMailService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public UserVerifyEmailResponseDto OnProcess(UserVerifyEmailRequestDto request = null)
        {
            if (request == null)
                throw new ArgumentNullException();

            var user = _userRepository.Find(request.UserId);

            if (user == null)
                return new UserVerifyEmailResponseDto { IsSucceeded = false, Message = "Böyle bir user bulunamadı" };

            user.SetVerifyEmail();
            _userRepository.Save();

            return new UserVerifyEmailResponseDto
            {
                IsSucceeded = true,
                Message = "Başarılı"
            };
        }
    }
}
