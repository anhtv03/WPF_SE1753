using CRUD_Q1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Q1.Services {
    internal class CategorieService {
        private NorthwindContext _context;

        public CategorieService(NorthwindContext context) {
            _context = context;
        }

        public List<Category> GetCategories() => _context.Categories.ToList();
    }
}
