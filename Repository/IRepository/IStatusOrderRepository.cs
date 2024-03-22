using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IStatusOrderRepository
    {
        IEnumerable<StatusOrder> GetAll();
        IEnumerable<StatusOrder> GetAllWithInclude(string field);
        IEnumerable<StatusOrder> GetAllWith2Include(string field1, string field2);
        StatusOrder? GetById(long id);
        void Add(StatusOrder StatusOrder);
        void Update(StatusOrder StatusOrder);
        void Delete(StatusOrder StatusOrder);
        void Save();
    }
}
