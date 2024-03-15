using Repository.IRepository;
using Service.IService;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = BusinessObject.Models.Task;

namespace Service.Service
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Add(Task Task)
        {
            _taskRepository.Add(Task);
        }

        public void Delete(Task Task)
        {
            _taskRepository.Delete(Task);
        }

        public IEnumerable<Task> GetAll()
        {
            return _taskRepository.GetAll();
        }

        public IEnumerable<Task> GetAll(int? page, int? quantity)
        {
            const int defaultPage = 1;
            const int defaultQuantity = 10;

            if (page.HasValue && page <= 0)
            {
                page = defaultPage;
            }
            if (quantity.HasValue && (quantity <= 0 || quantity > int.MaxValue))
            {
                quantity = defaultQuantity;
            }

            int skip = (page.GetValueOrDefault(defaultPage) - 1) * quantity.GetValueOrDefault(defaultQuantity);
            return _taskRepository.GetAll()
                .Skip(skip)
                .Take((int)quantity!);
        }

        public Task? GetById(long id)
        {
            return _taskRepository.GetById(id);
        }

        public void Save()
        {
            _taskRepository.Save();
        }

        public void Update(Task Task)
        {
            _taskRepository.Update(Task);
        }
    }
}
