using AlquilaFacilPlatform.IAM.Domain.Model.Aggregates;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace AlquilaFacilPlatform.Tests.AcceptanceTests.Steps;

[Binding]
    public class UserSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private User _user;
        private string _initialUsername;
        private string _initialPasswordHash;
        private string _newUsername;
        private string _newPasswordHash;
        private Exception _exception;

        public UserSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"a user with username ""(.*)"" and password hash ""(.*)""")]
        public void GivenAUserWithUsernameAndPasswordHash(string username, string passwordHash)
        {
            _user = new User(username, passwordHash);
            _initialUsername = username;
            _initialPasswordHash = passwordHash;
        }

        [When(@"the administrator updates the username to ""(.*)""")]
        public void WhenTheAdministratorUpdatesTheUsernameTo(string newUsername)
        {
            _newUsername = newUsername;
            try
            {
                _user.UpdateUsername(newUsername);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [When(@"the administrator updates the password hash to ""(.*)""")]
        public void WhenTheAdministratorUpdatesThePasswordHashTo(string newPasswordHash)
        {
            _newPasswordHash = newPasswordHash;
            try
            {
                _user.UpdatePasswordHash(newPasswordHash);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"the username should be ""(.*)""")]
        public void ThenTheUsernameShouldBe(string expectedUsername)
        {
            _user.Username.Should().Be(expectedUsername);
        }

        [Then(@"the password hash should be ""(.*)""")]
        public void ThenThePasswordHashShouldBe(string expectedPasswordHash)
        {
            _user.PasswordHash.Should().Be(expectedPasswordHash);
        }

        [Then(@"an error should occur")]
        public void ThenAnErrorShouldOccur()
        {
            _exception.Should().NotBeNull();
        }
    }