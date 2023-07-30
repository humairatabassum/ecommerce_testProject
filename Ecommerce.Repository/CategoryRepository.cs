using Ecommerce.Database;
using EcommerceModels.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository
{
    public class CategoryRepository
    {
        ApplicationDbContext _db;

        public CategoryRepository()
        {
            _db = new ApplicationDbContext();
        }


        public bool Add(Category category)
        {
            _db.Categories.Add(category);
            return _db.SaveChanges() > 0;
        }

        public bool AddRange(ICollection<Category> categories)
        {
            _db.Categories.AddRange(categories);
            return _db.SaveChanges() > 0;
        }

        public bool Update(Category category)
        {
            _db.Categories.Update(category);
            return _db.SaveChanges() > 0;
        }

        public bool UpdateRange(ICollection<Category> categories)
        {
            _db.Categories.UpdateRange(categories);
            return _db.SaveChanges() > 0;
        }

        public bool Delete(Category category)
        {
            _db.Categories.Remove(category);
            return _db.SaveChanges() > 0;
        }

        public Category GetById(int id)
        {
            return _db.Categories.FirstOrDefault(c => c.Id == id);
        }

        public ICollection<Category> GetAll()
        {
            return _db.Categories.ToList();
        }
    }
}
