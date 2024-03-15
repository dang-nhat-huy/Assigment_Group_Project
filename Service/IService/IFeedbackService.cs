using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IFeedbackService
    {
        public void Add(Feedback feedback);

        public void Delete(Feedback feedback);

        public IEnumerable<Feedback> GetAll();

        public IEnumerable<Feedback> GetAll(int? page, int? quantity);        

        public Feedback? GetById(long id);

        public void Save();

        public void Update(Feedback feedback);
    }
}
