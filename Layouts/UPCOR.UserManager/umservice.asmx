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
    [Serializable]
    public struct ResponseData
    {
        public string[] errs;
        public Dictionary<string, string>[] dicts;
        public int[] ints;
        public bool boolVal;
    }
    
    [WebService(Namespace = "http://jerntorget.se/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]    
    public class UserManagerService : WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat=ResponseFormat.Json)]
        public ResponseData Exist(string countyName, string orgName, string userName) {
            countyName = HttpUtility.UrlKeyValueDecode(countyName);
            orgName = HttpUtility.UrlKeyValueDecode(orgName);
            AdUserManager aum = new AdUserManager(countyName, orgName);
            ResponseData rd = new ResponseData();
            rd.boolVal = aum.Exist(userName);
            return rd;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public ResponseData Search(string countyName, string orgName, string filter) {
            countyName = HttpUtility.UrlKeyValueDecode(countyName);
            orgName = HttpUtility.UrlKeyValueDecode(orgName);
            ResponseData rd = new ResponseData();
            AdManager adm = new AdManager(countyName, orgName);
            rd.dicts = adm.Search(AdManager.UserProperties,
                String.Format("(&(objectClass=user)({0}))", 
                HttpUtility.UrlKeyValueDecode(filter)));
            return rd;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public ResponseData Create(string webUrl, string countyName, string orgName, string userName, string password, string givenName, string surName, string email, int[] groupIds) {
            countyName = HttpUtility.UrlKeyValueDecode(countyName);
            orgName = HttpUtility.UrlKeyValueDecode(orgName);
            userName = HttpUtility.UrlKeyValueDecode(userName);
            password = HttpUtility.UrlKeyValueDecode(password);
            givenName = HttpUtility.UrlKeyValueDecode(givenName);
            surName = HttpUtility.UrlKeyValueDecode(surName);
            email = HttpUtility.UrlKeyValueDecode(email);
            webUrl = HttpUtility.UrlKeyValueDecode(webUrl);

            ResponseData rd = new ResponseData();
            string err1, err2;
            AdUserManager adum = new AdUserManager(countyName, orgName);
            adum.Create(webUrl, "SAFE4", String.IsNullOrEmpty(orgName) ? countyName : orgName, userName, password, givenName, surName, email, groupIds, out err1);
            adum.AddToGroups(webUrl, "SAFE4", userName, groupIds, out err2);
            rd.errs = new string[] { err1, err2 };
            return rd;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public ResponseData Update(string webUrl, string countyName, string orgName, string userName, string password, string givenName, string surName, string email, int[] addGroupIds, int[] delGroupIds) {
            countyName = HttpUtility.UrlKeyValueDecode(countyName);
            orgName = HttpUtility.UrlKeyValueDecode(orgName);
            userName = HttpUtility.UrlKeyValueDecode(userName);
            password = HttpUtility.UrlKeyValueDecode(password);
            givenName = HttpUtility.UrlKeyValueDecode(givenName);
            surName = HttpUtility.UrlKeyValueDecode(surName);
            email = HttpUtility.UrlKeyValueDecode(email);
            webUrl = HttpUtility.UrlKeyValueDecode(webUrl);

            ResponseData rd = new ResponseData();
            string err1, err2, err3;            
            AdUserManager adum = new AdUserManager(countyName, orgName);
            adum.Update(userName, password, givenName, surName, email, out err1);
            adum.AddToGroups(webUrl, "SAFE4", userName, addGroupIds, out err2);
            adum.RemoveFromGroups(webUrl, "SAFE4", userName, delGroupIds, out err3);
            rd.errs = new string[] { err1, err2, err3 };
            return rd;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public ResponseData Groups(string countyName, string orgName, string webUrl, string userName){
            countyName = HttpUtility.UrlKeyValueDecode(countyName);
            orgName = HttpUtility.UrlKeyValueDecode(orgName);
            webUrl = HttpUtility.UrlKeyValueDecode(webUrl);
            userName = HttpUtility.UrlKeyValueDecode(userName);
            AdUserManager adum = new AdUserManager(countyName, orgName);
            ResponseData rd = new ResponseData();
            string err;            
            rd.ints = adum.Groups(webUrl, "SAFE4", userName, out err);
            rd.errs = new string[] { err };
            return rd;
        }        
    }
}
