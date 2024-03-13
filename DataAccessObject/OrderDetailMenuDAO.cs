using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class OrderDetailMenuDAO : BaseDAO<OrderDetailMenu>
    {
        private static OrderDetailMenuDAO instance = null;
        private static object lockObject = new object();
        public OrderDetailMenuDAO() { }
        public static OrderDetailMenuDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailMenuDAO();
                    }
                    return instance;
                }
            }
        }
    }
}
