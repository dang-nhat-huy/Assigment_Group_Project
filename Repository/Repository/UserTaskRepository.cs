using BusinessObject.Models;
using DataAccessObject;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserTaskTaskRepository : IUserTaskRepository
    {
        public void Add(UserTask userTask) => UserTaskDAO.Instance.Add(userTask);

        public void Delete(UserTask userTask) => UserTaskDAO.Instance.Delete(userTask);
        public IEnumerable<UserTask> GetAll() => UserTaskDAO.Instance.GetAll();

        public IEnumerable<UserTask> GetAllWith2Include(string field1, string field2) => UserTaskDAO.Instance.GetAllWith2Include(field1, field2);

        public IEnumerable<UserTask> GetAllWithInclude(string field) => UserTaskDAO.Instance.GetAllWithInclude(field);

        public UserTask? GetById(long id) => UserTaskDAO.Instance.GetById(id);

        public void Save() => UserTaskDAO.Instance.Save();

        public void Update(UserTask userTask) => UserTaskDAO.Instance.Update(userTask);
    }
}
