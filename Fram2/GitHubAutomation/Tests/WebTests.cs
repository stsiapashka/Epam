
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
            SignInPage signInPage = new MainPage(Driver).
                GoToSignIn().InputLogin(UserCreator.WithCredentialsFromProperty()).
                InputPassword(UserCreator.WithCredentialsFromProperty());
            Assert.AreEqual(signInPage.PageDialog, "Не удалось войтиПроверьте введенные адрес почты и пароль.");
        }

        [Test]
        public void SearchRouteWithoutDestination()
        {

            MainPage mainpage = new MainPage(Driver);
            mainpage.ChooseADepartureCity(RouteCreate.WithCredentialsFromProperty()).ChooseDateFlight().Search();
            Assert.AreEqual(mainpage.errorPopupMessage, "Введите название города или аэропорта");
        }

        [Test]
        public void FindCheapTicket()
        {
            MainPage mainpage = new MainPage(Driver);
            Assert.IsTrue(mainpage.Cheapticket());
        }

        [Test]
        public void SendOneChild()
        {
            MainPage mainpage = new MainPage(Driver);
            mainpage.ChooseADepartureCity(RouteCreate.WithCredentialsFromProperty()).
            ChooseCityOfArrival(RouteCreate.WithCredentialsFromProperty()).
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
        public void SameCityOfArrivalAndDeparture()
        {
            MainPage mainpage = new MainPage(Driver);
            mainpage.ChooseADepartureCity(RouteCreate.WithCredentialsFromProperty()).
                ChooseCityOfArrival(RouteCreate.WithCredentialsFromProperty()).
                ChooseDateFlight().
                Search();
            Assert.AreEqual(mainpage.notfound, "К сожалению не было найдено ни одного предложения. Поробуйте поменять параметры поиска. ");
        }

        [Test]
        public void MoreYoungAdultsThanAdults()
        {
            MainPage mainpage = new MainPage(Driver);
            mainpage.ChooseADepartureCity(RouteCreate.WithCredentialsFromProperty()).
                ChooseCityOfArrival(RouteCreate.WithCredentialsFromProperty()).
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
            mainpage.ChooseADepartureCity(RouteCreate.WithCredentialsFromProperty()).
            ChooseCityOfArrival(RouteCreate.WithCredentialsFromProperty()).
            ChooseDateFlight().
            Search();
            PassengerDataPage passenger = mainpage.GoToPassengerDataPage();
            passenger.InputDataPass(UserCreator.WithCredentialsFromProperty());
            Assert.AreEqual(passenger.ErrorPopupMessage, "Введите номер телефона");
        }

        [Test]
        public void ViewSarchHistory()
        {
            MainPage mainpage = new MainPage(Driver);
            mainpage.buttonVilnusOslo.Click();

            PassengerDataPage passenger = mainpage.GoToPassengerDataPage();
            passenger.InputDataPass(UserCreator.WithCredentialsFromProperty()).
                Inputdateforpassport(UserCreator.WithCredentialsFromProperty()).
                InputKardInfo(UserCreator.UserKardInfo());
            Assert.AreEqual(passenger.ErrorPopupMessage, "Неверный срок годности. Пожалуйста, проверьте, что срок действия вашей карты истек");
        }
    }
}
