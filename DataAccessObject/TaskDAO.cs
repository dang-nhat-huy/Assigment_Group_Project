using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessObject
{
    public class TaskDAO : BaseDAO<BusinessObject.Models.Task>
    {
        private static TaskDAO instance = null;
        private static object lockObject = new object();
        public TaskDAO() { }
        public static TaskDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new TaskDAO();
                    }
                    return instance;
                }
            }
        }
    }
}
