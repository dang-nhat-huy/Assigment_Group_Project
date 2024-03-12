using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class UserDAO : BaseDAO<User>
    {
        private static UserDAO instance = null;
        private static object lockObject = new object();
        public UserDAO() { }
        public static UserDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new UserDAO();
                    }
                    return instance;
                }
            }
        }
    }
}
