using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CRUD_Q1.Models;
using CRUD_Q1.Services;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Q1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private NorthwindContext _context;
        private ProductService _productService;
        private SupplierService _suplplierService;
        private CategorieService _categoryService;

        public MainWindow() {
            InitializeComponent();
            _context = new NorthwindContext();
            _productService = new ProductService(_context);
            _suplplierService = new SupplierService(_context);
            _categoryService = new CategorieService(_context);
        }

        private void LoadData() {
            lvEmps.ItemsSource = _productService.GetProducts();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e) {
            _productService.CreateProduct(GetProductsFromUI());
            LoadData();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e) {
            _productService.UpdateProduct(GetProductsFromUI(), int.Parse(tbId.Text));
            LoadData();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e) {
            _productService.DeleteProduct(int.Parse(tbId.Text));
            LoadData();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e) {
            tbId.Text = null;
            tbName.Text = null;
            tbPrice.Text = null;
            cbCategory.SelectedIndex = 0;
            cbSuplier.SelectedIndex = 0;
            LoadData();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            LoadData();
            cbCategory.ItemsSource = _categoryService.GetCategories();
            cbSuplier.ItemsSource = _suplplierService.GetSuppliers();
        }

        public Product GetProductsFromUI() {
            //Category category = cbCategory.SelectedItem as Category;
            //Supplier supplier = cbSuplier.SelectedItem as Supplier;

            Product pro = new Product() {
                ProductName = tbName.Text,
                UnitPrice = decimal.Parse(tbPrice.Text),
                //CategoryId = category.CategoryId,
                //SupplierId = supplier.SupplierId,
                
                CategoryId = int.Parse(cbCategory.SelectedValuePath),
                SupplierId = int.Parse(cbSuplier.SelectedValuePath)
            };
            return pro;
        }


    }
}