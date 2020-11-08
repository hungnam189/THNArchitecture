using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace THN.Infrastructure.Common.ExtentionHelpers
{
    public static class IpAddressHelper
    {
        /// <summary>
        /// Get IpAddress Client
        /// </summary>
        /// <param name="context"></param>
        /// <param name="allowForwarder"></param>
        /// <returns></returns>
        public static string GetIpAddressClient(this HttpContext context, bool allowForwarder = true)
        {
            if(allowForwarder)
            {
                return context.Request.Headers["CF-Connecting-IP"].FirstOrDefault() ?? context.Request.Headers["CF-Connecting-IP"].FirstOrDefault();
            }

            return context.Connection.RemoteIpAddress.ToString() ?? context.Connection.RemoteIpAddress.ToString();
        }


        public static string GetIpServerAddress()
        {
            string hostName = Dns.GetHostName();
            string ipServer = "";
            var ipEntry = Dns.GetHostEntry(hostName);

            foreach (IPAddress ipAddress in ipEntry.AddressList)
            {
                if(ipAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    ipServer = ipAddress.ToString();
                    break;
                }
            }
            return ipServer;
        }

    }
}
