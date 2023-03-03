using SecureAccess;

namespace PETAS.Classes
{
    public class Test
    {
        public User oUser { get; set; }
        public string accesscode { get; set; } = @"secureAccess";
        public async Task<SecureAccess.UserTicket> authenticate()
        {
            try
            {
                return new SecureAccess.UserTicket { };

                var obj = new ServiceClient(ServiceClient.EndpointConfiguration.CustomBinding_IService);
                //var task = await obj.IsAuthorizedAsync(AuthenticationModeEnum.Forms, oUser.userName, oUser.userPassword, accesscode, accesscode, accesscode);
                var task = await obj.GetUserTicketAsync(AuthenticationModeEnum.Forms, oUser.username, oUser.pass, accesscode);

                //return task;
            }
            catch(Exception x)
            {
                System.Diagnostics.Debug.Print(x.Message);
                throw x;
            }
        }
    }
}
