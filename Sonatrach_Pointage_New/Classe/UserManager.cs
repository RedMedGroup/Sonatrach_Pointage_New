using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonatrach_Pointage_New.Classe
{
    public static class UserManager
    {
        private static DAL.User _user;
        public static DAL.User User
        {
            get { return _user; }
        }

        public static void SetUser(DAL.User user)
        {
            _user = user;
        }
    }
}
