using System.Collections.ObjectModel;
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
using DemoBinding.Models;

namespace DemoBinding {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        Students cur;
        ObservableCollection<Students> students;

        public MainWindow() {
            InitializeComponent();
            Binding binding = new Binding();
            binding.Source = tbTextBox1;
            binding.Mode = BindingMode.TwoWay;
            binding.Path = new PropertyPath("Text");
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            tbTextBox2.SetBinding(TextBox.TextProperty, binding);


            cur = new Students { id = 1, name = "aaaa" };
            Binding binding2 = new Binding();
            binding2.Source = cur;
            binding2.Mode = BindingMode.TwoWay;
            binding2.Path = new PropertyPath("Name");
            tbTextBox5.SetBinding(TextBox.TextProperty, binding2);

            InitList();
            lbStudent.ItemsSource = students;
        }

        private void InitList() {
            students = new ObservableCollection<Students> {
                new Students {id=3, name="aaa"},
                new Students {id=4, name="aaa"},
                new Students {id=5, name="aaa"},
                new Students {id=6, name="aaa"},
                new Students {id=7, name="aaa"},
                new Students {id=8, name="aaa"}
            };
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show(cur.name);
        }
    }
}