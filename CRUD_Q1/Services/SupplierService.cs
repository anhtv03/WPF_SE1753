using CRUD_Q1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Q1.Services {
    internal class SupplierService {
        private NorthwindContext _context;

        public SupplierService(NorthwindContext context) {
            _context = context;
        }

        public List<Supplier> GetSuppliers() => _context.Suppliers.ToList();
    }
}
