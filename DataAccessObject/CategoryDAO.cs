using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class CategoryDAO : BaseDAO<Category>
    {
        private static CategoryDAO instance = null;
        private static object lockObject = new object();
        public CategoryDAO() { }
        public static CategoryDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new CategoryDAO();
                    }
                    return instance;
                }
            }
        }
    }
}
