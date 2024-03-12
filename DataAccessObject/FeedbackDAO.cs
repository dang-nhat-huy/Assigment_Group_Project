using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class FeedbackDAO : BaseDAO<Feedback>
    {
        private static FeedbackDAO instance = null;
        private static object lockObject = new object();
        public FeedbackDAO() { }
        public static FeedbackDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new FeedbackDAO();
                    }
                    return instance;
                }
            }
        }
    }
}
