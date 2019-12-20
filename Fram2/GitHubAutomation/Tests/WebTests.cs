
using NUnit.Framework;
using GitHubAutomation.Driver;
using GitHubAutomation.Pages;
using GitHubAutomation.Services;


namespace GitHubAutomation.Tests
{
    [TestFixture]
    public class WebTests : GeneralConfig
    {
        [Test]
        public void LogInAsAnUnknowUser()
        {
            SignInPage sigin = new SignInPage(Driver);
            sigin.InputLogin(UserCreator.WithCredentialsFromProperty()).InputPassword(UserCreator.WithCredentialsFromProperty());
            Assert.AreEqual(sigin.PageDialog, "Не удалось войти");
        }

        [Test]
        public void SearchRouteWithoutDestination()
        {

            MainPage mainpage = new MainPage(Driver);
            mainpage.ChooseADepartureCity().ChooseDateFlight().Search();
            Assert.AreEqual(mainpage.errorPopupMessage, "Введите название города или аэропорта");
        }

        [Test]
        public void FindCheapTicket()
        {
            MainPage mainpage = new MainPage(Driver);
            mainpage.buttonCheapticket.Click();
        }

        [Test]
        public void SendOneChild()
        {
            MainPage mainpage = new MainPage(Driver);
            mainpage.ChooseADepartureCity().
            ChooseCityOfArrival().
            ChooseDateFlight().
            AddChild().
            DeleteAdult().
            Search();
            Assert.AreEqual(mainpage.errorMessage, "К сожалению не было найдено ни одного предложения. Поробуйте поменять параметры поиска. ");
        }

        [Test]
        public void EnterAnInvalidBrone()
        {
            MainPage mainpage = new MainPage(Driver);
            mainpage.FindBron();
            Assert.AreEqual(mainpage.errorMesForBrone, "Не было найдено неоплаченых броней с таким кодом.");
        }
               
        [Test]
        public void FindFlightBySelectedAirline()
        {
            MainPage mainpage = new MainPage(Driver);
            mainpage.InputAirline().
                ChooseADepartureCity().
                ChooseCityOfArrival().
                ChooseDateFlight().
                Search();
        }

        [Test]
        public void SameCityOfArrivalAndDeparture()
        {
            MainPage mainpage = new MainPage(Driver);
            mainpage.ChooseADepartureCity().
                ChooseCityOfArrival().
                ChooseDateFlight().
                Search();
            Assert.AreEqual(mainpage.notfound, "К сожалению не было найдено ни одного предложения. Поробуйте поменять параметры поиска. ");
        }

        [Test]
        public void MoreYoungAdultsThanAdults()
        {
            MainPage mainpage = new MainPage(Driver);
            mainpage.ChooseADepartureCity().
                ChooseCityOfArrival().
                ChooseDateFlight().
                AddAdult().
                AddBaby().
                AddBaby().
                DeleteAdult().
                Search();
            Assert.AreEqual(mainpage.notfound, "К сожалению не было найдено ни одного предложения. Поробуйте поменять параметры поиска. ");
        }
        [Test]
        public void SendAPassengerWithoutData()
        {
            MainPage mainpage = new MainPage(Driver);
            mainpage.ChooseADepartureCity().
            ChooseCityOfArrival().
            ChooseDateFlight().
            Search().
            buttonShooce.Click();

            PassengerDataPage passenger = new PassengerDataPage(Driver);
            passenger.InputDataPass(UserCreator.WithCredentialsFromProperty());
            Assert.AreEqual(passenger.ErrorPopupMessage, "Введите номер телефона");
        }
        [Test]
        public void ViewSarchHistory()
        {
            MainPage mainpage = new MainPage(Driver);
            mainpage.buttonVilnusOslo.Click();
            mainpage.buttonShooce.Click();

            PassengerDataPage passenger = new PassengerDataPage(Driver);
            passenger.InputDataPass(UserCreator.WithCredentialsFromProperty()).
                Inputdateforpassport(UserCreator.WithCredentialsFromProperty()).
                InputKardInfo(UserCreator.UserKardInfo());
            Assert.AreEqual(passenger.ErrorPopupMessage, "Неверный срок годности. Пожалуйста, проверьте, что срок действия вашей карты истек");
        }
    }
}
