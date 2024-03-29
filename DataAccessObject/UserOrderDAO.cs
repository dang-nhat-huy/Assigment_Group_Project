﻿using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class UserOrderDAO : BaseDAO<UserOrder>
    {
        private static UserOrderDAO instance = null;
        private static object lockObject = new object();
        public UserOrderDAO() { }
        public static UserOrderDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new UserOrderDAO();
                    }
                    return instance;
                }
            }
        }
    }
}
