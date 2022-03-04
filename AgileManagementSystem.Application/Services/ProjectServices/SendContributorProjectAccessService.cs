using AgileManagementSystem.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Application.Services.ProjectServices
{
    public class SendContributorProjectAccessRequestDto
    {
        public string ProjectId { get; set; }
        public string ContributorMail { get; set; }
    }
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
        public SendContributorProjectAccessService()
        {

        }
        public SendContributorProjectAccessResponseDto OnProcess(SendContributorProjectAccessRequestDto request = null)
        {
            //request nullsa responsedto döndür

            //mailservise bağlanıp mail gönder  örn url = http://localhost:3000/contributoraccess/projectId/contributoremail

            //return succeeded true


            throw new NotImplementedException();
        }
    }
}
