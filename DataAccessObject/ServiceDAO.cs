using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class ServiceDAO : BaseDAO<Service>
    {
        private static ServiceDAO instance = null;
        private static object lockObject = new object();
        public ServiceDAO() { }
        public static ServiceDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new ServiceDAO();
                    }
                    return instance;
                }
            }
        }
    }
}
