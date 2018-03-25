using BasicCrud.Data.Domain;
using BasicCrud.Data.Entities;
using BasicCrud.Data.Mappers;
using BasicCrud.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;

namespace BasicCrud.Test.Repositories
{
    [TestClass]
    public class UserRepoTest
    {
        private Container _container;
        private readonly IDomainRepository<User, UserDomain> _domainRepository;

        public UserRepoTest()
        {
            AutoMapperInitializer.Initialize();
            _container = SimpleInjectorInitializer.Initialize();
            _domainRepository = (IDomainRepository<User, UserDomain>)_container.GetInstance(typeof(IDomainRepository<User, UserDomain>));
        }
        
        private UserDomain CreateUser()
        {
            int id = _domainRepository.Create(
                new UserDomain {
                    Name = "Barth",
                    Username = "Sleepwizard",
                    Surname = "Steeg",
                    Age = 29,
                    Email = "barthsteeg@outlook.com"
                });

            return _domainRepository.Get(id);
        }

        [TestMethod]
        public void Crud()
        {
            // Create
            var user = CreateUser();

            // Read [check]
            Assert.IsTrue(user.Name == "Barth");
            Assert.IsTrue(user.Surname == "Steeg");
            Assert.IsTrue(user.Username == "Sleepwizard");
            Assert.IsTrue(user.Age == 29);
            Assert.IsTrue(user.Email == "barthsteeg@outlook.com");
            
            // Update
            user.Name = "Kees";
            _domainRepository.Update(user);

            // update [check]
            var updatedUser = _domainRepository.Get(user.Id);
            Assert.IsTrue(updatedUser.Name == "Kees");

            _domainRepository.Remove(user);
        }

        [TestMethod]
        public void ExpressionGet()
        {
            var user = CreateUser();
            var checkuser = _domainRepository.Get(q => q.Age == 29);

            Assert.IsTrue(checkuser.Name == "Barth");
            _domainRepository.Remove(user);
        }
    }
}
