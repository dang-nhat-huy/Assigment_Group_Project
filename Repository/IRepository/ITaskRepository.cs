using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = BusinessObject.Models.Task;

namespace Repository.IRepository
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetAll();
        IEnumerable<Task> GetAllWithInclude(string field);
        IEnumerable<Task> GetAllWith2Include(string field1, string field2);
        Task? GetById(long id);
        void Add(Task Task);
        void Update(Task Task);
        void Delete(Task Task);
        void Save();
    }
}
