using HospitalManagementSystem.Models;
using HospitalManagementSystem.Models.Web;
using Multiplex.DomainServices.Security;
using Multiplex.Utilities.Configuration;
using System.Collections.Generic;
using System.Web;

namespace HospitalManagementSystem.Web.Helpers
{
    public class CommunicationNotifier
    {
        public CommunicationNotifier(Communication communication)
        {
            Communication = communication;
            //SetUsers();
        }

        public Communication Communication { get; private set; }

        private List<Person> Persons { get; set; }

        //private void SetUsers()
        //{
        //    var service = new DomainService<BusinessProfileLike>();
        //    var businessProfileLikes = service.GetEntities(bpl => bpl.BusinessProfileId == Communication.BusinessProfileId && bpl.Active, new string[] { "UserInformation" });

        //    if (businessProfileLikes != null)
        //    {
        //        Persons = businessProfileLikes.Select(bpl => bpl.UserInformation).ToList();
        //    }
        //}

        public void Notify()
        {
            if (Persons != null)
            {
                //foreach (var userInformation in Persons)
                //{
                //    var communicationService = new DomainServices.Communication.DomainService();
                //    var smsService = ConfigurationReader.GetAppSetting(Multiplex.Models.Security.Constants.SMS_SERVICE);
                
                //    var from = ConfigurationReader.GetAppSetting("CommsEmailFrom");
                //    var subject = ConfigurationReader.GetAppSetting("CommsEmailSubject");
                //    var body = string.Format(ConfigurationReader.GetAppSetting("CommsEmailBody"), userInformation.FirstName, userInformation.Surname, Communication.CommunicationType.DisplayName, Communication.BusinessProfile.Name, Communication.CommunicationType.DisplayName, ConfigurationReader.GetAppSetting("Domain"), Communication.Id, "<br/>", Communication.BusinessProfile.Id);
                //    var smsBody = string.Format(ConfigurationReader.GetAppSetting("CommsEmailBody"), userInformation.FirstName, userInformation.Surname, Communication.CommunicationType.DisplayName, Communication.BusinessProfile.Name, Communication.CommunicationType.DisplayName, ConfigurationReader.GetAppSetting("Domain"), Communication.Id, " \r\n", Communication.BusinessProfile.Id);
                //    var emailTemplatePath = string.Format("{0}App_Data\\EmailTemplates.xml", HttpContext.Current.Request.PhysicalApplicationPath);
                //    var emailTemplate = communicationService.GetTemplate(emailTemplatePath, "GeneralTemplate");
                //    var newBody = string.Format(emailTemplate.Body, body, emailTemplate.Client, emailTemplate.From);
                //    var status = communicationService.SendMail(string.Empty, from, userInformation.Email, string.Empty, string.Empty, subject, newBody, string.Empty);

                //    if (!string.IsNullOrWhiteSpace(smsService))
                //    {
                //        var smsHelper = new SmsHelper(userInformation, smsBody);
                //        smsHelper.SendRecommendationSms();
                //    }
                //}
            }
        }
    }
}