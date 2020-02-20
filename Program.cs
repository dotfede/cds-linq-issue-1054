using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;

namespace ConsoleApp6
{
	class Program
    {
        static void Main(string[] args)
        {
            var orgSvc = CreateOrganizationServiceProxy();

            var ctx = new OrganizationServiceContext(orgSvc);

            var accounts =
                ctx.CreateQuery<Account>()
                   .Where(x => x.account_primary_contact.FirstName.StartsWith("John"))
                   .ToList();

            Console.WriteLine();
        }
        
        public static IOrganizationService CreateOrganizationServiceProxy()
        {
            var connection = new
            {
                Url = "",
                UserName = "",
                Password = "",
            };
            
            var clientCredentials = new ClientCredentials();
            clientCredentials.UserName.UserName = connection.UserName;
            clientCredentials.UserName.Password = connection.Password;
            
            var organizationServiceProxy = new OrganizationServiceProxy(new Uri(connection.Url), null, clientCredentials, null);
            
            organizationServiceProxy.EnableProxyTypes();
            organizationServiceProxy.Authenticate();
            return organizationServiceProxy;
        }
    }


}
