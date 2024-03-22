using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class StatusOrderDAO : BaseDAO<StatusOrder>
    {
        private static StatusOrderDAO instance = null!;
        private static object lockObject = new object();
        public StatusOrderDAO() { }
        public static StatusOrderDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new StatusOrderDAO();
                    }
                    return instance;
                }
            }
        }
    }
}
