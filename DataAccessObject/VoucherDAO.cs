using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class VoucherDAO
    {
        private static VoucherDAO instance = null;
        private static object lockObject = new object();
        public VoucherDAO() { }
        public static VoucherDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new VoucherDAO();
                    }
                    return instance;
                }
            }
        }
    }
}
