using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using GitHubAutomation.Models;

namespace GitHubAutomation.Pages
{
    public class PassengerDataPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//label[@class='ui-button ui-widget ui-state-default ui-button-text-icon-primary ui-corner-right']")]
        public IWebElement inputgender;

        [FindsBy(How = How.Id, Using = "firstname0")]
        public IWebElement inputname;

        [FindsBy(How = How.Id, Using = "firstname0")]
        public IWebElement inputsurname;

        [FindsBy(How = How.Id, Using = "firstname0")]
        public IWebElement inputbirthday;

        [FindsBy(How = How.Id, Using = "firstname0")]
        public IWebElement inputpassport;
        [FindsBy(How = How.Id, Using = "fd_phone")]
        public IWebElement inputphone;
                
        [FindsBy(How = How.Id, Using = "doc_exp0")]
        public IWebElement inputdatepasport;

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement inputemail;

        [FindsBy(How = How.ClassName, Using = "button")]
        public IWebElement paymentbutton;

        [FindsBy(How = How.ClassName, Using = "fd_phone-error")]
        public IWebElement ErrorPopupMessage;

        [FindsBy(How = How.Id, Using = "cardnr")]
        public IWebElement inputcardnum;
        [FindsBy(How = How.Id, Using = "expmonth")]
        public IWebElement inputcardmonth;
        [FindsBy(How = How.ClassName, Using = "expyear")]
        public IWebElement inputcardyear;
        [FindsBy(How = How.ClassName, Using = "cardname")]
        public IWebElement inputcardname;
        public PassengerDataPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }
        public PassengerDataPage InputLogin(User user)
        {
            inputemail.SendKeys(user.login);
            return this;
        }
        public PassengerDataPage Inputdateforpassport(User user)
        {
            inputdatepasport.SendKeys(user.login);
            return this;
        }
        public PassengerDataPage InputDataPass(User user)
        {
            inputgender.Click();
            inputname.SendKeys(user.name);
            inputsurname.SendKeys(user.surname);
            inputbirthday.SendKeys(user.birthday);
            inputpassport.SendKeys(user.passport);
            inputphone.SendKeys(user.numphone);
            return this;
        }

        public PassengerDataPage InputKardInfo(User user)
        {
            inputcardnum.SendKeys(user.numсard);
            inputcardmonth.SendKeys(user.сardmonth);
            inputcardyear.SendKeys(user.сardyear);
            inputcardname.SendKeys(user.сardname);
            return this;
        }
    }
}
