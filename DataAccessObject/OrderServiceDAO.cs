using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class OrderServiceDAO
    {
        private static OrderServiceDAO instance = null;
        private static object lockObject = new object();
        public OrderServiceDAO() { }
        public static OrderServiceDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new OrderServiceDAO();
                    }
                    return instance;
                }
            }
        }
    }
}
