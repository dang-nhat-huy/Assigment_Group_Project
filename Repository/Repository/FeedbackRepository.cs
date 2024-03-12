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
    public class FeedbackRepository : IFeedbackRepository
    {
        public void Add(Feedback feedback) => FeedbackDAO.Instance.Add(feedback);

        public void Delete(Feedback feedback) => FeedbackDAO.Instance.Delete(feedback);
        public IEnumerable<Feedback> GetAll() => FeedbackDAO.Instance.GetAll();

        public IEnumerable<Feedback> GetAllWith2Include(string field1, string field2) => FeedbackDAO.Instance.GetAllWith2Include(field1, field2);

        public IEnumerable<Feedback> GetAllWithInclude(string field) => FeedbackDAO.Instance.GetAllWithInclude(field);

        public Feedback? GetById(long id) => FeedbackDAO.Instance.GetById(id);

        public void Save() => FeedbackDAO.Instance.Save();

        public void Update(Feedback feedback) => FeedbackDAO.Instance.Update(feedback);
    }
}
