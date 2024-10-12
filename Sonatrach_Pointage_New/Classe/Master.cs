using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonatrach_Pointage_New.Classe
{
    internal class Master
    {
        public static List<ValueAndID> UserTypeList = new List<ValueAndID>() {
                new ValueAndID() { ID = (int)UserType.Admin, Name="Admin" },
            new ValueAndID() { ID = (int)UserType.User, Name="Utilisateur"} };
        public enum UserType
        {
            Admin = 1,
            User,
        }
        public class ValueAndID
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        #region
    
        #endregion
    }
}
