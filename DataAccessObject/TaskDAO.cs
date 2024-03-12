using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class TaskDAO
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
