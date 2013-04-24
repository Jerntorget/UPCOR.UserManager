<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VwpUserManager.ascx.cs" Inherits="UPCOR.UserManager.UserManagerWebPart.UserManagerWebPart" %>

<SharePoint:CssRegistration ID="umCssReg" runat="server" Name="/_layouts/15/upcor.usermanager/style.css"></SharePoint:CssRegistration>
<SharePoint:ScriptLink ID="umScript" runat="server" LoadAfterUI="true" Name="/_layouts/15/upcor.usermanager/code.js"></SharePoint:ScriptLink>

<asp:Panel CssClass="um-panel" runat="server">
    <div class="um-user-manager">
        <p>
            <!-- store info here -->
            <asp:Label CssClass="um-store" ID="idStore" runat="server"></asp:Label>
            <!-- Error info -->
            <asp:Label CssClass="um-error" ID="idErrorText" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label ID="idLblOrganization" AssociatedControlID="idOrganization" runat="server" Text="Välj organisation:"></asp:Label>
            <asp:DropDownList ID="idOrganization" runat="server" CssClass="um-organization"></asp:DropDownList>
        </p>
        <p>
            <asp:Label ID="idLblGiveName" AssociatedControlID="idGivenName" runat="server" Text="Förnamn:"></asp:Label>
            <asp:TextBox ID="idGivenName" runat="server" CssClass="um-givenname" MaxLength="50"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="idLblSurName" AssociatedControlID="idSurName" runat="server" Text="Efternamn:"></asp:Label>
            <asp:TextBox ID="idSurName" runat="server" CssClass="um-surname" MaxLength="50"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="idLblEmail" AssociatedControlID="idEmail" runat="server" Text="E-post:"></asp:Label>
            <asp:TextBox ID="idEmail" runat="server" CssClass="um-email" MaxLength="50"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="idLblUsername" AssociatedControlID="idUsername" runat="server" Text="Användarnamn:"></asp:Label>
            <asp:TextBox ID="idUsername" runat="server" CssClass="um-username" MaxLength="20"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="idLblPassword1" AssociatedControlID="idPassword1" runat="server" Text="Lösenord:"></asp:Label>
            <asp:TextBox ID="idPassword1" runat="server" TextMode="Password" CssClass="um-password1" MaxLength="20"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="idLblPassword2" AssociatedControlID="idPassword2" runat="server" Text="Bekräfta lösenord:"></asp:Label>
            <asp:TextBox ID="idPassword2" runat="server" TextMode="Password" CssClass="um-password2" MaxLength="20"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="idLblSendto" AssociatedControlID="idSendto" runat="server" Text="Skickas till:"></asp:Label>
            <asp:TextBox ID="idSendto" runat="server" CssClass="um-sendto" MaxLength="50"></asp:TextBox>
        </p>
        <p>
            <asp:Panel runat="server">
                <asp:Label ID="idLblGroups" runat="server" Text="Grupper"></asp:Label>
            </asp:Panel>
        </p>
        <p>
            <button id="idBtnSave" class="um-btnsave">Spara</button>
        </p>
    </div>
    <div class="um-search-result"></div>
    <div style="clear: both;"></div>
</asp:Panel>
