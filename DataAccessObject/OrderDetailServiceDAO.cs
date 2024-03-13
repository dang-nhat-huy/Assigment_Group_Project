using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class OrderDetailServiceDAO : BaseDAO<OrderDetailService>
    {
        private static OrderDetailServiceDAO instance = null;
        private static object lockObject = new object();
        public OrderDetailServiceDAO() { }
        public static OrderDetailServiceDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailServiceDAO();
                    }
                    return instance;
                }
            }
        }
    }
}
