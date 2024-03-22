using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class StatusRoomDAO : BaseDAO<StatusRoom>
    {
        private static StatusRoomDAO instance = null!;
        private static object lockObject = new object();
        public StatusRoomDAO() { }
        public static StatusRoomDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new StatusRoomDAO();
                    }
                    return instance;
                }
            }
        }
    }
}
