using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint.Client;
using System.Net;
using System.Collections.Generic;
using Microsoft.SharePoint.Client.Utilities;
using System.Web.UI;
using UPCOR.Core;

namespace UPCOR.UserManager.UserManagerWebPart
{
    [ToolboxItemAttribute(false)]
    public partial class UserManagerWebPart : WebPart
    {
        /*
         * Url att använda för kommunen
         * t ex: "http://web1.upcor.se/borlange/".
         * */
        [WebBrowsable(true),
        WebDisplayName("Url"),
        WebDescription("Url att använda."),
        Personalizable(PersonalizationScope.Shared),
        Category("Inställningar")]
        public string WebUrlToUse {
            get;
            set;
        }

        /*
         * Namn på listan
         * t ex: "Butiker".
         * */
        [WebBrowsable(true),
        WebDisplayName("Listnamn"),
        WebDescription("Namn på listan som ska användas."),
        Personalizable(PersonalizationScope.Shared),
        Category("Inställningar")]
        public string ListName {
            get;
            set;
        }

        /*
         * Namn på kolumnen i listan för butiksnamnet
         * t ex "Title" för rubrik.
         * */
        [WebBrowsable(true),
        WebDisplayName("Listkolumn organisationsnamn"),
        WebDescription("Namn på kolumn för organisationsnamn."),
        Personalizable(PersonalizationScope.Shared),
        Category("Inställningar")]
        public string ColumnOrganizationName {
            get;
            set;
        }

        /*
         * Namn på kolumnen i listan för butiksid't.
         * */
        [WebBrowsable(true),
        WebDisplayName("Listkolumn organisationsid"),
        WebDescription("Namn på kolumn för organisationsid."),
        Personalizable(PersonalizationScope.Shared),
        Category("Inställningar")]
        public string ColumnOrganizationId {
            get;
            set;
        }

        /*
         * Namn på kommunens OU, denna skapas automatiskt i Managers konstruktor.
         * */
        [WebBrowsable(true),
        WebDisplayName("Namn på AD.OU för denna site"),
        WebDescription("Namn på OU som ligger under Kommuner"),
        Personalizable(PersonalizationScope.Shared),
        Category("Inställningar")]
        public string CountyName {
            get;
            set;
        }



        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling using
        // the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public UserManagerWebPart() {
        }

        protected override void OnInit(EventArgs e) {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e) {
            /*
             * Get site from this.WebUrlToUse
             * */
            if (this.WebUrlToUse != null && this.ListName != null && this.ColumnOrganizationId != null && this.ColumnOrganizationName != null) {
                var attrs = new string[][] {
                    new string[] { "weburl", this.WebUrlToUse },
                    new string[] { "county_name", HttpUtility.UrlKeyValueEncode(String.IsNullOrEmpty(this.CountyName) ? "" : this.CountyName) },
                };

                /*
                 * Store some attributes to be used in javascript
                 * */
                for (int i = 0; i < attrs.Length; i++) {
                    idStore.Attributes.Add(attrs[i][0], attrs[i][1]);
                }

                /*
                 * Load the essential things from sharepoint
                 * */
                ClientContext context = new ClientContext(this.WebUrlToUse);
                context.Credentials = new NetworkCredential("administrator", "j3rnt0rge7%", "SAFE4");
                Web web = context.Web;
                GroupCollection groups = web.SiteGroups;
                context.Load(groups, 
                    gs => gs.Include(
                        g => g.Title,
                        g => g.Id));
                context.Load(web);
                context.ExecuteQuery();

                /*
                 * Populate siteGroups
                 * */
                idSiteGroups.DataSource = groups;
                idSiteGroups.DataTextField = "Title";
                idSiteGroups.DataValueField = "Id";
                idSiteGroups.DataBind();

                /*
                 * Get list from this.ListName
                 * */
                List list = context.Web.Lists.GetByTitle(this.ListName);
                CamlQuery cq = CamlQuery.CreateAllItemsQuery();
                ListItemCollection items = list.GetItems(cq);
                context.Load(items,
                    its => its.Include(
                        it => it[this.ColumnOrganizationId],
                        it => it[this.ColumnOrganizationName]));
                context.ExecuteQuery();

                var dict = new Dictionary<String, String>();
                dict.Add(String.IsNullOrEmpty(this.CountyName) ? "-- inställningar saknas --" : this.CountyName, "0");

                /*
                 * Populate organizations
                 * */
                try {
                    foreach (ListItem item in items) {
                        dict.Add(item[this.ColumnOrganizationName].ToString(), item[this.ColumnOrganizationId].ToString());
                    }
                    idOrganization.DataSource = dict;
                    idOrganization.DataValueField = "Value";
                    idOrganization.DataTextField = "Key";
                    idOrganization.DataBind();
                }
                catch (Exception ex) {
                    idErrorText.Text = ex.Message;
                }
            }
        }
    }
}
