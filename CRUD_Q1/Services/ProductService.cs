using CRUD_Q1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CRUD_Q1.Services {
    internal class ProductService {

        private NorthwindContext _context;

        public ProductService(DbContext context) {
            _context = (NorthwindContext) context;
        }

        public List<Product> GetProducts() => _context.Products.Include(x => x.Category).Include(x => x.Supplier).ToList();

        public void CreateProduct(Product product) {
            try {
                if (!string.IsNullOrEmpty(product.ProductName) || !string.IsNullOrEmpty(product.UnitPrice.ToString())) {
                    _context.Products.Add(product);
                    _context.SaveChanges();
                } else {
                    MessageBox.Show("Product Name or Unit Price must be not null!");
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateProduct(Product product, int proId) {
            try {
                Product? oldPro = _context.Products.FirstOrDefault(x => x.ProductId == proId);
                if (oldPro != null && !string.IsNullOrEmpty(product.ProductName) && !string.IsNullOrEmpty(product.UnitPrice.ToString())) {
                    oldPro.ProductName = product.ProductName;
                    oldPro.UnitPrice = product.UnitPrice;
                    oldPro.CategoryId = product.CategoryId;
                    oldPro.SupplierId = product.SupplierId;

                    _context.Products.Update(oldPro);
                    _context.SaveChanges();
                } else {
                    MessageBox.Show("Product Name or Unit Price must be not null!");
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeleteProduct(int proID) {
            try {
                Product? oldPro = _context.Products.FirstOrDefault(x => x.ProductId == proID);
                if (oldPro != null) {
                    MessageBoxResult result = MessageBox.Show("Are you sure want to delete this product?", "Confirm Delete", MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.OK) {
                        List<OrderDetail> order = _context.OrderDetails.Where(x => x.ProductId == proID).ToList();
                        if (order.Count > 0) {
                            MessageBox.Show("Can't delete Product because some orders has this product");
                        } else {
                            _context.Products.Remove(oldPro);
                            _context.SaveChanges();
                        }
                    }
                } else {
                    MessageBox.Show("Product is not existed");
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
