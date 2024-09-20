using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_SE1753.Models;

namespace WPF_SE1753 {
    /// <summary>
    /// Interaction logic for ProductNothWind.xaml
    /// </summary>
    public partial class ProductNothWind : Window {

        private NorthwindContext context;

        public ProductNothWind() {
            InitializeComponent();
            context = new NorthwindContext();
        }

        private void LoadData() {
            lvEmps.ItemsSource = context.Products.ToList();
            cbCategory.ItemsSource = context.Categories.Select(x => x.CategoryName).ToList();
            cbSuplier.ItemsSource = context.Suppliers.Select(X => X.CompanyName).ToList();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e) {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e) {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e) {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            LoadData();
        }

        public Product GetProductsFromUI() {
            
        }

    }
}
