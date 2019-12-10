using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using GitHubAutomation.Models;

namespace GitHubAutomation.Pages
{
    public class SelectDataPage
    {
        [FindsBy(How = How.ClassName, Using = "sfInputTd")]
        private IWebElement destinationText;

        [FindsBy(How = How.XPath, Using = "//td[text()='Минск (Minsk International 2)']")]
        private IWebElement enterdeparturecity;

         [FindsBy(How = How.Id, Using = "outDate")]
        private IWebElement openkalendarto;

        [FindsBy(How = How.XPath, Using = "//a[@class='ui-state-default ui-state-highlight ui-state-active ui-state-hover']")]
        private readonly IWebElement selectdate;

        [FindsBy(How = How.Id, Using = "retDate")]
        private IWebElement openkalendarback;


        [FindsBy(How = How.XPath, Using = "//div[@title='В одну сторону']")]
        private IWebElement crest;

        [FindsBy(How = How.XPath, Using = "//div/i[@class='fa fa-search']")]
        private IWebElement searchButton;

         [FindsBy(How = How.XPath, Using = "//div[@id='cty1-error']")]
        public IWebElement errorMessage;

        public SelectDataPage(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        public string SearchRouteWithoutDestination()
        {
            destinationText.Click();
            enterdeparturecity.Click();
            openkalendarto.Click();
            selectdate.Click();
            openkalendarback.Click();
            crest.Click();
            searchButton.Click();
            return errorMessage.Text;

        }
    }
}
