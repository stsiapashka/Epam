
using NUnit.Framework;
using GitHubAutomation.Driver;
using GitHubAutomation.Pages;
using GitHubAutomation.Services;


namespace GitHubAutomation.Tests
{
    [TestFixture]
    public class WebTests : GeneralConfig
    {
        string UnknownUserLoginErrorText = "Не удалось войти";
        string ErrorTextForEmptyString = "Введите название города или аэропорта";

        [Test]
        public void LogInAsAnUnknowUser()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                SignInPage sigin = new SignInPage(Driver);
                Assert.AreEqual(sigin.LogInAsAnUnknowUser(UserCreator.WithCredentialsFromProperty()), UnknownUserLoginErrorText);
            });
        }
        [Test]
        public void SearchRouteWithoutDestination()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                SelectDataPage selectDataPage = new SelectDataPage(Driver);
                Assert.AreEqual(selectDataPage.SearchRouteWithoutDestination(), ErrorTextForEmptyString);

            });
        }
    }
}
