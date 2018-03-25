using BasicCrud.Data.Domain;
using BasicCrud.Data.Entities;
using BasicCrud.Data.Repositories;
using BasicCrud.Logic.Enums;
using BasicCrud.Logic.Security;
using BasicCrud.Logic.Settings;

namespace BasicCrud.Logic
{
    public class UserLogic : AbstractLogic<User, UserDomain>
    {
        private readonly HashGenerator _hashGenerator;
        private readonly SessionManager _sessionManager;

        public UserLogic(IDomainRepository<User,UserDomain> domainrepository, IDomainRepository<UserSession, UserSessionDomain> domainrepositorysession) : base (domainrepository)
        {
            _hashGenerator = new HashGenerator();
            _sessionManager = new SessionManager(domainrepositorysession);
        }


        /// <summary>
        /// Verify a token with the userId
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public TokenStatus VerifyToken(string token)
        {
            if (_sessionManager.Verify(token)) return TokenStatus.ok;
            return TokenStatus.revoked;
        }

        /// <summary>
        /// Register a new user into the system.
        /// </summary>
        /// <param name="newUser">The new user</param>
        /// <returns></returns>
        public CreateUserStatus Register(UserDomain newUser)
        {
            // Check username exist. 
            if (Get(q => q.Username.ToLower() == newUser.Username.ToLower())?.Id != null) return CreateUserStatus.usernameExist;

            // Check email exist.
            if (Get(q => q.Email.ToLower() == newUser.Email.ToLower())?.Id != null) return CreateUserStatus.emailExist;

            // Check password.
            if (newUser.Password.Length <= UserSettings.minimalPasswordLenght) return CreateUserStatus.noStrongPassword;

            // Generate Hash for the password
            newUser.Hash = _hashGenerator.GenerateFromPassword(newUser.Password);

            // Create the user
            newUser.Id = Create(newUser);

            // Verify if created
            if (Get(q => q.Id == newUser.Id)?.Id == null) return CreateUserStatus.userFailCreating;

            return CreateUserStatus.userCreated;
        }

        /// <summary>
        /// Verify the credentials. Returns token with userid
        /// </summary>
        /// <param name="username">given username by the user.</param>
        /// <param name="password">given password by the user.</param>
        /// <returns></returns>
        public UserSessionDomain VerifyCredentials(string username, string password)
        {
            // Check if there is a user that exist with the username
            var user = Get(q => q.Username.ToLower() == username.ToLower());
            if(user?.Id == null) return null;

            // Verify password with the stored value, succes: return user.
            if (_hashGenerator.CheckHashWithPassword(user.Hash, password)) return _sessionManager.Create(user.Id);
            
            return null;
        }
    }
}
