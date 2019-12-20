using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using GitHubAutomation.Models;

namespace GitHubAutomation.Pages
{
    public class MainPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "cty0")]
        private IWebElement destinationText;

        [FindsBy(How = How.XPath, Using = "//td[text()='Минск (Minsk International 2)']")]
        private IWebElement enterdeparturecity;

       
        [FindsBy(How = How.Id, Using = "cty1")]
        private IWebElement inputentercityofarrival;

        [FindsBy(How = How.XPath, Using = "//td[text()='Москва (все аэропорты)']")]
        private IWebElement entercityofarrival;

        [FindsBy(How = How.Id, Using = "outDate")]
        private IWebElement openkalendarto;

        [FindsBy(How = How.XPath, Using = "//a[@class='ui-state-default ui-state-highlight ui-state-active']")]
        private readonly IWebElement selectdate;

        [FindsBy(How = How.Id, Using = "retDate")]
        private IWebElement openkalendarback;


        [FindsBy(How = How.XPath, Using = "//div[@title='В одну сторону']")]
        private IWebElement crest;

        [FindsBy(How = How.XPath, Using = "//div/i[@class='fa fa-search']")]
        private IWebElement searchButton;

        [FindsBy(How = How.ClassName, Using = "ui-spinner-button ui-spinner-up ui-corner-tr ui-button ui-widget ui-state-default ui-button-text-only")]
        public IWebElement addonechild;

        [FindsBy(How = How.ClassName, Using = "ui-spinner-button ui-spinner-down ui-corner-br ui-button ui-widget ui-state-default ui-button-text-only")]
        public IWebElement deleteoneadult;

        [FindsBy(How = How.ClassName, Using = "ui-spinner-button ui-spinner-up ui-corner-tr ui-button ui-widget ui-state-default ui-button-text-only")]
        public IWebElement addbaby;

        [FindsBy(How = How.ClassName, Using = "ui-spinner-button ui-spinner-up ui-corner-tr ui-button ui-widget ui-state-default ui-button-text-only")]
        public IWebElement Addoneadult;



        [FindsBy(How = How.XPath, Using = "//div[@id='cty1-error']")]
        public IWebElement errorPopupMessage;

        [FindsBy(How = How.ClassName, Using = "error")]
        public IWebElement errorMessage;
        
        [FindsBy(How = How.XPath, Using = "//div[@class='section text-right']/a")]
        public IWebElement buttonCheapticket;

        [FindsBy(How = How.ClassName, Using = "button dialog")]
        public IWebElement buttonShooce;

        [FindsBy(How = How.ClassName, Using = "button")]
        public IWebElement consentbutton;

        [FindsBy(How = How.ClassName, Using = "realWhite")]
        public IWebElement orderpayment;

        [FindsBy(How = How.XPath, Using = "//input[@class='input2']")]
        public IWebElement enterreservationcode;

        [FindsBy(How = How.XPath, Using = "//div[text() ='Искать']")]
        public IWebElement searchButtonbrone;
        
        [FindsBy(How = How.ClassName, Using = "error")]
        public IWebElement errorMesForBrone;

        [FindsBy(How = How.Id, Using = "airlineLink")]
        public IWebElement buttonselectairlina;

        [FindsBy(How = How.XPath, Using = "//option[@value='B2']")]
        public IWebElement selectairlin;

        [FindsBy(How = How.ClassName, Using = "error")]
        public IWebElement notfound;

        [FindsBy(How = How.XPath, Using = "//a[@title='Дешевые авиабилеты: Дешевые авиабилеты: Вильнюс – Осло']")]
        public IWebElement buttonVilnusOslo;

        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        public MainPage ChooseADepartureCity()
        {
            destinationText.Click();
            enterdeparturecity.Click();
            return this;
        }
        public MainPage ChooseCityOfArrival()
        {
            inputentercityofarrival.Click();
            entercityofarrival.Click();
            return this;
        }
        public MainPage ChooseDateFlight()
        {
            openkalendarto.Click();
            selectdate.Click();
            openkalendarback.Click();
            crest.Click();
            return this;
        }
        public MainPage Search()
        {
            searchButton.Click();
            return this;
        }
        public MainPage AddChild()
        {
            addonechild.Click();
            return this;
        }
        public MainPage AddAdult()
        {
            Addoneadult.Click();
            return this;
        }
        public MainPage AddBaby()
        {
            addbaby.Click();
            return this;
        }
        public MainPage DeleteAdult()
        {
            deleteoneadult.Click();
            return this;
        }
        public MainPage FindBron()
        {
            orderpayment.Click();
            enterreservationcode.SendKeys("12345");
            searchButtonbrone.Click();
            return this;
        }

        public MainPage InputAirline()
        {
            buttonselectairlina.Click();
            selectairlin.Click();
            return this;
        }

    }
}
