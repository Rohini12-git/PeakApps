using PeakApps.Custom_Class;
using System;
using TechTalk.SpecFlow;

namespace PeakApps.Steps
{
    [Binding]
    public class CompareAuditQsSteps
    {
        AuditCompareClass compareAudit = new AuditCompareClass();
        [Then(@"Verify all the list item i\.e Audit Setup in the sheet is available in the site or not")]
        public void ThenVerifyAllTheListItemI_EAuditSetupInTheSheetIsAvailableInTheSiteOrNot()
        {
            compareAudit.count_policy();
        }
        [When(@"data matched click on cancel to close policy\.")]
        public void WhenDataMatchedClickOnCancelToClosePolicy_()
        {
            compareAudit.closePolicy();
        }
        [Then(@"Verify the '(.*)' having single flow")]
        public void ThenVerifyTheHavingSingleFlow(string p0)
        {
            compareAudit.single_data();
            compareAudit.CustomQs();
        }

        [When(@"Verify the '(.*)' having double flow  and click on next button")]
        public void WhenVerifyTheHavingDoubleFlowAndClickOnNextButton(string p0)
        {
            compareAudit.double_data();
        }

        [When(@"select the next data and match with sheet")]
        public void WhenSelectTheNextDataAndMatchWithSheet()
        {
            compareAudit.double_next();
            compareAudit.double_next1();
        }

        [When(@"select (.*)A '(.*)' having multiple flow  and click on next button")]
        public void WhenSelectAHavingMultipleFlowAndClickOnNextButton(int p0, string p1)
        {
            AuditCompareClass.needleless_connectors();
        }

        [Then(@"select (.*)A->(.*)\(Any/All\)->(.*)\(Any/All\)->(.*)\(Any/All\) and match with sheet")]
        public void ThenSelectA_AnyAll_AnyAll_AnyAllAndMatchWithSheet(int p0, int p1, int p2, int p3)
        {
            compareAudit.needleless_connectors_4();
            compareAudit.needleless_connectors_5();
            compareAudit.needleless_connectors_6();
            compareAudit.needleless_connectors_11();
        }
        [When(@"select (.*)B '(.*)' having multiple flow  and click on next button")]
        public void WhenSelectBHavingMultipleFlowAndClickOnNextButton(int p0, string p1)
        {
            AuditCompareClass.male_luers();
        }

        [Then(@"select (.*)->(.*)\(Any/All\)->(.*)\(Any/All\)->(.*)\(Any/All\) and match with sheet")]
        public void ThenSelect_AnyAll_AnyAll_AnyAllAndMatchWithSheet(int p0, int p1, int p2, int p3)
        {
            compareAudit.male_luers_7();
            compareAudit.male_luers_8();
            compareAudit.needleless_connectors_6();
            compareAudit.needleless_connectors_11();
        }

        [Then(@"select (.*)B->(.*)\(Any/All\) and match with sheet")]
        public void ThenSelectB_AnyAllAndMatchWithSheet(int p0, int p1)
        {
            compareAudit.male_luers_7B();
            compareAudit.needleless_connectors_11();
        }

        [When(@"select (.*)C '(.*)' having multiple flow  and click on next button")]
        public void WhenSelectCHavingMultipleFlowAndClickOnNextButton(int p0, string p1)
        {
            AuditCompareClass.female_luers();
        }

        [Then(@"select (.*)A->(.*)->(.*)\(Any/All\)->(.*)\(Any/All\) and match with sheet")]
        public void ThenSelectA__AnyAll_AnyAllAndMatchWithSheet(int p0, int p1, int p2, int p3)
        {
            compareAudit.female_luers_9();
            compareAudit.female_luers_10();
            compareAudit.needleless_connectors_6();
            compareAudit.needleless_connectors_11();
        }

        

    }
}
