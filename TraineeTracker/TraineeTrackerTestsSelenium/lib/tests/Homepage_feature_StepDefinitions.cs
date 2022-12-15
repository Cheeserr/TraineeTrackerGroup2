using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TraineeTrackerTests.lib.pages;

namespace TraineeTrackerTests.lib.tests
{
    [Binding]
    public class Homepage_feature_StepDefinitions
    {
        private Website<ChromeDriver> Website;
        [Given(@"I have a browser open")]
        public void GivenIHaveABrowserOpen()
        {
            Website = new Website<ChromeDriver>();
            Website.SeleniumDriver.Manage().Window.Maximize();
        }

        [Given(@"I am on a homepage")]
        public void GivenIAmOnAHomepage()
        {
            Website.Homepage.VisitHomePage();
        }

        [When(@"I press login button")]
        public void WhenIPressLoginButton()
        {
            Website.Homepage.ClickLoginButton();
        }

        [Then(@"I am redirected to the login page")]
        public void ThenIAmRedirectedToTheLoginPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://localhost:7166/Identity/Account/Login"));
        }

        [When(@"I press register button")]
        public void WhenIPressRegisterButton()
        {
            Website.Homepage.ClickRegisterButton();
        }

        [Then(@"I am redirected to the register page")]
        public void ThenIAmRedirectedToTheRegisterPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://localhost:7166/Identity/Account/Register"));
        }

        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            Website.LoginPage.VisitLoginPage();
            Website.LoginPage.EnterEmail("Phil@SpartaGlobal.com");
            Website.LoginPage.EnterPassword("Password1!");
            Website.LoginPage.ClickLoginButton();
        }

        [Then(@"Nothing happens")]
        public void ThenNothingHappens()
        {
            throw new PendingStepException();
        }

        [When(@"I press user button")]
        public void WhenIPressUserButton()
        {
            Website.Homepage.ClickUserButton();
        }

        [Then(@"I am redirected to the user page")]
        public void ThenIAmRedirectedToTheUserPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://localhost:7166/Identity/Account/Login"));
        }

        [When(@"I press privacy button")]
        public void WhenIPressPrivacyButton()
        {
            Website.Homepage.ClickPrivacyButton();
        }

        [Then(@"I am redirected to the privacy page")]
        public void ThenIAmRedirectedToThePrivacyPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://localhost:7166/Identity/Account/Login"));
        }
    }
}
