using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class StatusDAO : BaseDAO<Status>
    {
        private static StatusDAO instance = null;
        private static object lockObject = new object();
        public StatusDAO() { }
        public static StatusDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new StatusDAO();
                    }
                    return instance;
                }
            }
        }
    }
}
