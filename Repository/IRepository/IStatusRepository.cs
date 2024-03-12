using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IStatusRepository
    {
        IEnumerable<Status> GetAll();
        IEnumerable<Status> GetAllWithInclude(string field);
        IEnumerable<Status> GetAllWith2Include(string field1, string field2);
        Status? GetById(long id);
        void Add(Status Status);
        void Update(Status Status);
        void Delete(Status Status);
        void Save();
    }
}
