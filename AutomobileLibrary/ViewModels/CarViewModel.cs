using AutomobileLibrary.Command;
using AutomobileLibrary.Models;
using AutomobileLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AutomobileLibrary.ViewModels {
    public class CarViewModel : BaseViewModel {

        private readonly ICarRepository _carRepository;
        private ObservableCollection<Car> _cars;
        private Car _currentCar;

        public CarViewModel(ICarRepository carRepository) {
            CurrentCar = new Car();
            _carRepository = carRepository;
            LoadDataCommand = new RelayCommand(LoadCar, CanLoadCar);
            AddCarCommand = new RelayCommand(AddCar, CanAddCar);
            UpdateCarCommand = new RelayCommand(UpdateCar, CanUpdateCar);
            DeleteCarCommand = new RelayCommand(DeleteCar, CanDeleteCar);
            CloseCommand = new RelayCommand(CloseWindow, CanCloseWindow);
        }

        //-----------------------------------------
        public ObservableCollection<Car> Cars {
            get { return _cars; }
            set { _cars = value; OnPropertyChanged(); }
        }

        public Car CurrentCar {
            get { return _currentCar; }
            set { _currentCar = value; OnPropertyChanged(); }
        }

        public ICommand AddCarCommand { get; set; }
        public ICommand UpdateCarCommand { get; set; }
        public ICommand DeleteCarCommand { get; set; }
        public ICommand LoadDataCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        //----------------Load Car--------------------
        private void LoadData() {
            Cars = new ObservableCollection<Car>(_carRepository.GetCars());
        }

        private bool CanLoadCar(object obj) => true;

        private void LoadCar(object obj) {
            try {
                LoadData();
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        //------------Create Car--------------------
        private bool CanAddCar(object obj) => true;

        private void AddCar(object obj) {
            try {
                Car car = CurrentCar;
                _carRepository.InsertCar(car);
                LoadData();
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        //------------Update Car--------------------
        private bool CanUpdateCar(object obj) => true;

        private void UpdateCar(object obj) {
            try {
                Car car = CurrentCar;
                _carRepository.UpdateCar(car);
                LoadData();
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        //------------Delete Car--------------------
        private bool CanDeleteCar(object obj) => true;

        private void DeleteCar(object obj) {
            try {
                Car car = CurrentCar;
                _carRepository.DeleteCar(car);
                LoadData();
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        //------------Close--------------------
        private bool CanCloseWindow(object obj) => true;

        private void CloseWindow(object obj) {
            //Window.Close();
        }

    }
}
