using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class StatusUserDAO : BaseDAO<StatusUser>
    {
        private static StatusUserDAO instance = null!;
        private static object lockObject = new object();
        public StatusUserDAO() { }
        public static StatusUserDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new StatusUserDAO();
                    }
                    return instance;
                }
            }
        }
    }
}
