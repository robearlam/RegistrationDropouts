using System;
using System.Web;
using Sitecore.Analytics;
using Sitecore.Analytics.Automation.Data;
using Sitecore.Analytics.Automation.MarketingAutomation;
using Sitecore.Analytics.Data.Items;
using Sitecore.Data;
using Sitecore.StringExtensions;

namespace RegistrationDropouts.Web.Layouts.Sublayouts
{
    public partial class EngagementPlan : System.Web.UI.UserControl
    {
        private string registrationDropOutId = "{2619048E-1BF4-4825-95A0-A38A3280DD61}";
        private readonly ID step1Id = new ID("{FFFEA46D-2783-478E-8C9E-8946A2423626}");
        private readonly ID step1Goal = new ID("{A68B82FF-6CAF-419E-A81E-1681F8CBDFE8}");
        private readonly ID step2Goal = new ID("{3B352DCB-C4D8-4727-860D-DCC86CB38B3F}");
        private readonly ID step3Goal = new ID("{1E735F98-71C0-4FC5-B949-EBF324B2F8EC}");
        private readonly ID fullyCompletedGoal = new ID("{4BCA6E4D-33BF-46E4-B611-427D2A679DA7}");

        protected void btnStep1_OnClick(object sender, EventArgs e)
        {
            lblResultStep1.Text = RegisterGoal(step1Goal) ? "User logged into step1" : "failed to register Step 1 goal";
            lblResultStep1.Visible = true;
        }

        protected void btnStep2_OnClick(object sender, EventArgs e)
        {
            lblResultStep2.Text = RegisterGoal(step2Goal) ? "User logged into step2" : "failed to register Step 2 goal";
            lblResultStep2.Visible = true;
        }

        protected void btnStep3_OnClick(object sender, EventArgs e)
        {
            lblResultStep3.Text = RegisterGoal(step3Goal) ? "User logged into step3" : "failed to register Step 3 goal";
            lblResultStep3.Visible = true;
        }

        protected void btnCompletedRegistration_OnClick(object sender, EventArgs e)
        {
            lblCompleteRegistration.Text = RegisterGoal(fullyCompletedGoal) ? "User logged into step3" : "failed to register Step 3 goal";
            lblCompleteRegistration.Visible = true;

        }

        protected void btnIdentifyUser_OnClick(object sender, EventArgs e)
        {
            if (txtEmail.Text.IsNullOrEmpty())
            {
                lblResultStep1.Text = "Please enter your email";
                lblResultStep1.Visible = true;
                return;
            }

            IdentifyUser();
            EnrollInEngagementPlan();
        }

        protected void btnAbandonSession_OnClick(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Abandon();
            lblAbandonSession.Text = "Session Abandoned";
            lblAbandonSession.Visible = true;
        }

        private bool RegisterGoal(ID goalId)
        {
            if (!Tracker.IsActive || Tracker.Current == null || Tracker.Current.Session == null ||
                Tracker.Current.Session.Interaction == null || Tracker.Current.Session.Interaction.CurrentPage == null)
            {
                return false;
            }

            var goalItem = Sitecore.Context.Database.GetItem(goalId);
            if (goalItem == null)
            {
                return false;
            }

            var goal = new PageEventItem(goalItem);
            Tracker.Current.Session.Interaction.CurrentPage.Register(goal);
            return true;
        }

        private void EnrollInEngagementPlan()
        {
            AutomationStateManager automationStateManager = Tracker.Current.Session.CreateAutomationStateManager();
            var planItem = Sitecore.Context.Database.GetItem(new ID(registrationDropOutId));
            if (planItem != null && !automationStateManager.IsInEngagementState(step1Id))
            {
                automationStateManager.EnrollInEngagementPlan(planItem.ID, step1Id);
            }
        }

        private void IdentifyUser()
        {
            var email = txtEmail.Text;
            Tracker.Current.Session.Identify(email);
        }

    }
}