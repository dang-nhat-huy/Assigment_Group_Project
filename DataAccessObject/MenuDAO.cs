using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class MenuDAO : BaseDAO<Menu>
    {
        private static MenuDAO instance = null;
        private static object lockObject = new object();
        public MenuDAO() { }
        public static MenuDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new MenuDAO();
                    }
                    return instance;
                }
            }
        }
    }
}
