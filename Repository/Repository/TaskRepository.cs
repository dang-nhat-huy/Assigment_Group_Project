using BusinessObject.Models;
using DataAccessObject;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taskwork = BusinessObject.Models.Task;

namespace Repository
{
    public class TaskRepository :ITaskRepository
    {
        public void Add(Taskwork task) => TaskDAO.Instance.Add(task);

        public void Delete(Taskwork task) => TaskDAO.Instance.Delete(task);
        public IEnumerable<Taskwork> GetAll() => TaskDAO.Instance.GetAll();

        public IEnumerable<Taskwork> GetAllWith2Include(string field1, string field2) => TaskDAO.Instance.GetAllWith2Include(field1, field2);

        public IEnumerable<Taskwork> GetAllWithInclude(string field) => TaskDAO.Instance.GetAllWithInclude(field);

        public Taskwork? GetById(long id) => TaskDAO.Instance.GetById(id);

        public void Save() => TaskDAO.Instance.Save();

        public void Update(Taskwork task) => TaskDAO.Instance.Update(task);
    }
}
