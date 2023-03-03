﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SecureAccess
{
    using System.Runtime.Serialization;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AuthenticationModeEnum", Namespace="http://schemas.datacontract.org/2004/07/PortSight.SecureAccess.WCF.Common")]
    public enum AuthenticationModeEnum : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Windows = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Forms = 1,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserTicket", Namespace="http://schemas.datacontract.org/2004/07/PortSight.SecureAccess.WCF.Common")]
    public partial class UserTicket : object
    {
        
        private string CustomParameterField;
        
        private string DescriptionField;
        
        private string EmailField;
        
        private string FirstNameField;
        
        private string LastNameField;
        
        private string LoginField;
        
        private string MembershipAliasesField;
        
        private string MembershipObjectIDsField;
        
        private string MiddleNameField;
        
        private string ObjectAliasField;
        
        private int ObjectIDField;
        
        private string ObjectNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomParameter
        {
            get
            {
                return this.CustomParameterField;
            }
            set
            {
                this.CustomParameterField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description
        {
            get
            {
                return this.DescriptionField;
            }
            set
            {
                this.DescriptionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email
        {
            get
            {
                return this.EmailField;
            }
            set
            {
                this.EmailField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName
        {
            get
            {
                return this.FirstNameField;
            }
            set
            {
                this.FirstNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName
        {
            get
            {
                return this.LastNameField;
            }
            set
            {
                this.LastNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Login
        {
            get
            {
                return this.LoginField;
            }
            set
            {
                this.LoginField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MembershipAliases
        {
            get
            {
                return this.MembershipAliasesField;
            }
            set
            {
                this.MembershipAliasesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MembershipObjectIDs
        {
            get
            {
                return this.MembershipObjectIDsField;
            }
            set
            {
                this.MembershipObjectIDsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MiddleName
        {
            get
            {
                return this.MiddleNameField;
            }
            set
            {
                this.MiddleNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ObjectAlias
        {
            get
            {
                return this.ObjectAliasField;
            }
            set
            {
                this.ObjectAliasField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ObjectID
        {
            get
            {
                return this.ObjectIDField;
            }
            set
            {
                this.ObjectIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ObjectName
        {
            get
            {
                return this.ObjectNameField;
            }
            set
            {
                this.ObjectNameField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/PortSight.SecureAccess.WCF.Common")]
    public partial class FaultException : object
    {
        
        private int CodeField;
        
        private string ReasonField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Code
        {
            get
            {
                return this.CodeField;
            }
            set
            {
                this.CodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Reason
        {
            get
            {
                return this.ReasonField;
            }
            set
            {
                this.ReasonField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AuthenticationResultsEnum", Namespace="http://schemas.datacontract.org/2004/07/PortSight.SecureAccess.WCF.Common")]
    public enum AuthenticationResultsEnum : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        OK = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AccountDoesNotExist = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        LockedAccount = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        WrongPassword = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ExpiredPassword = 4,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:com:portsight:secureaccess:3.0", ConfigurationName="SecureAccess.IService")]
    public interface IService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:com:portsight:secureaccess:3.0/IService/GetUserTicket", ReplyAction="urn:com:portsight:secureaccess:3.0/IService/GetUserTicketResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(SecureAccess.FaultException), Action="urn:com:portsight:secureaccess:3.0/IService/GetUserTicketFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/PortSight.SecureAccess.WCF.Common")]
        System.Threading.Tasks.Task<SecureAccess.UserTicket> GetUserTicketAsync(SecureAccess.AuthenticationModeEnum authenticationmode, string loginname, string password, string catalogid);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:com:portsight:secureaccess:3.0/IService/IsDelegatedToManageObject", ReplyAction="urn:com:portsight:secureaccess:3.0/IService/IsDelegatedToManageObjectResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(SecureAccess.FaultException), Action="urn:com:portsight:secureaccess:3.0/IService/IsDelegatedToManageObjectFaultExcepti" +
            "onFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/PortSight.SecureAccess.WCF.Common")]
        System.Threading.Tasks.Task<bool> IsDelegatedToManageObjectAsync(SecureAccess.AuthenticationModeEnum authenticationmode, string loginname, string password, string catalogid, int objectid);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:com:portsight:secureaccess:3.0/IService/AuthenticateUser", ReplyAction="urn:com:portsight:secureaccess:3.0/IService/AuthenticateUserResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(SecureAccess.FaultException), Action="urn:com:portsight:secureaccess:3.0/IService/AuthenticateUserFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/PortSight.SecureAccess.WCF.Common")]
        System.Threading.Tasks.Task<SecureAccess.AuthenticationResultsEnum> AuthenticateUserAsync(SecureAccess.AuthenticationModeEnum authenticationmode, string loginname, string password, string catalogid);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:com:portsight:secureaccess:3.0/IService/IsAuthorized", ReplyAction="urn:com:portsight:secureaccess:3.0/IService/IsAuthorizedResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(SecureAccess.FaultException), Action="urn:com:portsight:secureaccess:3.0/IService/IsAuthorizedFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/PortSight.SecureAccess.WCF.Common")]
        System.Threading.Tasks.Task<bool> IsAuthorizedAsync(SecureAccess.AuthenticationModeEnum authenticationmode, string loginname, string password, string catalogid, string resourcealias, string relationshiptypealias);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:com:portsight:secureaccess:3.0/IService/IsInRole", ReplyAction="urn:com:portsight:secureaccess:3.0/IService/IsInRoleResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(SecureAccess.FaultException), Action="urn:com:portsight:secureaccess:3.0/IService/IsInRoleFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/PortSight.SecureAccess.WCF.Common")]
        System.Threading.Tasks.Task<bool> IsInRoleAsync(SecureAccess.AuthenticationModeEnum authenticationmode, string loginname, string password, string catalogid, string rolealias);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:com:portsight:secureaccess:3.0/IService/IsMemberAll", ReplyAction="urn:com:portsight:secureaccess:3.0/IService/IsMemberAllResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(SecureAccess.FaultException), Action="urn:com:portsight:secureaccess:3.0/IService/IsMemberAllFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/PortSight.SecureAccess.WCF.Common")]
        System.Threading.Tasks.Task<bool> IsMemberAllAsync(SecureAccess.AuthenticationModeEnum authenticationmode, string loginname, string password, string catalogid, int groupid);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:com:portsight:secureaccess:3.0/IService/IsMemberAllByGroupAlias", ReplyAction="urn:com:portsight:secureaccess:3.0/IService/IsMemberAllByGroupAliasResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(SecureAccess.FaultException), Action="urn:com:portsight:secureaccess:3.0/IService/IsMemberAllByGroupAliasFaultException" +
            "Fault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/PortSight.SecureAccess.WCF.Common")]
        System.Threading.Tasks.Task<bool> IsMemberAllByGroupAliasAsync(SecureAccess.AuthenticationModeEnum authenticationmode, string loginname, string password, string catalogid, string groupalias);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:com:portsight:secureaccess:3.0/IService/Log", ReplyAction="urn:com:portsight:secureaccess:3.0/IService/LogResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(SecureAccess.FaultException), Action="urn:com:portsight:secureaccess:3.0/IService/LogFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/PortSight.SecureAccess.WCF.Common")]
        System.Threading.Tasks.Task<bool> LogAsync(SecureAccess.AuthenticationModeEnum authenticationmode, string loginname, string password, string catalogid, string message, string eventcode, string resourceobjectalias);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:com:portsight:secureaccess:3.0/IService/ChangePassword", ReplyAction="urn:com:portsight:secureaccess:3.0/IService/ChangePasswordResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(SecureAccess.FaultException), Action="urn:com:portsight:secureaccess:3.0/IService/ChangePasswordFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/PortSight.SecureAccess.WCF.Common")]
        System.Threading.Tasks.Task<bool> ChangePasswordAsync(SecureAccess.AuthenticationModeEnum authenticationmode, string loginname, string password, string catalogid, string newpassword);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:com:portsight:secureaccess:3.0/IService/GetPropertyValue", ReplyAction="urn:com:portsight:secureaccess:3.0/IService/GetPropertyValueResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(SecureAccess.FaultException), Action="urn:com:portsight:secureaccess:3.0/IService/GetPropertyValueFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/PortSight.SecureAccess.WCF.Common")]
        System.Threading.Tasks.Task<string> GetPropertyValueAsync(SecureAccess.AuthenticationModeEnum authenticationmode, string loginname, string password, string catalogid, string propertyalias);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:com:portsight:secureaccess:3.0/IService/SetPropertyValue", ReplyAction="urn:com:portsight:secureaccess:3.0/IService/SetPropertyValueResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(SecureAccess.FaultException), Action="urn:com:portsight:secureaccess:3.0/IService/SetPropertyValueFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/PortSight.SecureAccess.WCF.Common")]
        System.Threading.Tasks.Task<bool> SetPropertyValueAsync(SecureAccess.AuthenticationModeEnum authenticationmode, string loginname, string password, string catalogid, string propertyalias, string value);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public interface IServiceChannel : SecureAccess.IService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<SecureAccess.IService>, SecureAccess.IService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public ServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(ServiceClient.GetBindingForEndpoint(endpointConfiguration), ServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(ServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(ServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<SecureAccess.UserTicket> GetUserTicketAsync(SecureAccess.AuthenticationModeEnum authenticationmode, string loginname, string password, string catalogid)
        {
            return base.Channel.GetUserTicketAsync(authenticationmode, loginname, password, catalogid);
        }
        
        public System.Threading.Tasks.Task<bool> IsDelegatedToManageObjectAsync(SecureAccess.AuthenticationModeEnum authenticationmode, string loginname, string password, string catalogid, int objectid)
        {
            return base.Channel.IsDelegatedToManageObjectAsync(authenticationmode, loginname, password, catalogid, objectid);
        }
        
        public System.Threading.Tasks.Task<SecureAccess.AuthenticationResultsEnum> AuthenticateUserAsync(SecureAccess.AuthenticationModeEnum authenticationmode, string loginname, string password, string catalogid)
        {
            return base.Channel.AuthenticateUserAsync(authenticationmode, loginname, password, catalogid);
        }
        
        public System.Threading.Tasks.Task<bool> IsAuthorizedAsync(SecureAccess.AuthenticationModeEnum authenticationmode, string loginname, string password, string catalogid, string resourcealias, string relationshiptypealias)
        {
            return base.Channel.IsAuthorizedAsync(authenticationmode, loginname, password, catalogid, resourcealias, relationshiptypealias);
        }
        
        public System.Threading.Tasks.Task<bool> IsInRoleAsync(SecureAccess.AuthenticationModeEnum authenticationmode, string loginname, string password, string catalogid, string rolealias)
        {
            return base.Channel.IsInRoleAsync(authenticationmode, loginname, password, catalogid, rolealias);
        }
        
        public System.Threading.Tasks.Task<bool> IsMemberAllAsync(SecureAccess.AuthenticationModeEnum authenticationmode, string loginname, string password, string catalogid, int groupid)
        {
            return base.Channel.IsMemberAllAsync(authenticationmode, loginname, password, catalogid, groupid);
        }
        
        public System.Threading.Tasks.Task<bool> IsMemberAllByGroupAliasAsync(SecureAccess.AuthenticationModeEnum authenticationmode, string loginname, string password, string catalogid, string groupalias)
        {
            return base.Channel.IsMemberAllByGroupAliasAsync(authenticationmode, loginname, password, catalogid, groupalias);
        }
        
        public System.Threading.Tasks.Task<bool> LogAsync(SecureAccess.AuthenticationModeEnum authenticationmode, string loginname, string password, string catalogid, string message, string eventcode, string resourceobjectalias)
        {
            return base.Channel.LogAsync(authenticationmode, loginname, password, catalogid, message, eventcode, resourceobjectalias);
        }
        
        public System.Threading.Tasks.Task<bool> ChangePasswordAsync(SecureAccess.AuthenticationModeEnum authenticationmode, string loginname, string password, string catalogid, string newpassword)
        {
            return base.Channel.ChangePasswordAsync(authenticationmode, loginname, password, catalogid, newpassword);
        }
        
        public System.Threading.Tasks.Task<string> GetPropertyValueAsync(SecureAccess.AuthenticationModeEnum authenticationmode, string loginname, string password, string catalogid, string propertyalias)
        {
            return base.Channel.GetPropertyValueAsync(authenticationmode, loginname, password, catalogid, propertyalias);
        }
        
        public System.Threading.Tasks.Task<bool> SetPropertyValueAsync(SecureAccess.AuthenticationModeEnum authenticationmode, string loginname, string password, string catalogid, string propertyalias, string value)
        {
            return base.Channel.SetPropertyValueAsync(authenticationmode, loginname, password, catalogid, propertyalias, value);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.CustomBinding_IService))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpTransportBindingElement httpBindingElement = new System.ServiceModel.Channels.HttpTransportBindingElement();
                httpBindingElement.AllowCookies = true;
                httpBindingElement.MaxBufferSize = int.MaxValue;
                httpBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpBindingElement);
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.ARWCFService_TcpBinding_IService))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.TcpTransportBindingElement tcpBindingElement = new System.ServiceModel.Channels.TcpTransportBindingElement();
                tcpBindingElement.MaxBufferSize = int.MaxValue;
                tcpBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(tcpBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.CustomBinding_IService))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:8204/serviceARWCF/ARWCFService");
            }
            if ((endpointConfiguration == EndpointConfiguration.ARWCFService_TcpBinding_IService))
            {
                return new System.ServiceModel.EndpointAddress("net.tcp://localhost:9204/serviceARWCF/ARWCFService");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            CustomBinding_IService,
            
            ARWCFService_TcpBinding_IService,
        }
    }
}