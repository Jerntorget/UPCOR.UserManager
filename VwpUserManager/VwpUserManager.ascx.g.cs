﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UPCOR.UserManager.UserManagerWebPart {
    using System.Web.UI.WebControls.Expressions;
    using System.Web.UI.HtmlControls;
    using System.Collections;
    using System.Text;
    using System.Web.UI;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Microsoft.SharePoint.WebPartPages;
    using System.Web.SessionState;
    using System.Configuration;
    using Microsoft.SharePoint;
    using System.Web;
    using System.Web.DynamicData;
    using System.Web.Caching;
    using System.Web.Profile;
    using System.ComponentModel.DataAnnotations;
    using System.Web.UI.WebControls;
    using System.Web.Security;
    using System;
    using Microsoft.SharePoint.Utilities;
    using System.Text.RegularExpressions;
    using System.Collections.Specialized;
    using System.Web.UI.WebControls.WebParts;
    using Microsoft.SharePoint.WebControls;
    
    
    public partial class UserManagerWebPart {
        
        protected global::Microsoft.SharePoint.WebControls.CssRegistration umCssReg;
        
        protected global::Microsoft.SharePoint.WebControls.ScriptLink umScript;
        
        protected global::System.Web.UI.WebControls.Label idStore;
        
        protected global::System.Web.UI.WebControls.Label idErrorText;
        
        protected global::System.Web.UI.WebControls.Label idLblOrganization;
        
        protected global::System.Web.UI.WebControls.DropDownList idOrganization;
        
        protected global::System.Web.UI.WebControls.Label idLblGiveName;
        
        protected global::System.Web.UI.WebControls.TextBox idGivenName;
        
        protected global::System.Web.UI.WebControls.Label idLblSurName;
        
        protected global::System.Web.UI.WebControls.TextBox idSurName;
        
        protected global::System.Web.UI.WebControls.Label idLblEmail;
        
        protected global::System.Web.UI.WebControls.TextBox idEmail;
        
        protected global::System.Web.UI.WebControls.Label idLblUsername;
        
        protected global::System.Web.UI.WebControls.TextBox idUsername;
        
        protected global::System.Web.UI.WebControls.Label idLblPassword1;
        
        protected global::System.Web.UI.WebControls.TextBox idPassword1;
        
        protected global::System.Web.UI.WebControls.Label idLblPassword2;
        
        protected global::System.Web.UI.WebControls.TextBox idPassword2;
        
        protected global::System.Web.UI.WebControls.Label idLblSendto;
        
        protected global::System.Web.UI.WebControls.TextBox idSendto;
        
        protected global::System.Web.UI.WebControls.CheckBoxList idSiteGroups;
        
        public static implicit operator global::System.Web.UI.TemplateControl(UserManagerWebPart target) 
        {
            return target == null ? null : target.TemplateControl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::Microsoft.SharePoint.WebControls.CssRegistration @__BuildControlumCssReg() {
            global::Microsoft.SharePoint.WebControls.CssRegistration @__ctrl;
            @__ctrl = new global::Microsoft.SharePoint.WebControls.CssRegistration();
            this.umCssReg = @__ctrl;
            @__ctrl.ID = "umCssReg";
            @__ctrl.Name = "/_layouts/15/upcor.usermanager/style.css";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::Microsoft.SharePoint.WebControls.ScriptLink @__BuildControlumScript() {
            global::Microsoft.SharePoint.WebControls.ScriptLink @__ctrl;
            @__ctrl = new global::Microsoft.SharePoint.WebControls.ScriptLink();
            this.umScript = @__ctrl;
            @__ctrl.ID = "umScript";
            @__ctrl.LoadAfterUI = true;
            @__ctrl.Name = "/_layouts/15/upcor.usermanager/code.js";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.Label @__BuildControlidStore() {
            global::System.Web.UI.WebControls.Label @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Label();
            this.idStore = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.CssClass = "um-store";
            @__ctrl.ID = "idStore";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.Label @__BuildControlidErrorText() {
            global::System.Web.UI.WebControls.Label @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Label();
            this.idErrorText = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.CssClass = "um-error";
            @__ctrl.ID = "idErrorText";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.Label @__BuildControlidLblOrganization() {
            global::System.Web.UI.WebControls.Label @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Label();
            this.idLblOrganization = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "idLblOrganization";
            @__ctrl.AssociatedControlID = "idOrganization";
            @__ctrl.Text = "Välj organisation:";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.DropDownList @__BuildControlidOrganization() {
            global::System.Web.UI.WebControls.DropDownList @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.DropDownList();
            this.idOrganization = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "idOrganization";
            @__ctrl.CssClass = "um-organization";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.Label @__BuildControlidLblGiveName() {
            global::System.Web.UI.WebControls.Label @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Label();
            this.idLblGiveName = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "idLblGiveName";
            @__ctrl.AssociatedControlID = "idGivenName";
            @__ctrl.Text = "Förnamn:";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.TextBox @__BuildControlidGivenName() {
            global::System.Web.UI.WebControls.TextBox @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.TextBox();
            this.idGivenName = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "idGivenName";
            @__ctrl.CssClass = "um-givenname";
            @__ctrl.MaxLength = 50;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.Label @__BuildControlidLblSurName() {
            global::System.Web.UI.WebControls.Label @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Label();
            this.idLblSurName = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "idLblSurName";
            @__ctrl.AssociatedControlID = "idSurName";
            @__ctrl.Text = "Efternamn:";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.TextBox @__BuildControlidSurName() {
            global::System.Web.UI.WebControls.TextBox @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.TextBox();
            this.idSurName = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "idSurName";
            @__ctrl.CssClass = "um-surname";
            @__ctrl.MaxLength = 50;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.Label @__BuildControlidLblEmail() {
            global::System.Web.UI.WebControls.Label @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Label();
            this.idLblEmail = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "idLblEmail";
            @__ctrl.AssociatedControlID = "idEmail";
            @__ctrl.Text = "E-post:";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.TextBox @__BuildControlidEmail() {
            global::System.Web.UI.WebControls.TextBox @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.TextBox();
            this.idEmail = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "idEmail";
            @__ctrl.CssClass = "um-email";
            @__ctrl.MaxLength = 50;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.Label @__BuildControlidLblUsername() {
            global::System.Web.UI.WebControls.Label @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Label();
            this.idLblUsername = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "idLblUsername";
            @__ctrl.AssociatedControlID = "idUsername";
            @__ctrl.Text = "Användarnamn:";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.TextBox @__BuildControlidUsername() {
            global::System.Web.UI.WebControls.TextBox @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.TextBox();
            this.idUsername = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "idUsername";
            @__ctrl.CssClass = "um-username";
            @__ctrl.MaxLength = 20;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.Label @__BuildControlidLblPassword1() {
            global::System.Web.UI.WebControls.Label @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Label();
            this.idLblPassword1 = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "idLblPassword1";
            @__ctrl.AssociatedControlID = "idPassword1";
            @__ctrl.Text = "Lösenord:";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.TextBox @__BuildControlidPassword1() {
            global::System.Web.UI.WebControls.TextBox @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.TextBox();
            this.idPassword1 = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "idPassword1";
            @__ctrl.CssClass = "um-password1";
            @__ctrl.MaxLength = 20;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.Label @__BuildControlidLblPassword2() {
            global::System.Web.UI.WebControls.Label @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Label();
            this.idLblPassword2 = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "idLblPassword2";
            @__ctrl.AssociatedControlID = "idPassword2";
            @__ctrl.Text = "Bekräfta lösenord:";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.TextBox @__BuildControlidPassword2() {
            global::System.Web.UI.WebControls.TextBox @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.TextBox();
            this.idPassword2 = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "idPassword2";
            @__ctrl.CssClass = "um-password2";
            @__ctrl.MaxLength = 20;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.Label @__BuildControlidLblSendto() {
            global::System.Web.UI.WebControls.Label @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Label();
            this.idLblSendto = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "idLblSendto";
            @__ctrl.AssociatedControlID = "idSendto";
            @__ctrl.Text = "Skicka e-post till:";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.TextBox @__BuildControlidSendto() {
            global::System.Web.UI.WebControls.TextBox @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.TextBox();
            this.idSendto = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "idSendto";
            @__ctrl.CssClass = "um-sendto";
            @__ctrl.MaxLength = 50;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.CheckBoxList @__BuildControlidSiteGroups() {
            global::System.Web.UI.WebControls.CheckBoxList @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.CheckBoxList();
            this.idSiteGroups = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "idSiteGroups";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.Panel @__BuildControl__control2() {
            global::System.Web.UI.WebControls.Panel @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Panel();
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.CssClass = "um-panel";
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n    <div class=\"um-notif\"></div>\r\n    <div class=\"um-user-manager\">\r\n        <d" +
                        "iv>\r\n            <!-- store info here -->\r\n            "));
            global::System.Web.UI.WebControls.Label @__ctrl1;
            @__ctrl1 = this.@__BuildControlidStore();
            @__parser.AddParsedSubObject(@__ctrl1);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n            <!-- Error info -->\r\n            "));
            global::System.Web.UI.WebControls.Label @__ctrl2;
            @__ctrl2 = this.@__BuildControlidErrorText();
            @__parser.AddParsedSubObject(@__ctrl2);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n        </div>\r\n        <div>\r\n            "));
            global::System.Web.UI.WebControls.Label @__ctrl3;
            @__ctrl3 = this.@__BuildControlidLblOrganization();
            @__parser.AddParsedSubObject(@__ctrl3);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n            "));
            global::System.Web.UI.WebControls.DropDownList @__ctrl4;
            @__ctrl4 = this.@__BuildControlidOrganization();
            @__parser.AddParsedSubObject(@__ctrl4);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n        </div>\r\n        <div><a href=\"#\" id=\"idBtnAuto\">Skapa användaruppgifter" +
                        "</a></div>\r\n        <div>\r\n            "));
            global::System.Web.UI.WebControls.Label @__ctrl5;
            @__ctrl5 = this.@__BuildControlidLblGiveName();
            @__parser.AddParsedSubObject(@__ctrl5);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n            "));
            global::System.Web.UI.WebControls.TextBox @__ctrl6;
            @__ctrl6 = this.@__BuildControlidGivenName();
            @__parser.AddParsedSubObject(@__ctrl6);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n        </div>\r\n        <div>\r\n            "));
            global::System.Web.UI.WebControls.Label @__ctrl7;
            @__ctrl7 = this.@__BuildControlidLblSurName();
            @__parser.AddParsedSubObject(@__ctrl7);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n            "));
            global::System.Web.UI.WebControls.TextBox @__ctrl8;
            @__ctrl8 = this.@__BuildControlidSurName();
            @__parser.AddParsedSubObject(@__ctrl8);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n        </div>\r\n        <div>\r\n            "));
            global::System.Web.UI.WebControls.Label @__ctrl9;
            @__ctrl9 = this.@__BuildControlidLblEmail();
            @__parser.AddParsedSubObject(@__ctrl9);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n            "));
            global::System.Web.UI.WebControls.TextBox @__ctrl10;
            @__ctrl10 = this.@__BuildControlidEmail();
            @__parser.AddParsedSubObject(@__ctrl10);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n        </div>\r\n        <div>\r\n            "));
            global::System.Web.UI.WebControls.Label @__ctrl11;
            @__ctrl11 = this.@__BuildControlidLblUsername();
            @__parser.AddParsedSubObject(@__ctrl11);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n            "));
            global::System.Web.UI.WebControls.TextBox @__ctrl12;
            @__ctrl12 = this.@__BuildControlidUsername();
            @__parser.AddParsedSubObject(@__ctrl12);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n        </div>\r\n        <div>\r\n            "));
            global::System.Web.UI.WebControls.Label @__ctrl13;
            @__ctrl13 = this.@__BuildControlidLblPassword1();
            @__parser.AddParsedSubObject(@__ctrl13);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n            "));
            global::System.Web.UI.WebControls.TextBox @__ctrl14;
            @__ctrl14 = this.@__BuildControlidPassword1();
            @__parser.AddParsedSubObject(@__ctrl14);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n        </div>\r\n        <div>\r\n            "));
            global::System.Web.UI.WebControls.Label @__ctrl15;
            @__ctrl15 = this.@__BuildControlidLblPassword2();
            @__parser.AddParsedSubObject(@__ctrl15);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n            "));
            global::System.Web.UI.WebControls.TextBox @__ctrl16;
            @__ctrl16 = this.@__BuildControlidPassword2();
            @__parser.AddParsedSubObject(@__ctrl16);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n        </div>\r\n        <div>\r\n            "));
            global::System.Web.UI.WebControls.Label @__ctrl17;
            @__ctrl17 = this.@__BuildControlidLblSendto();
            @__parser.AddParsedSubObject(@__ctrl17);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n            "));
            global::System.Web.UI.WebControls.TextBox @__ctrl18;
            @__ctrl18 = this.@__BuildControlidSendto();
            @__parser.AddParsedSubObject(@__ctrl18);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl(@"
        </div>
        <div>
            <button id=""idBtnSave"" class=""um-btnsave"">Spara</button>
            <button id=""idBtnCancel"" class=""um-btncancel"">Börja om</button>
        </div>
        <div>
            <!-- siteGroups -->
            <h3>Lägg till användaren i grupperna:</h3>
            <div class=""um-sitegroups"">
                "));
            global::System.Web.UI.WebControls.CheckBoxList @__ctrl19;
            @__ctrl19 = this.@__BuildControlidSiteGroups();
            @__parser.AddParsedSubObject(@__ctrl19);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"um-search-resul" +
                        "t\">\r\n        <h2>Användare</h2>\r\n        <div></div>\r\n    </div>\r\n    <div style" +
                        "=\"clear: both;\"></div>\r\n"));
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControlTree(global::UPCOR.UserManager.UserManagerWebPart.UserManagerWebPart @__ctrl) {
            global::Microsoft.SharePoint.WebControls.CssRegistration @__ctrl1;
            @__ctrl1 = this.@__BuildControlumCssReg();
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(@__ctrl1);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n"));
            global::Microsoft.SharePoint.WebControls.ScriptLink @__ctrl2;
            @__ctrl2 = this.@__BuildControlumScript();
            @__parser.AddParsedSubObject(@__ctrl2);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n"));
            global::System.Web.UI.WebControls.Panel @__ctrl3;
            @__ctrl3 = this.@__BuildControl__control2();
            @__parser.AddParsedSubObject(@__ctrl3);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n"));
        }
        
        private void InitializeControl() {
            this.@__BuildControlTree(this);
            this.Load += new global::System.EventHandler(this.Page_Load);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        protected virtual object Eval(string expression) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        protected virtual string Eval(string expression, string format) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression, format);
        }
    }
}
