using BusinessObject.Models;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IUserTaskService
    {
        public IEnumerable<UserTask> GetAll(int? page, int? quantity);

        public void Add(UserTask Task);

        public void Delete(UserTask Task);

        public IEnumerable<UserTask> GetAll();

        public UserTask? GetById(long id);

        public void Save();

        public void Update(UserTask Task);
    }
}
