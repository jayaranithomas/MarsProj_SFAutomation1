using MarsProject_SpecflowAutomation.Pages;
using MarsProject_SpecflowAutomation.Utilities;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace MarsProject_SpecflowAutomation.StepDefinitions
{
    [Binding]
    public class LanguageStepDefinition:CommonDriver
    {
        LoginPage loginObj = new LoginPage();
        HomePage homeObj = new HomePage();
        ProfilePage profileObj = new ProfilePage();
        LanguagePage languageObj = new LanguagePage();

        [Given(@"user logs in to the Mars Portal")]
        public void GivenUserLogsInToTheMarsPortal()
        {
            driver = new ChromeDriver();
            homeObj.SignInAction(driver);
        }

        [Given(@"user navigates to Profile Page")]
        public void GivenUserNavigatesToProfilePage()
        {
            loginObj.LoginActions(driver);
        }

        [Given(@"user selects the Langauge Tab '([^']*)'")]
        public void GivenUserSelectsTheLangaugeTab(string language)
        {
            profileObj.SelectLanguage(driver,language);
        }


        [When(@"user adds a new Language record '([^']*)' '([^']*)'")]
        public void WhenUserAddsANewLanguageRecord(string language, string level)
        {
            languageObj.AddLanguage(driver, language, level);
        }


        [Then(@"Mars portal should save the new Language record '([^']*)'")]
        public void ThenMarsPortalShouldSaveTheNewLanguageRecord(string language)
        {
            languageObj.AssertAddNewLanguage(driver, language);
        }

        [When(@"user edits an existing Language record '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenUserEditsAnExistingLanguageRecord(string OldLan, string OldLevel, string NewLan, string NewLevel)
        {
            languageObj.EditLanguage(driver, OldLan, OldLevel, NewLan, NewLevel);
        }

        [Then(@"Mars portal should save the updated Language record '([^']*)' '([^']*)'")]
        public void ThenMarsPortalShouldSaveTheUpdatedLanguageRecord(string NewLan, string NewLevel)
        {
            languageObj.AssertEditLanguage(driver, NewLan, NewLevel);
        }

        [When(@"user deletes all the existing Language records")]
        public void WhenUserDeletesAllTheExistingLanguageRecords()
        {
            languageObj.DeleteLanguage(driver);
        }

        [Then(@"Mars portal should not have any Language records")]
        public void ThenMarsPortalShouldNotHaveAnyLanguageRecords()
        {
            languageObj.AssertDeleteLanguage(driver);   
        }


        [AfterScenario]
        public void QuitDriver()
        {
            driver.Quit();
        }
    }
}
