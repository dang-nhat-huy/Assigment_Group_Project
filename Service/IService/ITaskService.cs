using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = BusinessObject.Models.Task;

namespace Service.IService
{
    public interface ITaskService
    {
        IEnumerable<Task> GetAll();
        IEnumerable<Task> GetAll(int? page, int? quantity);
        Task? GetById(long id);
        void Add(Task Task);
        void Update(Task Task);
        void Delete(Task Task);
        void Save();
    }
}
