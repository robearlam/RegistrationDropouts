<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EngagementPlan.ascx.cs" Inherits="RegistrationDropouts.Web.Layouts.Sublayouts.EngagementPlan" %>

<h1>Enagement Plan Testing</h1>
<section>
    <h2>Identify User & Enroll in Engagement Plan</h2>
    <label for="txtLabel">Email:</label>
    <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
    <asp:Button runat="server" id="btnIdentifyUser" OnClick="btnIdentifyUser_OnClick" Text="Identify User"/>
    <asp:Label runat="server" id="lblIdentifyUser" Visible="False"></asp:Label>
</section>
<section>
    <h2>Step 1</h2>
    <asp:Button runat="server" id="btnStep1" OnClick="btnStep1_OnClick" Text="Process Step 1"/>
    <asp:Label runat="server" id="lblResultStep1" Visible="False"></asp:Label>
</section>
<section>
    <h2>Step 2</h2>
    <asp:Button runat="server" id="btnStep2" OnClick="btnStep2_OnClick" Text="Process Step 2"/>
    <asp:Label runat="server" id="lblResultStep2" Visible="False"></asp:Label>
</section>
<section>
    <h2>Step 3</h2>
    <asp:Button runat="server" id="btnStep3" OnClick="btnStep3_OnClick" Text="Process Step 3"/>
    <asp:Label runat="server" id="lblResultStep3" Visible="False"></asp:Label>
</section>
<section>
    <h2>Complete Registration</h2>
    <asp:Button runat="server" id="btnCompletedRegistration" OnClick="btnCompletedRegistration_OnClick" Text="Complete Registration"/>
    <asp:Label runat="server" id="lblCompleteRegistration" Visible="False"></asp:Label>
</section>
<section>
    <h2>Abandon Session</h2>
    <p>You can use this button to fire the session end event and push your current session's analytics data into mongo.</p>
    <asp:Button runat="server" id="btnAbandonSession" OnClick="btnAbandonSession_OnClick" Text="Abandon Session"/>
    <asp:Label runat="server" id="lblAbandonSession" Visible="False"></asp:Label>
</section>