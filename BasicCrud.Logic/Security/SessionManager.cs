using BasicCrud.Data.Domain;
using BasicCrud.Data.Entities;
using BasicCrud.Data.Repositories;
using System;

namespace BasicCrud.Logic.Security
{
    public class SessionManager : AbstractLogic<UserSession, UserSessionDomain>
    {
        // The max number of minutes a session can be inactive. (inactive = no action has been done).
        private int _maxInactiveSessionLenght = 15;

        public SessionManager(IDomainRepository<UserSession, UserSessionDomain> repo) : base(repo)
        {

        }

        /// <summary>
        /// Verify the token and extend the lenght of the session (if verified).
        /// </summary>
        /// <param name="token"></param>
        /// <returns>True if verified and updated.</returns>
        public bool Verify(string token)
        {
            Guid validatedToken;

            if (Guid.TryParse(token, out validatedToken))
            {
                var activeToken = Get(q => q.Token == validatedToken);
                if (activeToken == null) return false;

                var timePassedSindsLastActivity = DateTime.Now - activeToken.LastActivity;

                if (activeToken != null && timePassedSindsLastActivity.Minutes < _maxInactiveSessionLenght)
                {
                    activeToken.LastActivity = DateTime.Now;
                    Update(activeToken);
                    return true;
                }
            }

            return false;
        }
        
        /// <summary>
        /// Create a new session.
        /// </summary>
        /// <param name="UserId">Verified user</param>
        /// <returns></returns>
        public UserSessionDomain Create(int UserId)
        {
            var NewToken = new UserSessionDomain
            {
                Token = Guid.NewGuid(),
                TokenCreated = DateTime.Now,
                LastActivity = DateTime.Now,
                UserId = UserId
            };

            // Delete any other session related to the user (permit only one session)
            Remove(q => q.UserId == UserId);

            var id = Create(NewToken);
            if (id >= 0) return NewToken;

            return null;
        }
    }
}
