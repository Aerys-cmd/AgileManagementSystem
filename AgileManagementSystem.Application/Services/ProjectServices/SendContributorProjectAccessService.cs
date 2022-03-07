using AgileManagementSystem.Core.Application;
using AgileManagementSystem.Core.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Application.Services.ProjectServices
{
    /// <summary>
    /// İstek Dto
    /// </summary>
    public class SendContributorProjectAccessRequestDto
    {
        public string ProjectId { get; set; }
        public string ContributorMail { get; set; }
    }
    /// <summary>
    /// Dönüş dto
    /// </summary>
    public class SendContributorProjectAccessResponseDto
    {
        public string Message { get; set; }
        public bool IsSucceeded { get; set; }
    }
    public class SendContributorProjectAccessService : IApplicationService<SendContributorProjectAccessRequestDto, SendContributorProjectAccessResponseDto>
    {
        /// <summary>
        /// Mail servise bağlanılacak.
        /// </summary>
        private readonly IEmailService _emailService;
        public SendContributorProjectAccessService(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public SendContributorProjectAccessResponseDto OnProcess(SendContributorProjectAccessRequestDto request = null)
        {
            if (request == null)
            {
                return new SendContributorProjectAccessResponseDto
                {
                    IsSucceeded = false,
                    Message = "İstek yanlış geldi."
                };
            }
            string activationLink = $"http://localhost:3000/contributorprojectaccess/{request.ProjectId}/{request.ContributorMail}";


            _emailService.SendSingleEmailAsync(request.ContributorMail, "Proje Katılım isteği", $"<p> Emaili onaylamak için <a href='{activationLink}'> Tıklaynız <a/></p>");

            return new SendContributorProjectAccessResponseDto
            {
                IsSucceeded = true,
                Message = "Başarılı"
            };

        }
    }
}
