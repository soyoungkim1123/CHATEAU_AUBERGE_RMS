using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChateauAuberge.Model;
using Types;
using System.Data;

namespace ChateauAuberge.Repository
{
    public class LoginRepo
    {
        private DataAccess db;

        public LoginRepo()
        {
            db = new DataAccess();
        }

        public ClerkDTO Login(string userName, string password)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@UserName", SqlDbType.NVarChar, 100, userName, ParameterDirection.Input));
            parms.Add(new ParmStruct("@Password", SqlDbType.NVarChar, 100, password, ParameterDirection.Input));

            DataTable dt = db.GetData("spClerkLogin", parms);

            ClerkDTO clerk = new ClerkDTO
            {
                ClerkId = Convert.ToInt32(dt.Rows[0]["ClerkId"]),
                FullName = dt.Rows[0]["Full Name"].ToString()
            };

            return clerk;
        }

    }
}
