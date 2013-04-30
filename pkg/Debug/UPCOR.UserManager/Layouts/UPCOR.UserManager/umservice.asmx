<%@ WebService Language="C#" Class="UPCOR.UserManager.UserManagerService" %>
<%@ Assembly Name="Microsoft.SharePoint.Client" %>
<%@ Assembly Name='System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35' %> 
<%@ Assembly Name="Microsoft.SharePoint.Client.Runtime" %>
<%@ Assembly Name="UPCOR.Core" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;
using System.Web.Script.Services;
using Microsoft.SharePoint.Client.Utilities;
using UPCOR.Core;

namespace UPCOR.UserManager
{
    [WebService(Namespace = "http://jerntorget.se/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]    
    public class UserManagerService : WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat=ResponseFormat.Json)]
        public bool Exist(string countyName, string orgName, string userName) {
            countyName = HttpUtility.UrlKeyValueDecode(countyName);
            orgName = HttpUtility.UrlKeyValueDecode(orgName);
            AdUserManager aum = new AdUserManager(countyName, orgName);
            return aum.Exist(userName);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Dictionary<string, string>[] Search(string countyName, string orgName, string filter) {
            countyName = HttpUtility.UrlKeyValueDecode(countyName);
            orgName = HttpUtility.UrlKeyValueDecode(orgName);
            AdManager adm = new AdManager(countyName, orgName);
            return adm.Search(AdManager.UserProperties,
                String.Format("(&(objectClass=user)({0}))", 
                HttpUtility.UrlKeyValueDecode(filter)));
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string Create(string countyName, string orgName, string userName, string password, string givenName, string surName, string email) {
            countyName = HttpUtility.UrlKeyValueDecode(countyName);
            orgName = HttpUtility.UrlKeyValueDecode(orgName);
            userName = HttpUtility.UrlKeyValueDecode(userName);
            password = HttpUtility.UrlKeyValueDecode(password);
            givenName = HttpUtility.UrlKeyValueDecode(givenName);
            surName = HttpUtility.UrlKeyValueDecode(surName);
            email = HttpUtility.UrlKeyValueDecode(email);

            string error;
            AdUserManager adum = new AdUserManager(countyName, orgName);
            adum.Create(String.IsNullOrEmpty(orgName) ? countyName : orgName, userName, password, givenName, surName, email, out error);
            return error;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string Update(string countyName, string orgName, string userName, string password, string givenName, string surName, string email) {
            countyName = HttpUtility.UrlKeyValueDecode(countyName);
            orgName = HttpUtility.UrlKeyValueDecode(orgName);
            userName = HttpUtility.UrlKeyValueDecode(userName);
            password = HttpUtility.UrlKeyValueDecode(password);
            givenName = HttpUtility.UrlKeyValueDecode(givenName);
            surName = HttpUtility.UrlKeyValueDecode(surName);
            email = HttpUtility.UrlKeyValueDecode(email);

            string error;
            AdUserManager adum = new AdUserManager(countyName, orgName);
            adum.Update(userName, password, givenName, surName, email, out error);
            return error;
        }
    }
}
