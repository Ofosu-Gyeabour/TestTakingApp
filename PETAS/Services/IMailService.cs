using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Diagnostics;
using PETAS.Classes;
using PETAS.Models.Domain;
using PETAS.Models.Domain.HRMS;
using System.Net.Http.Headers;
using Newtonsoft;
using Newtonsoft.Json;

namespace PETAS.Services
{
    public interface IMailService
    {
        public Task SendMailNotification(List<Employee> employeeList, Training trainingObj);
    }

    public class MailService: IMailService
    {
        private readonly MailClient mailClient;
        private readonly HttpClient http;

        public string? Token { get; private set; }

        public MailService(MailClient _mailclient)
        {
            mailClient = _mailclient;
            http = mailClient.http;
        }

        public MailService()
        {
            http = mailClient.http;
        }

        public async Task SendMailNotification(List<Employee> employeeList, Training trainingObj)
        {
            //method is responsible for sending mail notifications
            try
            {
                if (employeeList.Count() > 0)
                {
                    foreach(var e in employeeList)
                    {
                        try
                        {
                            var obj = new MailStub()
                            {
                                to = e.EmailAddress,
                                subject = @"TRAINING ENROLLMENT",
                                body = @"Testing",
                                cc = string.Empty,
                                bcc = string.Empty
                            };

                            string output = JsonConvert.SerializeObject(obj);
                            var status = await http.PostAsJsonAsync("v1/MailSender", output);
                        }
                        catch(Exception ee)
                        {

                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.Print(ex.Message);
                
            }
        }

    }
}
