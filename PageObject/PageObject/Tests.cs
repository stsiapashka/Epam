using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject
{
    [TestFixture]
    public class Tests
    {

        IWebDriver webDriver;

        string UnknownUserLoginErrorText = "Не удалось войти";
        string ErrorSuchUserIsRegistered = " Такой адрес эл. почты уже зарегистрирован в нашей системе. Укажите другой адрес эл. почты. Если вы забыли свой пароль, ";
        [SetUp]
        public void StartBrowserAndOpenSite()
        {
            webDriver = new EdgeDriver();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(220);
            webDriver.Navigate().GoToUrl("https://aviago.by");
        }
        [TearDown]
        public void QuitDriver()
        {
            webDriver.Quit();
        }

        [Test]
        public void LogInAsAnUnknowUser()
        {
            StartPage startPage = new StartPage(webDriver);
            startPage.LogInAsAnUnknowUser("abc@gmail.com", "12345678");
            Assert.AreEqual(startPage.PageDialog.Text, UnknownUserLoginErrorText);
        }
        [Test]
        public void RegistrationByExistingEmail()
        {
            StartPage startPage = new StartPage(webDriver).OpenRegistrationPage(webDriver);
            CheapTicket cheapTicket = new CheapTicket(webDriver).DataEntryForRegistration("Любовь", "Степанова", "abc@gmail.com", "296392112", "ABCD1234", "ABCD1234");
            Assert.AreEqual(cheapTicket.ErrorField.Text, ErrorSuchUserIsRegistered);
        }
    }
}
