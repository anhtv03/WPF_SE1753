using System;
using System.Collections.Generic;
using System.Linq;
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
using WPF_SE1753.Modelss;

namespace WPF_SE1753 {
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class Product : Window {

        private List<Products> pro;
        private int idCount;

        public Product() {
            InitializeComponent();
            pro = new List<Products>();
            idCount = 1;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            LoadData();
        }

        private void LoadData() {
            lvEmps.ItemsSource = null;
            lvEmps.ItemsSource = pro;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e) {
            try {
                if (tbName.Text != null || tbPrice.Text != null) {
                    Products products = new Products() {
                        Id = idCount++,
                        Name = tbName.Text,
                        Price = float.Parse(tbPrice.Text),
                        Category = cbCategory.Text,
                        IsActive = cbActive.IsChecked
                    };
                    pro.Add(products);
                    LoadData();
                } else {
                    MessageBox.Show("Name or Price can't null");
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
