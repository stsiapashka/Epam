using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace PageObject
{
    public class CheapTicket
    {
        public CheapTicket(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.Name, Using = "new_user[first_name]")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.Name, Using = "new_user[last_name]")]
        public IWebElement UserSurname { get; set; }

        [FindsBy(How = How.Name, Using = "new_user[email]")]
        public IWebElement UserEmail { get; set; }

        [FindsBy(How = How.Name, Using = "new_user[phone1]")]
        public IWebElement Userphone { get; set; }

        [FindsBy(How = How.Id, Using = "pass1")]
        public IWebElement PasswordFirst { get; set; }

        [FindsBy(How = How.Id, Using = "pass2")]
        public IWebElement PasswordSecond { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[text()='Зарегистрироваться']")]
        public IWebElement ButtonRegistration { get; set; }

        [FindsBy(How = How.ClassName, Using = "error")]
        public IWebElement ErrorField { get; set; }


        public CheapTicket DataEntryForRegistration(string Name,string Surname, string email, string number, string pass,string pass2)
        {
            UserName.SendKeys(Name);
            UserSurname.SendKeys(Surname);
            UserEmail.SendKeys(email);
            Userphone.SendKeys(number);
            PasswordFirst.SendKeys(pass);
            PasswordSecond.SendKeys(pass2);
             ButtonRegistration.Click();
            return this;
        }

    }
}
