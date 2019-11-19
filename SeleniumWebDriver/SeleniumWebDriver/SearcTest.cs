using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Edge;




namespace webdrive.Test
{
    [TestFixture]
    public class selenium_webdriver
    {
        public IWebDriver webdriver;
        private const string ErrorTextForEmptyString = "Введите название города или аэропорта";
        private const string ErrorTextForRowNotFound = "Не было найдено неоплаченых броней с таким кодом.";

        [SetUp]
        public void StartBrowser()
        {
            webdriver = new EdgeDriver();
            webdriver.Manage().Window.Maximize();
            webdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            webdriver.Navigate().GoToUrl("https://aviago.by/");
        }
        [TearDown]
        public void CloseBrowser()
        {
            webdriver.Quit();
        }
        static DateTime currentDate = DateTime.Now;
        public string dayAfterTomorrowDate = (currentDate.AddDays(0)).Day.ToString();
        private static string monthOfDayAfterTomorrow = (currentDate.AddMonths(-1)).Month.ToString();

        [Test]
        /* Поиск маршрута из определенного города без ввода города прибытия.
         Шаги: 
         ЗАйти  на главную страницу сайта;
         заполнить формы город вылета(Минск), Дату вылеты и прибытия;
         Нажать кнопку Найти билеты*/
         public void SearchRouteWithoutDestination()
         {
             var destinationText = webdriver.FindElement(By.ClassName("sfInputTd"));

             var entercity = webdriver.FindElement(By.Id("cty0")); 
             entercity.SendKeys("Минск (все аэропорты), Беларусь");

             var openkalendarto = webdriver.FindElement(By.Id("outDate"));
             openkalendarto.Click();

             var enterdate = webdriver.FindElement(By.XPath("//td[@data-month=" + monthOfDayAfterTomorrow + "]/descendant-or-self::a[text() = " + dayAfterTomorrowDate + "]"));
             enterdate.Click();

              var openkalendarback = webdriver.FindElement(By.Id("retDate"));
              openkalendarback.Click();

             var crest = webdriver.FindElement(By.XPath("//div[@title='В одну сторону']"));
             crest.Click();

             var searchButton = webdriver.FindElement(By.XPath("//div/i[@class='fa fa-search']"));
             searchButton.Click();

             string errorMessage = (webdriver.FindElement(By.XPath("//div[@id='cty1-error']"))).Text;
             Assert.AreEqual(ErrorTextForEmptyString, errorMessage);
         }
        //Ожидаемый результат:
        //Появление всплывающего окна с сообщением:"введите название города или аэропорта".



        //        Ввод некорректного номера брони
        //Шаги:
        //-Зайти на сайт 
        //-Нажимаем кнопу "Оплата заказа"
        //-Указать в поле "Код брони" номер 12345
        //-нажимаем кнопку "Искать"
        //Ожидаемый результат: сообщение об ошибке:"Не было найдено неоплаченых броней с таким кодом:.

        [Test]
        public void SendOneChild()
        {
            var orderpayment = webdriver.FindElement(By.ClassName("realWhite"));
            orderpayment.Click();

            var enterreservationcode = webdriver.FindElement(By.XPath("//input[@class='input2']"));
            enterreservationcode.SendKeys("12345");

            var searchButton = webdriver.FindElement(By.XPath("//div[text() ='Искать']"));
            searchButton.Click();

            string errorMessage = (webdriver.FindElement(By.Id("payonlineResult")).FindElement(By.ClassName("error"))).Text;
            Assert.AreEqual(ErrorTextForRowNotFound, errorMessage);    
        }

    }
}
