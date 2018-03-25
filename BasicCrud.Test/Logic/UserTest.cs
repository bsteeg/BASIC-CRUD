using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;
using BasicCrud.Logic;
using BasicCrud.Data.Mappers;
using BasicCrud.Data.Domain;
using BasicCrud.Logic.Enums;

namespace BasicCrud.Test.Logic
{
    [TestClass]
    public class UserLogicTest
    {
        private Container _container;
        private readonly UserLogic _logic;

        private UserDomain _user;

        public UserLogicTest()
        {
            AutoMapperInitializer.Initialize();
            _container = SimpleInjectorInitializer.Initialize();
            _logic = (UserLogic)_container.GetInstance(typeof(UserLogic));
        }

        private UserDomain CreateUser()
        {
            return new UserDomain
            {
                Name = "Barth",
                Username = "Sleepwizard",
                Surname = "Steeg",
                Age = 29,
                Email = "barthsteeg@outlook.com",
                Password = "test123456"
            };
        }

        [TestInitialize]
        public void Initialize()
        {
            _user = CreateUser();
        }
        
        [TestCleanup]
        public void Cleanup()
        {
            _logic.Remove(_user);
        }

        [TestMethod]
        public void Create()
        {
            // Create
            var status = _logic.Register(_user);
            Assert.IsTrue(status == CreateUserStatus.userCreated);
        }

        [TestMethod]
        public void VerifyCredentials()
        {
            var status = _logic.Register(_user);
            Assert.IsTrue(status == CreateUserStatus.userCreated);

            // Verify login
            var userSuccess = _logic.VerifyCredentials(_user.Username, _user.Password);

            // Verify token
            Assert.IsTrue(_logic.VerifyToken(userSuccess.Token.ToString()) == TokenStatus.ok);

            var userFail1 = _logic.VerifyCredentials("Sleepwiz", "test123456");
            var userFail2 = _logic.VerifyCredentials("Sleepwizard", "123456test");

            Assert.IsTrue(userSuccess != null);
            Assert.IsTrue(userFail1 == null);
            Assert.IsTrue(userFail2 == null);
        }
    }
}
