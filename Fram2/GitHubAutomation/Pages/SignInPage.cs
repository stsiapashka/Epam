using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using GitHubAutomation.Models;

namespace GitHubAutomation.Pages
{
    public class SignInPage
    {       
        private IWebDriver webDriver;

        [FindsBy(How = How.Id, Using = "login")]
        private IWebElement LoginButton;

        [FindsBy(How = How.Id, Using = "loginEmail")]
        private IWebElement InputEmail;

        [FindsBy(How = How.Id, Using = "loginPassword")]
        private IWebElement Inputpassword;

        [FindsBy(How = How.XPath, Using = "//div/i[@class='fa fa-sign-in']")]
        private IWebElement ButtonComeIn;

        [FindsBy(How = How.XPath, Using = "//div[text() ='Не удалось войти']")]
        public IWebElement PageDialog;

     
        public SignInPage(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
            this.webDriver = webDriver;
        }
        public SignInPage InputLogin(User user)
        {
            LoginButton.Click();
            InputEmail.SendKeys(user.login);
            return this;

        }
        public SignInPage InputPassword(User user)
        {
            Inputpassword.SendKeys(user.password);
            ButtonComeIn.Click();
            return this;
        }

    }
}
