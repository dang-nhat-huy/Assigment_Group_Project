using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IFeedbackRepository
    {
        IEnumerable<Feedback> GetAll();
        IEnumerable<Feedback> GetAllWithInclude(string field);
        IEnumerable<Feedback> GetAllWith2Include(string field1, string field2);
        Feedback? GetById(long id);
        void Add(Feedback Feedback);
        void Update(Feedback Feedback);
        void Delete(Feedback Feedback);
        void Save();
    }
}
