using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class RoomDAO : BaseDAO<Room>
    {
        private static RoomDAO instance = null!;
        private static object lockObject = new object();
        public RoomDAO() { }
        public static RoomDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new RoomDAO();
                    }
                    return instance;
                }
            }
        }
    }
}
