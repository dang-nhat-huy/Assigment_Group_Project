using BusinessObject.Models;
using Repository;
using Repository.IRepository;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class UserTaskService : IUserTaskService
    {
        private readonly IUserTaskRepository _userTaskRepository;
        public UserTaskService(IUserTaskRepository userTaskRepository)
        {
            _userTaskRepository = userTaskRepository;
        }
        public IEnumerable<UserTask> GetAll(int? page, int? quantity)
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
            return _userTaskRepository.GetAll()
                .Skip(skip)
                .Take((int)quantity!);
        }

        public void Add(UserTask Task)
        {
            _userTaskRepository.Add(Task);
        }

        public void Delete(UserTask Task)
        {
            _userTaskRepository.Delete(Task);
        }

        public IEnumerable<UserTask> GetAll()
        {
            return _userTaskRepository.GetAll();
        }

        public UserTask? GetById(long id)
        {
            return _userTaskRepository.GetById(id);
        }

        public void Save()
        {
            _userTaskRepository.Save();
        }

        public void Update(UserTask Task)
        {
            _userTaskRepository.Update(Task);
        }
    }
}
