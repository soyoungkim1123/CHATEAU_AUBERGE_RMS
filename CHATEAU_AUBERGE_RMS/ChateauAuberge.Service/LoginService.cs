using ChateauAuberge.Repository;
using ChateauAuberge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChateauAuberge.Service
{
    public class LoginService
    {
        private LoginRepo repo;

        public LoginService()
        {
            repo = new LoginRepo();
        }

        public ClerkDTO GetClerkInfo(string userName, string password)
        {
            return repo.Login(userName, password);
        }
    }
}
