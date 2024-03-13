using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class OrderDetailDAO : BaseDAO<OrderDetail>
    {
        private static OrderDetailDAO instance = null;
        private static object lockObject = new object();
        public OrderDetailDAO() { }
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }
    }
}
