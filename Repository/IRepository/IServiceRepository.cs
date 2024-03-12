using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IServiceRepository
    {
        IEnumerable<Service> GetAll();
        IEnumerable<Service> GetAllWithInclude(string field);
        IEnumerable<Service> GetAllWith2Include(string field1, string field2);
        Service? GetById(long id);
        void Add(Service Service);
        void Update(Service Service);
        void Delete(Service Service);
        void Save();
    }
}
