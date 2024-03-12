using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IUserTaskRepository
    {
        IEnumerable<UserTask> GetAll();
        IEnumerable<UserTask> GetAllWithInclude(string field);
        IEnumerable<UserTask> GetAllWith2Include(string field1, string field2);
        UserTask? GetById(long id);
        void Add(UserTask UserTask);
        void Update(UserTask UserTask);
        void Delete(UserTask UserTask);
        void Save();
    }
}
