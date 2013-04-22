<%@ WebService Language="C#" Class="UPCOR.UserManager.UserManagerService" %>
<%@ Assembly Name="Microsoft.SharePoint.Client" %>
<%@ Assembly Name="Microsoft.SharePoint.Client.Runtime" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;
using Microsoft.SharePoint.Client.Utilities;
using UPCOR.UserManager;

namespace UPCOR.UserManager
{
    [WebService(Namespace = "http://jerntorget.se/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class UserManagerService : WebService
    {
        [WebMethod]
        public bool UserExist(string userName, string countyName) {
            string cn = HttpUtility.UrlKeyValueDecode(countyName);
            ManagerUser um = new ManagerUser(cn);
            return um.Exist(userName);
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
