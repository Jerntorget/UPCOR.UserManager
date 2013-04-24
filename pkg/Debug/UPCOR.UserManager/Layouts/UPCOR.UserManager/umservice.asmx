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
        public bool UserExist(string countyName, string userName) {
            string cn = HttpUtility.UrlKeyValueDecode(countyName);
            AdUserManager aum = new AdUserManager(cn);
            return aum.Exist(userName);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Dictionary<string, string>[] Search(string countyName, string filter) {
            string cn = HttpUtility.UrlKeyValueDecode(countyName);
            AdManager adm = new AdManager(cn);
            return adm.Search(AdManager.UserProperties,
                String.Format("(&(objectClass=user)({0}))", 
                HttpUtility.UrlKeyValueDecode(filter)));
        }
        
        /*
        public void ColorAdd(string color, bool grandma, bool onlyone) {
            ClientContext ctx = new ClientContext("http://web1.upcor.se/david/");
            List l = ctx.Web.Lists.GetById(new Guid("EC7CD8A6-4C98-4301-8F02-FBF58CF0F8D2"));
            ListItem li = l.AddItem(new ListItemCreationInformation { });
            li["Title"] = color;
            li["Mormor"] = grandma;
            li["EndastEnMormor"] = onlyone;
            li.Update();
            ctx.ExecuteQuery();
        } */
    }
}
