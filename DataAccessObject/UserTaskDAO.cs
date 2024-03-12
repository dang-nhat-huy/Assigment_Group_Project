using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class UserTaskDAO
    {
        private static UserTaskDAO instance = null;
        private static object lockObject = new object();
        public UserTaskDAO() { }
        public static UserTaskDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new UserTaskDAO();
                    }
                    return instance;
                }
            }
        }
    }
}
