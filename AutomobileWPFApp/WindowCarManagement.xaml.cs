﻿using AutomobileLibrary.ViewModels;
using System.Windows;

namespace AutomobileWPFApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WindowCarManagement : Window {

        public WindowCarManagement(CarViewModel carViewModel) {
            InitializeComponent();
            this.DataContext = carViewModel;
        }


        //---------------------------------------------
        //private Car GetCarObject() {
        //    Car car = new Car();
        //    try {
        //        car = new Car {
        //            CarId = int.Parse(txtCarId.Text),
        //            CarName = txtCarName.Text,
        //            Manufacturer = txtManufacturer.Text,
        //            Price = decimal.Parse(txtPrice.Text),
        //            ReleasedYear = int.Parse(txtReleasedYear.Text)
        //        };
        //    } catch (Exception ex) {
        //        MessageBox.Show(ex.Message, "Get Car");
        //    }
        //    return car;
        //}
        ////---------------------------------------------
        //public async Task LoadCarList() => lvCars.ItemsSource = _carRepository.GetCars();
        ////---------------------------------------------


        //private void btnLoad_Click(object sender, RoutedEventArgs e) {
        //    try {
        //        LoadCarList();
        //    } catch (Exception ex) {
        //        MessageBox.Show(ex.Message, "Load Car List");
        //    }
        //}

        //private void btnInsert_Click(object sender, RoutedEventArgs e) {
        //    try {
        //        Car car = GetCarObject();
        //        _carRepository.InsertCar(car);
        //        LoadCarList();
        //        MessageBox.Show($"{car.CarName} inserted successfully", "Insert Car");
        //    } catch (Exception ex) {
        //        MessageBox.Show(ex.Message, "Insert Car");
        //    }
        //}

        //private void btnUpdate_Click(object sender, RoutedEventArgs e) {
        //    try {
        //        Car car = GetCarObject();
        //        _carRepository.UpdateCar(car);
        //        LoadCarList();
        //        MessageBox.Show($"{car.CarName} updated successfully", "Update Car");
        //    } catch (Exception ex) {
        //        MessageBox.Show(ex.Message, "Update Car");
        //    }
        //}

        //private void btnDelete_Click(object sender, RoutedEventArgs e) {
        //    try {
        //        MessageBoxResult result = MessageBox.Show("Are you sure want to delete this product?", "Confirm Delete", MessageBoxButton.OKCancel);
        //        if (result == MessageBoxResult.OK) {
        //            Car car = GetCarObject();
        //            _carRepository.DeleteCar(car);
        //            LoadCarList();
        //            MessageBox.Show($"{car.CarName} deleted successfully", "Delete Car");
        //        }
        //    } catch (Exception ex) {
        //        MessageBox.Show(ex.Message, "Delete Car");
        //    }
        //}

        //private void btnClose_Click(object sender, RoutedEventArgs e) => Close();
    }
}