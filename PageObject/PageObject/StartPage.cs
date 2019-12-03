using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject
{
    public class StartPage
    {
        public StartPage(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }
           
        [FindsBy(How = How.Id, Using = "login")]
        private IWebElement LoginButton { get; set; }

        [FindsBy(How = How.Id, Using = "loginEmail")]
        private IWebElement InputEmail { get; set; }

        [FindsBy(How = How.Id, Using = "loginPassword")]
        private IWebElement InputPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//div/i[@class='fa fa-sign-in']")]
        private IWebElement ButtonComeIn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[text() ='Не удалось войти']")]
        public IWebElement PageDialog { get; set; }

        [FindsBy(How = How.ClassName, Using = "blueButton")]
        IWebElement ButtonRegistration { get; set; }
                
        public StartPage LogInAsAnUnknowUser(string email, string password)
        {
            LoginButton.Click();
            InputEmail.SendKeys(email);
            InputPassword.SendKeys(password);
            ButtonComeIn.Click();
            return this;
        } 
        public StartPage OpenRegistrationPage(IWebDriver webDriver)
        {
            LoginButton.Click();
            Actions action = new Actions(webDriver);
            action.MoveToElement(ButtonRegistration).Click().Build().Perform();            
            return this;
        }

    }
}
